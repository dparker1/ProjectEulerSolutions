using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems.Structures
{
    public class Vector3
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }

        public static readonly Vector3 ZERO = new Vector3(0, 0, 0);

        public Vector3(long x, long y, long z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector3(long x, long y) : this(x, y, 0) { }

        public Vector3() : this(0, 0, 0) { }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public long Dot(Vector3 b)
        {
            return (this.X * b.X) + (this.Y * b.Y) + (this.Z * b.Z);
        }

        public Vector3 Cross(Vector3 b)
        {
            return new Vector3((this.Y * b.Z) - (b.Y * this.Z), -(this.X * b.Z) + (b.X * this.Z), (this.X * b.Y) - (b.X * this.Y));
        }

        public override string ToString()
        {
            return "(" + this.X + ", " + this.Y + ", " + this.Z + ")";
        }
    }
}
