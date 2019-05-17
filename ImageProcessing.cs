using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ImageProcessing
{
    public partial class ImageProcessing : Form
    {
        private readonly OpenFileDialog oDlg;
        private readonly SaveFileDialog sDlg;
        private readonly ImageHandler imageHandler = new ImageHandler();
        private int counter = 0;

        public ImageProcessing()
        {
            InitializeComponent();
            oDlg = new OpenFileDialog(); // Open Dialog Initialization
            oDlg.RestoreDirectory = true;
            oDlg.InitialDirectory = "C:\\";
            oDlg.FilterIndex = 1;
            oDlg.Filter =
                "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";
            /*************************/
            sDlg = new SaveFileDialog(); // Save Dialog Initialization
            sDlg.RestoreDirectory = true;
            sDlg.InitialDirectory = "C:\\";
            sDlg.FilterIndex = 1;
            sDlg.Filter =
                "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";
        }

        private void ImageProcessing_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawImage(imageHandler.CurrentBitmap,
                new Rectangle(AutoScrollPosition.X, AutoScrollPosition.Y,
                    Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                    Convert.ToInt32(imageHandler.CurrentBitmap.Height)));
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            var histForm = new Histograms();
            if (DialogResult.OK == oDlg.ShowDialog())
            {
                imageHandler.CurrentBitmap = (Bitmap)Image.FromFile(oDlg.FileName);
                imageHandler.BitmapPath = oDlg.FileName;

                if (imageHandler.GetBitmapSize().Width >= Screen.PrimaryScreen.Bounds.Width &&
                    imageHandler.GetBitmapSize().Height >= Screen.PrimaryScreen.Bounds.Height)
                {
                    TopMost = true;
                    Location = new Point(0, 0);
                    Bounds = Screen.PrimaryScreen.Bounds;
                    WindowState = FormWindowState.Maximized;
                    AutoScroll = true;
                    AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                        Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                    Bitmap bmp = imageHandler.CurrentBitmap;
                    histForm.AddRedHistogram(bmp);
                    histForm.AddGreenHistogram(bmp);
                    histForm.AddBlueHistogram(bmp);
                    histForm.Show();
                    Invalidate();
                }
                else if (imageHandler.GetBitmapSize().Width >= Screen.PrimaryScreen.Bounds.Width)
                {
                    TopMost = true;
                    Location = new Point(0, 0);
                    Width = Screen.PrimaryScreen.Bounds.Width;
                    Height = imageHandler.GetBitmapSize().Height + 33;
                    AutoScroll = true;
                    AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                        Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                    WindowState = FormWindowState.Normal;
                    Bitmap bmp = imageHandler.CurrentBitmap;
                    histForm.AddRedHistogram(bmp);
                    histForm.AddGreenHistogram(bmp);
                    histForm.AddBlueHistogram(bmp);
                    histForm.Show();
                    Invalidate();
                }
                else if (imageHandler.GetBitmapSize().Height >= Screen.PrimaryScreen.Bounds.Height)
                {
                    TopMost = true;
                    Location = new Point(0, 0);
                    Width = imageHandler.GetBitmapSize().Width + 33;
                    Height = Screen.PrimaryScreen.Bounds.Height;
                    AutoScroll = true;
                    AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                        Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                    WindowState = FormWindowState.Normal;
                    Bitmap bmp = imageHandler.CurrentBitmap;
                    histForm.AddRedHistogram(bmp);
                    histForm.AddGreenHistogram(bmp);
                    histForm.AddBlueHistogram(bmp);
                    histForm.Show();
                    Invalidate();
                }
                else
                {
                    TopMost = true;
                    Location = new Point(0, 0);
                    Bounds = RestoreBounds;
                    WindowState = FormWindowState.Normal;
                    AutoScroll = false;
                    ClientSize = imageHandler.GetBitmapSize();
                    Bitmap bmp = imageHandler.CurrentBitmap;
                    histForm.AddRedHistogram(bmp);
                    histForm.AddGreenHistogram(bmp);
                    histForm.AddBlueHistogram(bmp);
                    histForm.Show();
                    Invalidate();
                }
            }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == sDlg.ShowDialog()) imageHandler.SaveBitmap(sDlg.FileName);
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemUndo_Click(object sender, EventArgs e)
        {
            imageHandler.ResetBitmap();
            AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                Convert.ToInt32(imageHandler.CurrentBitmap.Height));
            WindowState = FormWindowState.Normal;
            ClientSize = imageHandler.GetBitmapSize();
            
            Invalidate();
        }

        private void menuItemClearImage_Click(object sender, EventArgs e)
        {
            imageHandler.RestorePrevious();
            imageHandler.ClearImage();
            Invalidate();
        }

        private void menuItemSetColor_Click(object sender, EventArgs e)
        {

            var histForm = new Histograms();
            var cForm = new ColorForm();
            if (cForm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.SetColor(cForm.GetRed, cForm.GetGreen, cForm.GetBlue);
                Bitmap bmp = imageHandler.CurrentBitmap;
                histForm.AddRedHistogram(bmp);
                histForm.AddGreenHistogram(bmp);
                histForm.AddBlueHistogram(bmp);
                histForm.Show();
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void menuItemGamma_Click(object sender, EventArgs e)
        {
            var histForm = new Histograms();
            var gFrm = new GammaForm();
            if (gFrm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.SetGamma(gFrm.RedComponent, gFrm.GreenComponent, gFrm.BlueComponent);
                Bitmap bmp = imageHandler.CurrentBitmap;
                histForm.AddRedHistogram(bmp);
                histForm.AddGreenHistogram(bmp);
                histForm.AddBlueHistogram(bmp);
                histForm.Show();
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void menuItemBrightness_Click(object sender, EventArgs e)
        {
            var histForm = new Histograms();
            var bFrm = new BrightnessForm();
            if (bFrm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.SetBrightness(bFrm.BrightnessValue);
                Bitmap bmp = imageHandler.CurrentBitmap;
                histForm.AddRedHistogram(bmp);
                histForm.AddGreenHistogram(bmp);
                histForm.AddBlueHistogram(bmp);
                histForm.Show();
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void menuItemContrast_Click(object sender, EventArgs e)
        {
            var histForm = new Histograms();
            var cFrm = new ContrastForm();
            if (cFrm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.SetContrast(cFrm.ContrastValue);
                Bitmap bmp = imageHandler.CurrentBitmap;
                histForm.AddRedHistogram(bmp);
                histForm.AddGreenHistogram(bmp);
                histForm.AddBlueHistogram(bmp);
                histForm.Show();
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void menuItemGrayscale_Click(object sender, EventArgs e)
        {
            var histForm = new Histograms();
            Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            imageHandler.SetGrayscale();
            Bitmap bmp = imageHandler.CurrentBitmap;
            histForm.AddRedHistogram(bmp);
            histForm.AddGreenHistogram(bmp);
            histForm.AddBlueHistogram(bmp);
            histForm.Show();
            Invalidate();
            Cursor = Cursors.Default;
        }

        private void menuItemInvert_Click(object sender, EventArgs e)
        {
            var histForm = new Histograms();

            Cursor = Cursors.WaitCursor;
            imageHandler.RestorePrevious();
            imageHandler.SetInvert();
            Bitmap bmp = imageHandler.CurrentBitmap;
            histForm.AddRedHistogram(bmp);
            histForm.AddGreenHistogram(bmp);
            histForm.AddBlueHistogram(bmp);
            histForm.Show();
            Invalidate();
            Cursor = Cursors.Default;
        }

        private void powerConstrast_Click(object sender, EventArgs e)
        {
            var histForm = new Histograms();
            var powerForm = new PowerContrastForm();
            if (powerForm.ShowDialog() == DialogResult.OK)
            {

                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.PowerContrast(powerForm.GammaValue);
                Bitmap bmp = imageHandler.CurrentBitmap;
                histForm.AddRedHistogram(bmp);
                histForm.AddGreenHistogram(bmp);
                histForm.AddBlueHistogram(bmp);
                histForm.Show();
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void menuItemResize_Click(object sender, EventArgs e)
        {
            var rFrm = new InsertTextForm1();
            rFrm.NewWidth = imageHandler.CurrentBitmap.Width;
            rFrm.NewHeight = imageHandler.CurrentBitmap.Height;
            if (rFrm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();

                if (rFrm.NewWidth < Screen.PrimaryScreen.Bounds.Width && rFrm.NewHeight < Screen.PrimaryScreen.Bounds.Height)
                {
                    imageHandler.Resize(rFrm.NewWidth, rFrm.NewHeight);
                    AutoScroll = false;
                    WindowState = FormWindowState.Normal;
                    ClientSize = imageHandler.GetBitmapSize();
                }
                AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                    Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                ClientSize = imageHandler.GetBitmapSize();
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void menuItemRotate90_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (imageHandler.GetBitmapSize().Width >= Screen.PrimaryScreen.Bounds.Width &&
                imageHandler.GetBitmapSize().Height >= Screen.PrimaryScreen.Bounds.Height)
            {
                AutoScroll = true;
                AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                    Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                Invalidate();
            }
            else if (imageHandler.GetBitmapSize().Width >= Screen.PrimaryScreen.Bounds.Width)
            {
                Width = Screen.PrimaryScreen.Bounds.Width;
                Height = imageHandler.GetBitmapSize().Height + 33;
                AutoScroll = true;
                AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                    Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                Invalidate();
            }
            else if (imageHandler.GetBitmapSize().Height >= Screen.PrimaryScreen.Bounds.Height)
            {
                Width = imageHandler.GetBitmapSize().Width + 33;
                Height = Screen.PrimaryScreen.Bounds.Height;
                AutoScroll = true;
                AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                    Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                Invalidate();
            }
            else
            {
                Bounds = RestoreBounds;
                AutoScroll = false;
                ClientSize = imageHandler.GetBitmapSize();
                Invalidate();
            }
        }

        private void menuItemRotate180_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (imageHandler.GetBitmapSize().Width >= Screen.PrimaryScreen.Bounds.Width &&
                imageHandler.GetBitmapSize().Height >= Screen.PrimaryScreen.Bounds.Height)
            {
                AutoScroll = true;
                AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                    Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                Invalidate();
            }
            else if (imageHandler.GetBitmapSize().Width >= Screen.PrimaryScreen.Bounds.Width)
            {
                Width = Screen.PrimaryScreen.Bounds.Width;
                Height = imageHandler.GetBitmapSize().Height + 33;
                AutoScroll = true;
                AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                    Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                Invalidate();
            }
            else if (imageHandler.GetBitmapSize().Height >= Screen.PrimaryScreen.Bounds.Height)
            {
                Width = imageHandler.GetBitmapSize().Width + 33;
                Height = Screen.PrimaryScreen.Bounds.Height;
                AutoScroll = true;
                AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                    Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                Invalidate();
            }
            else
            {
                Bounds = RestoreBounds;
                AutoScroll = false;
                ClientSize = imageHandler.GetBitmapSize();
                Invalidate();
            }
        }

        private void menuItemRotate270_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.Rotate270FlipNone);
            if (imageHandler.GetBitmapSize().Width >= Screen.PrimaryScreen.Bounds.Width &&
                imageHandler.GetBitmapSize().Height >= Screen.PrimaryScreen.Bounds.Height)
            {
                AutoScroll = true;
                AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                    Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                Invalidate();
            }
            else if (imageHandler.GetBitmapSize().Width >= Screen.PrimaryScreen.Bounds.Width)
            {
                Width = Screen.PrimaryScreen.Bounds.Width;
                Height = imageHandler.GetBitmapSize().Height + 33;
                AutoScroll = true;
                AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                    Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                Invalidate();
            }
            else if (imageHandler.GetBitmapSize().Height >= Screen.PrimaryScreen.Bounds.Height)
            {
                Width = imageHandler.GetBitmapSize().Width + 33;
                Height = Screen.PrimaryScreen.Bounds.Height;
                AutoScroll = true;
                AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                    Convert.ToInt32(imageHandler.CurrentBitmap.Height));
                Invalidate();
            }
            else
            {
                Bounds = RestoreBounds;
                AutoScroll = false;
                ClientSize = imageHandler.GetBitmapSize();
                Invalidate();
            }
        }

        private void menuItemFlipH_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.RotateNoneFlipX);
            AutoScroll = true;
            AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                Convert.ToInt32(imageHandler.CurrentBitmap.Height));
            Invalidate();
        }

        private void menuItemFlipV_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.RotateNoneFlipY);
            AutoScroll = true;
            AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.CurrentBitmap.Width),
                Convert.ToInt32(imageHandler.CurrentBitmap.Height));
            Invalidate();
        }

        private void menuItemCrop_Click(object sender, EventArgs e)
        {
            var cpFrm = new CropForm();
            cpFrm.CropXPosition = 0; ClientSize = imageHandler.GetBitmapSize(); cpFrm.CropYPosition = 0;
            cpFrm.CropWidth = imageHandler.CurrentBitmap.Width;
            cpFrm.CropHeight = imageHandler.CurrentBitmap.Height;
            if (cpFrm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.DrawOutCropArea(cpFrm.CropXPosition, cpFrm.CropYPosition, cpFrm.CropWidth,
                    cpFrm.CropHeight);
                Invalidate();
                if (MessageBox.Show("Do u want to crop this area?", "ImageProcessing", MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (cpFrm.CropWidth < Screen.PrimaryScreen.Bounds.Width && cpFrm.CropHeight < Screen.PrimaryScreen.Bounds.Height)
                    {
                        imageHandler.Crop(cpFrm.CropXPosition, cpFrm.CropYPosition, cpFrm.CropWidth, cpFrm.CropHeight);
                        AutoScroll = false;
                        WindowState = FormWindowState.Normal;
                        ClientSize = imageHandler.GetBitmapSize();
                    }
                    else if (cpFrm.CropWidth > Screen.PrimaryScreen.Bounds.Width &&
                             cpFrm.CropHeight < Screen.PrimaryScreen.Bounds.Height)
                    {
                        imageHandler.Crop(cpFrm.CropXPosition, cpFrm.CropYPosition, cpFrm.CropWidth, cpFrm.CropHeight);
                        WindowState = FormWindowState.Normal;
                        ClientSize = imageHandler.GetBitmapSize();
                    }
                    else if (cpFrm.CropWidth < Screen.PrimaryScreen.Bounds.Width && cpFrm.CropHeight > Screen.PrimaryScreen.Bounds.Height)
                    {
                        imageHandler.Crop(cpFrm.CropXPosition, cpFrm.CropYPosition, cpFrm.CropWidth, cpFrm.CropHeight);
                        WindowState = FormWindowState.Normal;
                        ClientSize = imageHandler.GetBitmapSize();
                    }
                    else
                    {
                        ClientSize = imageHandler.GetBitmapSize();
                    }
                }
                else
                {
                    imageHandler.RemoveCropAreaDraw();
                }
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void skalowanieHist_Click(object sender, EventArgs e)
        {
            var histForm = new Histograms();
            var sFrm = new ScaleHistogram();
            if (sFrm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.HistogramScalling(sFrm.a, sFrm.b, sFrm.c, sFrm.d);
                Bitmap bmp = imageHandler.CurrentBitmap;
                histForm.AddRedHistogram(bmp);
                histForm.AddGreenHistogram(bmp);
                histForm.AddBlueHistogram(bmp);
                histForm.Show();
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void obroc_Click(object sender, EventArgs e)
        {
            var obFrm = new Rotate();
            if (obFrm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.Rotate(imageHandler.CurrentBitmap, obFrm.kat);
                ClientSize = imageHandler.GetBitmapSize();
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void rozmycie_Click(object sender, EventArgs e)
        {
            var rozFrm = new Blur();
            if (rozFrm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.Rozmycie(rozFrm.Value);
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void pochylenie_Click(object sender, EventArgs e)
        {
            var skFrm = new Skew();
            if (skFrm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.Pochylenie(skFrm.A, skFrm.B);
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void binary_Click(object sender, EventArgs e)
        {
            var inFrm = new Interpolation();
            if (inFrm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.Interpolate(inFrm.Width2, inFrm.Height2, InterpolationMode.Bilinear);
                ClientSize = imageHandler.GetBitmapSize();
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void bicubic_Click(object sender, EventArgs e)
        {
            var inFrm = new Interpolation();
            if (inFrm.ShowDialog() == DialogResult.OK)
            {
                Cursor = Cursors.WaitCursor;
                imageHandler.RestorePrevious();
                imageHandler.Interpolate(inFrm.Width2, inFrm.Height2, InterpolationMode.Bicubic);
                ClientSize = imageHandler.GetBitmapSize();
                Invalidate();
                Cursor = Cursors.Default;
            }
        }

        private void RobertsPoziom_Click(object sender, EventArgs e)
        {
            imageHandler.Masks(Masks.RobertsPoziom);
            Invalidate();
                 
        }

        private void RobertsPion_Click(object sender, EventArgs e)
        {
            imageHandler.Masks(Masks.RobertsPion);
            Invalidate();
        }

        private void PrewittPoziom_Click(object sender, EventArgs e)
        {
            imageHandler.Masks(Masks.PrewittPoziom);
            Invalidate();
        }

        private void PrewittPion_Click(object sender, EventArgs e)
        {
            imageHandler.Masks(Masks.PrewittPion);
            Invalidate();
        }

        private void SobelPoziom_Click(object sender, EventArgs e)
        {
            imageHandler.Masks(Masks.SobelPoziom);
            Invalidate();
        }

        private void SobelPion_Click(object sender, EventArgs e)
        {
            imageHandler.Masks(Masks.SobelPion);
            Invalidate();
        }

        private void LaplaceFirst_Click(object sender, EventArgs e)
        {
            imageHandler.Masks(Masks.LaplaceFirst);
            counter++;
            Console.WriteLine(counter);
            Invalidate();
        }

        private void LaplaceSecond_Click(object sender, EventArgs e)
        {
            imageHandler.Masks(Masks.LaplaceSecond);
            counter++;
            Invalidate();
        }

        private void LaplaceThird_Click(object sender, EventArgs e)
        {
            imageHandler.Masks(Masks.LaplaceThird);
            counter++;
            Invalidate();
        }

        private void LaplaceSharp_Click(object sender, EventArgs e)
        {
            if (counter >= 1)
            {
                imageHandler.LaplaceSharp();
                Invalidate();
            }
        }

        private void StatMin_Click(object sender, EventArgs e)
        {
            imageHandler.Minimum();
            Invalidate();
        }

        private void StatMax_Click(object sender, EventArgs e)
        {
            imageHandler.Maximum();
            Invalidate();
        }

        private void MedianowyN1_Click(object sender, EventArgs e)
        {
            imageHandler.MedianowyN1();
            Invalidate();
        }

        private void MedianowyN2_Click(object sender, EventArgs e)
        {
            imageHandler.MedianowyN2();
            Invalidate();
        }

        private void InicjalyBezier_Click(object sender, EventArgs e)
        {/*
            Graphics g = CreateGraphics();
            PaintEventArgs pta = new PaintEventArgs(g, ClientRectangle);
            List<double> punkty1 = new List<double>();
            List<double> punkty2 = new List<double>();
            List<double> punkty3 = new List<double>();
            
            imageHandler.Load(punkty1, @"C:\Users\buruk\Desktop\punkty1.txt");
            imageHandler.Load(punkty2, @"C:\Users\buruk\Desktop\punkty2.txt");
            imageHandler.Load(punkty3, @"C:\Users\buruk\Desktop\punkty3.txt");
            imageHandler.Bezier(pta, punkty1);
            imageHandler.Bezier(pta, punkty2);
            imageHandler.Bezier(pta, punkty3);
            */
            Graphics g = CreateGraphics();
            PaintEventArgs pta = new PaintEventArgs(g, ClientRectangle);
            imageHandler.Bezier(pta);

        }

        private void platyBezier_Click(object sender, EventArgs e)
        {

        }
    }
}