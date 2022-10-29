using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCSVParser.Types;

namespace ZCSVParser.Validator
{
    public sealed class FileValidator : IValidator
    {
        private readonly ValidatableFile _file;
        public FileValidator(string path)
        {
            _file = new ValidatableFile(path);
        }
        public bool Validate()
        {
            
        }
    }
}
