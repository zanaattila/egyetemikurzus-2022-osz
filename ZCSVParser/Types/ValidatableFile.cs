using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCSVParser.Types
{
    public class ValidatableFile
    {
        public string Name { get; }
        public string FileName { get; }
        public bool isReadonly { get; set; }
        public ValidatableFile(string path)
        {
            Name = Path.GetFileNameWithoutExtension(path);
            FileName = Path.GetFileName(path);
            isReadonly = true;
        }
    }
}
