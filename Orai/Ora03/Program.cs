// See https://aka.ms/new-console-template for more information
using Ora03;
using System.ComponentModel;

Console.WriteLine("Hello, World!");

int[] pelda = new int[15];

IEnumerable<int> pelda2Items = new int[] { 1, 2, 3, 4, 5 };

foreach (var item in pelda2Items)
{
    Console.WriteLine(item);
}

int[] puruttyaHashSet = new int[15];

//12
puruttyaHashSet[12.GetHashCode() % puruttyaHashSet.Length] = 12;

List<int> list = new List<int>(50);
list.Add(55);

HashSet<int> hashes = new HashSet<int>();
hashes.Add(55);

Dictionary<string, string> keyValuePairs = new();
keyValuePairs["asd"] = "asd";

LinkedList<int> Linkedlist = new LinkedList<int>();
Linkedlist.AddLast(12);

CicaList asd = new CicaList()
{
    "Cirmi",
    "Feri",
    "Girhes",
};