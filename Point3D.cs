using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lr2
{
    internal class Point3D
    {
        private float x;
        private float y;
        private float z;
        public float X
        {
            get => x;
            set => x = value;
        }
        public float Y
        {
            get => y;
            set => y = value;
        }
        public float Z
        {
            get => z;
            set => z = value;
        }

        public Point3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Point3D(Point3D inp)
        {
            this.x = inp.X;
            this.y = inp.Y;
            this.z = inp.Z;
        }

    }
}
