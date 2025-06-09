using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Interface
{
    public interface IPasswordBuilder
    {
        IPasswordBuilder WithLowercase();
        IPasswordBuilder WithUppercase();
        IPasswordBuilder WithNumbers();
        IPasswordBuilder WithSymbols();
        IPasswordBuilder WithCustomSymbols(string symbols);
        IPasswordBuilder WithLength(int length);
        string Generate();
        IEnumerable<string> GenerateMultiple(int count);
    }
}
