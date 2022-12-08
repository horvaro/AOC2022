namespace AOC2022
{
    public class Day8 : Day
    {
        public void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day8.txt");

            var visibleTrees = 0;

            // Create 2D Array, which is as wide as a sinlge line in inputLines
            // and as long as the whole file
            var forestMap = new int[inputLines.Count(),inputLines[0].Length];

            for (int i=0; i < forestMap.GetLength(0); i++)
            {
                var forestSlice = inputLines[i];
                for (int j=0; j < forestMap.GetLength(1); j++)
                {
                    forestMap[i,j] = ParseInt(forestSlice[j]);
                }
            }

            // Add Edge Trees, they are always visible
            visibleTrees += ( (2 * forestMap.GetLength(0)) + (2 * (forestMap.GetLength(1) - 2)) );

            // Run For-Loop inside Forest-Edge
            var IsTreeVisible = false;
            for (int i=1; i < (forestMap.GetLength(0) -1); i++)
            {
                for (int j=1; j < (forestMap.GetLength(1) -1); j++)
                {
                    IsTreeVisible = false;

                    //From Top
                    var fromTopInvis = Enumerable.Range(0,i)
                                                .Select(x => forestMap[x,j])
                                                .Where(x => x >= forestMap[i,j])
                                                .Any();

                    //From Bottom
                    var fromBottomInvis = Enumerable.Range(i+1, forestMap.GetLength(0)-(i+1))
                                                .Select(x => forestMap[x,j])
                                                .Where(x => x >= forestMap[i,j])
                                                .Any();

                    //From Left
                    var fromLeftInvis = Enumerable.Range(0, j)
                                                .Select(x => forestMap[i,x])
                                                .Where(x => x >= forestMap[i,j])
                                                .Any();

                    //From Right
                    var fromRightInvis = Enumerable.Range(j+1, forestMap.GetLength(1)-(j+1))
                                                .Select(x => forestMap[i,x])
                                                .Where(x => x >= forestMap[i,j])
                                                .Any();

                    IsTreeVisible = !fromTopInvis || !fromBottomInvis || !fromLeftInvis || !fromRightInvis;

                    //Console.WriteLine($"Tree at [{i}][{j}] (={forestMap[i,j]}) visible = {IsTreeVisible}");

                    if (IsTreeVisible) visibleTrees++;
                }
            }

            Console.WriteLine($":: Visible Trees = {visibleTrees}");

            StopExec();
        }
    }
}