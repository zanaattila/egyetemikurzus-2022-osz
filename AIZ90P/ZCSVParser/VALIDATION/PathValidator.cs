using System;
using System.IO;
using System.Linq;
using System.Security;

namespace ZCSVParser.VALIDATION
{
    public static class PathValidator
    {
        public static bool CanWorkWithPath(string QuestionableInputPath, string QuestionableOutputPath)
        {
            if (!Directory.Exists(QuestionableInputPath) || !Directory.Exists(QuestionableOutputPath))
            {
                Console.WriteLine("Nem lehet dolgozni a mappával, mert nem létezik");
                return false;
            }

            foreach (char InvalidPathChar in Path.GetInvalidPathChars())
            {
                if (QuestionableInputPath.Contains(InvalidPathChar) || QuestionableOutputPath.Contains(InvalidPathChar))
                {
                    Console.WriteLine("Ezt az elérési utat nem használhatod, mert tartalmaz invalid karaktert!");
                    return false;
                }
            }

            try
            {
                GLOBALS.InputFiles = Directory.EnumerateFiles(QuestionableInputPath, "*.csv").ToList<string>();
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
            GLOBALS.InputPath = QuestionableInputPath;
            GLOBALS.OutputPath = QuestionableOutputPath;
            return true;
        }
    }
}
