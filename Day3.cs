namespace AOC2022
{
    public class Day3 : Day
    {
        public void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day3.txt");

            var prioSum = 0;
            foreach(string rcksck in inputLines)
            {
                // split to compartments
                var middle = rcksck.Length / 2;
                var comp1 = rcksck.Take(middle).ToList();
                var comp2 = rcksck.Skip(middle).Take(middle).ToList();

                // find duplicates in compartments
                var dup = comp1.Intersect(comp2).ToList();
                var dupItem = dup.First();

                // get prio of duplicate
                var dupItemPrio = ConvertCharToPrio(dupItem);

                // add to sum
                prioSum += dupItemPrio;
            }

            Console.WriteLine($":: Final Score = {prioSum}");

            StopExec();
        }

        private int ConvertCharToPrio(char c)
        {
            var offset = 96;
            if (64 < c && 91 > c){ offset = (65 - 27);}
            return c - offset;
        }
    }
}