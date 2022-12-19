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
                @"^Valve (\S{2}) has flow rate=(-?\d+); tunnel(s?) lead(s?) to valve(s?) ((\S{2}(, )?)+)",
                RegexOptions.Compiled  // Will be compiled at init, for exec performance
            );
            var sum = 0;

            var flowRateLUT = new Dictionary<string,int>();
            var valveConnections = new Dictionary<string,IList<string>>();

            foreach (string line in inputLines)
            {
                var regexMatch = lineRegex.Match(line);
                var valve = regexMatch.Groups[1].Value;
                var flow = Convert.ToInt32(regexMatch.Groups[2].Value);
                var connectedValves = regexMatch.Groups[6].Value.Split(',').AsEnumerable()
                                                .Select(v => v.Trim()).ToList();
                flowRateLUT.Add(valve, flow);
                valveConnections.Add(valve, connectedValves);
            }

            var closedValves = new HashSet<string>();
            for(var time = 30; time > 0; time--)
            {

            }

            Console.WriteLine($":: Final Score = {sum}");

            StopExec();
        }
    }
}