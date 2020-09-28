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
    public struct BigRational : IFormattable, IEquatable<BigRational>, IComparable<BigRational>, IComparable
    {
        #region Static fields
        private const string POSITIVE_INFINITY_LITERAL = "Infinity";
        private const string NEGATIVE_INFINITY_LITERAL = "-Infinity";
        private const string NAN_LITERAL = "NaN";
        private const int FROM_DOUBLE_MAX_ITERATIONS = 25;

        public static readonly BigRational One = new BigRational(1);
        public static readonly BigRational Zero = new BigRational(0);
        public static readonly BigRational NaN = new BigRational(0, 0, true);
        public static readonly BigRational PositiveInfinity = new BigRational(1, 0, true);
        public static readonly BigRational NegativeInfinity = new BigRational(-1, 0, true);
        #endregion

        #region Instance fields
        private readonly BigInteger numerator, denominator;
        private readonly bool explicitConstructorCalled, isDefinitelyIrreducible;
        #endregion

        #region Constructors
        [DebuggerStepThrough]
        public BigRational(BigInteger numerator)
            : this(numerator, 1, true)
        { }

        [DebuggerStepThrough]
        public BigRational(BigInteger numerator, BigInteger denominator)
            : this(numerator, denominator, false)
        { }

        [DebuggerStepThrough]
        private BigRational(BigRational numerator, BigRational denominator)
            : this(numerator.numerator * denominator.Denominator, numerator.Denominator * denominator.numerator, false)
        { }

        private BigRational(BigInteger numerator, BigInteger denominator, bool isIrreducible)
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
        public BigInteger Denominator { get { return explicitConstructorCalled ? denominator : 1; } } //We want default value to be zero, not NaN.

        public BigRational FractionalPart
        {
            get
            {
                if(Denominator != 0)
                {
                    if(IsProper(this))
                        return new BigRational(numerator % Denominator, Denominator);

                    return new BigRational(BigInteger.Abs(numerator % Denominator), Denominator);
                }

                if(numerator == 0)
                    return NaN;

                if(numerator > 0)
                    return PositiveInfinity;

                return NegativeInfinity;
            }
        }

        public BigRational IntegerPart
        {
            get
            {
                if(Denominator != 0)
                    return (BigInteger)this;

                if(numerator == 0)
                    return NaN;

                if(numerator > 0)
                    return PositiveInfinity;

                return NegativeInfinity;
            }
        }

        public BigInteger Numerator { get { return numerator; } }

        public BigRational Sign { get { return numerator.Sign; } }
        #endregion

        #region Instance methods
        public int CompareTo(BigRational other)
        {
            //Even though neither infinities nor NaNs are equal to themselves, for 
            //comparison's sake it makes sense to return 0 when comparing PositiveInfinities
            //or NaNs, etc. The only other option would be to throw an exception...yuck.

            if(BigRational.IsNaN(other))
                return BigRational.IsNaN(this) ? 0 : 1;

            if(BigRational.IsNaN(this))
                return BigRational.IsNaN(other) ? 0 : -1;

            if(BigRational.IsPositiveInfinity(this))
                return BigRational.IsPositiveInfinity(other) ? 0 : 1;

            if(BigRational.IsNegativeInfinity(this))
                return BigRational.IsNegativeInfinity(other) ? 0 : -1;

            if(BigRational.IsPositiveInfinity(other))
                return BigRational.IsPositiveInfinity(this) ? 0 : -1;

            if(BigRational.IsNegativeInfinity(other))
                return BigRational.IsNegativeInfinity(this) ? 0 : 1;

            return (this.numerator * other.Denominator).CompareTo(this.Denominator * other.numerator);
        }

        public int CompareTo(object obj)
        {
            if(obj is BigRational)
                return this.CompareTo((BigRational)obj);

            if(obj == null)
                return 1;

            throw new ArgumentException("obj is not a RationalNumber.", "obj");
        }

        public bool Equals(BigRational other)
        {
            if(this.Denominator == 0 || other.Denominator == 0) //By definition NaNs and infinities are not equal.
                return false;

            return this.numerator * other.Denominator == this.Denominator * other.numerator;
        }

        public override bool Equals(object obj)
        {
            if(obj is BigRational)
                return this.Equals((BigRational)obj);

            return false;
        }

        [DebuggerStepThrough]
        public override int GetHashCode()
        {
            if(isDefinitelyIrreducible)
                return this.numerator.GetHashCode() ^ this.Denominator.GetHashCode();

            return BigRational.GetReducedForm(this).GetHashCode();
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
        public static bool IsInfinity(BigRational rationalNumber)
        {
            return BigRational.IsPositiveInfinity(rationalNumber) ||
                    BigRational.IsNegativeInfinity(rationalNumber);
        }

        public static bool IsIrreducible(BigRational rationalNumber)
        {
            if(rationalNumber.isDefinitelyIrreducible)
                return true;

            if(rationalNumber.Denominator == 1 ||
                (rationalNumber.Denominator == 0 && (rationalNumber.numerator == 1 || rationalNumber.numerator == -1 || rationalNumber.numerator == 0)) ||
                rationalNumber.numerator.GreatestCommonDivisor(rationalNumber.Denominator) == 1)
                return true;

            return false;
        }

        public static bool IsPositiveInfinity(BigRational rationalNumber)
        {
            return rationalNumber.Denominator == 0 && rationalNumber.numerator > 0; //Can not check using rationalNumber == positiveInfinity because by definition
                                                                                    //infinities are not equal.
        }

        public static bool IsProper(BigRational rationalNumber)
        {
            return BigInteger.Abs(rationalNumber.IntegerPart.numerator) < 1;
        }

        public static bool IsNaN(BigRational rationalNumber)
        {
            return rationalNumber.Denominator == 0 && rationalNumber.numerator == 0; //Can not check using rationalNumber == naN because by definition NaN are not equal.
        }

        public static bool IsNegativeInfinity(BigRational rationalNumber)
        {
            return rationalNumber.Denominator == 0 && rationalNumber.numerator < 0; //Can not check using rationalNumber == negativeInfinity because by definition
                                                                                    //infinities are not equal.
        }
        #endregion

        #region Static methods
        public static BigRational Abs(BigRational number)
        {
            return new BigRational(BigInteger.Abs(number.numerator), number.Denominator);
        }

        public static BigRational Add(BigRational left, BigRational right, bool reduceOutput = false)
        {
            return reduceOutput ? BigRational.GetReducedForm(left + right) : left + right;
        }

        public static BigRational Ceiling(BigRational number)
        {
            if(number.FractionalPart == Zero)
                return number.IntegerPart;

            if(number < Zero)
                return number.IntegerPart;

            return number.IntegerPart + 1;
        }

        public static BigRational Divide(BigRational left, BigRational right, bool reduceOutput = false)
        {
            return reduceOutput ? BigRational.GetReducedForm(left / right) : left / right;
        }

        public static BigRational Floor(BigRational number)
        {
            if(number.FractionalPart == Zero)
                return number.IntegerPart;

            if(number < Zero)
                return number.IntegerPart - 1;

            return number.IntegerPart;
        }

        public static BigRational FromDouble(double target, double precision)
        {
            BigRational result;

            if(!TryFromDouble(target, precision, out result))
                throw new ArgumentException("Can not find a rational aproximation with the specified precision.", "precision");

            return result;
        }

        public static BigRational GetReciprocal(BigRational rationalNumber)
        {
            return new BigRational(rationalNumber.Denominator, rationalNumber.numerator, rationalNumber.isDefinitelyIrreducible);
        }

        public static BigRational GetReducedForm(BigRational rationalNumber)
        {
            if(rationalNumber.isDefinitelyIrreducible)
                return rationalNumber;

            var greatesCommonDivisor = rationalNumber.numerator.GreatestCommonDivisor(rationalNumber.Denominator);
            return new BigRational(rationalNumber.numerator / greatesCommonDivisor, rationalNumber.Denominator / greatesCommonDivisor, true);
        }

        public static BigRational Max(BigRational first, BigRational second)
        {
            if(first >= second)
                return first;

            return second;
        }

        public static BigRational Min(BigRational first, BigRational second)
        {
            if(first <= second)
                return first;

            return second;
        }

        public static BigRational Multiply(BigRational left, BigRational right, bool reduceOutput = false)
        {
            return reduceOutput ? BigRational.GetReducedForm(left * right) : left * right;
        }

        public static BigRational Negate(BigRational right, bool reduceOutput = false)
        {
            return reduceOutput ? BigRational.GetReducedForm(-right) : -right;
        }

        public static BigRational Pow(BigRational r, int n, bool reduceOutput = false)
        {
            if(BigRational.IsNaN(r))
                return NaN;

            if(n > 0)
            {
                var result = new BigRational(BigInteger.Pow(r.numerator, n), BigInteger.Pow(r.Denominator, n), false);
                return reduceOutput ? BigRational.GetReducedForm(result) : result;
            }

            if(n < 0)
                return Pow(GetReciprocal(r), -n, reduceOutput);

            if(r == Zero || BigRational.IsInfinity(r))
                return NaN;

            return One;
        }

        public static BigRational Subtract(BigRational left, BigRational right, bool reduceOutput = false)
        {
            return reduceOutput ? BigRational.GetReducedForm(left - right) : left - right;
        }

        public static double ToDouble(BigRational rationalNumber)
        {
            return ((double)rationalNumber.numerator) / (double)rationalNumber.Denominator;
        }

        public static BigRational Truncate(BigRational number)
        {
            return number.IntegerPart;
        }

        public static bool TryFromDouble(double target, double precision, out BigRational result)
        {
            //Continued fraction algorithm: http://en.wikipedia.org/wiki/Continued_fraction
            //Implemented recursively. Problem is figuring out when precision is met without unwinding each solution. Haven't figured out how to do that.
            //Current implementation computes rational number approximations for increasing algorithm depths until precision criteria is met, maximum depth is reached (fromDoubleMaxIterations)
            //or an OverflowException is thrown. Efficiency is probably improvable but this method will not be used in any performance critical code. No use in optimizing it unless there is
            //a good reason. Current implementation works reasonably well.

            result = Zero;
            int steps = 0;

            while(Math.Abs(target - BigRational.ToDouble(result)) > precision)
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

        private static BigRational getNearestRationalNumber(double number, int currentStep, int maximumSteps)
        {
            var integerPart = (BigInteger)number;
            double fractionalPart = number - Math.Truncate(number);

            if(currentStep < maximumSteps && fractionalPart != 0)
                return integerPart + new BigRational(1, getNearestRationalNumber(1 / fractionalPart, ++currentStep, maximumSteps));

            return new BigRational(integerPart);
        }
        #endregion

        #region Operators
        public static explicit operator double(BigRational rationalNumber) { return BigRational.ToDouble(rationalNumber); }

        public static implicit operator BigRational(BigInteger number) { return new BigRational(number); }

        public static implicit operator BigRational(long number) { return new BigRational(number); }

        public static explicit operator BigInteger(BigRational rationalNumber) { return rationalNumber.numerator / rationalNumber.Denominator; }

        public static bool operator ==(BigRational left, BigRational right) { return left.Equals(right); }

        public static bool operator !=(BigRational left, BigRational right) { return !left.Equals(right); }

        public static bool operator >(BigRational left, BigRational right) { return left.CompareTo(right) > 0; }

        public static bool operator >=(BigRational left, BigRational right) { return left.CompareTo(right) >= 0; }

        public static bool operator <(BigRational left, BigRational right) { return left.CompareTo(right) < 0; }

        public static bool operator <=(BigRational left, BigRational right) { return left.CompareTo(right) <= 0; }

        public static BigRational operator +(BigRational right)
        {
            return right;
        }

        public static BigRational operator -(BigRational right)
        {
            return new BigRational(-right.numerator, right.Denominator, right.isDefinitelyIrreducible);
        }

        public static BigRational operator +(BigRational left, BigRational right)
        {
            if((IsPositiveInfinity(left) && IsPositiveInfinity(right)) || //Otherwise the sum of two equally signed infinities would return NaN which is not correct.
                (IsNegativeInfinity(left) && IsNegativeInfinity(right)))
                return left;

            return new BigRational(left.Numerator * right.Denominator + right.numerator * left.Denominator, left.Denominator * right.Denominator, false);
        }

        public static BigRational operator -(BigRational left, BigRational right)
        {
            return left + (-right);
        }

        public static BigRational operator *(BigRational left, BigRational right)
        {
            return new BigRational(left.numerator * right.numerator, left.Denominator * right.Denominator, false);
        }

        public static BigRational operator /(BigRational left, BigRational right)
        {
            if((IsInfinity(left) && IsInfinity(right)) ||
                (left == Zero && right == 0))
                return NaN;

            return new BigRational(left.numerator * right.Denominator, left.Denominator * right.numerator, false);
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

                if(!(arg is BigRational))
                    return handleOtherFormats(format, arg, formatProvider);

                var rational = (BigRational)arg;

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
                            BigInteger.Abs(fractionalPart.numerator).ToString(innerFormat, formatProvider), fractionalPart.Denominator.ToString(innerFormat, formatProvider));
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
