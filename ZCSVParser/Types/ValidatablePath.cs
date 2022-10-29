using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCSVParser.Types
{
    public class ValidatablePath
    {
        public string FolderName { get; }
        public string FolderPath { get; }
        public ValidatablePath(string path)
        {
            FolderName = Path.GetDirectoryName(path);
            FolderPath = path;
        }
    }
}
