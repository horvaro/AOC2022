namespace AOC2022
{
    public class Day4 : Day
    {
        public void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day4.txt");

            var sum = 0;

            foreach(string line in inputLines)
            {
                var elves = line.Split(',');
                var elf1Range = CreateElfRange(elves[0]);
                var elf2Range = CreateElfRange(elves[1]);

                if (elf1Range.First() <= elf2Range.First() && elf1Range.Last() >= elf2Range.Last() ||
                    elf2Range.First() <= elf1Range.First() && elf2Range.Last() >= elf1Range.Last())
                    {
                        sum++;
                    }
            }

            Console.WriteLine($":: Fully Containing assignment pairs = {sum}");

            StopExec();
        }

        private IEnumerable<int> CreateElfRange(string elf)
        {
            var range = elf.Split('-');
            var start = int.Parse(range[0]);
            var end = int.Parse(range[1]);
            return Enumerable.Range(start,end-start+1);
        }

    }
}