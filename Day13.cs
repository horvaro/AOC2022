namespace AOC2022
{
    public abstract class Day13 : Day
    {
        public static void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day13Example.txt");

            var listPairs = new List<string[]>();

            var pair = new string[2];
            var pairCount = 0;
            foreach (string line in inputLines)
            {
                if (string.IsNullOrEmpty(line.Trim()))
                {
                    listPairs.Add(pair);
                    pair = new string[2];
                    pairCount = 0;
                }
                else
                {
                    pair[pairCount] = line;
                    pairCount++;
                }
            }
            listPairs.Add(pair);

            foreach (var dataPair in listPairs)
            {
                _ = IsInputInOrder(dataPair, 0);
            }

            //Console.WriteLine($":: Final Score = {sum}");

            StopExec();
        }

        private static bool IsInputInOrder(string[] dataPair, int depth)
        {
            var indent = new String(' ', depth*2);
            var left = dataPair[0];
            var right = dataPair[1];

            Console.WriteLine($"{indent}- Comparing {left} vs {right}");
            
            // Do Both contain items? e.g. only [] ?
                // check which side ran out --> Left ran out = right order
            
            // if both have only 1 int --> compare --> left lower = right order

            // Split by ,
            // Check if both same type
                // do have both sides enough items --> left ran out = right order
                // if both list --> recursion
                // if one is list --> make the other as list too --> recursion
                // if both int --> compare --> left lower = right order

            return true;
        }
    }
}