using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCSVParser.Validator
{
    internal interface IValidator
    {
        bool Validate(string validatable);
        bool Validate(IEnumerable<string> validatables);
        bool Validate(string[] validatables);
    }
}
