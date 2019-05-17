using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace ImageProcessing
{
    public class ImageHandler
    {
        private Bitmap _currentBitmap;
        private Bitmap _bitmapPrevCropArea;

        public Bitmap CurrentBitmap
        {
            get
            {
                if (_currentBitmap == null)
                    _currentBitmap = new Bitmap(1, 1);
                return _currentBitmap;
            }
            set { _currentBitmap = value; }
        }

        public Bitmap BitmapBeforeProcessing { get; set; }

        public string BitmapPath { get; set; }

        public Size GetBitmapSize()
        {
            return _currentBitmap.Size;
        }

        public void ResetBitmap()
        {
            if (_currentBitmap != null && BitmapBeforeProcessing != null)
            {
                var temp = (Bitmap) _currentBitmap.Clone();
                _currentBitmap = (Bitmap) BitmapBeforeProcessing.Clone();
                BitmapBeforeProcessing = (Bitmap) temp.Clone();
            }
        }

        public void SaveBitmap(string saveFilePath)
        {
            BitmapPath = saveFilePath;
            if (File.Exists(saveFilePath))
                File.Delete(saveFilePath);
            _currentBitmap.Save(saveFilePath);
        }

        public void ClearImage()
        {
            _currentBitmap = new Bitmap(1, 1);  
        }

        public void RestorePrevious()
        {
            BitmapBeforeProcessing = _currentBitmap;
        }

        public void SetColor(double red, double green, double blue)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            Color c;
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                var nPixelR = c.R + red;
                var nPixelG = c.G + green;
                var nPixelB = c.B + blue;

                nPixelR = Math.Max(nPixelR, 0);
                nPixelR = Math.Min(255, nPixelR);

                nPixelG = Math.Max(nPixelG, 0);
                nPixelG = Math.Min(255, nPixelG);

                nPixelB = Math.Max(nPixelB, 0);
                nPixelB = Math.Min(255, nPixelB);

                bmap.SetPixel(i, j, Color.FromArgb((byte) nPixelR, (byte) nPixelG, (byte) nPixelB));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void SetGamma(double red, double green, double blue)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            Color c;
            var redGamma = CreateGammaArray(red);
            var greenGamma = CreateGammaArray(green);
            var blueGamma = CreateGammaArray(blue);
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                bmap.SetPixel(i, j, Color.FromArgb(redGamma[c.R], greenGamma[c.G], blueGamma[c.B]));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        private byte[] CreateGammaArray(double color)
        {
            var gammaArray = new byte[256];
            for (var i = 0; i < 256; ++i)
                gammaArray[i] = (byte) Math.Min(255, (int) (255.0 * Math.Pow(i / 255.0, 1.0 / color) + 0.5));
            return gammaArray;
        }

        public void SetBrightness(int brightness)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;
            Color c;
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                var cR = c.R + brightness;
                var cG = c.G + brightness;
                var cB = c.B + brightness;

                if (cR < 0) cR = 1;
                if (cR > 255) cR = 255;

                if (cG < 0) cG = 1;
                if (cG > 255) cG = 255;

                if (cB < 0) cB = 1;
                if (cB > 255) cB = 255;

                bmap.SetPixel(i, j, Color.FromArgb((byte) cR, (byte) cG, (byte) cB));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void SetContrast(double contrast)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;
            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            Color c;
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                var pR = c.R / 255.0;
                pR -= 0.5;
                pR *= contrast;
                pR += 0.5;
                pR *= 255;
                if (pR < 0) pR = 0;
                if (pR > 255) pR = 255;

                var pG = c.G / 255.0;
                pG -= 0.5;
                pG *= contrast;
                pG += 0.5;
                pG *= 255;
                if (pG < 0) pG = 0;
                if (pG > 255) pG = 255;

                var pB = c.B / 255.0;
                pB -= 0.5;
                pB *= contrast;
                pB += 0.5;
                pB *= 255;
                if (pB < 0) pB = 0;
                if (pB > 255) pB = 255;

                bmap.SetPixel(i, j, Color.FromArgb((byte) pR, (byte) pG, (byte) pB));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void SetGrayscale()
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            Color c;
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                var gray = (byte) (.299 * c.R + .587 * c.G + .114 * c.B);

                bmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void SetInvert()
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            Color c;
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                bmap.SetPixel(i, j, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void PowerContrast(double gammaValue)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            Color c;
            for (var i = 0; i < bmap.Width; i++)
            for (var j = 0; j < bmap.Height; j++)
            {
                c = bmap.GetPixel(i, j);
                var cR = (double) c.R / 255.0;
                var cG = (double) c.G / 255.0;
                var cB = (double) c.B / 255.0;

                double setR = 255.0 * Math.Pow(cR, gammaValue);
                double setG = 255.0 * Math.Pow(cG, gammaValue);
                double setB = 255.0 * Math.Pow(cB, gammaValue);

                if (setR > 255) setR = 255;
                if (setR < 0) setR = 0;
                if (setG > 255) setG = 255;
                if (setG < 0) setG = 0;
                if (setB > 255) setB = 255;
                if (setB < 0) setB = 0;

                bmap.SetPixel(i, j, Color.FromArgb((int) setR, (int) setG, (int) setB));
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void Resize(int newWidth, int newHeight)
        {
            if (newWidth != 0 && newHeight != 0)
            {
                var temp = _currentBitmap;
                var bmap = new Bitmap(newWidth, newHeight, temp.PixelFormat);

                var nWidthFactor = temp.Width / (double) newWidth;
                var nHeightFactor = temp.Height / (double) newHeight;

                double fx, fy, nx, ny;
                int cx, cy, fr_x, fr_y;
                Color color1;
                Color color2;
                Color color3;
                Color color4;
                byte nRed, nGreen, nBlue;

                byte bp1, bp2;

                for (var x = 0; x < bmap.Width; ++x)
                for (var y = 0; y < bmap.Height; ++y)
                {
                    fr_x = (int) Math.Floor(x * nWidthFactor);
                    fr_y = (int) Math.Floor(y * nHeightFactor);
                    cx = fr_x + 1;
                    if (cx >= temp.Width) cx = fr_x;
                    cy = fr_y + 1;
                    if (cy >= temp.Height) cy = fr_y;
                    fx = x * nWidthFactor - fr_x;
                    fy = y * nHeightFactor - fr_y;
                    nx = 1.0 - fx;
                    ny = 1.0 - fy;

                    color1 = temp.GetPixel(fr_x, fr_y);
                    color2 = temp.GetPixel(cx, fr_y);
                    color3 = temp.GetPixel(fr_x, cy);
                    color4 = temp.GetPixel(cx, cy);

                    // Blue
                    bp1 = (byte) (nx * color1.B + fx * color2.B);

                    bp2 = (byte) (nx * color3.B + fx * color4.B);

                    nBlue = (byte) (ny * bp1 + fy * bp2);

                    // Green
                    bp1 = (byte) (nx * color1.G + fx * color2.G);

                    bp2 = (byte) (nx * color3.G + fx * color4.G);

                    nGreen = (byte) (ny * bp1 + fy * bp2);

                    // Red
                    bp1 = (byte) (nx * color1.R + fx * color2.R);

                    bp2 = (byte) (nx * color3.R + fx * color4.R);

                    nRed = (byte) (ny * bp1 + fy * bp2);

                    bmap.SetPixel(x, y, Color.FromArgb(255, nRed, nGreen, nBlue));
                }

                _currentBitmap = (Bitmap) bmap.Clone();
            }
        }

        public void RotateFlip(RotateFlipType rotateFlipType)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            bmap.RotateFlip(rotateFlipType);
            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void Crop(int xPosition, int yPosition, int width, int height)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            if (xPosition + width > _currentBitmap.Width)
                width = _currentBitmap.Width - xPosition;
            if (yPosition + height > _currentBitmap.Height)
                height = _currentBitmap.Height - yPosition;
            var rect = new Rectangle(xPosition, yPosition, width, height);
            _currentBitmap = bmap.Clone(rect, bmap.PixelFormat);
        }

        public void DrawOutCropArea(int xPosition, int yPosition, int width, int height)
        {
            _bitmapPrevCropArea = _currentBitmap;
            var bmap = (Bitmap) _bitmapPrevCropArea.Clone();
            var gr = Graphics.FromImage(bmap);
            var cBrush = new Pen(Color.FromArgb(150, Color.White)).Brush;
            var rect1 = new Rectangle(0, 0, _currentBitmap.Width, yPosition);
            var rect2 = new Rectangle(0, yPosition, xPosition, height);
            var rect3 = new Rectangle(0, yPosition + height, _currentBitmap.Width, _currentBitmap.Height);
            var rect4 = new Rectangle(xPosition + width, yPosition, _currentBitmap.Width - xPosition - width, height);
            gr.FillRectangle(cBrush, rect1);
            gr.FillRectangle(cBrush, rect2);
            gr.FillRectangle(cBrush, rect3);
            gr.FillRectangle(cBrush, rect4);
            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void RemoveCropAreaDraw()
        {
            _currentBitmap = (Bitmap) _bitmapPrevCropArea.Clone();
        }

        public void HistogramScalling(int a, int b, int c, int d)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            Color color;

            for (var i = 0; i < bmap.Width; i++)
            {
                for (var j = 0; j < bmap.Height; j++)
                {
                    color = bmap.GetPixel(i, j);
                    double cR = color.R;
                    double cG = color.G;
                    double cB = color.B;

                    double rest = (((double) d - (double) c) / ((double) b - (double) a));

                    double setR = (cR - a) * rest + (double) c;
                    double setG = (cG - a) * rest + (double) c;
                    double setB = (cB - a) * rest + (double) c;

                    if (setR > 255) setR = 255;
                    if (setR < 0) setR = 0;
                    if (setG > 255) setG = 255;
                    if (setG < 0) setG = 0;
                    if (setB > 255) setB = 255;
                    if (setB < 0) setB = 0;

                    bmap.SetPixel(i, j, Color.FromArgb((int) setR, (int) setG, (int) setB));

                }
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void Rotate(Bitmap image, float angle)
        {
            if (image == null)
                throw new ArgumentNullException("image");

            const double pi2 = Math.PI / 2.0;

            double oldWidth = (double) image.Width;
            double oldHeight = (double) image.Height;

            double theta = ((double) angle) * Math.PI / 180.0;
            double locked_theta = theta;

            while (locked_theta < 0.0)
                locked_theta += 2 * Math.PI;

            double newWidth, newHeight;
            int nWidth, nHeight;

            double adjacentTop, oppositeTop;
            double adjacentBottom, oppositeBottom;

            if ((locked_theta >= 0.0 && locked_theta < pi2) ||
                (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2)))
            {
                adjacentTop = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
                oppositeTop = Math.Abs(Math.Sin(locked_theta)) * oldWidth;

                adjacentBottom = Math.Abs(Math.Cos(locked_theta)) * oldHeight;
                oppositeBottom = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
            }
            else
            {
                adjacentTop = Math.Abs(Math.Sin(locked_theta)) * oldHeight;
                oppositeTop = Math.Abs(Math.Cos(locked_theta)) * oldHeight;

                adjacentBottom = Math.Abs(Math.Sin(locked_theta)) * oldWidth;
                oppositeBottom = Math.Abs(Math.Cos(locked_theta)) * oldWidth;
            }

            newWidth = adjacentTop + oppositeBottom;
            newHeight = adjacentBottom + oppositeTop;

            nWidth = (int) Math.Ceiling(newWidth);
            nHeight = (int) Math.Ceiling(newHeight);

            Bitmap rotatedBmp = new Bitmap(nWidth, nHeight);

            using (Graphics g = Graphics.FromImage(rotatedBmp))
            {
                Point[] points;
                if (locked_theta >= 0.0 && locked_theta < pi2)
                {
                    points = new Point[]
                    {
                        new Point((int) oppositeBottom, 0),
                        new Point(nWidth, (int) oppositeTop),
                        new Point(0, (int) adjacentBottom)
                    };

                }
                else if (locked_theta >= pi2 && locked_theta < Math.PI)
                {
                    points = new Point[]
                    {
                        new Point(nWidth, (int) oppositeTop),
                        new Point((int) adjacentTop, nHeight),
                        new Point((int) oppositeBottom, 0)
                    };
                }
                else if (locked_theta >= Math.PI && locked_theta < (Math.PI + pi2))
                {
                    points = new Point[]
                    {
                        new Point((int) adjacentTop, nHeight),
                        new Point(0, (int) adjacentBottom),
                        new Point(nWidth, (int) oppositeTop)
                    };
                }
                else
                {
                    points = new Point[]
                    {
                        new Point(0, (int) adjacentBottom),
                        new Point((int) oppositeBottom, 0),
                        new Point((int) adjacentTop, nHeight)
                    };
                }

                g.DrawImage(image, points);
            }


            _currentBitmap = rotatedBmp;
        }

        public void Rozmycie(int amount)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();
            int avgR;
            int avgG;
            int avgB;
            for (int x = 0; x < bmap.Width - 1; x++)
            {
                for (int y = 0; y < bmap.Height - 1; y++)
                {
                    try
                    {
                        Color a = temp.GetPixel(x - amount, y - amount);
                        Color b = temp.GetPixel(x, y - amount);
                        Color c = temp.GetPixel(x + amount, y - amount);

                        Color d = temp.GetPixel(x - amount, y);
                        Color x1 = temp.GetPixel(x, y);
                        Color f = temp.GetPixel(x + amount, y);

                        Color g = temp.GetPixel(x - amount, y + amount);
                        Color h = temp.GetPixel(x, y + amount);
                        Color i = temp.GetPixel(x + amount, y + amount);

                        avgR = (a.R + b.R + c.R + d.R + x1.R + f.R + g.R + h.R + i.R) / 9;
                        avgG = (a.G + b.G + c.G + d.G + x1.G + f.G + g.G + h.G + i.G) / 9;
                        avgB = (a.B + b.B + c.B + d.B + x1.B + f.B + g.B + h.B + i.B) / 9;
                        bmap.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));

                    }

                    catch
                    {
                    }
                }
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void Pochylenie(int a, int b)
        {
            var temp = _currentBitmap;
            var bmap = new Bitmap(temp.Width, temp.Height);
            int x0 = temp.Width / 2;
            int y0 = temp.Height / 2;
            Color pixel;

            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    int x = x0 + (i - x0) + (j - y0) * a;
                    int y = y0 + (j - y0) + (i - x0) * b;

                    if (x >= bmap.Width || x < 0 || y >= bmap.Height || y < 0) continue;

                    pixel = temp.GetPixel(x, y);
                    bmap.SetPixel(i, j, pixel);
                }
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void Interpolate(int width, int height, InterpolationMode mode)
        {
            var temp = _currentBitmap;
            var destRect = new Rectangle(0, 0, width, height);
            var bmap = new Bitmap(width, height);

            bmap.SetResolution(temp.HorizontalResolution, temp.VerticalResolution);

            using (var graphics = Graphics.FromImage(bmap))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.Default;
                graphics.InterpolationMode = mode;
                graphics.SmoothingMode = SmoothingMode.None;
                graphics.PixelOffsetMode = PixelOffsetMode.None;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(temp, destRect, 0, 0, temp.Width, temp.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void Masks(int[,] mask)
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();

            for (var i = 1; i < bmap.Width - 1; i++)
            {
                for (var j = 1; j < bmap.Height - 1; j++)
                {
                    var lg = temp.GetPixel(i - 1, j - 1);
                    var sg = temp.GetPixel(i - 1, j);
                    var pg = temp.GetPixel(i - 1, j + 1);
                    var ll = temp.GetPixel(i, j - 1);
                    var ss = temp.GetPixel(i, j);
                    var pp = temp.GetPixel(i, j + 1);
                    var ld = temp.GetPixel(i + 1, j - 1);
                    var sd = temp.GetPixel(i + 1, j);
                    var pd = temp.GetPixel(i + 1, j + 1);

                    double[,] tab =
                    {
                        {lg.R * mask[0, 0], lg.G * mask[0, 0], lg.B * mask[0, 0]},
                        {sg.R * mask[0, 1], sg.G * mask[0, 1], sg.B * mask[0, 1]},
                        {pg.R * mask[0, 2], pg.G * mask[0, 2], pg.B * mask[0, 2]},
                        {ll.R * mask[1, 0], ll.G * mask[1, 0], ll.B * mask[1, 0]},
                        {ss.R * mask[1, 1], ss.G * mask[1, 1], ss.B * mask[1, 1]},
                        {pp.R * mask[1, 2], pp.G * mask[1, 2], pp.B * mask[1, 2]},
                        {ld.R * mask[2, 0], ld.G * mask[2, 0], ld.B * mask[2, 0]},
                        {sd.R * mask[2, 1], sd.G * mask[2, 1], sd.B * mask[2, 1]},
                        {pd.R * mask[2, 2], pd.G * mask[2, 2], pd.B * mask[2, 2]}
                    };

                    double sumR = 0, sumG = 0, sumB = 0;

                    for (int ii = 0; ii < tab.GetLength(0); ii++)
                    {
                        sumR += tab[ii, 0];
                        sumG += tab[ii, 1];
                        sumB += tab[ii, 2];
                    }

                    if (sumR > 255) sumR = 255;
                    if (sumR < 0) sumR = 0;

                    if (sumG > 255) sumG = 255;
                    if (sumG < 0) sumG = 0;

                    if (sumB > 255) sumB = 255;
                    if (sumB < 0) sumB = 0;


                    bmap.SetPixel(i, j, Color.FromArgb((int) sumR, (int) sumG, (int) sumB));
                }
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void LaplaceSharp()
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap)temp.Clone();
            var before = (Bitmap)Image.FromFile(BitmapPath);

            for (int i = 1; i < bmap.Width - 1; i++)
            {
                for (int j = 1; j < bmap.Height - 1; j++)
                {
                    var color1 = before.GetPixel(i, j);
                    var color2 = bmap.GetPixel(i, j);

                    var sumR = color1.R + color2.R;
                    var sumG = color1.G + color2.G;
                    var sumB = color1.B + color2.B;

                    if (sumR > 255) sumR = 255;
                    if (sumR < 0) sumR = 0;

                    if (sumG > 255) sumG = 255;
                    if (sumG < 0) sumG = 0;

                    if (sumB > 255) sumB = 255;
                    if (sumB < 0) sumB = 0;

                    bmap.SetPixel(i,j,Color.FromArgb(sumR, sumG, sumB));
                }
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void Minimum()
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap)temp.Clone();

            for (int i = 1; i < bmap.Width - 1; i++)
            {
                for (int j = 1; j < bmap.Height - 1; j++)
                {
                    var lg = temp.GetPixel(i - 1, j - 1);
                    var sg = temp.GetPixel(i - 1, j);
                    var pg = temp.GetPixel(i - 1, j + 1);
                    var ll = temp.GetPixel(i, j - 1);
                    var ss = temp.GetPixel(i, j);
                    var pp = temp.GetPixel(i, j + 1);
                    var ld = temp.GetPixel(i + 1, j - 1);
                    var sd = temp.GetPixel(i + 1, j);
                    var pd = temp.GetPixel(i + 1, j + 1);

                    double[] reds = new double[]
                    {
                        lg.R, sg.R, pg.R, ll.R, ss.R, pp.R, ld.R, sd.R, pd.R
                    };
                    double[] greens = new double[]
                    {
                        lg.G, sg.G, pg.G, ll.G, ss.G, pp.G, ld.G, sd.G, pd.G
                    };
                    double[] blues = new double[]
                    {
                        lg.B, sg.B, pg.B, ll.B, ss.B, pp.B, ld.B, sd.B, pd.B
                    };

                    Array.Sort(reds);
                    Array.Sort(greens);
                    Array.Sort(blues);

                    bmap.SetPixel(i,j, Color.FromArgb((int) reds[0], (int) greens[0], (int) blues[0]));
                }
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void Maximum()
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap)temp.Clone();

            for (int i = 1; i < bmap.Width - 1; i++)
            {
                for (int j = 1; j < bmap.Height - 1; j++)
                {
                    var lg = temp.GetPixel(i - 1, j - 1);
                    var sg = temp.GetPixel(i - 1, j);
                    var pg = temp.GetPixel(i - 1, j + 1);
                    var ll = temp.GetPixel(i, j - 1);
                    var ss = temp.GetPixel(i, j);
                    var pp = temp.GetPixel(i, j + 1);
                    var ld = temp.GetPixel(i + 1, j - 1);
                    var sd = temp.GetPixel(i + 1, j);
                    var pd = temp.GetPixel(i + 1, j + 1);

                    double[] reds = new double[]
                    {
                        lg.R, sg.R, pg.R, ll.R, ss.R, pp.R, ld.R, sd.R, pd.R
                    };
                    double[] greens = new double[]
                    {
                        lg.G, sg.G, pg.G, ll.G, ss.G, pp.G, ld.G, sd.G, pd.G
                    };
                    double[] blues = new double[]
                    {
                        lg.B, sg.B, pg.B, ll.B, ss.B, pp.B, ld.B, sd.B, pd.B
                    };

                    Array.Sort(reds);
                    Array.Sort(greens);
                    Array.Sort(blues);

                    Array.Reverse(reds);
                    Array.Reverse(greens);
                    Array.Reverse(blues);


                    bmap.SetPixel(i, j, Color.FromArgb((int)reds[0], (int)greens[0], (int)blues[0]));
                }
            }

            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void MedianowyN1()
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap)temp.Clone();

            for (int i = 1; i < bmap.Width - 1; i++)
            {
                for (int j = 1; j < bmap.Height - 1; j++)
                {
                    var lg = temp.GetPixel(i - 1, j - 1);
                    var sg = temp.GetPixel(i - 1, j);
                    var pg = temp.GetPixel(i - 1, j + 1);
                    var ll = temp.GetPixel(i, j - 1);
                    var ss = temp.GetPixel(i, j);
                    var pp = temp.GetPixel(i, j + 1);
                    var ld = temp.GetPixel(i + 1, j - 1);
                    var sd = temp.GetPixel(i + 1, j);
                    var pd = temp.GetPixel(i + 1, j + 1);

                    double[] reds = new double[]
                    {
                        lg.R, sg.R, pg.R, ll.R, ss.R, pp.R, ld.R, sd.R, pd.R
                    };
                    double[] greens = new double[]
                    {
                        lg.G, sg.G, pg.G, ll.G, ss.G, pp.G, ld.G, sd.G, pd.G
                    };
                    double[] blues = new double[]
                    {
                        lg.B, sg.B, pg.B, ll.B, ss.B, pp.B, ld.B, sd.B, pd.B
                    };

                    Array.Sort(reds);
                    Array.Sort(greens);
                    Array.Sort(blues);

                    int sizeRed = reds.Length;
                    int sizeGreen = greens.Length;
                    int sizeBlue = blues.Length;
                    int mid = sizeRed / 2;

                    double medianRed = (sizeRed % 2 == 0) ? reds[mid] : (reds[mid - 1] + reds[mid]) / 2;
                    double medianGreen = (sizeGreen % 2 == 0) ? greens[mid] : (greens[mid - 1] + greens[mid]) / 2;
                    double medianBlue = (sizeBlue % 2 == 0) ? blues[mid] : (blues[mid - 1] + blues[mid]) / 2;


                    bmap.SetPixel(i, j, Color.FromArgb((int)medianRed, (int)medianGreen, (int)medianBlue));
                }
            }

            _currentBitmap = (Bitmap)bmap.Clone();
        }

        public void MedianowyN2()
        {
            var temp = _currentBitmap;
            var bmap = (Bitmap) temp.Clone();

            for (int i = 2; i < bmap.Width - 2; i++)
            {
                for (int j = 2; j < bmap.Height - 2; j++)
                {
                    #region n=1

                    var lg = temp.GetPixel(i - 1, j - 1);
                    var sg = temp.GetPixel(i - 1, j);
                    var pg = temp.GetPixel(i - 1, j + 1);
                    var ll = temp.GetPixel(i, j - 1);
                    var ss = temp.GetPixel(i, j);
                    var pp = temp.GetPixel(i, j + 1);
                    var ld = temp.GetPixel(i + 1, j - 1);
                    var sd = temp.GetPixel(i + 1, j);
                    var pd = temp.GetPixel(i + 1, j + 1);

                    #endregion

                    #region n=2

                    var llgg = temp.GetPixel(i - 2, j - 2);
                    var llg = temp.GetPixel(i - 1, j - 2);
                    var lll = temp.GetPixel(i, j - 2);
                    var lld = temp.GetPixel(i + 1, j - 2);
                    var lldd = temp.GetPixel(i + 2, j - 2);
                    var ldd = temp.GetPixel(i + 2, j - 1);
                    var dd = temp.GetPixel(i + 2, j);
                    var pdd = temp.GetPixel(i + 2, j + 1);
                    var ppdd = temp.GetPixel(i + 2, j + 2);
                    var ppd = temp.GetPixel(i + 1, j + 2);
                    var ppp = temp.GetPixel(i, j + 2);
                    var ppg = temp.GetPixel(i - 1, j + 2);
                    var ppgg = temp.GetPixel(i - 2, j + 2);
                    var pgg = temp.GetPixel(i - 2, j + 1);
                    var ggg = temp.GetPixel(i - 2, j);
                    var lgg = temp.GetPixel(i - 2, j - 1);
                        
                    #endregion


                    double[] reds = new double[]
                    {
                        lg.R, sg.R, pg.R, ll.R, ss.R, pp.R, ld.R, sd.R, pd.R, llgg.R, llg.R, lll.R, lld.R, lldd.R, ldd.R, dd.R, pdd.R, ppdd.R, ppd.R, ppp.R, ppg.R, ppgg.R, pgg.R, ggg.R, lgg.R
                    };
                    double[] greens = new double[]
                    {
                        lg.G, sg.G, pg.G, ll.G, ss.G, pp.G, ld.G, sd.G, pd.G, lgg.G, llg.G, lll.G, lld.G, lldd.G, ldd.G, dd.G, pdd.G, ppdd.G, ppd.G, ppp.G, ppg.G, ppgg.G, pgg.G, ggg.G, lgg.G
                    };
                    double[] blues = new double[]
                    {
                        lg.B, sg.B, pg.B, ll.B, ss.B, pp.B, ld.B, sd.B, pd.B, lgg.B, llg.B, lll.B, lld.B, lldd.B, ldd.B, dd.B, pdd.B, ppdd.B, ppd.B, ppp.B, ppg.B, ppgg.B, pgg.B, ggg.B, lgg.B
                    };

                    Array.Sort(reds);
                    Array.Sort(greens);
                    Array.Sort(blues);

                    int sizeRed = reds.Length;
                    int sizeGreen = greens.Length;
                    int sizeBlue = blues.Length;
                    int mid = sizeRed / 2;

                    double medianRed = (sizeRed % 2 == 0) ? reds[mid] : (reds[mid - 1] + reds[mid]) / 2;
                    double medianGreen = (sizeGreen % 2 == 0) ? greens[mid] : (greens[mid - 1] + greens[mid]) / 2;
                    double medianBlue = (sizeBlue % 2 == 0) ? blues[mid] : (blues[mid - 1] + blues[mid]) / 2;


                    bmap.SetPixel(i, j, Color.FromArgb((int) medianRed, (int) medianGreen, (int) medianBlue));
                }
            }

            _currentBitmap = (Bitmap) bmap.Clone();
        }

        public void Bezier(PaintEventArgs e)
        {
            /*Graphics g = e.Graphics;
            BezierCurve bc = new BezierCurve();
            const int POINTS_ON_CURVE = 1000;

            double[] ptind = new double[punkty.Count];
            double[] p = new double[POINTS_ON_CURVE];
            punkty.CopyTo(ptind, 0);

            bc.Bezier2D(ptind, (POINTS_ON_CURVE) / 2, p);

            //pictureBox1.Refresh();
            // draw points
            for (int i = 1; i != POINTS_ON_CURVE - 1; i += 2)
            {
                g.DrawRectangle(Pens.Red, new Rectangle((int)p[i + 1], (int)p[i], 1, 1));
                g.Flush();
                Application.DoEvents();
            }*/

            BezierCurve bc = new BezierCurve();
            Point[] pp =
            {
                new Point(25,424),
                new Point(23,438),
                new Point(207,133),
                new Point(5,87),
                new Point(209,44),
                new Point(349,102),
                new Point(444,141),
                new Point(252,157),
                new Point(361,239),
                new Point(377,251),
                new Point(187,172),
                new Point(143,246),
                new Point(121,283),
                new Point(213,383),
                new Point(336,397),
                new Point(351,399),
                new Point(260,408),
                new Point(245,411),
                new Point(126,318),
                new Point(125,303),
                new Point(124,288),
                new Point(66,372),
                new Point(129,414),
                new Point(141,422),
                new Point(41,435),
                new Point(25,424),
            };

            Point[] pp2 =
            {
                new Point(138, 112),
                new Point(123, 112), 
                new Point(157, 75), 
                new Point(267, 114), 
                new Point(329, 136), 
                new Point(246, 156), 
                new Point(284, 188), 
                new Point(299, 201), 
                new Point(183, 151), 
                new Point(156, 194), 
                new Point(147, 209), 
                new Point(187, 109), 
                new Point(138, 112), 
            };

            Point[] pp3 =
            {
                new Point(415, 100),
                new Point(479, 173),
                new Point(360, 322),
                new Point(413, 407),
                new Point(425, 426),
                new Point(528, 226),
                new Point(539, 327),
                new Point(551, 392),
                new Point(699, 411),
                new Point(683, 398),
                new Point(566, 303),
                new Point(752, 158),
                new Point(669, 103),
                new Point(651, 91),
                new Point(607, 87),
                new Point(619, 95),
                new Point(703, 151),
                new Point(623, 256),
                new Point(622, 279),
                new Point(621, 314),
                new Point(600, 337),
                new Point(541, 248),
                new Point(515, 209),
                new Point(474, 322),
                new Point(463, 307),
                new Point(407, 228),
                new Point(522, 76),
                new Point(485, 96),
                new Point(445, 118),
                new Point(430, 103),
                new Point(415, 100),
            };

            bc.drawMyBezier(e, pp);
            bc.drawMyBezier(e, pp2);
            bc.drawMyBezier(e, pp3);

            
        }

        public void Load(List<double> punkty, string path)
        {
            int counter = 0;
            string line = "";
            StreamReader sr = new StreamReader(path);
            while ((line = sr.ReadLine()) != null)
            {
                String[] fragments = line.Split(' ');
                if (fragments.Length != 1)
                {
                    for (int i = 0; i < fragments.Length; i++)
                    {
                        
                        punkty.Add(Convert.ToDouble(fragments[i]));
                    }
                }
            }
        }

        public void BezierSurfaces(PaintEventArgs e)
        {
            
        }
    }

}