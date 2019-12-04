using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Pdf;
using System.IO;
using Spire.Pdf.Graphics;
using System.Drawing;
using Microsoft.Win32;

namespace WpfApp1.Services
{
    class PdfService
    {
        public void ExportToPDF(string pdfHeader, string pdfBody)
        {
            //A: create PDF file and save it to stream

            //create a pdf document.
            PdfDocument doc = new PdfDocument();

            // create one page
            PdfPageBase page = doc.Pages.Add();
            string pdfString = pdfHeader + "\n \n" + pdfBody;
            //draw the text
            
            page.Canvas.DrawString(pdfString,
                                   new PdfFont(PdfFontFamily.Symbol, 14f),
                                   new PdfSolidBrush(Color.Black),
                                   10, 10);

            OpenFileDialog folderBrowser = new OpenFileDialog();

            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
           
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == true)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                FileStream to_stream = new FileStream(folderPath + "\\To_stream.pdf", FileMode.Create);

                doc.SaveToStream(to_stream);
                to_stream.Close();
                doc.Close();
             
            }



        }
    }
}
