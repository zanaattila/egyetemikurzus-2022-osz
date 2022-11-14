using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ZCSVParser.DATATYPES;
using ZCSVParser.VALIDATION;

namespace ZCSVParser
{
    class Program
    {
        static void Help()
        {
            Console.WriteLine($"Használat: ./{System.AppDomain.CurrentDomain.FriendlyName} /utvonal/a/bemenethez /utvonal/a/kimenethez");
        }

        public static async Task ReadAndProcessFiles(List<string> inputFiles)
        {
            var lines = new BlockingCollection<string>();

            var readStage = Task.Run(() =>
            {
                try
                {
                    foreach (var filePath in inputFiles)
                    {
                        using (var reader = new StreamReader(filePath))
                        {
                            string line;

                            while ((line = reader.ReadLine()) != null)
                            {
                                lines.Add(line);
                            }
                        }
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("IO Hiba!");
                }
                finally
                {
                    lines.CompleteAdding();
                }
            });

            var processStage = Task.Run(() =>
            {
                var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };
                Parallel.ForEach(lines.GetConsumingEnumerable(), parallelOptions, line =>
                {
                    string[] splittedLine = line.Split(';');
                    DateOnly datum;
                    DateOnly.TryParse(splittedLine[0], out datum);
                    string FogyasztoKod = splittedLine[1];
                    string FogyasztoTipusKod = splittedLine[2];
                    string EtkezesTipusKod = splittedLine[3];
                    string EtkezesFajtaKod = splittedLine[4];
                    int Adag;
                    int.TryParse(splittedLine[5], out Adag);
                    RendelesInput rendelesInput = new RendelesInput(datum,
                                                                    FogyasztoKod,
                                                                    FogyasztoTipusKod,
                                                                    EtkezesTipusKod,
                                                                    EtkezesFajtaKod,
                                                                    Adag);
                    lock (GLOBALS.filesorok)
                    {
                        GLOBALS.filesorok.Add(rendelesInput);
                    }
                }
                );
            });
            Task.WaitAll(readStage, processStage);
        }

        public static async void RunFileProcessTasks()
        {
             await ReadAndProcessFiles(GLOBALS.InputFiles);
        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Pontosan kettő paramétert kell megadj: A mappát, ahonnan olvasok, és egy másikat, ahova exportálok.");
                Help();
                Environment.Exit(-2);
            }
            if (!PathValidator.CanWorkWithPath(args[0]))
            {
                Console.WriteLine("Erről az útvonalról nem tudok dolgozni! Kérlek válassz másikat!");
                Environment.Exit(-1);
            }
            if (!PathValidator.CanWorkWithPath(args[1]))
            {
                Console.WriteLine("Erre az útvonalra nem tudok dolgozni! Kérlek válassz másikat!");
                Environment.Exit(-1);
            }
            RunFileProcessTasks();
            Console.WriteLine("Halihó!");
        }
    }
}
