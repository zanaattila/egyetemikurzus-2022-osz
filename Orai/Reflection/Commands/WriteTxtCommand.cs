using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reflection.Commands
{
    internal class WriteTxtCommand : IConsoleCommand
    {
        public string Name => "WriteTxt";

        public async void Execute()
        {

            //var appDir = AppContext.BaseDirectory;
            //Stream stream = File.Create(Path.Combine(appDir, "asd.txt"));
            //StreamWriter sw = new StreamWriter(stream);
            ////okés
            //try
            //{
            //    var zero = 0;
            //    sw.WriteLine($"{1 / zero}");
            //}
            //finally
            //{
            //    sw.Close();
            //    stream.Close();
            //}
            var appDir = AppContext.BaseDirectory;
            using (StreamWriter txt = File.CreateText(Path.Combine(appDir, "asd.txt")))
            {
                txt.WriteLine("Hello file");

                /*Thread t = new Thread(() =>
                {
                    Console.WriteLine("Another thread");
                });

                t.Start();*/

                await txt.WriteLineAsync("Hello async");

                //Thread vs Process Potected mode
            }
        }
    }
}
