using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ZCSVParser.VALIDATION
{
    public static class PathValidator
    {
        public static bool CanWorkWithPath(string QuestionablePath)
        {
            if (!Directory.Exists(QuestionablePath))
            {
                Console.WriteLine("Nem lehet dolgozni a mappából, mert nem létezik");
                return false;
            }

            foreach(char InvalidPathChar in Path.GetInvalidPathChars())
            {
                if (QuestionablePath.Contains(InvalidPathChar))
                {
                    Console.WriteLine("Ezt az elérési utat nem használhatod, mert tartalmaz invalid karaktert!");
                    return false;
                }
            }

            try
            {
                GLOBALS.InputFiles = (List<string>)Directory.EnumerateFiles(QuestionablePath,"*.csv");
            }
            catch (Exception e) when (e is IOException || e is PathTooLongException)
            {
                Console.WriteLine("Sajnálatos módon valamilyen probléma adódott az Input/Output területen. Ellenőrizze a tárat, és próbálja meg újra!");
                return false;
            }
            catch (Exception e) when (e is UnauthorizedAccessException || e is SecurityException)
            {
                Console.WriteLine("Úgy tűnik, nincs joga hozzáférni egy vagy több fájlhoz. Ellenőrizze a biztonsági beállításokat és próbálja újra!");
                return false;
            }
            GLOBALS.InputPath = QuestionablePath;
            return true;
        }
    }
}
