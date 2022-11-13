using System;
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
            if(args.Length != 2)
            {
                Console.WriteLine("Pontosan kettő paramétert kell megadj: A mappát, ahonnan olvasok, és egy másikat, ahova exportálok.");
                Help();
            }
            if (!PathValidator.CanWorkFromPath(args[0]))
            {
                Console.WriteLine("Erről az útvonalról nem tudok dolgozni! Kérlek válassz másikat!");
                Environment.Exit(-1);
            }
            if (!PathValidator.CanWorkFromPath(args[1]))
            {
                Console.WriteLine("Erre az útvonalra nem tudok dolgozni! Kérlek válassz másikat!");
                Environment.Exit(-1);
            }
        }
    }
}
