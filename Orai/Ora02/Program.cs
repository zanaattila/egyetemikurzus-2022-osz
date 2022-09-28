// See https://aka.ms/new-console-template for more information
using Ora02;

Console.WriteLine("Hello, World!");

var teszt1 = new ReferencaErtekPelda
{
    X = 22,
    Y = 10,
};

var teszt2 = new ReferencaErtekPelda
{
    X = 22,
    Y = 10,
};

Console.WriteLine(teszt1.Equals(teszt2));