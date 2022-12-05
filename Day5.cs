using System.Collections;

namespace AOC2022
{
    public class Day5 : Day
    {
        public void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day5.txt");
            var crateInitState = new List<string>();
            var loadProcedure = new List<string>();
            var numCrates = 0;

            var crateDefinitionLoaded = false;
            foreach(string line in inputLines)
            {
                if (!crateDefinitionLoaded)
                {
                    if (line.StartsWith('['))
                    {
                        crateInitState.Add(line);
                    }
                    else{
                        var cratesCount = line.Trim().Split(' ').Last();
                        numCrates = ParseInt(cratesCount);
                        crateDefinitionLoaded = true;
                    }
                }
                else
                {
                    loadProcedure.Add(line);
                }
            }

            var crates = new List<Stack<string>>();
            for (int i = 0; i < numCrates; i++) { crates.Add(new Stack<string>()); }

            // Load Init Crate State
            crateInitState.Reverse();
            foreach (var crateLine in crateInitState)
            {
                Console.WriteLine(crateLine);
                var crateEnumerator = crates.GetEnumerator();
                for (int i = 0; i < crateLine.Length; i+=4)
                {
                    var crateItem = crateLine.Substring(i,3);
                    crateEnumerator.MoveNext();
                    if (!string.IsNullOrEmpty(crateItem.Trim()))
                    {
                        crateEnumerator.Current.Push(crateItem);
                    }
                }
            }

            // Step Through procedure moves
            foreach (var procStep in loadProcedure.Skip(1))  //Skip 1 empty string line
            {
                var command = procStep.Split(' ');
                var ammount = ParseInt(command[1]);
                var from = ParseInt(command[3]) -1;
                var to = ParseInt(command[5]) -1;

                for (int i=0; i < ammount; i++){
                    crates[to].Push(crates[from].Pop());
                }
            }

            var topCrates = string.Empty;
            crates.ForEach(c => topCrates += c.Pop());
            topCrates = topCrates.Replace("[","").Replace("]","");

            Console.WriteLine($":: Top Crates = {topCrates}");

            StopExec();
        }
    }
}