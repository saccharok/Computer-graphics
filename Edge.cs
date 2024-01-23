using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cg_lr2
{
    internal class Edge
    {
        private Point3D p1;
        private Point3D p2;

        public Point3D P1 => p1;
        public Point3D P2 => p2;

        public Edge(Point3D p1, Point3D p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public Edge(Edge edge)
        {
            this.p1 = edge.P1;
            this.p2 = edge.P2;
        }
    }
}
