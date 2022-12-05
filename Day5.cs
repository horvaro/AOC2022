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
            var cratesPart2 = new List<Stack<string>>();
            for (int i = 0; i < numCrates; i++) { crates.Add(new Stack<string>()); }
            for (int i = 0; i < numCrates; i++) { cratesPart2.Add(new Stack<string>()); }

            // Load Init Crate State
            crateInitState.Reverse();
            foreach (var crateLine in crateInitState)
            {
                Console.WriteLine(crateLine);
                var crateEm = crates.GetEnumerator();
                var crate2Em = cratesPart2.GetEnumerator();
                for (int i = 0; i < crateLine.Length; i+=4)
                {
                    var crateItem = crateLine.Substring(i,3);
                    crateEm.MoveNext();
                    crate2Em.MoveNext();
                    if (!string.IsNullOrEmpty(crateItem.Trim()))
                    {
                        crateEm.Current.Push(crateItem);
                        crate2Em.Current.Push(crateItem);
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
                var tmpStack = new Stack<string>();

                for (int i=0; i < ammount; i++){
                    crates[to].Push(crates[from].Pop());
                    tmpStack.Push(cratesPart2[from].Pop()); // Push to Temp Stack for retaining order for Part2
                }

                // Pop From tempstack. Reverses Order Again -> Target Crate gets correct order for Part2
                for (int i=0; i < ammount; i++){
                    cratesPart2[to].Push(tmpStack.Pop());
                }
            }

            var topCrates = string.Empty;
            var topCreatesPart2 = string.Empty;
            crates.ForEach(c => topCrates += c.Pop());
            cratesPart2.ForEach(c => topCreatesPart2 += c.Pop());
            topCrates = topCrates.Replace("[","").Replace("]","");
            topCreatesPart2 = topCreatesPart2.Replace("[","").Replace("]","");

            Console.WriteLine($":: Top Crates = {topCrates}");
            Console.WriteLine($":: Top Crates with CreateMover 9001 = {topCreatesPart2}");

            StopExec();
        }
    }
}