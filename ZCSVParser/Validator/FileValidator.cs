using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCSVParser.Validator
{
    public sealed class FileValidator : IValidator
    {
        public bool Validate(string validatable)
        {
            throw new NotImplementedException();
        }

        public bool Validate(IEnumerable<string> validatables)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string[] validatables)
        {
            throw new NotImplementedException();
        }
    }
}
