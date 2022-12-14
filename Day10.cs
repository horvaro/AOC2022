namespace AOC2022
{
    public abstract class Day10 : Day
    {
        public static void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day10.txt");

            var targetCycles = new List<int>() { 20, 60, 100, 140, 180, 220 };
            var signalStrengthSum = 0;

            var regX = 1;
            var cycle = 1;
            var instructionCycles = 1;

            foreach (string line in inputLines)
            {
                var instruction = line.Split(' ');

                switch (instruction[0])
                {
                    case "noop":
                        instructionCycles = 1;
                        break;
                    case "addx":
                        instructionCycles = 2;
                        break;
                    default:
                        break;
                }

                for (var i = 0; i < instructionCycles; i++)
                {
                    if (targetCycles.Contains(cycle))
                    {
                        var signalStrength = regX * cycle;
                        signalStrengthSum += signalStrength;
                    }

                    cycle++;
                }

                switch (instruction[0])
                    {
                        case "addx":
                            regX += Convert.ToInt32(instruction[1]);
                            break;
                        default:
                            break;
                    }
            }

            Console.WriteLine($":: Final Score = {signalStrengthSum}");

            StopExec();

            Part2(inputLines);
        }

        private static void Part2(string[] inputLines)
        {
            StartExec();
            Console.WriteLine("::: Part 2");

            var regX = 1;
            var cycle = 0;
            var instructionCycles = 1;

            foreach (string line in inputLines)
            {
                var instruction = line.Split(' ');

                switch (instruction[0])
                {
                    case "noop":
                        instructionCycles = 1;
                        break;
                    case "addx":
                        instructionCycles = 2;
                        break;
                    default:
                        break;
                }

                for (var i = 0; i < instructionCycles; i++)
                {
                    Draw(cycle, regX);

                    cycle++;
                }

                switch (instruction[0])
                {
                    case "addx":
                        regX += Convert.ToInt32(instruction[1]);
                        break;
                    default:
                        break;
                }
            }

            Console.Write(Environment.NewLine);

            StopExec();
        }

        private static void Draw (int cycle, int regX)
        {
            var crtRow = (cycle % 40);
            if (crtRow == 0)
            {
                Console.Write(Environment.NewLine);
            }
            var pixel = (crtRow >= regX-1 && crtRow <= regX+1) ? "#" : ".";
            Console.Write(pixel);
        }
    }
}