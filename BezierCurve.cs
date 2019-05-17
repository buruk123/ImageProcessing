using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageProcessing
{
    public class BezierCurve
    {
        private double[] FactorialLookup;

        public BezierCurve()
        {
            CreateFactorialTable();
        }
        public double factorial(int n)
        {
            if (n < 0) { throw new Exception("n is less than 0"); }
            if (n > 32) { throw new Exception("n is greater than 32"); }

            return FactorialLookup[n];

        }

        private void CreateFactorialTable()
        {
            double[] a = new double[33];
            a[0] = 1.0;
            a[1] = 1.0;
            a[2] = 2.0;
            a[3] = 6.0;
            a[4] = 24.0;
            a[5] = 120.0;
            a[6] = 720.0;
            a[7] = 5040.0;
            a[8] = 40320.0;
            a[9] = 362880.0;
            a[10] = 3628800.0;
            a[11] = 39916800.0;
            a[12] = 479001600.0;
            a[13] = 6227020800.0;
            a[14] = 87178291200.0;
            a[15] = 1307674368000.0;
            a[16] = 20922789888000.0;
            a[17] = 355687428096000.0;
            a[18] = 6402373705728000.0;
            a[19] = 121645100408832000.0;
            a[20] = 2432902008176640000.0;
            a[21] = 51090942171709440000.0;
            a[22] = 1124000727777607680000.0;
            a[23] = 25852016738884976640000.0;
            a[24] = 620448401733239439360000.0;
            a[25] = 15511210043330985984000000.0;
            a[26] = 403291461126605635584000000.0;
            a[27] = 10888869450418352160768000000.0;
            a[28] = 304888344611713860501504000000.0;
            a[29] = 8841761993739701954543616000000.0;
            a[30] = 265252859812191058636308480000000.0;
            a[31] = 8222838654177922817725562880000000.0;
            a[32] = 263130836933693530167218012160000000.0;
            FactorialLookup = a;
        }

        public double Ni(int n, int i)
        {
            double ni;
            double a1 = factorial(n);
            double a2 = factorial(i);
            double a3 = factorial(n - i);
            ni = a1 / (a2 * a3);
            return ni;
        }
        public double Bernstein(int n, int i, double t)
        {
            double basis;
            double ti;
            double tni;

            if (t == 0.0 && i == 0)
                ti = 1.0;
            else
                ti = Math.Pow(t, i);

            if (n == i && t == 1.0)
                tni = 1.0;
            else
                tni = Math.Pow((1 - t), (n - i));

            //Bernstein basis
            basis = Ni(n, i) * ti * tni;
            return basis;
        }

        /*public void Bezier2D(double[] b, int cpts, double[] p)
        {
            int npts = (b.Length) / 2;
            int icount, jcount;
            double step, t;

            icount = 0;
            t = 0;
            step = (double)1.0 / (cpts - 1);

            for (int i1 = 0; i1 != cpts; i1++)
            {
                if ((1.0 - t) < 5e-6)
                    t = 1.0;

                jcount = 0;
                p[icount] = 0.0;
                p[icount + 1] = 0.0;
                for (int i = 0; i != npts; i++)
                {
                    double basis = Bernstein(npts - 1, i, t);
                    p[icount] += basis * b[jcount];
                    p[icount + 1] += basis * b[jcount + 1];
                    jcount = jcount + 2;
                }

                icount += 2;
                t += step;
            }

        }*/
        public int[] Bezier(double t, Point p0, Point p1, Point p2, Point p3)
        {
            var cX = 3 * (p1.X - p0.X);
            var bX = 3 * (p2.X - p1.X) - cX;
            var aX = p3.X - p0.X - cX - bX;

            var cY = 3 * (p1.Y - p0.Y);
            var bY = 3 * (p2.Y - p1.Y - cY);
            var aY = p3.Y - p0.Y - cY - bY;

            var x = (aX * Math.Pow(t, 3)) + (bX * Math.Pow(t, 2)) + (cX * t) + p0.X;
            var y = (aY * Math.Pow(t, 3)) + (bY * Math.Pow(t, 2)) + (cY * t) + p0.Y;

            return new int[] {(int)x,(int)y};
        }

        public void drawMyBezier(PaintEventArgs e, Point[] pp)
        {
            Graphics g = e.Graphics;
            double accuracy = 0.001;

            for (double i = 0.0; i < 1.0; i += accuracy)
            {
                //Point p0 = new Point(pp[i].X, pp[i].Y);
                //Point p1 = new Point(pp[i + 1].X, pp[i + 1].Y);
                //Point p2 = new Point(pp[i + 2].X, pp[i + 2].Y);
                //Point p3 = new Point(pp[i + 3].X, pp[i + 3].Y);

                for (int j = 0; j < pp.Length - 2; j += 3)
                {
                    Point p0 = new Point(pp[j].X, pp[j].Y);
                    Point p1 = new Point(pp[j + 1].X, pp[j + 1].Y);
                    Point p2 = new Point(pp[j + 2].X, pp[j + 2].Y);
                    Point p3 = new Point(pp[j + 3].X, pp[j + 3].Y);
                    var p = Bezier(i, p0, p1, p2, p3);
                    g.DrawRectangle(Pens.Red, p[0], p[1], 1, 1);
                }
            }
            

        }
    }
}