// Image Viewer sample application
// AForge.NET framework
// http://www.aforgenet.com/framework/
//
// Copyright © AForge.NET, 2006-2011
// contacts@aforgenet.com
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Accord.Imaging.Formats;

namespace SampleApp
{

    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
        }

        // Exit from application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Open image file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ImageInfo imageInfo = null;

                    pictureBox.Image = ImageDecoder.DecodeFromFile(openFileDialog.FileName, out imageInfo);

                    propertyGrid.SelectedObject = imageInfo;
                    propertyGrid.ExpandAllGridItems();
                }
                catch (NotSupportedException ex)
                {
                    MessageBox.Show("Image format is not supported: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Invalid image: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Failed loading the image", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pen rectPen = new Pen(Color.Blue);

            Bitmap OrigBitmap = ImageDecoder.DecodeFromFile("C:\\Users\\tbowen\\source\\repos\\framework\\Samples\\Imaging\\Image Viewer\\bin\\x86\\Debug\\NoctiAnswerSheet.png");



           // pictureBox.Image = OrigBitmap;



            // Create a blank bitmap with the same dimensions
            Bitmap tempBitmap = new Bitmap(OrigBitmap.Width, OrigBitmap.Height);

            // From this bitmap, the graphics can be obtained, because it has the right PixelFormat
            using (Graphics g = Graphics.FromImage(tempBitmap))
            {
                // Draw the original bitmap onto the graphics of the new bitmap
                
                g.DrawImage(OrigBitmap, 0, 0);
                // Use g to do whatever you like
                g.DrawRectangle(rectPen, 200, 200, 500, 500);
                pictureBox.Image = tempBitmap;
            }

            
            


        }
    }
}
