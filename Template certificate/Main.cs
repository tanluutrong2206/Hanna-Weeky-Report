using SelectPdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Template_certificate
{
    public partial class main : Form
    {
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES'";
        private CheckBox headerCheckBox = new CheckBox();
        private string connectionString = null, fileName;
        private bool selectedFile = false;

        private enum comparison
        {
            Equal_to,
            Not_equal_to,
            Greater_than,
            Less_than,
            Less_than_or_equal,
            Greater_than_or_equal,
            Is_blank,
            Is_not_blank,
            Contains,
            Does_not_contain,
        }

        private enum Certificate
        {
            CC1, CC2, CC3, CC4, CC5, CC6, CC7, CC8
        }

        private string queryCondition = "";

        public main()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
        }

        private void chooseFileBtn_Click(object sender, EventArgs e)
        {
            //init setting for user can only choosing excel file
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FileName = "";
            openFileDialog1.SupportMultiDottedExtensions = true;
            openFileDialog1.Filter = "Excel file| *.xls;*.xlsx";
            openFileDialog1.Title = "Select excel file";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(fileName) && fileName.Equals(openFileDialog1.FileName))
                {
                    return;
                }
                fileName = openFileDialog1.FileName;

                //display file content in grid view
                if (tabControl.SelectedIndex == 0)  //Certificate
                {
                    //user selected file
                    //set file name to text box
                    excelPathCertificate.Text = openFileDialog1.SafeFileName;
                    DisplayExcelCertificateContentToGridView();
                    groupBox1.Enabled = true;
                    selectedFile = true;

                    if (selectedFile)
                    {
                        renderPdfBtn.Enabled = true;
                        renderAndUploadBtn.Enabled = true;
                    }
                }
                else
                {
                    //user selected file
                    //set file name to text box
                    excelPathHWR.Text = openFileDialog1.SafeFileName;
                    //HWR
                    DisplayExcelHWRContentToGridView();
                }

                //display header to combo box for filter
                DisplayHeaderToCbx();

                //auto selected all row
                headerCheckBox.Checked = true;
                HeaderCheckBox_Clicked(null, null);
            }
        }

        private void DisplayExcelHWRContentToGridView()
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();

            SetConnectionString();

            string cc = GetSelectedTemplate();

            try
            {
                //Check if any of cell is empty will ignore
                string query = $"SELECT distinct [Chứng chỉ], [Mã SV], [Danh sách sinh viên], [Lớp] From [{cc}$] where [Chứng chỉ] = '{cc}'";
                DataTable dt = GetDataSourceForGridView(query);
                //Populate DataGridView.
                dataGridView2.DataSource = dt;

                AddHeaderCheckBox(dataGridView2);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal string GetSelectedTemplate()
        {
            var checkedButton = groupBox2.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);

            return checkedButton.Text;
        }

        private void DisplayHeaderToCbx()
        {
            List<string> headers = new List<string>();
            headers.Add("none");
            //the first column of data grid view is check box 
            // start collect header from second column
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                headers.Add(dataGridView1.Columns[i].HeaderText);
            }
            SetDataSource(field1, headers);
            SetDataSource(field2, headers);
            field2.Enabled = false;
            field2.SelectedIndex = -1;
            SetDataSource(field3, headers);
            field3.Enabled = false;
            field3.SelectedIndex = -1;
        }

        private void SetDataSource(ComboBox field, List<string> headers)
        {
            field.BindingContext = new BindingContext();
            field.DataSource = headers;
        }

        private void DisplayExcelCertificateContentToGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            SetConnectionString();

            try
            {
                //Check if any of cell is empty will ignore
                string query = "SELECT * From [Sheet1$] Where [Mã sinh viên] is not null and [Họ và tên] is not null and [Tên chứng chỉ] is not null and [Ngày hoàn thành ] is not null and [Tên chứng chỉ (tiếng anh)] is not null and [Số CC] is not null and [Email] is not null";
                DataTable dt = GetDataSourceForGridView(query);
                dataGridView1.DataSource = dt;

                AddHeaderCheckBox(dataGridView1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SetConnectionString()
        {
            if (Path.GetExtension(fileName).Equals(".xls"))
            {
                //excel old version. Before 2007
                connectionString = string.Format(Excel03ConString, fileName);
            }
            else
            {
                connectionString = string.Format(Excel07ConString, fileName);
            }
        }

        private void AddHeaderCheckBox(DataGridView dataGridView)
        {
            //add check box column to data grid view
            //Add a CheckBox Column to the DataGridView Header Cell.

            //Find the Location of Header Cell.
            Point headerCellLocation = dataGridView.GetCellDisplayRectangle(0, -1, true).Location;

            //Place the Header CheckBox in the Location of the Header Cell.
            headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
            headerCheckBox.BackColor = System.Drawing.Color.White;
            headerCheckBox.Size = new Size(18, 18);

            //Assign Click event to the Header CheckBox.
            headerCheckBox.Click += new EventHandler(HeaderCheckBox_Clicked);
            dataGridView.Controls.Add(headerCheckBox);

            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = CreateCheckBoxColumn();

            dataGridView.Columns.Insert(0, checkBoxColumn);
            dataGridView.Columns["checkBoxColumn"].Frozen = true;

            ////Assign Click event to the DataGridView Cell.
            //dataGridView.CellContentClick += new DataGridViewCellEventHandler(DataGridView_CellClick);
        }

        private DataGridViewCheckBoxColumn CreateCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            checkBoxColumn.Resizable = DataGridViewTriState.False;

            return checkBoxColumn;
        }

        internal DataTable GetDataSourceForGridView(string query)
        {
            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmd.CommandText = query;
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();

                            return dt;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void HeaderCheckBox_Clicked(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            //dataGridView1.EndEdit();

            //Loop and check and uncheck all row CheckBoxes based on Header Cell CheckBox.
            DataGridView dataGridView;
            if (tabControl.SelectedIndex == 0)
            {
                dataGridView = dataGridView1;
            }
            else
            {
                dataGridView = dataGridView2;
            }
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataGridViewCheckBoxCell checkBox = (row.Cells["checkBoxColumn"] as DataGridViewCheckBoxCell);
                checkBox.Value = headerCheckBox.Checked;
            }
            dataGridView.EndEdit();
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Check to ensure that the row CheckBox is clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell boxCell = GetDataGridView().Rows[e.RowIndex].Cells["checkBoxColumn"] as DataGridViewCheckBoxCell;
                boxCell.Value = !Convert.ToBoolean(boxCell.Value);

                //Loop to verify whether all row CheckBoxes are checked or not.
                bool isChecked = true;
                foreach (DataGridViewRow row in GetDataGridView().Rows)
                {
                    if (Convert.ToBoolean(row.Cells["checkBoxColumn"]
                        .EditedFormattedValue) == false)
                    {
                        isChecked = false;
                        break;
                    }
                }
                headerCheckBox.Checked = isChecked;
            }
        }

        private void chooseFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                if (tabControl.SelectedIndex == 0)
                {
                    //user selected folder
                    //set folder path to text box
                    folderPathCertificate.Text = folderBrowserDialog1.SelectedPath;
                }
                else
                {
                    //user selected folder
                    //set folder path to text box
                    folderPathHWR.Text = folderBrowserDialog1.SelectedPath;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void resetFilterBtn_Click(object sender, EventArgs e)
        {
            field1.SelectedIndex = 0;

            resetCombobox(and_orCbx1);
            resetCombobox(and_orCbx2);

            resetCombobox(comparison1);
            resetCombobox(comparison2);
            resetCombobox(comparison3);

            resetTextField(compare1);
            resetTextField(compare2);
            resetTextField(compare3);
        }

        private void resetTextField(TextBox txt)
        {
            txt.Text = "";
        }

        private void resetCombobox(ComboBox cbx)
        {
            cbx.SelectedIndex = -1;

        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            string query = "";
            //get the data to sort
            if (field1.SelectedIndex == 0)
            {
                //user want to show all
                query = "SELECT * From [Sheet1$]";
            }
            else
            {
                queryCondition += GetSortData(field1, comparison1, compare1) + " ";
                if (field2.Enabled && comparison2.Enabled)
                {
                    queryCondition += and_orCbx1.SelectedItem + " ";
                    queryCondition += GetSortData(field2, comparison2, compare2);
                }
                if (field3.Enabled && comparison3.Enabled)
                {
                    queryCondition += and_orCbx2.SelectedItem + " ";
                    queryCondition += GetSortData(field3, comparison3, compare3);
                }
                query = $"SELECT * From [Sheet1$] where {queryCondition}";
            }
            DataTable dt = GetDataSourceForGridView(query);
            dataGridView1.DataSource = dt;
            queryCondition = "";
        }

        private string GetSortData(ComboBox field, ComboBox comparisonCbx, TextBox compare)
        {
            string query = "";
            string compareTxt = compare.Text.Trim();
            if (field.SelectedItem != null)
            {
                query += $"[{field.SelectedItem}] ";
                switch (comparisonCbx.SelectedIndex)
                {
                    case (int)comparison.Contains:
                        {
                            query += $"like '%{compareTxt}%' ";
                            break;
                        }
                    case (int)comparison.Does_not_contain:
                        {
                            query += $"not like '%{compareTxt}%' ";
                            break;
                        }
                    case (int)comparison.Equal_to:
                        {
                            query += $" = {compareTxt}";
                            break;
                        }
                    case (int)comparison.Greater_than:
                        {
                            double number;
                            try
                            {
                                number = Convert.ToDouble(compareTxt);
                            }
                            catch (Exception)
                            {
                                number = 0;
                            }
                            query += $"> {number} ";

                            break;
                        }
                    case (int)comparison.Greater_than_or_equal:
                        {
                            double number;
                            try
                            {
                                number = Convert.ToDouble(compareTxt);
                            }
                            catch (Exception)
                            {
                                number = 0;
                            }
                            query += $">= {number} ";
                            break;
                        }
                    case (int)comparison.Is_blank:
                        {
                            query += "is null ";
                            break;
                        }
                    case (int)comparison.Is_not_blank:
                        {
                            query += "is not null ";
                            break;
                        }
                    case (int)comparison.Less_than:
                        {
                            double number;
                            try
                            {
                                number = Convert.ToDouble(compareTxt);
                            }
                            catch (Exception)
                            {
                                number = 0;
                            }
                            query += $"< {number} ";
                            break;
                        }
                    case (int)comparison.Less_than_or_equal:
                        {
                            double number;
                            try
                            {
                                number = Convert.ToDouble(compareTxt);
                            }
                            catch (Exception)
                            {
                                number = 0;
                            }
                            query += $"<= {number} ";
                            break;
                        }
                    case (int)comparison.Not_equal_to:
                        {
                            double number;
                            try
                            {
                                number = Convert.ToDouble(compareTxt);
                            }
                            catch (Exception)
                            {
                                number = 0;
                            }
                            query += $"not = {number} ";
                            break;
                        }
                }
            }
            return query;
        }

        private void field1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field1.SelectedIndex > 0)
            {
                compare1.Enabled = true;
                comparison1.Enabled = true;
                comparison1.SelectedIndex = 0;
                and_orCbx1.Enabled = true;
                and_orCbx1.SelectedIndex = 0;
            }
            else
            {
                compare1.Enabled = false;
                comparison1.Enabled = false;
                and_orCbx1.SelectedIndex = -1;
                and_orCbx1.Enabled = false;
            }
        }

        private void field2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field2.SelectedIndex > 0)
            {
                compare2.Enabled = true;
                comparison2.Enabled = true;
                comparison2.SelectedIndex = 0;

                and_orCbx2.Enabled = true;
                and_orCbx2.SelectedIndex = 0;
            }
            else
            {
                compare2.Enabled = false;
                comparison2.Enabled = false;
                and_orCbx2.SelectedIndex = -1;
                and_orCbx2.Enabled = false;
            }
        }

        private void field3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (field3.SelectedIndex > 0)
            {
                compare3.Enabled = true;
                comparison3.Enabled = true;
                comparison3.SelectedIndex = 0;

            }
            else
            {
                compare3.Enabled = false;
                comparison3.Enabled = false;
            }
        }

        private void comparison1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.SelectedItem == null)
            {
                return;
            }
            else if (comboBox.SelectedItem.Equals("Is blank") || comboBox.SelectedItem.Equals("Is not blank"))
            {
                switch (comboBox.Name)
                {
                    case "comparison1":
                        {
                            compare1.Enabled = false;
                            break;
                        }
                    case "comparison2":
                        {
                            compare2.Enabled = false;
                            break;
                        }
                    default:
                        {
                            compare3.Enabled = false;
                            break;
                        }
                }
            }
            else
            {
                switch (comboBox.Name)
                {
                    case "comparison1":
                        {
                            compare1.Enabled = true;
                            break;
                        }
                    case "comparison2":
                        {
                            compare2.Enabled = true;
                            break;
                        }
                    default:
                        {
                            compare3.Enabled = true;
                            break;
                        }
                }
            }
        }

        private void and_orCbx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (and_orCbx1.SelectedIndex >= 0)
            {
                field2.Enabled = true;
                field2.SelectedIndex = 0;
            }
            else
            {
                field2.Enabled = false;
                field2.SelectedIndex = -1;
            }
        }

        private void and_orCbx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (and_orCbx2.SelectedIndex >= 0)
            {
                field3.Enabled = true;
                field3.SelectedIndex = 0;
            }
            else
            {
                field3.Enabled = false;
                field3.SelectedIndex = -1;
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal string GetFolderPath()
        {
            if (tabControl.SelectedIndex == 0)
            {
                return folderPathCertificate.Text;
            }
            else
            {
                return folderPathHWR.Text;
            }
        }

        internal DataGridView GetDataGridView()
        {
            if (tabControl.SelectedIndex == 0)
            {
                return dataGridView1;
            }
            else
            {
                return dataGridView2;
            }
        }

        internal DateTime GetReportedDate()
        {
            return reportedDate.Value;
        }

        private void renderPdfBtn_Click(object sender, EventArgs e)
        {
            ProcessDialogGenerateCertificate dialog = new ProcessDialogGenerateCertificate(this, false);
            dialog.ShowDialog();
        }

        private void renderAndUploadBtn_Click(object sender, EventArgs e)
        {
            ProcessDialogGenerateCertificate dialog = new ProcessDialogGenerateCertificate(this, true);
            dialog.ShowDialog();
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
        }

        private void generateHWR_Click(object sender, EventArgs e)
        {
            ProcessDialogHWR processDialogHWR = new ProcessDialogHWR(this);
            processDialogHWR.ShowDialog();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                Text = "Home - Generate Certificate";
                Update();
            }
            else
            {
                Text = "Home - Generate HWR";
                Update();
            }
        }

        private void radioButtonCC_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            if (radioButton.Checked && !string.IsNullOrEmpty(fileName))
            {
                DisplayExcelHWRContentToGridView();
            }
            pictureBox1.ImageLocation = $@"file:///D:\Funix\Hanna Weekly Report\Template-certificate\Hanna-Weeky-Report\Template certificate\Images/Template cc/{radioButton.Text}.png";
        }
    }
}
