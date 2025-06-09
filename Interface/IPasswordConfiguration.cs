using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Interface
{
    public interface IPasswordConfiguration
    {
        bool HasLowercase { get; }
        bool HasUppercase { get; }
        bool HasNumbers { get; }
        bool HasSymbols { get; }
        int Length { get; set; }
        string CharacterPool { get; }
        int RetryLimit { get; }
        int MinLength { get; }
        int MaxLength { get; }
        IPasswordConfiguration EnableLowercase();
        IPasswordConfiguration EnableUppercase();
        IPasswordConfiguration EnableNumbers();
        IPasswordConfiguration EnableSymbols();
        IPasswordConfiguration EnableCustomSymbols(string customSymbols);
        string SymbolSet { get; set; }
    }
}
