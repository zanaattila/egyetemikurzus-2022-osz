using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Commands
{
    internal class ExitCommand : IConsoleCommand
    {
        public string Name => "Exit";

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
