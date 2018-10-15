using SelectPdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template_certificate
{
    public partial class ProcessDialogHWR : Form
    {
        private readonly main _owner;
        private readonly int total;
        private readonly string certificate;
        private readonly DateTime reportedDate;
        private readonly DataGridView dataGridView;
        private string folderStoragePath;

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
            }
            else
            {
                folderStoragePath = Path.Combine(folderStoragePath, $"HWR\\{reportedDate.ToString("dd-MM-yyyy")}\\{certificate}");
            }
            DirectoryInfo directory = new DirectoryInfo(folderStoragePath);
            if (!directory.Exists)
            {
                directory.Create();
            }

            try
            {
                List<Task> tasks = new List<Task>();
                Parallel.ForEach(dataGridView.Rows.Cast<DataGridViewRow>(), row =>
                {
                    try
                    {
                        //check if row has checked in check box
                        if (!backgroundWorker1.CancellationPending && Convert.ToBoolean(row.Cells["checkBoxColumn"].Value))
                        {
                            //render this row to image
                            string studentName = row.Cells["Danh sách sinh viên"].Value.ToString();
                            string studentID = row.Cells["Mã SV"].Value.ToString();

                            string query = $"Select * from [{certificate}$] where [Mã SV] = '{studentID}' and [Chứng chỉ] = '{certificate}'";

                            DataTable dt = _owner.GetDataSourceForGridView(query);

                            GenerateImage generateImage = new GenerateImage(dt, studentID, studentName, certificate, reportedDate, folderStoragePath);
                            tasks.Add(Task.Run(() =>
                            {
                                //TODO: check if header is not correct, show error and stop
                                try
                                {
                                    if (!backgroundWorker1.CancellationPending)
                                    {
                                        generateImage.GenerateToImage();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    tasks.Clear();
                                    backgroundWorker1.CancelAsync();
                                    throw ex;
                                }
                            })
                            .ContinueWith(t =>
                            {
                                count++;
                                worker.ReportProgress(count);
                            }));
                        }
                    }
                    catch
                    {
                        throw;
                    }
                });

            
                // Wait on all the tasks.
                Task.WaitAll(tasks.ToArray());

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
