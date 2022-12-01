using System;

namespace AOC2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(":::::: AOC 2022");
            Console.WriteLine(":: Which Day do you want to run? ");
            var consoleAnswer = Console.ReadLine();

            consoleAnswer = consoleAnswer?.Trim();

            switch (consoleAnswer)
            {
                case "1":
                    Console.WriteLine(":::: Running Day 1");
                    Day1.Part1();
                    break;
                default:
                    Console.WriteLine("No such AOC2022 Day found. Bye ...");
                    break;
            }
        }
    }
}