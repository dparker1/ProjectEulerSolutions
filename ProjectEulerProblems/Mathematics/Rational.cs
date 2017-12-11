using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems.Mathematics
{
    public class Rational
    {
        public long Numerator { get; set; }
        public long Denominator { get; set; }

        public Rational() : this(0, 1) { }

        public Rational(int val) : this(val, 1) { }

        public Rational(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public static Rational operator +(Rational right, Rational left)
        {
            Rational result = 1;
            result.Denominator = right.Denominator * left.Denominator;
            result.Numerator = right.Numerator * left.Denominator + right.Denominator * left.Numerator;
            result.Simplify();
            return result;
        }

        public static Rational operator *(Rational right, Rational left)
        {
            right.Denominator *= left.Denominator;
            right.Numerator *= left.Numerator;
            right.Simplify();
            return right;
        }

        public static Rational operator /(Rational right, Rational left)
        {
            right.Denominator *= left.Numerator;
            right.Numerator *= left.Denominator;
            right.Simplify();
            return right;
        }

        public static implicit operator Rational(int value)
        {
            return new Rational(value);
        }

        public void Simplify()
        {
            for(long divisor = 2; divisor <= Denominator; divisor++)
            {
                if(Denominator % divisor == 0 && Numerator % divisor == 0)
                {
                    Denominator /= divisor;
                    Numerator /= divisor;
                    divisor = 1;
                }
            }
        }

        public override string ToString()
        {
            return Numerator + "/" + Denominator;
        }
    }
}
