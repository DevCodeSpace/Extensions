using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class NumExtension
    {
        // Converts positive numbers to their negative counterparts.
        public static double Negative(this double number) => Math.Sign(number) > 0 ? -number : number;

        // Checks if the number is between value1 and value2, inclusive if true.
        public static bool IsBetween(this double number, double value1, double value2, bool inclusive = false)
        {
            return inclusive
                ? (number >= value1 && number <= value2) || (number >= value2 && number <= value1)
                : (number > value1 && number < value2) || (number > value2 && number < value1);
        }

        // Rounds the number to a specific number of decimal places.
        public static double RoundToDecimals(this double number, int decimalPlaces)
        {
            return Math.Round(number, decimalPlaces);
        }

        // Converts degrees to radians.
        public static double AsRadians(this double degrees) => degrees * Math.PI / 180;

        // Converts radians to degrees.
        public static double AsDegrees(this double radians) => radians * 180 / Math.PI;
    }

    public static class TypedNumExtension
    {
        // Limits the value to the upper bound, exclusive if specified.
        public static T Maxim<T>(this T number, T upperBound, bool exclusive = false) where T : struct, IComparable<T>
        {
            return exclusive
                ? (number.CompareTo(upperBound) < 0 ? number : upperBound)
                : (number.CompareTo(upperBound) <= 0 ? number : upperBound);
        }

        // Ensures the value is not less than the lower bound, exclusive if specified.
        public static T Minm<T>(this T number, T lowerBound, bool exclusive = false) where T : struct, IComparable<T>
        {
            return exclusive
                ? (number.CompareTo(lowerBound) > 0 ? number : lowerBound)
                : (number.CompareTo(lowerBound) >= 0 ? number : lowerBound);
        }

        // Ensures the value is not below the lower bound.
        public static T ClampAtMin<T>(this T number, T lowerBound) where T : struct, IComparable<T>
        {
            return number.CompareTo(lowerBound) < 0 ? lowerBound : number;
        }

        // Ensures the value does not exceed the upper bound.
        public static T ClampAtMax<T>(this T number, T upperBound) where T : struct, IComparable<T>
        {
            return number.CompareTo(upperBound) > 0 ? upperBound : number;
        }
    }

    public static class NullableNumExtension
    {
        // Returns this value or 0 if null.
        public static double OrZero(this double? number) => number ?? 0;

        // Returns this value or 1 if null.
        public static double OrOne(this double? number) => number ?? 1;

        // Returns this value or the provided fallback value if null.
        public static double Or(this double? number, double fallback) => number ?? fallback;
    }
}
