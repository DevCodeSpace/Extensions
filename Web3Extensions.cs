using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class Web3Extensions
    {
        /// <summary>
        /// Generates a random numeric pin code with the specified number of digits.
        /// </summary>
        /// <param name="digits">The number of digits for the pin code.</param>
        /// <returns>A random pin code as a string.</returns>
        public static string GeneratePin(int digits = 6)
        {
            var random = new Random();
            var maxNumber = (int)Math.Pow(10, digits) - 1;
            return random.Next(0, maxNumber).ToString().PadLeft(digits, '0');
        }

        /// <summary>
        /// Converts a BigInt to a hexadecimal string with optional "0x0" prefix.
        /// </summary>
        /// <param name="decimalValue">The BigInt value to convert.</param>
        /// <param name="includePrefix">Indicates whether to include the "0x0" prefix.</param>
        /// <returns>The hexadecimal representation of the BigInt.</returns>
        public static string ToHex(BigInteger decimalValue, bool includePrefix = true)
        {
            var hex = decimalValue.ToString("X");
            return includePrefix ? $"0x0{hex}" : hex;
        }

        /// <summary>
        /// Converts a value in Wei (BigInt) to Ether (double).
        /// </summary>
        /// <param name="weiValue">The value in Wei to convert.</param>
        /// <param name="decimals">The decimal precision; default is 18 for Ether.</param>
        /// <returns>The equivalent value in Ether.</returns>
        public static double ToEther(BigInteger weiValue, int decimals = 18)
        {
            var unit = BigInteger.Pow(10, decimals);
            return (double)(weiValue / unit) + ((double)(weiValue % unit) / (double)unit);
        }
         
        /// <summary>
        /// Parses an Ethereum BigInt string in Wei and converts it to Ether as a double.
        /// </summary>
        /// <param name="weiString">The BigInt value in Wei as a string.</param>
        /// <returns>The equivalent value in Ether.</returns>
        public static double GetEtherValue(string weiString)
        {
            var weiValue = BigInteger.Parse(weiString);
            var factor = BigInteger.Pow(10, 18);
            return (double)(weiValue / factor) + ((double)(weiValue % factor) / (double)factor);
        }

        /// <summary>
        /// Formats an Ethereum address to a shortened version (e.g., 0xB2E...400D).
        /// </summary>
        /// <param name="address">The full Ethereum address.</param>
        /// <returns>The formatted, shortened address.</returns>
        public static string FormatCryptoAddress(string address)
        {
            if (address.Length > 10)
            {
                return $"{address.Substring(0, 5)}...{address.Substring(address.Length - 5)}";
            }
            return address;
        }

        /// <summary>
        /// Removes "0x" prefix from a hexadecimal string, if present.
        /// </summary>
        /// <param name="hex">The hexadecimal string.</param>
        /// <returns>The string without the "0x" prefix.</returns>
        public static string Strip0x(string hex)
        {
            return hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase) ? hex.Substring(2) : hex;
        }

        /// <summary>
        /// Converts a hexadecimal string to a BigInteger.
        /// </summary>
        /// <param name="hex">The hexadecimal string to convert.</param>
        /// <returns>The equivalent BigInteger.</returns>
        public static BigInteger HexToInt(string hex)
        {
            return BigInteger.Parse(Strip0x(hex), NumberStyles.HexNumber);
        }
    }
}
