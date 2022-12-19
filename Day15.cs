using System.Numerics;
using System.Text.RegularExpressions;
using System.Linq;

namespace AOC2022
{
    public class Day15 : Day
    {
        public static void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day15.txt");
            var lineRegex = new Regex(
                @"^Sensor at x=(-?\d+), y=(-?\d+): closest beacon is at x=(-?\d+), y=(-?\d+)$",
                RegexOptions.Compiled  // Will be compiled at init, for exec performance
            );
            var sensors = new HashSet<Vector2>();
            var beacons = new HashSet<Vector2>();
            var distances = new Dictionary<Vector2,int>();
            var coveredPosOnTargetLine = new HashSet<int>();

            foreach (string line in inputLines)
            {
                var regexMatch = lineRegex.Match(line);
                var s = new Vector2(
                    Convert.ToInt32(regexMatch.Groups[1].Value),
                    Convert.ToInt32(regexMatch.Groups[2].Value)
                );
                var b = new Vector2(
                    Convert.ToInt32(regexMatch.Groups[3].Value),
                    Convert.ToInt32(regexMatch.Groups[4].Value)
                );

                sensors.Add(s);
                beacons.Add(b);
                distances.Add(s,Distance(s,b));
            }

            var targetY = 2000000;

            foreach (var dist in distances)
            {
                var s = dist.Key;
                var d = dist.Value;

                if (IsLineReachable(s, d, targetY)){
                    Console.WriteLine($":::: {s} with distance {d} can reach Y={targetY}");
                    var coveredXPos = CalcCoveredXPos(s, d, targetY);
                    coveredXPos.ToList().ForEach(x => coveredPosOnTargetLine.Add(x));
                }
                else{
                    Console.WriteLine($":::: {s} with distance {d} can NOT reach Y={targetY}");
                }
            }

            Console.WriteLine($":: Final Score = {coveredPosOnTargetLine.Count}");

            StopExec();
        }

        private static ISet<int> CalcCoveredXPos(Vector2 s, int d, int targetY)
        {
            var coveredXPos = new HashSet<int>();

            var sY = Convert.ToInt32(s.Y);
            var sX = Convert.ToInt32(s.X);
            
            if (sY == targetY)
            {
                coveredXPos.Add(sX);
                Enumerable.Range(sX, d).Select(x => coveredXPos.Add(x));
                Enumerable.Range(sX - d, d).Select(x => coveredXPos.Add(x));
            }
            else
            {
                for (var i = 0; i < (d-1); i++)
                {
                    if ((sY > targetY) && (d-i) > targetY)
                    {
                        coveredXPos.Add(sX+i);
                        coveredXPos.Add(sX-i);
                    }
                    else if ((sY < targetY) && (d-i) < targetY)
                    {
                        coveredXPos.Add(sX+i);
                        coveredXPos.Add(sX-i);
                    }
                }
            }

            return coveredXPos;
        }

        private static int Distance(Vector2 s, Vector2 b)
        {
            var x = Math.Abs(s.X - b.X);
            var y = Math.Abs(s.Y - b.Y);
            return Convert.ToInt32(x+y);
        }

        private static bool IsLineReachable(Vector2 s, int d, int y)
        {
            if (s.Y < y)        return (s.Y + d) >= y;
            else if (s.Y > y)   return (s.Y - d) <= y;
            else                return true;
        }
    }
}