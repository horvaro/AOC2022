using System.Numerics;

namespace AOC2022
{
    public abstract class Day12 : Day
    {
        public static void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day12Example.txt");

            var sum = 0;
            var start = new Vector2();
            var end = new Vector2();

            var map = new int[inputLines.Count(),inputLines.First().Length];
            var n = 0;
            foreach (string line in inputLines)
            {
                var elevations = line.ToCharArray();
                for (int i = 0; i < line.Length; i++)
                {
                    var elevation = elevations[i];
                    map[n,i] = elevation;
                    if (elevation.Equals('S')) { start.X = n; start.Y = i; }
                    if (elevation.Equals('E')) { end.X = n; end.Y = i; }
                }
                n++;
            }

            PrintMap(map);



            Console.WriteLine($":: Final Score = {sum}");

            StopExec();
        }

        private static void PrintMap(int[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write((char)map[i,j]);
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
        }
    }
}