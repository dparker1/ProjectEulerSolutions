using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ProjectEulerProblems.Structures;

namespace ProjectEulerProblems
{
    public class Problem102
    {
        public static int Solve()
        {
            int count = 0;
            string[] text = File.ReadAllLines(@"..\..\txt\Problem102Text.txt");
            foreach(string line in text)
            {
                int[] points = Array.ConvertAll(line.Split(','), x => int.Parse(x));
                Vector3[] triangle = new Vector3[3];
                triangle[0] = new Vector3(points[0], points[1]);
                triangle[1] = new Vector3(points[2], points[3]);
                triangle[2] = new Vector3(points[4], points[5]);
                if(InsideTriangle(triangle, Vector3.ZERO))
                {
                    count++;
                }
            }

            return count;
        }

        public static bool InsideTriangle(Vector3[] triangle, Vector3 point)
        {
            if(SameSide(triangle[0], triangle[1], triangle[2], point)
                && SameSide(triangle[2], triangle[0], triangle[1], point)
                && SameSide(triangle[1], triangle[2], triangle[0], point))
            {
                return true;
            }
            return false;
        }

        public static bool SameSide(Vector3 a, Vector3 b, Vector3 p1, Vector3 p2)
        {
            Vector3 cross1 = (b - a).Cross(p1 - a);
            Vector3 cross2 = (b - a).Cross(p2 - a);
            if(cross1.Dot(cross2) >= 0)
            {
                return true;
            }
            return false;

        }
    }
}
