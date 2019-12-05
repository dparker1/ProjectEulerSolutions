using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gurobi;

namespace ProjectEulerProblems
{
    public class Problem392
    {
        static double halfPi = Math.PI / 2;
        public static double Solve()
        {
            int n = 200;
            double[] x = Start(n);
            double a = 4 * Area(x);

            double[] temp = new double[3];
            double[] g = new double[n];
            Gradient(x, g);
            int dir = Direction(g);
            double p = 0;
            for(int i = 0; i < 750000; i++)
            {
                if(g[dir] < 0)
                {
                    if(dir == n - 1)
                    {
                        temp[0] = x[dir - 1];
                        temp[1] = x[dir];
                        temp[2] = halfPi;
                        p = Place(temp, x[dir], halfPi);
                    }
                    else if(dir == 0)
                    {
                        temp[0] = 0;
                        temp[1] = x[dir];
                        temp[2] = x[dir + 1];
                        p = Place(temp, x[dir], x[dir + 1]);
                    }
                    else
                    {
                        temp[0] = x[dir - 1];
                        temp[1] = x[dir];
                        temp[2] = x[dir + 1];
                        p = Place(temp, x[dir], x[dir + 1]);
                    }
                }
                else
                {
                    if(dir == n - 1)
                    {
                        temp[0] = x[dir - 1];
                        temp[1] = x[dir];
                        temp[2] = halfPi;
                        p = Place(temp, x[dir - 1], x[dir]);
                    }
                    else if(dir == 0)
                    {
                        temp[0] = 0;
                        temp[1] = x[dir];
                        temp[2] = x[dir + 1];
                        p = Place(temp, 0, x[dir]);
                    }
                    else
                    {
                        temp[0] = x[dir - 1];
                        temp[1] = x[dir];
                        temp[2] = x[dir + 1];
                        p = Place(temp, x[dir - 1], x[dir]);
                    }
                }
                x[dir] = p;
                x[n - dir - 1] = halfPi - p;
                a = 4 * Area(x);
                UpdateGradient(x, g, dir);
                UpdateGradient(x, g, n - dir - 1);
                dir = Direction(g);
            }

            return 4 * Area(x);
        }

        public static double[] Start(int n)
        {
            double[] r = new double[n];
            for(int i = 0; i < n; i++)
            {
                r[i] = halfPi * (i + 1) / (n + 1);
            }
            return r;
        }

        public static double Area(double[] angles)
        {
            double r = Math.Sin(angles[0]);
            for(int i = 1; i < angles.Length; i++)
            {
                r += (Math.Sin(angles[i]) - Math.Sin(angles[i - 1])) * Math.Cos(angles[i - 1]);
            }
            r += (1 - Math.Sin(angles.Last())) * Math.Cos(angles.Last());
            return r;
        }

        public static double ReducedArea(double[] angles, double a, double b)
        {
            return (Math.Sin(angles[1]) - a) * Math.Cos(angles[0]) + (b - Math.Sin(angles[1])) * Math.Cos(angles[1]);
        }

        public static void Gradient(double[] angles, double[] r)
        {
            int n = angles.Length;
            r[0] = Math.Cos(angles[0]) - Math.Cos(2 * angles[0]) - Math.Sin(angles[0]) * Math.Sin(angles[1]);
            for(int i = 1; i < n - 1; i++)
            {
                r[i] = Math.Cos(angles[i - 1]) * Math.Cos(angles[i]) - Math.Cos(2 * angles[i]) - Math.Sin(angles[i]) * Math.Sin(angles[i + 1]);
            }
            r[n - 1] = Math.Cos(angles[n - 2]) * Math.Cos(angles[n - 1]) - Math.Cos(2 * angles[n - 1]) - Math.Sin(angles[n - 1]);
        }

        public static void UpdateGradient(double[] angles, double[] r, int dir)
        {
            int n = angles.Length;
            if(dir == n - 1)
            {
                r[n - 1] = Math.Cos(angles[n - 2]) * Math.Cos(angles[n - 1]) - Math.Cos(2 * angles[n - 1]) - Math.Sin(angles[n - 1]);
                r[n - 2] = Math.Cos(angles[n - 3]) * Math.Cos(angles[n - 2]) - Math.Cos(2 * angles[n - 2]) - Math.Sin(angles[n - 2]) * Math.Sin(angles[n - 1]);
            }
            else if(dir == 0)
            {
                r[0] = Math.Cos(angles[0]) - Math.Cos(2 * angles[0]) - Math.Sin(angles[0]) * Math.Sin(angles[1]);
                r[1] = Math.Cos(angles[0]) * Math.Cos(angles[1]) - Math.Cos(2 * angles[1]) - Math.Sin(angles[1]) * Math.Sin(angles[2]);
            }
            else if(dir == n - 2)
            {
                r[n - 1] = Math.Cos(angles[n - 2]) * Math.Cos(angles[n - 1]) - Math.Cos(2 * angles[n - 1]) - Math.Sin(angles[n - 1]);
                r[n - 2] = Math.Cos(angles[n - 3]) * Math.Cos(angles[n - 2]) - Math.Cos(2 * angles[n - 2]) - Math.Sin(angles[n - 2]) * Math.Sin(angles[n - 1]);
                r[n - 3] = Math.Cos(angles[n - 4]) * Math.Cos(angles[n - 3]) - Math.Cos(2 * angles[n - 3]) - Math.Sin(angles[n - 3]) * Math.Sin(angles[n - 2]);
            }
            else if(dir == 1)
            {
                r[0] = Math.Cos(angles[0]) - Math.Cos(2 * angles[0]) - Math.Sin(angles[0]) * Math.Sin(angles[0]);
                r[1] = Math.Cos(angles[0]) * Math.Cos(angles[1]) - Math.Cos(2 * angles[1]) - Math.Sin(angles[1]) * Math.Sin(angles[2]);
                r[2] = Math.Cos(angles[1]) * Math.Cos(angles[2]) - Math.Cos(2 * angles[2]) - Math.Sin(angles[2]) * Math.Sin(angles[3]);
            }
            else
            {
                r[dir - 1] = Math.Cos(angles[dir - 2]) * Math.Cos(angles[dir - 1]) - Math.Cos(2 * angles[dir - 1]) - Math.Sin(angles[dir - 1]) * Math.Sin(angles[dir]);
                r[dir] = Math.Cos(angles[dir - 1]) * Math.Cos(angles[dir]) - Math.Cos(2 * angles[dir]) - Math.Sin(angles[dir]) * Math.Sin(angles[dir + 1]);
                r[dir + 1] = Math.Cos(angles[dir]) * Math.Cos(angles[dir + 1]) - Math.Cos(2 * angles[dir + 1]) - Math.Sin(angles[dir + 1]) * Math.Sin(angles[dir + 2]);
            }

        }

        public static int Direction(double[] gradient)
        {
            int r = 0;
            double m = Math.Abs(gradient[0]);
            for(int i = 1; i < gradient.Length; i++)
            {
                double m1 = Math.Abs(gradient[i]);
                if(m1 > m)
                {
                    r = i;
                    m = m1;
                }
            }
            return r;
        }

        public static double Place(double[] temp, double left, double right)
        {
            double a = Math.Sin(temp[0]);
            double b = Math.Sin(temp[2]);
            while(right - left > 0.00000001)
            {
                double midLeft = (2 * left + right) / 3;
                double midRight = (left + 2 * right) / 3;

                temp[1] = midLeft;
                double areaLeft = ReducedArea(temp, a, b);

                temp[1] = midRight;
                double areaRight = ReducedArea(temp, a, b);
                if(areaLeft < areaRight)
                {
                    right = midRight;
                }
                else
                {
                    left = midLeft;
                }
            }

            return right;
        }

        public static double ToDeg(double x)
        {
            return x * 180 / Math.PI;
        }
    }
}
