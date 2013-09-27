using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aspose.OCR;
using System.IO;

namespace ocrTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string filepath = @"C:\Users\Tyler\Desktop\testFile4.png";
            const string resourceFileName = @"..\..\Resources\Aspose.OCR.Resouces.zip";

            // Initialize OcrEngine
            OcrEngine ocr = new OcrEngine();
            // Set the image
            ocr.Image = ImageStream.FromFile(filepath);
            // Add language
            ocr.Languages.AddLanguage(Language.Load("english"));
            // Load the resource file
            using (ocr.Resource = new FileStream(resourceFileName, FileMode.Open))
            {
                try
                {
                    // Process the whole image
                    if (ocr.Process())
                    {
                        // Get the complete recognized text found from the image
                        label1.Text = ocr.Text.ToString();
                    }
                }
                catch (Exception ex)
                {
                    label1.Text = "failure";
                }
            }


        }
    }
}
