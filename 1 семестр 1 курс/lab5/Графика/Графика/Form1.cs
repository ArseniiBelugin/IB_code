using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Графика
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        Point[] pts = null;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            int[,] rect;
            int n;
            int min_x = 10000, min_y = 10000, max_x = -10000, max_y = -10000;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                n = int.Parse(sr.ReadLine());
                pts = new Point[n * 2];
                string[] line;
                for (int i = 0; i < 2 * n; i++)
                {
                    line = sr.ReadLine().Split(' ');
                    pts[i] = new Point(int.Parse(line[0]), int.Parse(line[1]));
                    if (i % 2 == 0)
                    {
                        if (min_x > pts[i].X)
                        {
                            min_x = pts[i].X;
                        }
                        if (min_y > pts[i].Y)
                        {
                            min_y = pts[i].Y;
                        }
                    }
                    else
                    {
                        if (max_x < pts[i].X)
                        {
                            max_x = pts[i].X;
                        }
                        if (max_y < pts[i].Y)
                        {
                            max_y = pts[i].Y;
                        }
                    }
                }
            }
            float width = this.Width;
            float heiget = this.Height;
            Pen blackPen = new Pen(Color.Black, 2);
            g.DrawLine(blackPen, 0, heiget / 2, width, heiget / 2); // оси X и Y
            g.DrawLine(blackPen, width / 2, 0, width / 2, heiget);
            float maxX, coef;
            maxX = pts[0].X;// коэфицент для маштабирования
            var minX = maxX;
            var maxY = pts[0].Y;
            var minY = maxY;
            foreach (Point point in pts)
            {
                minX = Math.Min(minX, point.X);
                maxX = Math.Max(maxX, point.X);
                minY = Math.Min(minY, point.Y);
                maxY = Math.Max(maxY, point.Y);
            }
            coef = Math.Min(width / (maxX - minX) / 2, heiget / (maxY - minY) / 2);
            Brush redBrush = new SolidBrush(Color.Green);
            Pen Redpen = new Pen(Color.Red);
            for (int i = 0; i < 2 * n; i++)
            {
                g.FillEllipse(redBrush, width / 2 + pts[i].X * coef, heiget / 2 - pts[i].Y * coef, 6, 6);
                if (i % 2 == 0)
                    g.DrawRectangle(Redpen, width / 2 + pts[i].X * coef, heiget / 2 - pts[i + 1].Y * coef, (pts[i + 1].X - pts[i].X) * coef, (pts[i + 1].Y - pts[i].Y) * coef);
            }
            int k = 0;
            for (int i = min_x; i < max_x; i++)
            {
                for (int j = min_y; j < max_y; j++)
                {
                    int count = 0;
                    for (int l = 0; l < 2 * n; l = l + 2)
                    {
                        if ((i >= pts[l].X && i <= pts[l + 1].X) && (j >= pts[l].Y && j <= pts[l + 1].Y))
                        {

                            count++;
                        }
                    }
                    if (count > k)
                    {
                        k = count;
                    }
                }
            }
        }
        struct Point
        {
            public int X, Y;
            public Point(int a, int b)
            {
                X = a; Y = b;
            }

        }
        private void Form1_ClientSizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
