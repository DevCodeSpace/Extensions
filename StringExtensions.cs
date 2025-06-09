using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Extensions
{
    public static class StringExtensions
    {
        // Capitalizes the first letter of the string.
        public static string Capitalize(this string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            return char.ToUpper(str[0]) + str.Substring(1);
        }

        // Returns the first letter of the string.
        public static string GetFirstLetter(this string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : str[0].ToString();
        }

        // Returns the last letter of the string or an empty string if empty.
        public static string GetLastLetter(this string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : str[^1].ToString();
        }
         
        // Checks if the string is a valid email address.
        public static bool IsValidEmail(this string str)
        {
            var emailRegex = new Regex(@"^[^@]+@[^@]+\.[^@]+$");
            return emailRegex.IsMatch(str);
        }

        // Checks if the string contains any type of emoji.
        public static bool ContainsEmoji(this string str)
        {
            var emojiRegex = new Regex(@"(\u00a9|\u00ae|[\u2000-\u3300]|[\ud83c-\ud83e][\udc00-\udfff]|[\u0023-\u0039]\ufe0f?\u20e3?|[\u2194-\u21aa]|[\u2300-\u2b55]|[\u2934-\u2b55]|[\u3030-\u303d]|[\u3297-\u3299]|[\u2049-\u2139]|[\ud83c][\udde6-\uddff]|[\ud83c][\udde8-\uddec]|[\ud83c][\uddee-\uddfa]|[\ud83c][\uddfb-\uddff]|[\ud83d][\ude00-\ude4f]|[\ud83d][\ude80-\udec2]|[\ud83d][\uded0-\udee5]|[\ud83d][\udee7-\udfff]|[\ud83d][\udc00-\uddff]|[\ud83e][\udd00-\uddff]|[\ud83e][\udc00-\udfff]|[\ud83e][\udc00-\uddff])");
            return emojiRegex.IsMatch(str);
        }

        // Checks if the string does not contain any emoji.
        public static bool DoesNotContainEmoji(this string str)
        {
            return !str.ContainsEmoji();
        }

        // Checks if the string is a valid Indian mobile number.
        public static bool IsIndianMobileNumber(this string str)
        {
            var regex = new Regex(@"^[6-9]\d{9}$");
            return regex.IsMatch(str);
        }

        // Validates if the string is a valid 5-digit PIN code.
        public static bool IsValidPinCode(this string str)
        {
            var pinCodeRegex = new Regex(@"^\d{5}$");
            return pinCodeRegex.IsMatch(str);
        }

        // Returns true if the string is a valid URL.
        public static bool IsValidUrl(this string str)
        {
            var urlRegex = new Regex(@"^(https?|ftp):\/\/[^\s/$.?#].[^\s]*$", RegexOptions.IgnoreCase);
            return urlRegex.IsMatch(str);
        }

        // Returns true if the string is a valid number.
        public static bool IsNumeric(this string str)
        {
            return double.TryParse(str, out _);
        }

        // Trims the string and removes all whitespace.
        public static string RemoveAllWhitespace(this string str)
        {
            return Regex.Replace(str, @"\s+", string.Empty);
        }

        // Returns true if the string is a palindrome.
        public static bool IsPalindrome(this string str)
        {
            var trimmed = str.RemoveAllWhitespace().ToLower();
            return trimmed == new string(trimmed.Reverse().ToArray());
        }

        // Converts the string to camel case.
        public static string ToCamelCase(this string str)
        {
            return string.Join("", str.Split(' ').Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
        }

        // Converts the string to snake case.
        public static string ToSnakeCase(this string str)
        {
            return Regex.Replace(str, @"([A-Z])", "_$1").TrimStart('_').ToLower();
        }

        // Reverses the string.
        public static string Reverse(this string str)
        {
            return new string(str.Reverse().ToArray());
        }

        // Checks if the string contains only alphabets.
        public static bool IsAlphabetic(this string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z]+$");
        }

        // Checks if the string contains only alphanumeric characters.
        public static bool IsAlphanumeric(this string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z0-9]+$");
        }

        // Returns the initials of the string.
        public static string Initials(this string str)
        {
            return string.Join("", str.Split(' ').Where(word => word.Length > 0).Select(word => char.ToUpper(word[0])));
        }

        // Checks if the string is a strong password.
        public static bool IsStrongPassword(this string str)
        {
            var passwordRegex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,}$");
            return passwordRegex.IsMatch(str);
        }

        // Checks if the string is a proper name.
        public static bool IsUserName(this string str)
        {
            if (string.IsNullOrEmpty(str)) return false;
            if (!char.IsUpper(str[0])) return false;
            return Regex.IsMatch(str, @"^[A-Za-z\s-]+$");
        }

        // Converts the string to a double or returns null if conversion fails.
        public static double? ToDouble(this string str)
        {
            return double.TryParse(str, out var result) ? result : (double?)null;
        }

        // Converts the string to an int or returns null if conversion fails.
        public static int? ToInt(this string str)
        {
            return int.TryParse(str, out var result) ? result : (int?)null;
        }

        // Returns the number of words in the string.
        public static int WordCount(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? 0 : str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // Wraps the string with prefix and suffix.
        public static string Wrap(this string str, string prefix, string? suffix = null)
        {
            suffix ??= prefix;
            return $"{prefix}{str}{suffix}";
        }

        // Removes the specified prefix from the string if it exists.
        public static string RemovePrefix(this string str, string prefix)
        {
            return str.StartsWith(prefix) ? str.Substring(prefix.Length) : str;
        }

        // Removes the specified suffix from the string if it exists.
        public static string RemoveSuffix(this string str, string suffix)
        {
            return str.EndsWith(suffix) ? str.Substring(0, str.Length - suffix.Length) : str;
        }

        // Checks if the string can be parsed as a binary number.
        public static bool IsBinary(this string str)
        {
            return Regex.IsMatch(str, "^[01]+$");
        }

        // Checks if the string can be parsed as a hexadecimal number.
        public static bool IsHexadecimal(this string str)
        {
            return Regex.IsMatch(str, @"^[\da-fA-F]+$");
        }

        // Checks if the string can be parsed as a boolean.
        public static bool? ToBoolOrNull(this string str)
        {
            if (str.Equals("true", StringComparison.OrdinalIgnoreCase)) return true;
            if (str.Equals("false", StringComparison.OrdinalIgnoreCase)) return false;
            return int.TryParse(str, out var number) && number > 0 ? true : (bool?)null;
        }

        // Parses the string into a DateTime or returns null if parsing fails.
        public static DateTime? ToDateTimeOrNull(this string str)
        {
            return DateTime.TryParse(str, out var date) ? date : (DateTime?)null;
        }
          
        // Compares two strings for equality, ignoring case.
        public static bool EqualsIgnoreCase(this string str, string comparer)
        {
            return str.Equals(comparer, StringComparison.OrdinalIgnoreCase);
        }

        // Counts occurrences of a character in a string.
        public static int CountOccurrences(this string str, char match)
        {
            return str.Count(c => c == match);
        }

        // Capitalizes the first letter of each word.
        public static string ToTitleCase(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        // Encodes the string for URL.
        public static string EncodeUrl(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        // Decodes the URL-encoded string.
        public static string DecodeUrl(this string str)
        {
            return HttpUtility.UrlDecode(str);
        }
    }
}
