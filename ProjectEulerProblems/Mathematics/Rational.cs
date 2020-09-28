using System;
using System.Numerics;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

/*
* Sourced from https://codereview.stackexchange.com/questions/95681/rational-number-implementation
*/
namespace ProjectEulerProblems.Mathematics
{
    [Serializable]
    public struct Rational : IFormattable, IEquatable<Rational>, IComparable<Rational>, IComparable
    {
        #region Static fields
        private const string POSITIVE_INFINITY_LITERAL = "Infinity";
        private const string NEGATIVE_INFINITY_LITERAL = "-Infinity";
        private const string NAN_LITERAL = "NaN";
        private const int FROM_DOUBLE_MAX_ITERATIONS = 25;

        public static readonly Rational One = new Rational(1);
        public static readonly Rational Zero = new Rational(0);
        public static readonly Rational NaN = new Rational(0, 0, true);
        public static readonly Rational PositiveInfinity = new Rational(1, 0, true);
        public static readonly Rational NegativeInfinity = new Rational(-1, 0, true);
        #endregion

        #region Instance fields
        private readonly int numerator, denominator;
        private readonly bool explicitConstructorCalled, isDefinitelyIrreducible;
        #endregion

        #region Constructors
        [DebuggerStepThrough]
        public Rational(int numerator)
            : this(numerator, 1, true)
        { }

        [DebuggerStepThrough]
        public Rational(int numerator, int denominator)
            : this(numerator, denominator, false)
        { }

        [DebuggerStepThrough]
        private Rational(Rational numerator, Rational denominator)
            : this(numerator.numerator * denominator.Denominator, numerator.Denominator * denominator.numerator, false)
        { }

        private Rational(int numerator, int denominator, bool isIrreducible)
        {
            if(denominator < 0) //normalize to positive denominator
            {
                this.denominator = -denominator;
                this.numerator = -numerator;
            }
            else
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }

            this.explicitConstructorCalled = true;
            this.isDefinitelyIrreducible = isIrreducible;
        }
        #endregion

        #region Instance properties
        public int Denominator { get { return explicitConstructorCalled ? denominator : 1; } } //We want default value to be zero, not NaN.

        public Rational FractionalPart
        {
            get
            {
                if(Denominator != 0)
                {
                    if(IsProper(this))
                        return new Rational(numerator % Denominator, Denominator);

                    return new Rational(Math.Abs(numerator % Denominator), Denominator);
                }

                if(numerator == 0)
                    return NaN;

                if(numerator > 0)
                    return PositiveInfinity;

                return NegativeInfinity;
            }
        }

        public Rational IntegerPart
        {
            get
            {
                if(Denominator != 0)
                    return (int)this;

                if(numerator == 0)
                    return NaN;

                if(numerator > 0)
                    return PositiveInfinity;

                return NegativeInfinity;
            }
        }

        public int Numerator { get { return numerator; } }

        public Rational Sign { get { return numerator > 0 ? 1 : 0; } }
        #endregion

        #region Instance methods
        public int CompareTo(Rational other)
        {
            //Even though neither infinities nor NaNs are equal to themselves, for 
            //comparison's sake it makes sense to return 0 when comparing PositiveInfinities
            //or NaNs, etc. The only other option would be to throw an exception...yuck.

            if(Rational.IsNaN(other))
                return Rational.IsNaN(this) ? 0 : 1;

            if(Rational.IsNaN(this))
                return Rational.IsNaN(other) ? 0 : -1;

            if(Rational.IsPositiveInfinity(this))
                return Rational.IsPositiveInfinity(other) ? 0 : 1;

            if(Rational.IsNegativeInfinity(this))
                return Rational.IsNegativeInfinity(other) ? 0 : -1;

            if(Rational.IsPositiveInfinity(other))
                return Rational.IsPositiveInfinity(this) ? 0 : -1;

            if(Rational.IsNegativeInfinity(other))
                return Rational.IsNegativeInfinity(this) ? 0 : 1;

            return (this.numerator * other.Denominator).CompareTo(this.Denominator * other.numerator);
        }

        public int CompareTo(object obj)
        {
            if(obj is Rational)
                return this.CompareTo((Rational)obj);

            if(obj == null)
                return 1;

            throw new ArgumentException("obj is not a RationalNumber.", "obj");
        }

        public bool Equals(Rational other)
        {
            if(this.Denominator == 0 || other.Denominator == 0) //By definition NaNs and infinities are not equal.
                return false;

            return this.numerator * other.Denominator == this.Denominator * other.numerator;
        }

        public override bool Equals(object obj)
        {
            if(obj is Rational)
                return this.Equals((Rational)obj);

            return false;
        }

        [DebuggerStepThrough]
        public override int GetHashCode()
        {
            if(isDefinitelyIrreducible)
                return this.numerator.GetHashCode() ^ this.Denominator.GetHashCode();

            return Rational.GetReducedForm(this).GetHashCode();
        }

        [DebuggerStepThrough]
        public override string ToString()
        {
            return ToString(null, null);
        }

        [DebuggerStepThrough]
        public string ToString(string format)
        {
            return ToString(format, null);
        }

        [DebuggerStepThrough]
        public string ToString(IFormatProvider formatProvider)
        {
            return ToString(null, formatProvider);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            try
            {
                if(formatProvider is RationalFormatProvider)
                    return ((RationalFormatProvider)formatProvider).Format(format ?? "G", this, CultureInfo.CurrentCulture);

                var rationalFormatProvider = new RationalFormatProvider();
                return rationalFormatProvider.Format(format ?? "G", this, formatProvider ?? CultureInfo.CurrentCulture);
            }
            catch(FormatException e)
            {
                throw new FormatException(String.Format("The specified format string '{0}' is invalid.", format), e);
            }
        }
        #endregion

        #region Static properties
        public static bool IsInfinity(Rational rationalNumber)
        {
            return Rational.IsPositiveInfinity(rationalNumber) ||
                    Rational.IsNegativeInfinity(rationalNumber);
        }

        public static bool IsIrreducible(Rational rationalNumber)
        {
            if(rationalNumber.isDefinitelyIrreducible)
                return true;

            if(rationalNumber.Denominator == 1 ||
                (rationalNumber.Denominator == 0 && (rationalNumber.numerator == 1 || rationalNumber.numerator == -1 || rationalNumber.numerator == 0)) ||
                EulerUtilities.GreatestCommonDivisor(rationalNumber.numerator, rationalNumber.denominator) == 1)
                return true;

            return false;
        }

        public static bool IsPositiveInfinity(Rational rationalNumber)
        {
            return rationalNumber.Denominator == 0 && rationalNumber.numerator > 0; //Can not check using rationalNumber == positiveInfinity because by definition
                                                                                    //infinities are not equal.
        }

        public static bool IsProper(Rational rationalNumber)
        {
            return Math.Abs(rationalNumber.IntegerPart.numerator) < 1;
        }

        public static bool IsNaN(Rational rationalNumber)
        {
            return rationalNumber.Denominator == 0 && rationalNumber.numerator == 0; //Can not check using rationalNumber == naN because by definition NaN are not equal.
        }

        public static bool IsNegativeInfinity(Rational rationalNumber)
        {
            return rationalNumber.Denominator == 0 && rationalNumber.numerator < 0; //Can not check using rationalNumber == negativeInfinity because by definition
                                                                                    //infinities are not equal.
        }
        #endregion

        #region Static methods
        public static Rational Abs(Rational number)
        {
            return new Rational(Math.Abs(number.numerator), number.Denominator);
        }

        public static Rational Add(Rational left, Rational right, bool reduceOutput = false)
        {
            return reduceOutput ? Rational.GetReducedForm(left + right) : left + right;
        }

        public static Rational Ceiling(Rational number)
        {
            if(number.FractionalPart == Zero)
                return number.IntegerPart;

            if(number < Zero)
                return number.IntegerPart;

            return number.IntegerPart + 1;
        }

        public static Rational Divide(Rational left, Rational right, bool reduceOutput = false)
        {
            return reduceOutput ? Rational.GetReducedForm(left / right) : left / right;
        }

        public static Rational Floor(Rational number)
        {
            if(number.FractionalPart == Zero)
                return number.IntegerPart;

            if(number < Zero)
                return number.IntegerPart - 1;

            return number.IntegerPart;
        }

        public static Rational FromDouble(double target, double precision)
        {
            Rational result;

            if(!TryFromDouble(target, precision, out result))
                throw new ArgumentException("Can not find a rational aproximation with the specified precision.", "precision");

            return result;
        }

        public static Rational GetReciprocal(Rational rationalNumber)
        {
            return new Rational(rationalNumber.Denominator, rationalNumber.numerator, rationalNumber.isDefinitelyIrreducible);
        }

        public static Rational GetReducedForm(Rational rationalNumber)
        {
            if(rationalNumber.isDefinitelyIrreducible)
                return rationalNumber;

            var greatesCommonDivisor = EulerUtilities.GreatestCommonDivisor(rationalNumber.numerator, rationalNumber.denominator);
            return new Rational(rationalNumber.numerator / greatesCommonDivisor, rationalNumber.Denominator / greatesCommonDivisor, true);
        }

        public static Rational Max(Rational first, Rational second)
        {
            if(first >= second)
                return first;

            return second;
        }

        public static Rational Min(Rational first, Rational second)
        {
            if(first <= second)
                return first;

            return second;
        }

        public static Rational Multiply(Rational left, Rational right, bool reduceOutput = false)
        {
            return reduceOutput ? Rational.GetReducedForm(left * right) : left * right;
        }

        public static Rational Negate(Rational right, bool reduceOutput = false)
        {
            return reduceOutput ? Rational.GetReducedForm(-right) : -right;
        }

        public static Rational Pow(Rational r, int n, bool reduceOutput = false)
        {
            if(Rational.IsNaN(r))
                return NaN;

            if(n > 0)
            {
                var result = new Rational((int)Math.Pow(r.numerator, n), (int)Math.Pow(r.Denominator, n), false);
                return reduceOutput ? Rational.GetReducedForm(result) : result;
            }

            if(n < 0)
                return Pow(GetReciprocal(r), -n, reduceOutput);

            if(r == Zero || Rational.IsInfinity(r))
                return NaN;

            return One;
        }

        public static Rational Subtract(Rational left, Rational right, bool reduceOutput = false)
        {
            return reduceOutput ? Rational.GetReducedForm(left - right) : left - right;
        }

        public static double ToDouble(Rational rationalNumber)
        {
            return ((double)rationalNumber.numerator) / (double)rationalNumber.Denominator;
        }

        public static Rational Truncate(Rational number)
        {
            return number.IntegerPart;
        }

        public static bool TryFromDouble(double target, double precision, out Rational result)
        {
            //Continued fraction algorithm: http://en.wikipedia.org/wiki/Continued_fraction
            //Implemented recursively. Problem is figuring out when precision is met without unwinding each solution. Haven't figured out how to do that.
            //Current implementation computes rational number approximations for increasing algorithm depths until precision criteria is met, maximum depth is reached (fromDoubleMaxIterations)
            //or an OverflowException is thrown. Efficiency is probably improvable but this method will not be used in any performance critical code. No use in optimizing it unless there is
            //a good reason. Current implementation works reasonably well.

            result = Zero;
            int steps = 0;

            while(Math.Abs(target - Rational.ToDouble(result)) > precision)
            {
                if(steps > FROM_DOUBLE_MAX_ITERATIONS)
                {
                    result = Zero;
                    return false;
                }

                result = getNearestRationalNumber(target, 0, steps++);
            }

            return true;
        }

        private static Rational getNearestRationalNumber(double number, int currentStep, int maximumSteps)
        {
            var integerPart = (int)number;
            double fractionalPart = number - Math.Truncate(number);

            if(currentStep < maximumSteps && fractionalPart != 0)
                return integerPart + new Rational(1, getNearestRationalNumber(1 / fractionalPart, ++currentStep, maximumSteps));

            return new Rational(integerPart);
        }
        #endregion

        #region Operators
        public static explicit operator double(Rational rationalNumber) { return Rational.ToDouble(rationalNumber); }

        public static implicit operator Rational(int number) { return new Rational(number); }

        public static implicit operator Rational(long number) { return new Rational((int)number); }

        public static explicit operator int(Rational rationalNumber) { return rationalNumber.numerator / rationalNumber.Denominator; }

        public static bool operator ==(Rational left, Rational right) { return left.Equals(right); }

        public static bool operator !=(Rational left, Rational right) { return !left.Equals(right); }

        public static bool operator >(Rational left, Rational right) { return left.CompareTo(right) > 0; }

        public static bool operator >=(Rational left, Rational right) { return left.CompareTo(right) >= 0; }

        public static bool operator <(Rational left, Rational right) { return left.CompareTo(right) < 0; }

        public static bool operator <=(Rational left, Rational right) { return left.CompareTo(right) <= 0; }

        public static Rational operator +(Rational right)
        {
            return right;
        }

        public static Rational operator -(Rational right)
        {
            return new Rational(-right.numerator, right.Denominator, right.isDefinitelyIrreducible);
        }

        public static Rational operator +(Rational left, Rational right)
        {
            if((IsPositiveInfinity(left) && IsPositiveInfinity(right)) || //Otherwise the sum of two equally signed infinities would return NaN which is not correct.
                (IsNegativeInfinity(left) && IsNegativeInfinity(right)))
                return left;

            return new Rational(left.Numerator * right.Denominator + right.numerator * left.Denominator, left.Denominator * right.Denominator, false);
        }

        public static Rational operator -(Rational left, Rational right)
        {
            return left + (-right);
        }

        public static Rational operator *(Rational left, Rational right)
        {
            return new Rational(left.numerator * right.numerator, left.Denominator * right.Denominator, false);
        }

        public static Rational operator /(Rational left, Rational right)
        {
            if((IsInfinity(left) && IsInfinity(right)) ||
                (left == Zero && right == 0))
                return NaN;

            return new Rational(left.numerator * right.Denominator, left.Denominator * right.numerator, false);
        }
        #endregion

        [DebuggerStepThrough]
        private class RationalFormatProvider : IFormatProvider, ICustomFormatter
        {
            public object GetFormat(Type formatType)
            {
                if(formatType == typeof(ICustomFormatter))
                    return this;

                return null;
            }

            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                var upperFormat = format != null ? format.ToUpperInvariant().TrimStart() : "G";

                if(!(arg is Rational))
                    return handleOtherFormats(format, arg, formatProvider);

                var rational = (Rational)arg;

                if(rational.Denominator == 0)
                {
                    if(rational.numerator == 0)
                        return NAN_LITERAL;

                    if(rational.numerator > 0)
                        return POSITIVE_INFINITY_LITERAL;

                    return NEGATIVE_INFINITY_LITERAL;
                }

                string innerFormat = format;

                if(upperFormat[0] == 'M')
                {
                    innerFormat = format.Replace('M', 'G');
                    var integerPart = rational.IntegerPart.Numerator;

                    if(integerPart != 0)
                    {
                        var fractionalPart = rational.FractionalPart;
                        return string.Format("{0} [{1}/{2}]", integerPart.ToString(innerFormat, formatProvider),
                            Math.Abs(fractionalPart.numerator).ToString(innerFormat, formatProvider), fractionalPart.Denominator.ToString(innerFormat, formatProvider));
                    }
                }

                return string.Format("{0}/{1}", rational.numerator.ToString(innerFormat, formatProvider), rational.Denominator.ToString(innerFormat, formatProvider));
            }

            private string handleOtherFormats(string format, object arg, IFormatProvider formatProvider)
            {
                if(arg is IFormattable)
                    return ((IFormattable)arg).ToString(format, formatProvider);

                if(arg != null)
                    return arg.ToString();

                return String.Empty;
            }
        }
    }
}
