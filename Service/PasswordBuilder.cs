using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Extensions.Interface;

namespace Extensions.Service
{
    /// <summary>
    /// Class for building configurable passwords with various options like uppercase, lowercase, numbers, and symbols.
    /// </summary>
    public class PasswordBuilder : IPasswordBuilder
    {
        private const int DefaultLength = 12;
        private const int DefaultRetryLimit = 100;
        private static readonly RandomNumberGenerator RandomGenerator = RandomNumberGenerator.Create();

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordBuilder"/> class with default configuration.
        /// </summary>
        public PasswordBuilder() : this(new PasswordConfiguration(true, true, true, true, DefaultLength, DefaultRetryLimit)) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordBuilder"/> class with the specified configuration.
        /// </summary>
        /// <param name="config">The password configuration.</param>
        public PasswordBuilder(IPasswordConfiguration config)
        {
            Configuration = config;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordBuilder"/> class with a specified length.
        /// </summary>
        /// <param name="length">The length of the password to generate.</param>
        public PasswordBuilder(int length)
            : this(new PasswordConfiguration(true, true, true, true, length, DefaultRetryLimit)) { }

        /// <summary>
        /// Gets or sets the password configuration.
        /// </summary>
        public IPasswordConfiguration Configuration { get; set; }

        /// <summary>
        /// Enables lowercase letters in the password.
        /// </summary>
        public IPasswordBuilder WithLowercase()
        {
            Configuration = Configuration.EnableLowercase();
            return this;
        }

        /// <summary>
        /// Enables uppercase letters in the password.
        /// </summary>
        public IPasswordBuilder WithUppercase()
        {
            Configuration = Configuration.EnableUppercase();
            return this;
        }

        /// <summary>
        /// Enables numbers in the password.
        /// </summary>
        public IPasswordBuilder WithNumbers()
        {
            Configuration = Configuration.EnableNumbers();
            return this;
        }

        /// <summary>
        /// Enables symbols in the password.
        /// </summary>
        public IPasswordBuilder WithSymbols()
        {
            Configuration = Configuration.EnableSymbols();
            return this;
        }

        /// <summary>
        /// Enables custom symbols for the password.
        /// </summary>
        /// <param name="symbols">The custom symbols to include.</param>
        public IPasswordBuilder WithCustomSymbols(string symbols)
        {
            Configuration = Configuration.EnableCustomSymbols(symbols);
            return this;
        }

        /// <summary>
        /// Sets the length of the password.
        /// </summary>
        /// <param name="length">The length of the password to generate.</param>
        public IPasswordBuilder WithLength(int length)
        {
            Configuration.Length = length;
            return this;
        }

        /// <summary>
        /// Generates a password based on the current configuration.
        /// </summary>
        /// <returns>The generated password.</returns>
        public string Generate()
        {
            int attempts = 0;
            string password;

            do
            {
                password = GeneratePassword(Configuration);
                attempts++;
            } while (attempts < Configuration.RetryLimit && !ValidatePassword(Configuration, password));

            return attempts < Configuration.RetryLimit ? password : "Generation failed. Try again.";
        }

        /// <summary>
        /// Generates multiple passwords based on the current configuration.
        /// </summary>
        /// <param name="count">The number of passwords to generate.</param>
        /// <returns>A list of generated passwords.</returns>
        public IEnumerable<string> GenerateMultiple(int count)
        {
            var passwords = new List<string>();
            for (var i = 0; i < count; i++)
            {
                passwords.Add(Generate());
            }
            return passwords;
        }

        private static string GeneratePassword(IPasswordConfiguration config)
        {
            var characterSet = config.CharacterPool.ToCharArray();
            var passwordChars = new char[config.Length];

            for (var i = 0; i < config.Length; i++)
            {
                passwordChars[i] = characterSet[GetRandomIndex(0, characterSet.Length - 1)];
            }

            return new string(passwordChars);
        }

        private static int GetRandomIndex(int min, int max)
        {
            var data = new byte[4];
            RandomGenerator.GetBytes(data);
            int randomValue = BitConverter.ToInt32(data, 0);
            return new Random().Next(min, max);
        }

        private static bool ValidatePassword(IPasswordConfiguration config, string password)
        {
            return Regex.IsMatch(password, "[a-z]") == config.HasLowercase
                && Regex.IsMatch(password, "[A-Z]") == config.HasUppercase
                && Regex.IsMatch(password, "[0-9]") == config.HasNumbers
                && Regex.IsMatch(password, "[!@#$%^&*]") == config.HasSymbols;
        }
    }
}
