﻿using SelectPdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Template_certificate
{
    class GenerateImage
    {
        //DataTable dt, string studentID, string studentName, string certificate;
        public DataTable dt{ get; set; }
        public string studentId { get; set; }
        public string studentName { get; set; }
        public string certificate { get; set; }
        public DateTime reportedDate { get; set; }
        public string folderStoragePath { get; set; }

        private readonly string folder = @"file:///D:\Funix\Hanna Weekly Report\Html source";
        private readonly string contentHtml = File.ReadAllText(@"D:\Funix\Hanna Weekly Report\Html source\hwr.html");

        public GenerateImage(DataTable dt, string studentId, string studentName, string certificate, DateTime reportedDate, string folderStoragePath)
        {
            this.dt = dt;
            this.studentId = studentId;
            this.studentName = studentName;
            this.certificate = certificate;
            this.reportedDate = reportedDate;
            this.folderStoragePath = folderStoragePath;
        }

        internal void GenerateToImage()
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
            string[] parameters = { folder, reportedDate.ToString("dd/MM/yyyy"), studentName, studentId, timeRemain, studyAvg, studyCompletedLastWeek, htmlTable, width };
            HtmlToImage htmlToImage = new HtmlToImage();

            string html = string.Format(contentHtml, parameters);
            Image img = htmlToImage.ConvertHtmlString(html);

            //TODO: create new file first
            DirectoryInfo directory = new DirectoryInfo(Path.Combine(folderStoragePath, $"{studentClass}"));
            if (!directory.Exists)
            {
                directory.Create();
            }
            FileStream stream = File.Open(Path.Combine(folderStoragePath, $"{studentClass}/{studentId} - {studentName}.png"), FileMode.Create);
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

    }
}