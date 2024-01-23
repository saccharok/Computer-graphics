using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace cg_lr2
{
    internal class Figure
    {
        private List<Edge> ridge;
        private List<Point3D> points;
        private int color;

        private List<Edge> copyRidge;
        private float[][] matrix;

        public List<Edge> Ridge => ridge;
        public List<Point3D> Points => points;
        public int Color => color;

        public Figure(string fileLoad, int _color)
        {
            ridge = new List<Edge>();
            copyRidge = new List<Edge>();
            points = new List<Point3D>();
            fillListEdge(fileLoad);
            this.color = _color;
            foreach (var elem in ridge)
                copyRidge.Add(new Edge(new Point3D(elem.P1), new Point3D(elem.P2)));

            matrix = new float[4][];
            for (int i = 0; i < 4; i++)
                matrix[i] = new float[4];
        }

        private void fillListEdge(string fileLoad)
        {
            using (StreamReader srs = new StreamReader(fileLoad))
            {
                string line;

                while ((line = srs.ReadLine()) != null)
                {
                    string[] readData = line.Split();
                    float x1 = float.Parse(readData[0], System.Globalization.NumberStyles.Float);
                    float y1 = float.Parse(readData[1], System.Globalization.NumberStyles.Float);
                    float z1 = float.Parse(readData[2], System.Globalization.NumberStyles.Float);

                    float x2 = float.Parse(readData[3], System.Globalization.NumberStyles.Float);
                    float y2 = float.Parse(readData[4], System.Globalization.NumberStyles.Float);
                    float z2 = float.Parse(readData[5], System.Globalization.NumberStyles.Float);

                    this.points.Add(new Point3D(x1, y1, z1));
                    this.ridge.Add(new Edge(new Point3D(x1, y1, z1), new Point3D(x2, y2, z2)));
                }
            }
        }
        private void setMatrixToZero()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matrix[i][j] = 0.0F;
        }
        private float[] mult(float[] vect, float[][] matr)
        {
            float[] result = new float[4];
            for (int i = 0; i < 4; i++) 
            {
                result[i] = 0;
                for (int j = 0; j < 4; j++)
                    result[i] += vect[j] * matr[j][i];
            }
            return result;
        }

    }
}
