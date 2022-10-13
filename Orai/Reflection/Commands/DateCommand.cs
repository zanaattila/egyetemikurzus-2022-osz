using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Commands
{
    internal sealed class DateCommand : IConsoleCommand
    {
        public string Name => "Date";

        public void Execute()
        {
            Console.WriteLine($"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}");
        }
    }
}
