namespace AOC2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(":::::: AOC 2022 ::::::");
            Console.WriteLine(":::: Which Day do you want to run? ");
            var consoleAnswer = Console.ReadLine();

            //DEBUG
            //var consoleAnswer = "8";

            consoleAnswer = consoleAnswer?.Trim();

            switch (consoleAnswer)
            {
                case "1":
                    Console.WriteLine(":::: Running Day 1");
                    (new Day1()).Part1();
                    break;
                case "2":
                    Console.WriteLine(":::: Running Day 2");
                    (new Day2()).Part1();
                    break;
                case "3":
                    Console.WriteLine(":::: Running Day 3");
                    (new Day3()).Part1();
                    break;
                case "4":
                    Console.WriteLine(":::: Running Day 4");
                    (new Day4()).Part1();
                    break;
                case "5":
                    Console.WriteLine(":::: Running Day 5");
                    (new Day5()).Part1();
                    break;
                case "6":
                    Console.WriteLine(":::: Running Day 6");
                    (new Day6()).Part1();
                    break;
                case "7":
                    Console.WriteLine(":::: Running Day 7");
                    (new Day7()).Part1();
                    break;
                case "8":
                    Console.WriteLine(":::: Running Day 8");
                    Day8.Part1();
                    break;
                case "9":
                    Console.WriteLine(":::: Running Day 9");
                    Day9.Part1();
                    break;
                default:
                    Console.WriteLine(":::: No such AOC2022 Day found. Bye ...");
                    break;
            }
        }
    }
}