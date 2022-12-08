using System.Diagnostics;
using System.Globalization;

namespace AOC2022
{
    public abstract class Day
    {
        private static Stopwatch? _stopwatch;

        protected static void StartExec()
        {
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
        }

        protected static void StopExec()
        {
            if (_stopwatch is not null)
            {
                _stopwatch.Stop();
                Console.WriteLine(":: Elapsed Time is {0} ms", _stopwatch.ElapsedMilliseconds);
            }
        }

        protected static string[] LoadInputFile(string filePath)
        {
            Console.WriteLine(":: Load Input");
            var inputLines = System.IO.File.ReadAllLines(filePath);
            Console.WriteLine($":: Input has {inputLines.Length} lines");
            return inputLines;
        }

        protected static int ParseInt(string input)
        {
            var parseState = int.TryParse(input, CultureInfo.InvariantCulture, out int integer);
            return parseState ? integer : throw new ArgumentOutOfRangeException();
        }

        protected static int ParseInt(char input)
        {
            return ParseInt(input.ToString());
        }
    }
}