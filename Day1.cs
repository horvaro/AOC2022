using System;
using System.Globalization;

namespace AOC2022
{
    public static class Day1
    {
        public static void Part1(){
            var maxCalories = (int)0;

            // LOAD puzzle input
            Console.WriteLine(":: Load Input");
            string[] inputLines = System.IO.File.ReadAllLines("./puzzles/Day1.txt");

            Console.WriteLine($":::: Input has {inputLines.Length} lines");

            Console.WriteLine(":: Go trough input and find Elf carrying the most Calories");

            var currentCals = (int)0;
            var calories = (int)0;
            foreach (string line in inputLines)
            {
                if (string.IsNullOrEmpty(line)){
                    // list of calories for an elf ended
                    maxCalories = currentCals > maxCalories ? currentCals : maxCalories;
                    currentCals = 0;
                }
                else{
                    _ = int.TryParse(line, CultureInfo.InvariantCulture, out calories);
                    currentCals += calories;
                }
            }

            Console.WriteLine($":: Most Calories = {maxCalories}");
        }
    }
}