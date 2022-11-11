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
        private readonly ValidatablePath _file;
        private bool isReadOnly { get; set; }
        private bool isReadable { get; set; }
        private bool isWriteable { get; set; }
        public FileValidator(string path)
        {
            _file = new ValidatablePath(path);
            isReadOnly = true;
            isReadable = false;
            isWriteable = false;
        }
        public bool Validate()
        {
            FileAttributes attr = File.GetAttributes(_file.FullPath);
            
            if (!attr.HasFlag(FileAttributes.Directory))
            {
                return false;
            }
            if (!File.Exists(_file.FullPath))
            {
                return false;
            }
            else
            {
                using (var fs = File.Open(_file.FullPath, FileMode.Open))
                {
                    isReadable = fs.CanRead;
                }
            }
            return isReadable;
        }

        public bool IsWriteable()
        {
            if (Validate())
            {
                isReadOnly = new FileInfo(_file.FullPath).Attributes.HasFlag(FileAttributes.ReadOnly);
                using (var fs = File.Open(_file.FullPath, FileMode.Open))
                {
                    isWriteable = fs.CanWrite;
                }
                return !isReadOnly && isWriteable;
            }
            return false;
        }
    }
}
