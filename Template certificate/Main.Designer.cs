namespace Template_certificate
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageCertificate = new System.Windows.Forms.TabPage();
            this.renderAndUploadBtn = new System.Windows.Forms.Button();
            this.renderPdfBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.excelPath = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.filterBtn = new System.Windows.Forms.Button();
            this.resetFilterBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.compare3 = new System.Windows.Forms.TextBox();
            this.compare2 = new System.Windows.Forms.TextBox();
            this.compare1 = new System.Windows.Forms.TextBox();
            this.comparison3 = new System.Windows.Forms.ComboBox();
            this.comparison2 = new System.Windows.Forms.ComboBox();
            this.comparison1 = new System.Windows.Forms.ComboBox();
            this.field3 = new System.Windows.Forms.ComboBox();
            this.field2 = new System.Windows.Forms.ComboBox();
            this.field1 = new System.Windows.Forms.ComboBox();
            this.and_orCbx2 = new System.Windows.Forms.ComboBox();
            this.and_orCbx1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.folderPath = new System.Windows.Forms.TextBox();
            this.chooseFolder = new System.Windows.Forms.Button();
            this.chooseFileBtn = new System.Windows.Forms.Button();
            this.tabPageHWR = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.reportedDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.previewBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog2 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl.SuspendLayout();
            this.tabPageCertificate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPageHWR.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageCertificate);
            this.tabControl.Controls.Add(this.tabPageHWR);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(574, 509);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageCertificate
            // 
            this.tabPageCertificate.Controls.Add(this.renderAndUploadBtn);
            this.tabPageCertificate.Controls.Add(this.renderPdfBtn);
            this.tabPageCertificate.Controls.Add(this.cancelBtn);
            this.tabPageCertificate.Controls.Add(this.excelPath);
            this.tabPageCertificate.Controls.Add(this.dataGridView1);
            this.tabPageCertificate.Controls.Add(this.groupBox1);
            this.tabPageCertificate.Controls.Add(this.folderPath);
            this.tabPageCertificate.Controls.Add(this.chooseFolder);
            this.tabPageCertificate.Controls.Add(this.chooseFileBtn);
            this.tabPageCertificate.Location = new System.Drawing.Point(4, 22);
            this.tabPageCertificate.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tabPageCertificate.Name = "tabPageCertificate";
            this.tabPageCertificate.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tabPageCertificate.Size = new System.Drawing.Size(566, 483);
            this.tabPageCertificate.TabIndex = 0;
            this.tabPageCertificate.Text = "Certificate";
            this.tabPageCertificate.UseVisualStyleBackColor = true;
            // 
            // renderAndUploadBtn
            // 
            this.renderAndUploadBtn.Enabled = false;
            this.renderAndUploadBtn.Location = new System.Drawing.Point(323, 448);
            this.renderAndUploadBtn.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.renderAndUploadBtn.Name = "renderAndUploadBtn";
            this.renderAndUploadBtn.Size = new System.Drawing.Size(116, 22);
            this.renderAndUploadBtn.TabIndex = 38;
            this.renderAndUploadBtn.Text = "Generate and upload";
            this.renderAndUploadBtn.UseVisualStyleBackColor = true;
            this.renderAndUploadBtn.Click += new System.EventHandler(this.renderAndUploadBtn_Click);
            // 
            // renderPdfBtn
            // 
            this.renderPdfBtn.Enabled = false;
            this.renderPdfBtn.Location = new System.Drawing.Point(241, 448);
            this.renderPdfBtn.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.renderPdfBtn.Name = "renderPdfBtn";
            this.renderPdfBtn.Size = new System.Drawing.Size(76, 22);
            this.renderPdfBtn.TabIndex = 37;
            this.renderPdfBtn.Text = "Generate";
            this.renderPdfBtn.UseVisualStyleBackColor = true;
            this.renderPdfBtn.Click += new System.EventHandler(this.renderPdfBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(160, 448);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(74, 22);
            this.cancelBtn.TabIndex = 36;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // excelPath
            // 
            this.excelPath.Location = new System.Drawing.Point(6, 6);
            this.excelPath.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.excelPath.Name = "excelPath";
            this.excelPath.ReadOnly = true;
            this.excelPath.Size = new System.Drawing.Size(407, 20);
            this.excelPath.TabIndex = 32;
            this.excelPath.Click += new System.EventHandler(this.chooseFileBtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 80);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(548, 180);
            this.dataGridView1.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filterBtn);
            this.groupBox1.Controls.Add(this.resetFilterBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.compare3);
            this.groupBox1.Controls.Add(this.compare2);
            this.groupBox1.Controls.Add(this.compare1);
            this.groupBox1.Controls.Add(this.comparison3);
            this.groupBox1.Controls.Add(this.comparison2);
            this.groupBox1.Controls.Add(this.comparison1);
            this.groupBox1.Controls.Add(this.field3);
            this.groupBox1.Controls.Add(this.field2);
            this.groupBox1.Controls.Add(this.field1);
            this.groupBox1.Controls.Add(this.and_orCbx2);
            this.groupBox1.Controls.Add(this.and_orCbx1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(6, 278);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.groupBox1.Size = new System.Drawing.Size(548, 164);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // filterBtn
            // 
            this.filterBtn.Location = new System.Drawing.Point(466, 135);
            this.filterBtn.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(76, 22);
            this.filterBtn.TabIndex = 26;
            this.filterBtn.Text = "Ok";
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // resetFilterBtn
            // 
            this.resetFilterBtn.Location = new System.Drawing.Point(385, 135);
            this.resetFilterBtn.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.resetFilterBtn.Name = "resetFilterBtn";
            this.resetFilterBtn.Size = new System.Drawing.Size(74, 22);
            this.resetFilterBtn.TabIndex = 25;
            this.resetFilterBtn.Text = "Clear All";
            this.resetFilterBtn.UseVisualStyleBackColor = true;
            this.resetFilterBtn.Click += new System.EventHandler(this.resetFilterBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(382, 17);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Compare to:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Comparison:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Field:";
            // 
            // compare3
            // 
            this.compare3.Location = new System.Drawing.Point(385, 100);
            this.compare3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.compare3.Name = "compare3";
            this.compare3.Size = new System.Drawing.Size(156, 20);
            this.compare3.TabIndex = 20;
            this.compare3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // compare2
            // 
            this.compare2.Location = new System.Drawing.Point(385, 74);
            this.compare2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.compare2.Name = "compare2";
            this.compare2.Size = new System.Drawing.Size(156, 20);
            this.compare2.TabIndex = 19;
            this.compare2.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // compare1
            // 
            this.compare1.Location = new System.Drawing.Point(385, 47);
            this.compare1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.compare1.Name = "compare1";
            this.compare1.Size = new System.Drawing.Size(156, 20);
            this.compare1.TabIndex = 18;
            this.compare1.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // comparison3
            // 
            this.comparison3.FormattingEnabled = true;
            this.comparison3.Items.AddRange(new object[] {
            "Equal to",
            "Not equal to",
            "Greater than",
            "Less than",
            "Less than or equal",
            "Greater than or equal",
            "Is blank",
            "Is not blank",
            "Contains",
            "Does not contain"});
            this.comparison3.Location = new System.Drawing.Point(235, 100);
            this.comparison3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.comparison3.Name = "comparison3";
            this.comparison3.Size = new System.Drawing.Size(124, 21);
            this.comparison3.TabIndex = 16;
            this.comparison3.SelectedIndexChanged += new System.EventHandler(this.comparison1_SelectedIndexChanged);
            // 
            // comparison2
            // 
            this.comparison2.FormattingEnabled = true;
            this.comparison2.Items.AddRange(new object[] {
            "Equal to",
            "Not equal to",
            "Greater than",
            "Less than",
            "Less than or equal",
            "Greater than or equal",
            "Is blank",
            "Is not blank",
            "Contains",
            "Does not contain"});
            this.comparison2.Location = new System.Drawing.Point(235, 74);
            this.comparison2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.comparison2.Name = "comparison2";
            this.comparison2.Size = new System.Drawing.Size(124, 21);
            this.comparison2.TabIndex = 15;
            this.comparison2.SelectedIndexChanged += new System.EventHandler(this.comparison1_SelectedIndexChanged);
            // 
            // comparison1
            // 
            this.comparison1.FormattingEnabled = true;
            this.comparison1.Items.AddRange(new object[] {
            "Equal to",
            "Not equal to",
            "Greater than",
            "Less than",
            "Less than or equal",
            "Greater than or equal",
            "Is blank",
            "Is not blank",
            "Contains",
            "Does not contain"});
            this.comparison1.Location = new System.Drawing.Point(235, 47);
            this.comparison1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.comparison1.Name = "comparison1";
            this.comparison1.Size = new System.Drawing.Size(124, 21);
            this.comparison1.TabIndex = 14;
            this.comparison1.SelectedIndexChanged += new System.EventHandler(this.comparison1_SelectedIndexChanged);
            // 
            // field3
            // 
            this.field3.FormattingEnabled = true;
            this.field3.Location = new System.Drawing.Point(78, 100);
            this.field3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.field3.Name = "field3";
            this.field3.Size = new System.Drawing.Size(132, 21);
            this.field3.TabIndex = 12;
            this.field3.SelectedIndexChanged += new System.EventHandler(this.field3_SelectedIndexChanged);
            // 
            // field2
            // 
            this.field2.FormattingEnabled = true;
            this.field2.Location = new System.Drawing.Point(78, 74);
            this.field2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.field2.Name = "field2";
            this.field2.Size = new System.Drawing.Size(132, 21);
            this.field2.TabIndex = 11;
            this.field2.SelectedIndexChanged += new System.EventHandler(this.field2_SelectedIndexChanged);
            // 
            // field1
            // 
            this.field1.FormattingEnabled = true;
            this.field1.Location = new System.Drawing.Point(78, 47);
            this.field1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.field1.Name = "field1";
            this.field1.Size = new System.Drawing.Size(132, 21);
            this.field1.TabIndex = 10;
            this.field1.SelectedIndexChanged += new System.EventHandler(this.field1_SelectedIndexChanged);
            // 
            // and_orCbx2
            // 
            this.and_orCbx2.FormattingEnabled = true;
            this.and_orCbx2.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.and_orCbx2.Location = new System.Drawing.Point(6, 100);
            this.and_orCbx2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.and_orCbx2.Name = "and_orCbx2";
            this.and_orCbx2.Size = new System.Drawing.Size(50, 21);
            this.and_orCbx2.TabIndex = 8;
            this.and_orCbx2.SelectedIndexChanged += new System.EventHandler(this.and_orCbx1_SelectedIndexChanged);
            // 
            // and_orCbx1
            // 
            this.and_orCbx1.FormattingEnabled = true;
            this.and_orCbx1.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.and_orCbx1.Location = new System.Drawing.Point(6, 74);
            this.and_orCbx1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.and_orCbx1.Name = "and_orCbx1";
            this.and_orCbx1.Size = new System.Drawing.Size(50, 21);
            this.and_orCbx1.TabIndex = 7;
            this.and_orCbx1.SelectedIndexChanged += new System.EventHandler(this.and_orCbx1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 280);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 22);
            this.button2.TabIndex = 0;
            this.button2.Text = "Ok";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // folderPath
            // 
            this.folderPath.Location = new System.Drawing.Point(6, 41);
            this.folderPath.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.folderPath.Name = "folderPath";
            this.folderPath.ReadOnly = true;
            this.folderPath.Size = new System.Drawing.Size(407, 20);
            this.folderPath.TabIndex = 34;
            this.folderPath.Click += new System.EventHandler(this.chooseFolder_Click);
            // 
            // chooseFolder
            // 
            this.chooseFolder.Location = new System.Drawing.Point(431, 41);
            this.chooseFolder.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chooseFolder.Name = "chooseFolder";
            this.chooseFolder.Size = new System.Drawing.Size(122, 22);
            this.chooseFolder.TabIndex = 33;
            this.chooseFolder.Text = "Choose folder storage";
            this.chooseFolder.UseVisualStyleBackColor = true;
            this.chooseFolder.Click += new System.EventHandler(this.chooseFolder_Click);
            // 
            // chooseFileBtn
            // 
            this.chooseFileBtn.Location = new System.Drawing.Point(431, 6);
            this.chooseFileBtn.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chooseFileBtn.Name = "chooseFileBtn";
            this.chooseFileBtn.Size = new System.Drawing.Size(122, 22);
            this.chooseFileBtn.TabIndex = 31;
            this.chooseFileBtn.Text = "Choose excel file";
            this.chooseFileBtn.UseVisualStyleBackColor = true;
            this.chooseFileBtn.Click += new System.EventHandler(this.chooseFileBtn_Click);
            // 
            // tabPageHWR
            // 
            this.tabPageHWR.Controls.Add(this.groupBox2);
            this.tabPageHWR.Controls.Add(this.label7);
            this.tabPageHWR.Controls.Add(this.previewBtn);
            this.tabPageHWR.Controls.Add(this.button3);
            this.tabPageHWR.Controls.Add(this.button4);
            this.tabPageHWR.Controls.Add(this.textBox3);
            this.tabPageHWR.Controls.Add(this.dataGridView2);
            this.tabPageHWR.Controls.Add(this.textBox5);
            this.tabPageHWR.Controls.Add(this.button8);
            this.tabPageHWR.Controls.Add(this.button9);
            this.tabPageHWR.Location = new System.Drawing.Point(4, 22);
            this.tabPageHWR.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tabPageHWR.Name = "tabPageHWR";
            this.tabPageHWR.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.tabPageHWR.Size = new System.Drawing.Size(566, 483);
            this.tabPageHWR.TabIndex = 1;
            this.tabPageHWR.Text = "HWR";
            this.tabPageHWR.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton4);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.reportedDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(8, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 100);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "More Informations";
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(205, 73);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(45, 17);
            this.radioButton4.TabIndex = 6;
            this.radioButton4.Text = "CC4";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(205, 50);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(45, 17);
            this.radioButton3.TabIndex = 5;
            this.radioButton3.Text = "CC3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(110, 73);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(45, 17);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "CC2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(110, 50);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(45, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "CC1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Template";
            // 
            // reportedDate
            // 
            this.reportedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.reportedDate.Location = new System.Drawing.Point(110, 19);
            this.reportedDate.Name = "reportedDate";
            this.reportedDate.Size = new System.Drawing.Size(99, 20);
            this.reportedDate.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Reported Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(36, 381);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Preview Template";
            // 
            // previewBtn
            // 
            this.previewBtn.Font = new System.Drawing.Font("Segoe MDL2 Assets", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previewBtn.Location = new System.Drawing.Point(8, 375);
            this.previewBtn.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.previewBtn.Name = "previewBtn";
            this.previewBtn.Size = new System.Drawing.Size(24, 22);
            this.previewBtn.TabIndex = 38;
            this.previewBtn.Text = " ";
            this.previewBtn.UseVisualStyleBackColor = true;
            this.previewBtn.Click += new System.EventHandler(this.previewBtn_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(479, 376);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 22);
            this.button3.TabIndex = 37;
            this.button3.Text = "Generate";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(398, 376);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 22);
            this.button4.TabIndex = 36;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(8, 7);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(407, 20);
            this.textBox3.TabIndex = 32;
            this.textBox3.Click += new System.EventHandler(this.chooseFileBtn_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(8, 82);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(548, 180);
            this.dataGridView2.TabIndex = 30;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(8, 43);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(407, 20);
            this.textBox5.TabIndex = 34;
            this.textBox5.Click += new System.EventHandler(this.chooseFolder_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(434, 43);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(122, 22);
            this.button8.TabIndex = 33;
            this.button8.Text = "Choose folder storage";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.chooseFolder_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(434, 7);
            this.button9.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(122, 22);
            this.button9.TabIndex = 31;
            this.button9.Text = "Choose excel file";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.chooseFileBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(574, 511);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home - Generate Certificate";
            this.tabControl.ResumeLayout(false);
            this.tabPageCertificate.ResumeLayout(false);
            this.tabPageCertificate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageHWR.ResumeLayout(false);
            this.tabPageHWR.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCertificate;
        private System.Windows.Forms.Button renderAndUploadBtn;
        private System.Windows.Forms.Button renderPdfBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox excelPath;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button filterBtn;
        private System.Windows.Forms.Button resetFilterBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox compare3;
        private System.Windows.Forms.TextBox compare2;
        private System.Windows.Forms.TextBox compare1;
        private System.Windows.Forms.ComboBox comparison3;
        private System.Windows.Forms.ComboBox comparison2;
        private System.Windows.Forms.ComboBox comparison1;
        private System.Windows.Forms.ComboBox field3;
        private System.Windows.Forms.ComboBox field2;
        private System.Windows.Forms.ComboBox field1;
        private System.Windows.Forms.ComboBox and_orCbx2;
        private System.Windows.Forms.ComboBox and_orCbx1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox folderPath;
        private System.Windows.Forms.Button chooseFolder;
        private System.Windows.Forms.Button chooseFileBtn;
        private System.Windows.Forms.TabPage tabPageHWR;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button previewBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker reportedDate;
        private System.Windows.Forms.Label label4;
    }
}

