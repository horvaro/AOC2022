namespace AOC2022
{
    public abstract class Day0 : Day
    {
        public static void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day0.txt");

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