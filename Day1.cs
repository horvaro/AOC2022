using System.Globalization;

namespace AOC2022
{
    public class Day1 : Day
    {
        public void Part1()
        {
            StartExec();

            var maxCalories = (int)0;
            var elves = new List<List<int>>();
            var elf = new List<int>();
            var inputLines = LoadInputFile("./puzzles/Day1.txt");

            var currentCals = (int)0;
            var calories = (int)0;
            
            foreach (string line in inputLines)
            {
                if (string.IsNullOrEmpty(line)){
                    // list of calories for an elf ended
                    maxCalories = currentCals > maxCalories ? currentCals : maxCalories;
                    currentCals = 0;
                    elves.Add(elf);
                    elf = new List<int>();
                }
                else{
                    _ = int.TryParse(line, CultureInfo.InvariantCulture, out calories);
                    currentCals += calories;
                    elf.Add(calories);
                }
            }

            Console.WriteLine($":: Most Calories = {maxCalories}");

            StopExec();

            Part2(elves);
        }

        private void Part2(List<List<int>> elves)
        {
            StartExec();
            Console.WriteLine("::: Part 2");

            var order = new SortedSet<int>();

            var elfCal = 0;
            foreach(List<int> elf in elves)
            {
                elfCal = elf.Aggregate( (a, b) => a + b );

                order.Add(elfCal);
            }

            var topThreeSum = order.Reverse().Take(3).Aggregate( (a,b) => a+b );

            Console.WriteLine($":: Top 3 Most Calories = {topThreeSum}");

            StopExec();
        }
    }
}