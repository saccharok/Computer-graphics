using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cg_lr2
{
    public partial class Form1 : Form
    {
        private List<Figure> figures;
        private float windowSize = 512;
        private Dictionary<int, Brush> brushes;
        private int beforeWarnock = 1; // 1 - вызов без запуска алгоритма, 0 - непосредственный запуск
        private int color;

        public Form1()
        {
            InitializeComponent();
            figures = new List<Figure>();
            brushes = new Dictionary<int, Brush>();
            brushes.Add(0, Brushes.Black);
            brushes.Add(1, Brushes.Blue);
            brushes.Add(2, Brushes.Green);
            brushes.Add(3, Brushes.DarkCyan);
            brushes.Add(4, Brushes.Red);
            brushes.Add(5, Brushes.DarkMagenta);
            brushes.Add(6, Brushes.Goldenrod);
            color = 0;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\.."));
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    figures.Add(new Figure(filePath, color));
                    color = color + 1;
                    picture.Refresh();
                    picture.CreateGraphics();
                }
            }
        }

        private (float a, float b) getCoordsPointFor2DFigure(Point3D point)
        {
            return (point.X, -point.Y);
        }

        private void drawObject(object sender, PaintEventArgs e, Figure obj)
        {
            float a, b, c, d;
            foreach (var edge in obj.Ridge)
            {
                (a, b) = getCoordsPointFor2DFigure(edge.P1);
                (c, d) = getCoordsPointFor2DFigure(edge.P2);
                e.Graphics.DrawLine(new Pen(Color.Black, 1), a, b, c, d);
            }
        }

        private void picture_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(10.0F, float.Parse((picture.ClientSize.Height - 10).ToString()));
            // оси рисуем
            e.Graphics.DrawLine(new Pen(Color.Red, 1), windowSize, 0, 0, 0);
            e.Graphics.DrawLine(new Pen(Color.Red, 1), 0, -windowSize, 0, 0);

            if (beforeWarnock == 1)
            {
                if (figures.Count != 0)
                    foreach (var figure in figures)
                        drawObject(sender, e, figure);
            }
            else if (beforeWarnock == 0)
            {
                Console.WriteLine("Warnock algorithm running");
                WarnockAlgorithm(sender, e, 0.0F, windowSize, 0.0F, windowSize);
                Console.WriteLine("Warnock algorithm executed");
            }
        }

        private bool crossingNumber(Figure figure, float x, float y)
        {
            // Функция определяет количество пересечений с полигоном
            // https://stackoverflow.com/questions/27589796/check-point-within-polygon

            int crosNum = 0, i = 0; // crosNum - число-счетчик пересечений
            List<Point3D> points = figure.Points;
            do
            {

                int next = (i + 1) % points.Count;
                if (((points[i].Y <= y) && (points[next].Y > y)) ||
                    ((points[i].Y > y) && (points[next].Y <= y)))
                {
                    float vt = (y - points[i].Y) / (points[next].Y - points[i].Y);
                    if (x < points[i].X + vt * (points[next].X - points[i].X)) crosNum++;
                }
                i = next;

            } while (i != 0);

            // 0 - если четный (не входит), 1 - если нечетный (входит)
            return (crosNum & 1) != 0;
        }

        private bool onSegment(Point3D p, Point3D q, Point3D r)
        {
            // Функция поиска пересечения между двумя отрезками
            // https://www.youtube.com/watch?v=bbTqI0oqL5U&t=596s&ab_channel=TECHDOSE

            if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
                q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
                return true;

            return false;
        }

        private int orientation(Point3D p, Point3D q, Point3D r)
        {
            // Функция поиска ориентации упорядоченного триплета (p, q, r)
            // Если p, q, r коллинеарные, то возвращаем 0
            // Если по часовой стрелке - 1
            // Против часовой - 2
            // https://www.geeksforgeeks.org/orientation-3-ordered-points/ 

            int val = int.Parse(((q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y)).ToString());

            if (val == 0) return 0;     // колиниарны
            return (val > 0) ? 1 : 2;   // по часовой или против часовой стрелки
        }

        private bool doIntersect(Point3D p1, Point3D q1, Point3D p2, Point3D q2)
        {
            // Основная функция, которая возращает true, если отрезок p1q1 и отрезок p2q2 пересекаются

            int o1 = orientation(p1, q1, p2);
            int o2 = orientation(p1, q1, q2);
            int o3 = orientation(p2, q2, p1);
            int o4 = orientation(p2, q2, q1);

            if (o1 != o2 && o3 != o4)
                return true;
            // p1, q1 и p2 явл коллинеар, а p2 лежит на p1q1
            if (o1 == 0 && onSegment(p1, p2, q1)) return true;

            if (o2 == 0 && onSegment(p1, q2, q1)) return true;

            if (o3 == 0 && onSegment(p2, p1, q2)) return true;

            if (o4 == 0 && onSegment(p2, q1, q2)) return true;

            return false;
        }

        private float getDeepPixel(Figure poly, float x, float y)
        {
            List<Point3D> points = poly.Points;
            float det1, det2, det3;
            det1 = (points[1].Y - points[0].Y) * (points[2].Z - points[0].Z) - ((points[1].Z - points[0].Z) * (points[2].Y - points[0].Y));
            det2 = (points[1].X - points[0].X) * (points[2].Z - points[0].Z) - ((points[1].Z - points[0].Z) * (points[2].X - points[0].X));
            det3 = (points[1].X - points[0].X) * (points[2].Y - points[0].Y) - ((points[1].Y - points[0].Y) * (points[2].X - points[0].X));

            float A = det1, B = -det2, C = det3, D = (-points[0].X * det1 + points[0].Y * det2 - points[0].Z * det3);
            return -(A * x + B * y + D) / C;
        }

        public void WarnockAlgorithm(object sender, PaintEventArgs e, float leftX, float rightX, float topY, float bottomY)
        {
            Func<Figure, bool> onScreen = triangle =>
            {
                if (crossingNumber(triangle, leftX, topY)) return true;
                if (crossingNumber(triangle, rightX, topY)) return true;
                if (crossingNumber(triangle, leftX, bottomY)) return true;
                if (crossingNumber(triangle, rightX, bottomY)) return true;
                int _i;
                for (_i = 0; _i < triangle.Points.Count; _i++)
                    if (triangle.Points[_i].X >= leftX && triangle.Points[_i].X <= rightX &&
                        triangle.Points[_i].Y >= topY && triangle.Points[_i].Y <= bottomY)
                        return true;

                _i = 0;
                Point3D p1 = new Point3D(leftX, topY, 0.0F);
                Point3D p2 = new Point3D(rightX, topY, 0.0F);
                Point3D p3 = new Point3D(leftX, bottomY, 0.0F);
                Point3D p4 = new Point3D(rightX, bottomY, 0.0F);
                do
                {
                    int next = (_i + 1) % triangle.Points.Count;

                    if (doIntersect(triangle.Points[_i], triangle.Points[next], p1, p2)) return true;
                    if (doIntersect(triangle.Points[_i], triangle.Points[next], p1, p3)) return true;
                    if (doIntersect(triangle.Points[_i], triangle.Points[next], p2, p4)) return true;
                    if (doIntersect(triangle.Points[_i], triangle.Points[next], p3, p4)) return true;

                    _i = next;

                } while (_i != 0);

                return false;
            };

            List<Figure> tempTriangles = new List<Figure>();
            foreach (var tri in this.figures)
            {
                if (onScreen(tri)) tempTriangles.Add(tri);
            }

            if (tempTriangles.Count == 0) return;
            else if (tempTriangles.Count > 0)
            {
                if (((rightX - leftX) > 1.0F) && ((bottomY - topY) > 1.0F))
                {
                    float dx = (rightX - leftX) / 2;
                    float dy = (bottomY - topY) / 2;

                    // Верхний левый
                    WarnockAlgorithm(sender, e, leftX, leftX + dx, topY, topY + dy);
                    // Верхний правый
                    WarnockAlgorithm(sender, e, leftX + dx, rightX, topY, topY + dy);
                    // Нижний левый
                    WarnockAlgorithm(sender, e, leftX, leftX + dx, topY + dy, bottomY);
                    // Нижний правый
                    WarnockAlgorithm(sender, e, leftX + dx, rightX, topY + dy, bottomY);
                }
                else
                {
                    // Только 1 пиксель - заполняем его
                    List<float> z = new List<float>();
                    List<int> colors = new List<int>();
                    foreach (var figure in tempTriangles)
                    {
                        z.Add(getDeepPixel(figure, leftX, topY));
                        colors.Add(figure.Color);
                    }
                    float maximum = z[0];
                    for (int i = 1; i < z.Count; i++)
                        if (maximum < z[i]) maximum = z[i];
                    int index = z.IndexOf(maximum);
                    e.Graphics.FillRectangle(brushes[colors[index]],
                            leftX, -topY, (rightX - leftX), (bottomY - topY));
                }
            }
        }

        private void buttonWarnok_Click(object sender, EventArgs e)
        {
            beforeWarnock = 0;
            picture.Refresh();
            picture.CreateGraphics();
            figures.Clear();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            beforeWarnock = 1;
            figures.Clear();
            this.figures.Clear();
            picture.Refresh();
            picture.CreateGraphics();
        }
    }
}
