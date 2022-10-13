using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Commands
{
    internal sealed class TimeCommand : IConsoleCommand
    {
        public string Name => "Time";

        public void Execute()
        {
            Console.WriteLine($"{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}");
        }
    }
}
