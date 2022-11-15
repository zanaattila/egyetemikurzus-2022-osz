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
using ZCSVParser.RECORDS;
using ZCSVParser.VALIDATION;

namespace ZCSVParser
{
    class Program
    {
        static void Help()
        {
            Console.WriteLine($"Használat: ./{System.AppDomain.CurrentDomain.FriendlyName} /utvonal/a/bemenethez /utvonal/a/kimenethez");
        }

        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Pontosan kettő paramétert kell megadj: A mappát, ahonnan olvasok, és egy másikat, ahova exportálok.");
                Help();
                Environment.Exit(-2);
            }
            if (!PathValidator.CanWorkWithPath(args[0], args[1]))
            {
                Console.WriteLine("Erről az útvonalról/útvonalra nem tudok dolgozni! Kérlek válassz másikat!");
                Console.WriteLine($"Feltételezett INPUT: {args[0]}");
                Console.WriteLine($"Feltételezett OUTPUT: {args[1]}");
                Environment.Exit(-1);
            }
            var lines = new BlockingCollection<string>();

            var readStage = Task.Run(() =>
            {
                try
                {
                    foreach (var filePath in GLOBALS.InputFiles)
                    {
                        using (var reader = new StreamReader(filePath))
                        {
                            string line;
                            reader.ReadLine();
                            while ((line = reader.ReadLine()) != null)
                            {
                                lines.Add(line);
                                //Console.WriteLine(line);
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
                    DateTime datum;
                    DateTime.TryParse(splittedLine[0], out datum);
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
            Task.WaitAll( readStage, processStage );
            Console.WriteLine("A fájlok beolvasása kész!");
            DataExporter.ExportNapiAdagXML(GLOBALS.filesorok);
            DataExporter.ExportNapiAdagPerEtkezesFajta(GLOBALS.filesorok);
            DataExporter.ExportNapiAdagPerFogyasztoKod(GLOBALS.filesorok);
        }
    }
}
