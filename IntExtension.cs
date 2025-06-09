using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class IntExtension
    {
        // Converts the integer to a Duration in seconds.
        public static TimeSpan Seconds(this int value) => TimeSpan.FromSeconds(value);

        // Converts the integer to a Duration in milliseconds.
        public static TimeSpan Milliseconds(this int value) => TimeSpan.FromMilliseconds(value);

        // Converts the integer to a Duration in microseconds.
        public static TimeSpan Microseconds(this int value) => TimeSpan.FromTicks(value * 10);

        // Returns the number of digits in the integer.
        public static int Length(this int value) => value.ToString().Length;

        // Returns a list of digits of the integer.
        public static List<int> Digits(this int value) => value.ToString().Select(digit => int.Parse(digit.ToString())).ToList();

        // Checks if the integer is divisible by the specified divider.
        public static bool IsDivisibleBy(this int value, int divider) => value % divider == 0;

        // Checks if the integer is divisible by all values in the list of dividers.
        public static bool IsDivisibleByAll(this int value, List<int> dividers) => dividers.All(divider => value % divider == 0);

        // Repeats the function for the absolute value of the integer times.
        public static List<T> Repeat<T>(this int value, Func<int, T> func)
        {
            var results = new List<T>();
            for (int i = 1; i <= Math.Abs(value); i++)
            {
                results.Add(func(i));
            }
            return results;
        }

        // Converts the integer to a boolean (non-zero is true).
        public static bool AsBool(this int value) => value != 0;

        // Converts the integer to a two-digit string.
        public static string TwoDigits(this int value) => value < 10 ? $"0{value}" : value.ToString();

        // Creates a range from this value to the end value.
        public static IEnumerable<int> RangeTo(this int start, int end)
        {
            return start <= end
                ? Enumerable.Range(start, end - start + 1)
                : Enumerable.Range(end, start - end + 1).Reverse();
        }

        // Creates a range from this value down to the end value.
        public static IEnumerable<int> DownTo(this int start, int end)
        {
            for (int i = start; i >= end; i--)
            {
                yield return i;
            }
        }

        // Creates a range up to, but not including, the end value.
        public static IEnumerable<int> Until(this int start, int end)
        {
            return Enumerable.Range(start, end - start);
        }
    }

    public static class RandomExtension
    {
        private static readonly Random _random = new Random();

        // Generates a random integer in the range [0, max].
        public static int RandomInt(int? max = null) => _random.Next(max ?? 1000000);
    }
}
