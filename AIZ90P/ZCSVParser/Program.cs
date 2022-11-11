using System;
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
        }
    }
}
