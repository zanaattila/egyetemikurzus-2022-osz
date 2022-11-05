using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using ZCSVParser.Types;

namespace ZCSVParser.Validator
{
    public sealed class PathValidator : IValidator
    {
        private readonly ValidatablePath _path;
        public PathValidator(string path)
        {
            _path = new ValidatablePath(path);
        }

        public bool Validate()
        {
            if (!Directory.Exists(_path.FullPath)) {
                Console.WriteLine($"Nem létezik a {_path.FolderPath} az adott útvonallal: {_path.FullPath}");
                return false;
            }
            return true;
        }
    }
}
