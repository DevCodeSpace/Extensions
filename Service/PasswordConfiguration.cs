using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extensions.Interface;

namespace Extensions.Service
{
    /// <summary>
    /// Configuration class for password generation settings.
    /// </summary>
    public class PasswordConfiguration : IPasswordConfiguration
    {
        private const string Lowercase = "abcdefghijklmnopqrstuvwxyz";
        private const string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";
        private const string DefaultSymbols = "!@#$%^&*";

        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordConfiguration"/> class with specified settings.
        /// </summary>
        /// <param name="lowercase">Include lowercase letters.</param>
        /// <param name="uppercase">Include uppercase letters.</param>
        /// <param name="numbers">Include numbers.</param>
        /// <param name="symbols">Include symbols.</param>
        /// <param name="length">Length of the password.</param>
        /// <param name="retries">Retry limit for password generation.</param>
        public PasswordConfiguration(bool lowercase, bool uppercase, bool numbers, bool symbols, int length, int retries)
        {
            HasLowercase = lowercase;
            HasUppercase = uppercase;
            HasNumbers = numbers;
            HasSymbols = symbols;
            Length = length;
            RetryLimit = retries;
            CharacterPool = BuildCharacterPool();
        }

        public bool HasLowercase { get; private set; }
        public bool HasUppercase { get; private set; }
        public bool HasNumbers { get; private set; }
        public bool HasSymbols { get; private set; }
        public int Length { get; set; }
        public int RetryLimit { get; }
        public string CharacterPool { get; private set; }
        public string SymbolSet { get; set; } = DefaultSymbols;

        public int MinLength => 4;
        public int MaxLength => 100;

        public IPasswordConfiguration EnableLowercase()
        {
            HasLowercase = true;
            CharacterPool += Lowercase;
            return this;
        }

        public IPasswordConfiguration EnableUppercase()
        {
            HasUppercase = true;
            CharacterPool += Uppercase;
            return this;
        }

        public IPasswordConfiguration EnableNumbers()
        {
            HasNumbers = true;
            CharacterPool += Digits;
            return this;
        }

        public IPasswordConfiguration EnableSymbols()
        {
            HasSymbols = true;
            CharacterPool += SymbolSet;
            return this;
        }

        public IPasswordConfiguration EnableCustomSymbols(string customSymbols)
        {
            HasSymbols = true;
            SymbolSet = customSymbols;
            CharacterPool += SymbolSet;
            return this;
        }

        private string BuildCharacterPool()
        {
            var pool = string.Empty;
            if (HasLowercase) pool += Lowercase;
            if (HasUppercase) pool += Uppercase;
            if (HasNumbers) pool += Digits;
            if (HasSymbols) pool += SymbolSet;
            return pool;
        }
    }
}
