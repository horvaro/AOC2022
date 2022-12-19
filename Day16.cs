using System.Text.RegularExpressions;

namespace AOC2022
{
    public class Day16 : Day
    {
        public static void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day16Example.txt");
            var lineRegex = new Regex(
                @"^Sensor at x=(-?\d+), y=(-?\d+): closest beacon is at x=(-?\d+), y=(-?\d+)$",
                RegexOptions.Compiled  // Will be compiled at init, for exec performance
            );
            var sum = 0;

            foreach (string line in inputLines)
            {
                // ToDo
            }

            Console.WriteLine($":: Final Score = {sum}");

            StopExec();
        }
    }
}