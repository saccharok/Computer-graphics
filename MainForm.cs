using System;
using System.Drawing;
using System.Windows.Forms;

namespace kg_lab1
{
    public partial class MainForm : Form
    {
        private int[,] Z;
        private float[,] proection;
        private int cenX;
        private int cenY;

        private Graphics _graphics;

        public MainForm() 
            => InitializeComponent();

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            cenX = Size.Width / 2;
            cenY = Size.Height / 2;
            SetDefaultPosition();
            //центральное проецирование относительно центра правосторонней системы координат
            float[,] p =
            {
                { 1, 0, 0, 1},
                { 0, -1, 0, 1},
                { 0, 0, 1, 1},
                { cenX, cenY, 0, 1}
            };
            proection = p;
            DrawZ();
        }


        //умножение матриц
        private int[,] Mult(int[,] X, float[,] Y)
        {
            float[,] result = new float[X.GetLength(0), Y.GetLength(1)];
            for (int i = 0; i < X.GetLength(0); i++)
                for (int j = 0; j < Y.GetLength(1); j++)
                    for (int k = 0; k < Y.GetLength(0); k++)
                        result[i, j] += X[i, k] * Y[k, j];
            int[,] res = new int[result.GetLength(0), result.GetLength(1)];
            for (int i = 0; i < result.GetLength(0); i++)
                for (int j = 0; j < result.GetLength(1); j++)
                    res[i, j] = Convert.ToInt32(result[i, j]);
            return res;
        }

        private void DrawAxis()
        {
            _graphics = CreateGraphics();
            _graphics.Clear(Color.White);
            #region X
            _graphics.DrawLine(Pens.Gray, cenX, cenY, cenX + 500, cenY);
            _graphics.DrawLine(Pens.Gray, cenX + 500, cenY, cenX + 490, cenY - 10);
            _graphics.DrawLine(Pens.Gray, cenX + 500, cenY, cenX + 490, cenY + 10);
            #endregion
            #region Y
            _graphics.DrawLine(Pens.Gray, cenX, cenY, cenX, cenY - 400);
            _graphics.DrawLine(Pens.Gray, cenX, cenY - 400, cenX - 10, cenY - 390);
            _graphics.DrawLine(Pens.Gray, cenX, cenY - 400, cenX + 10, cenY - 390);
            #endregion
            #region Z
            _graphics.DrawLine(Pens.Gray, cenX, cenY, cenX - 300, cenY + 150);
            _graphics.DrawLine(Pens.Gray, cenX - 300, cenY + 150, cenX - 285, cenY + 155);
            _graphics.DrawLine(Pens.Gray, cenX - 300, cenY + 150, cenX - 300, cenY + 140);
            #endregion
        }

        private void SetDefaultPosition()
        {
            int[,] DefZ =
            {
                { 0, 0, 0, 1 },      //A - 0
                { 0, 20, 0, 1 },     //B - 1
                { 40, 60, 0, 1 },    //C - 2
                { 0, 60, 0, 1 },     //D - 3
                { 0, 80, 0, 1 },     //E - 4
                { 60, 80, 0, 1 },    //F - 5
                { 60, 60, 0, 1 },    //G - 6
                { 20, 20, 0, 1 },    //H - 7
                { 60, 20, 0, 1 },    //I - 8
                { 60, 0, 0, 1 },     //J - 9
                { 0, 0, 10, 1 },     //A' - 10
                { 0, 20, 10, 1 },    //B' - 11
                { 40, 60, 10, 1 },   //C' - 12
                { 0, 60, 10, 1 },    //D' - 13
                { 0, 80, 10, 1 },    //E' - 14
                { 60, 80, 10, 1 },   //F' - 15
                { 60, 60, 10, 1 },   //G' - 16
                { 20, 20, 10, 1 },   //H' - 17
                { 60, 20, 10, 1 },   //I' - 18
                { 60, 0, 10, 1 }     //J' - 19
            };
            Z = DefZ;
        }

        //преобразования трехмерных координат в двумерные
        private Point convertToPoint(int x, int y, int z)
        {
            Point point = new Point();
            point.X = x - 2 * z;
            point.Y = y + z;
            return point;
        }

        private void DrawZ()
        {
            _graphics = CreateGraphics();
            DrawAxis();
            int[,] matrixDraw = Mult(Z, proection);
            Point p1 = new Point();
            Point p2 = new Point();
            for (int i = 0; i < 9; i++)
            {
                p1 = convertToPoint(matrixDraw[i, 0], matrixDraw[i, 1], matrixDraw[i, 2]);
                p2 = convertToPoint(matrixDraw[i + 1, 0], matrixDraw[i + 1, 1] , matrixDraw[i + 1, 2]);
                _graphics.DrawLine(Pens.Red, p1, p2);
                p1 = convertToPoint(matrixDraw[i + 10, 0], matrixDraw[i + 10, 1] , matrixDraw[i + 10, 2]);
                p2 = convertToPoint(matrixDraw[i + 11, 0], matrixDraw[i + 11, 1] , matrixDraw[i + 11, 2]);
                _graphics.DrawLine(Pens.Red, p1, p2);
                p1 = convertToPoint(matrixDraw[i, 0], matrixDraw[i, 1] , matrixDraw[i, 2]);
                p2 = convertToPoint(matrixDraw[i + 10, 0], matrixDraw[i + 10, 1] , matrixDraw[i + 10, 2]);
                _graphics.DrawLine(Pens.Red, p1, p2);
            }
            p1 = convertToPoint(matrixDraw[0, 0], matrixDraw[0, 1] , matrixDraw[0, 2]);
            p2 = convertToPoint(matrixDraw[9, 0], matrixDraw[9, 1] , matrixDraw[9, 2]);
            _graphics.DrawLine(Pens.Red, p1, p2);
            p1 = convertToPoint(matrixDraw[10, 0], matrixDraw[10, 1] , matrixDraw[10, 2]);
            p2 = convertToPoint(matrixDraw[19, 0], matrixDraw[19, 1] , matrixDraw[19, 2]);
            _graphics.DrawLine(Pens.Red, p1, p2);
            p1 = convertToPoint(matrixDraw[9, 0], matrixDraw[9, 1] , matrixDraw[9, 2]);
            _graphics.DrawLine(Pens.Red, p1, p2);
        }

        private void buttonDeffaultPosition_Click(object sender, EventArgs e)
        {
            SetDefaultPosition();
            DrawZ();
        }

        //движение вдоль OX в положительном направлении
        private void MovePlusX_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { toMove, 0, 0, 1}
            };
            Z = Mult(Z, Move);
            DrawZ();
        }

        //движение вдоль OX в отрицательном направлении
        private void MoveMinusX_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { -toMove, 0, 0, 1}
            };
            Z = Mult(Z, Move);
            DrawZ();
        }

        //движение вдоль OY в положительном направлении
        private void MovePlusY_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, toMove, 0, 1}
            };
            Z = Mult(Z, Move);
            DrawZ();
        }

        //движение вдоль OY в отрицательном направлении
        private void MoveMinusY_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, -toMove, 0, 1}
            };
            Z = Mult(Z, Move);
            DrawZ();
        }

        //движение вдоль OZ в положительном направлении
        private void MovePlusZ_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, toMove, 1}
            };
            Z = Mult(Z, Move);
            DrawZ();
        }

        //движение вдоль OZ в отрицательном направлении
        private void MoveMinusZ_Click(object sender, EventArgs e)
        {
            int toMove = Convert.ToInt32(MoveTextBox.Text);
            float[,] Move =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, -toMove, 1}
            };
            Z = Mult(Z, Move);
            DrawZ();
        }

        //вращение вокруг OX вправо
        private void RotateRightX_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            float[,] Rotate =
            {
                { 1, 0, 0, 0},
                { 0, ((float)(Math.Cos(toRotate))), ((float)(Math.Sin(toRotate))), 0},
                { 0, -((float)(Math.Sin(toRotate))), ((float)(Math.Cos(toRotate))), 0},
                { 0, 0, 0, 1}
            };
            Z = Mult(Z, Rotate);
            DrawZ();
        }

        //вращение вокруг OX влево
        private void RotateLeftX_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            float[,] Rotate =
            {
                { 1, 0, 0, 0},
                { 0, ((float)(Math.Cos(toRotate))), -((float)(Math.Sin(toRotate))), 0},
                { 0, ((float)(Math.Sin(toRotate))), ((float)(Math.Cos(toRotate))), 0},
                { 0, 0, 0, 1}
            };
            Z = Mult(Z, Rotate);
            DrawZ();
        }

        //вращение вокруг OY вправо
        private void RotateRightY_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            float[,] Rotate =
            {
                { ((float)(Math.Cos(toRotate))), 0, ((float)(Math.Sin(toRotate))), 0},
                { 0, 1, 0, 0},
                { -((float)(Math.Sin(toRotate))), 0, ((float)(Math.Cos(toRotate))), 0},
                { 0, 0, 0, 1}
            };
            Z = Mult(Z, Rotate);
            DrawZ();
        }

        //вращение вокруг OY влево
        private void RotateLeftY_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            float[,] Rotate =
            {
                { ((float)(Math.Cos(toRotate))), 0, -((float)(Math.Sin(toRotate))), 0},
                { 0, 1, 0, 0},
                { ((float)(Math.Sin(toRotate))), 0, ((float)(Math.Cos(toRotate))), 0},
                { 0, 0, 0, 1}
            };
            Z = Mult(Z, Rotate);
            DrawZ();
        }

        //вращение вокруг OZ вправо
        private void RotateRightZ_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            float[,] Rotate =
            {
                { ((float)(Math.Cos(toRotate))), -((float)(Math.Sin(toRotate))), 0, 0},
                { ((float)(Math.Sin(toRotate))), ((float)(Math.Cos(toRotate))), 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            Z = Mult(Z, Rotate);
            DrawZ();
        }

        //вращение вокруг OZ влево
        private void RotateLeftZ_Click(object sender, EventArgs e)
        {
            int toRotate = Convert.ToInt32(RotateTextBox.Text);
            float[,] Rotate =
            {
                { ((float)(Math.Cos(toRotate))), ((float)(Math.Sin(toRotate))), 0, 0},
                { -((float)(Math.Sin(toRotate))), ((float)(Math.Cos(toRotate))), 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            Z = Mult(Z, Rotate);
            DrawZ();
        }

        //отражение относительно плоскости XY
        private void MirrorXY_Click(object sender, EventArgs e)
        {
            float[,] Mirror =
            {
                { 1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, -1, 0},
                { 0, 0, 0, 1}
            };
            Z = Mult(Z, Mirror);
            DrawZ();
        }

        //отражение относительно плоскости XZ
        private void MirrorXZ_Click(object sender, EventArgs e)
        {
            float[,] Mirror =
            {
                { 1, 0, 0, 0},
                { 0, -1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            Z = Mult(Z, Mirror);
            DrawZ();
        }

        //отражение относительно плоскости YZ
        private void MirrorYZ_Click(object sender, EventArgs e)
        {
            float[,] Mirror =
            {
                { -1, 0, 0, 0},
                { 0, 1, 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            Z = Mult(Z, Mirror);
            DrawZ();
        }

        //растяжение
        private void Stretch_Click(object sender, EventArgs e)
        {
            float[,] Stretch =
            {
                { 2, 0, 0, 0},
                { 0, 2, 0, 0},
                { 0, 0, 2, 0},
                { 0, 0, 0, 1}
            };
            Z = Mult(Z, Stretch);
            DrawZ();
        }

        //сжатие
        private void Clench_Click(object sender, EventArgs e)
        {
            float[,] Clench =
            {
                { (float)(0.5), 0, 0, 0},
                { 0, (float)(0.5), 0, 0},
                { 0, 0, (float)(0.5), 0},
                { 0, 0, 0, 1}
            };
            Z = Mult(Z, Clench);
            DrawZ();
        }

        //анимация движения по спирали вдоль OX
        private void taskOX_Click(object sender, EventArgs e)
        {
            int way = 90;
            int count = 0;
            int coef = 5;
            float[,] Spiral =
            {
                { 1, 0, 0, 0},
                { 0, ((float)(Math.Cos(25))), -((float)(Math.Sin(25))), 0},
                { 0, ((float)(Math.Sin(25))), ((float)(Math.Cos(25))), 0},
                { 2, 0, 0, 1}
            };
            Timer timer = new Timer();
            timer.Interval = 25;
            timer.Tick += new EventHandler((o, ev) =>
            {
                count++;
                Z = Mult(Z, Spiral);
                DrawZ();
                if (count % 3 == 0)
                    timer.Interval += coef;
                if (count == (way / 2)) 
                {
                    Spiral[1, 2] *= -1;
                    Spiral[2, 1] *= -1;
                    Spiral[3, 0] *= -1;
                    coef *= -1;
                }
                if (count == way)
                {
                    Timer t = o as Timer;
                    t.Stop();
                }
            });
            timer.Start();
        }

        //анимация движения по спирали вдоль OY
        private void taskOY_Click(object sender, EventArgs e)
        {
            int way = 90;
            int count = 0;
            int coef = 5;
            float[,] Spiral =
            {
                { ((float)(Math.Cos(25))), 0, -((float)(Math.Sin(25))), 0},
                { 0, 1, 0, 0},
                { ((float)(Math.Sin(25))), 0, ((float)(Math.Cos(25))), 0},
                { 0, 2, 0, 1}
            };
            Timer timer = new Timer();
            timer.Interval = 25;
            timer.Tick += new EventHandler((o, ev) =>
            {
                count++;
                Z = Mult(Z, Spiral);
                DrawZ();
                if (count % 3 == 0)
                    timer.Interval += coef;
                if (count == (way / 2))
                {
                    Spiral[0, 2] *= -1;
                    Spiral[2, 0] *= -1;
                    Spiral[3, 1] *= -1;
                    coef *= -1;
                }
                if (count == way)
                {
                    Timer t = o as Timer;
                    t.Stop();
                }
            });
            timer.Start();
        }

        //анимация движения по спирали вдоль OZ
        private void taskOZ_Click(object sender, EventArgs e)
        {
            int way = 90;
            int count = 0;
            int coef = 5;
            float[,] Spiral =
            {
                { ((float)(Math.Cos(25))), ((float)(Math.Sin(25))), 0, 0},
                { -((float)(Math.Sin(25))), ((float)(Math.Cos(25))), 0, 0},
                { 0, 0, 1, 0},
                { 0, 0, 1, 1}
            };
            Timer timer = new Timer();
            timer.Interval = 25;
            timer.Tick += new EventHandler((o, ev) =>
            {
                count++;
                Z = Mult(Z, Spiral);
                DrawZ();
                if (count % 3 == 0)
                    timer.Interval += coef;
                if (count == (way / 2))
                {
                    Spiral[0, 1] *= -1;
                    Spiral[1, 0] *= -1;
                    Spiral[3, 2] *= -1;
                    coef *= -1;
                }
                if (count == way)
                {
                    Timer t = o as Timer;
                    t.Stop();
                }
            });
            timer.Start();
        }
    }

}
