namespace AOC2022
{
    public class Day8 : Day
    {
        public void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day8.txt");

            var visibleTrees = 0;

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
                    var fromTopInvis = Enumerable.Range(0,i)
                                                .Select(x => forestMap[x,j])
                                                .Where(x => x >= forestMap[i,j])
                                                .Any();

                    var fromBottomInvis = Enumerable.Range(i+1, forestMap.GetLength(0)-(i+1))
                                                .Select(x => forestMap[x,j])
                                                .Where(x => x >= forestMap[i,j])
                                                .Any();

                    var fromLeftInvis = Enumerable.Range(0, j)
                                                .Select(x => forestMap[i,x])
                                                .Where(x => x >= forestMap[i,j])
                                                .Any();

                    var fromRightInvis = Enumerable.Range(j+1, forestMap.GetLength(1)-(j+1))
                                                .Select(x => forestMap[i,x])
                                                .Where(x => x >= forestMap[i,j])
                                                .Any();

                    IsTreeVisible = !fromTopInvis || !fromBottomInvis || !fromLeftInvis || !fromRightInvis;

                    if (IsTreeVisible) visibleTrees++;
                }
            }

            Console.WriteLine($":: Visible Trees = {visibleTrees}");
            StopExec();

            Part2(forestMap);
        }

        private void Part2 (int[,] forestMap)
        {
            StartExec();
            Console.WriteLine("::: Part 2");

            var maxScenicScore = 0;

            for (int i=0; i < forestMap.GetLength(0); i++)
            {
                for (int j=0; j < forestMap.GetLength(1); j++)
                {
                    var up = GetViewDistUpwards(i,j,forestMap);
                    var down = GetViewDistDownwards(i,j,forestMap);
                    var left = GetViewDistLeft(i,j,forestMap);
                    var right = GetViewDistRight(i,j,forestMap);
                    var scenicScore = up * down * left * right;

                    maxScenicScore = scenicScore > maxScenicScore ? scenicScore : maxScenicScore;
                }
            }

            Console.WriteLine($":: highest scenic score possible = {maxScenicScore}");

            StopExec();
        }

        private int GetViewDistUpwards(int column, int row, int[,] map)
        {
            if (column==0) return 0;
            var tree = map[column,row];
            var viewDist = 0;
            for (int i=(column-1); i>=0; i--)
            {
                viewDist++;
                if (map[i,row] >= tree) break;
            }
            return viewDist;
        }

        private int GetViewDistDownwards(int column, int row, int[,] map)
        {
            if (column==(map.GetLength(0)-1)) return 0;
            var tree = map[column,row];
            var viewDist = 0;
            for (int i=(column+1); i<map.GetLength(0); i++)
            {
                viewDist++;
                if (map[i,row] >= tree) break;
            }
            return viewDist;
        }

        private int GetViewDistLeft(int column, int row, int[,] map)
        {
            if (row==0) return 0;
            var tree = map[column,row];
            var viewDist = 0;
            for (int i=(row-1); i>=0; i--)
            {
                viewDist++;
                if (map[column,i] >= tree) break;
            }
            return viewDist;
        }

        private int GetViewDistRight(int column, int row, int[,] map)
        {
            if (row==(map.GetLength(1)-1)) return 0;
            var tree = map[column,row];
            var viewDist = 0;
            for (int i=(row+1); i<map.GetLength(1); i++)
            {
                viewDist++;
                if (map[column,i] >= tree) break;
            }
            return viewDist;
        }

    }
}