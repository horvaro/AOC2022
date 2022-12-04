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
            //var consoleAnswer = "1";

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
                default:
                    Console.WriteLine(":::: No such AOC2022 Day found. Bye ...");
                    break;
            }
        }
    }
}