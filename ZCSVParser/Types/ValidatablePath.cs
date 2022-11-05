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
        public string FolderPath { get; }
        public string FullPath { get; }
        public string FileName { get; }
        public ValidatablePath(string path)
        {
            FolderPath = Path.GetDirectoryName(path);
            FullPath = path;
            FileName = Path.GetFileName(path);
        }
    }
}
