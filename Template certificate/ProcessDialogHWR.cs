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
        private readonly Main _owner;
        private readonly string contentHtml = File.ReadAllText(@"D:\Funix\Hanna Weekly Report\Html source\hwr.html");

        public ProcessDialogHWR(Main parent)
        {
            InitializeComponent();

            _owner = parent;

            StartAsync();
            
        }

        // This event handler is where the time-consuming work is done.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            HtmlToImage htmlToImage = new HtmlToImage();
            Image img = htmlToImage.ConvertHtmlString(contentHtml);

            ////TODO: create new file first
            FileStream stream = File.Open("D:/Image/testHWR.png", FileMode.Create);
            img.Save(stream, ImageFormat.Png);
            stream.Close();
        }

        // This event handler updates the progress.
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            resultLabel.Text = ("Processing: " + e.ProgressPercentage.ToString() + "/" + 1);
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
