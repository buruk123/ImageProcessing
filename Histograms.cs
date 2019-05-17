using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Histograms : Form
    {
        //private Bitmap bmp;
        public Histograms()
        {
            InitializeComponent();
        }

        public void AddRedHistogram(Bitmap red)
        {
            Bitmap bmp = red;
            int[] histogram_r = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int redValue = bmp.GetPixel(i, j).R;
                    histogram_r[redValue]++;
                    if (max < histogram_r[redValue])
                        max = histogram_r[redValue];
                }
            }

            int histHeight = pictureBox1.Height;
            Bitmap img = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < histogram_r.Length; i++)
                {
                    float pct = histogram_r[i] / max;
                    g.DrawLine(Pens.Red,
                        new Point(i, img.Height - 5),
                        new Point(i, img.Height - 5 - (int)(pct * histHeight))
                    );
                }
            }
            pictureBox1.Image = img;
        }

        public void AddGreenHistogram(Bitmap green)
        {
            Bitmap bmp = green;
            int[] histogram_r = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int greenValue = bmp.GetPixel(i, j).G;
                    histogram_r[greenValue]++;
                    if (max < histogram_r[greenValue])
                        max = histogram_r[greenValue];
                    
                }
            }


            int histHeight = pictureBox2.Height;
            Bitmap img = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < histogram_r.Length; i++)
                {
                    float pct = histogram_r[i] / max;
                    g.DrawLine(Pens.Green,
                        new Point(i, img.Height - 5),
                        new Point(i, img.Height - 5 - (int)(pct * histHeight))
                    );
                }
            }
            pictureBox2.Image = img;
        }

        public void AddBlueHistogram(Bitmap blue)
        {
            Bitmap bmp = blue;
            int[] histogram_r = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int blueValue = bmp.GetPixel(i, j).B;
                    histogram_r[blueValue]++;
                    if (max < histogram_r[blueValue])
                        max = histogram_r[blueValue];
                }
            }

            int histHeight = pictureBox3.Height;
            Bitmap img = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < histogram_r.Length; i++)
                {
                    float pct = histogram_r[i] / max;
                    g.DrawLine(Pens.Blue,
                        new Point(i, img.Height - 5),
                        new Point(i, img.Height - 5 - (int)(pct * histHeight))
                    );
                }
            }
            pictureBox3.Image = img;
        }
    }
}
