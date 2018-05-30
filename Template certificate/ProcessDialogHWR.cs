using SelectPdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template_certificate
{
    public partial class ProcessDialogHWR : Form
    {
        private readonly main _owner;
        private readonly string contentHtml = File.ReadAllText(@"D:\Funix\Hanna Weekly Report\Html source\hwr.html");
        private readonly int total;
        private readonly string certificate;
        private readonly DateTime reportedDate;
        private readonly DataGridView dataGridView;
        private string folderStoragePath;
        private readonly string folder = @"file:///D:\Funix\Hanna Weekly Report\Html source";


        public ProcessDialogHWR(main parent)
        {
            InitializeComponent();

            _owner = parent;

            folderStoragePath = _owner.GetFolderPath();
            reportedDate = _owner.GetReportedDate();
            certificate = _owner.GetSelectedTemplate();
            dataGridView = _owner.GetDataGridView();
            total = GetTotalSelectedRow();
            resultLabel.Text = $"Processing: 0/{total}";
            StartAsync();
        }

        private int GetTotalSelectedRow()
        {
            int count = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {

                //check if row has checked in check box
                if (Convert.ToBoolean(row.Cells["checkBoxColumn"].Value))
                {
                    count++;
                }
            }
            return count;
        }

        // This event handler is where the time-consuming work is done.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int count = 0;
            if (string.IsNullOrEmpty(folderStoragePath))
            {
                string exePath = Application.ExecutablePath;
                folderStoragePath = Path.Combine(exePath.Remove(exePath.LastIndexOf('\\')), $"HWR\\{reportedDate.ToString("dd-MM-yyyy")}\\{certificate}");
                DirectoryInfo directory = new DirectoryInfo(folderStoragePath);
                if (!directory.Exists)
                {
                    directory.Create();
                }
            }
            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    //TODO: (Ms.Hồng Anh required) File excel change the column Tên chứng chỉ (tiếng anh) and Chứng chỉ to single column Mã môn.
                    //check if row has checked in check box
                    if (!backgroundWorker1.CancellationPending && Convert.ToBoolean(row.Cells["checkBoxColumn"].Value))
                    {
                        //render this row to pdf
                        string studentName = row.Cells["Danh sách sinh viên"].Value.ToString();
                        string studentID = row.Cells["Mã SV"].Value.ToString();

                        string query = $"Select * from [{certificate}$] where [Mã SV] = '{studentID}' and [Chứng chỉ] = '{certificate}'";

                        DataTable dt = _owner.GetDataSourceForGridView(query);

                        GenerateImage(dt, studentID, studentName, certificate);

                        count++;

                        worker.ReportProgress(count);
                    }

                }
                MessageBox.Show("Generate successfull", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                backgroundWorker1.CancelAsync();
            }
            finally
            {
                Process.Start(folderStoragePath);
            }
        }

        private void GenerateImage(DataTable dt, string studentID, string studentName, string certificate)
        {
            //these fields is not change with each student
            string htmlTable = "";
            string studyAvg = dt.Rows[0]["KL HT tb"].ToString();
            string studentClass = dt.Rows[0]["Lớp"].ToString();
            string studyCompletedLastWeek = dt.Rows[0]["KL học tập đã TH tuần trước"].ToString();
            string timeRemain = dt.Rows[0]["thời gian còn lại"].ToString();

            studyAvg = BeautiNumber(studyAvg, "{0:0.0}");
            studyCompletedLastWeek = BeautiNumber(studyCompletedLastWeek, "{0:0.0}");
            timeRemain = BeautiNumber(timeRemain, "{0:0}");

            foreach (DataRow row in dt.Rows)
            {
                string course = row["Môn"].ToString();
                string exam = row["Exam"].ToString();
                string quest = row["% ques"].ToString();
                string quiz = row["% quiz"].ToString();
                string asm = row["% asm"].ToString();
                string lab = row["%Lab"].ToString();
                string courseStatus = row["Trạng thái môn"].ToString();

                courseStatus = BeautiNumber(courseStatus, "{0:0.0}");
                lab = BeautiNumber(lab, "{0:0.0%}");
                quest = BeautiNumber(quest, "{0:0.0%}");
                quiz = BeautiNumber(quiz, "{0:0.0%}");
                asm = BeautiNumber(asm, "{0:0.0%}");

                htmlTable += $@"<tr>
                        <td>{course}</td>
                        <td>{courseStatus}</td>
                        <td>{quest}</td>
                        <td>{quiz}</td>
                        <td>{lab}</td>
                        <td>{asm}</td>
                        <td>{exam}</td>
                    </tr>";
            }

            string width = "";
            if (!string.IsNullOrEmpty(timeRemain))
            {
                width = Convert.ToDouble(timeRemain) / 26 * 100 + "%";
            }
            else
            {
                width = "0%";
            }
            string[] parameters = { folder, reportedDate.ToString("dd/MM/yyyy"), studentName, studentID, timeRemain, studyAvg, studyCompletedLastWeek, htmlTable, width };
            HtmlToImage htmlToImage = new HtmlToImage();

            string html = string.Format(contentHtml, parameters);
            Image img = htmlToImage.ConvertHtmlString(html);

            //TODO: create new file first
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(folderStoragePath, $"{studentClass}"));
            if (!directory.Exists)
            {
                directory.Create();
            }
            FileStream stream = File.Open(Path.Combine(folderStoragePath, $"{studentClass}/{studentID} - {studentName}.png"), FileMode.Create);
            img.Save(stream, ImageFormat.Png);
            stream.Close();
        }

        private string BeautiNumber(string number, string format)
        {
            try
            {
                if (string.IsNullOrEmpty(number))
                {
                    return "N/A";
                }
                else
                {
                    double dNumber = Convert.ToDouble(number);
                    return string.Format(format, dNumber);
                }
            }
            catch (Exception)
            {
                return "N/A";
                throw;
            }
        }

        // This event handler updates the progress.
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultLabel.Text = ("Processing: " + e.ProgressPercentage.ToString() + "/" + total);
        }

        // This event handler deals with the results of the background operation.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                resultLabel.Text = "Canceled!";
                this.Dispose();
            }
            else if (e.Error != null)
            {
                resultLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                resultLabel.Text = "Done!";
                this.Dispose();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
                cancelBtn.Enabled = false;
            }
        }

        public void StartAsync()
        {
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
        }
    }
}
