using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageResizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg"
            };

            if (open.ShowDialog() == DialogResult.OK)
            {
                selectedPicturebox.Image = Image.FromFile(open.FileName);
            }
        }

        private void resizeBar_Scroll(object sender, EventArgs e)
        {
            int value = resizeBar.Value;

            resizeValueTextBox.Text = value.ToString();
            updateImage(value);
        }

        private void updateImage(int pValue)
        {
            if (pValue > 1)
            {
                increaseImage(pValue);
            }
            else if (pValue < -1)
            {
                decreaseImage(pValue);
            }
        }

        private void increaseImage(int pValue)
        {
            Bitmap currentBitmap = (Bitmap)selectedPicturebox.Image;

            int resultX = currentBitmap.Width * pValue;
            int resultY = currentBitmap.Height * pValue;

            Bitmap resultBitmap = new Bitmap(resultX, resultY);

            int currentX = 0;
            int currentY = 0;

            for (int y = 0; y < currentBitmap.Height; y++)
            {
                for (int x = 0; x < currentBitmap.Width; x++)
                {
                    Color color = currentBitmap.GetPixel(x, y);

                    for (int countResizedPixel = 1; countResizedPixel <= pValue; countResizedPixel++)
                    {
                        currentX = currentX + countResizedPixel;

                        resultBitmap.SetPixel(currentX, y, color);
                    }
                }
            }

            resultPicturebox.Image = resultBitmap;
        }

        private void decreaseImage(int pValue)
        {

        }
    }
}