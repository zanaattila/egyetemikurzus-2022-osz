using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Reflection.Commands
{
    internal class ListDrivesCommand : IConsoleCommand
    {
        public string Name => "ListDrives";

        public void Execute()
        {
            try
            {
                string[] drives = Directory.GetLogicalDrives();
                foreach (var drive in drives)
                {
                    Console.WriteLine(drive);
                }

                throw new IOException();
            }
            catch (Exception e) when (e is IOException ||
            e is UnauthorizedAccessException)
            {
                Debug.WriteLine("Ez egy debug üzenet");
            }
        }
    }
}
