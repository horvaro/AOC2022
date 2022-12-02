namespace AOC2022
{
    public class Day2 : Day
    {
        public void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day2.txt");

            // Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock.
            // If both players choose the same shape, the round instead ends in a draw.
            // Hands:
            //   A for Rock, B for Paper, and C for Scissors
            //   X for Rock, Y for Paper, and Z for Scissors
            // Scores:
            //   1 for Rock, 2 for Paper, and 3 for Scissors
            //   0 if you lost, 3 if the round was a draw, and 6 if you won

            var score = 0;

            var roundScore = 0;
            foreach(string round in inputLines){
                var hands = round.ToCharArray();
                var opponent = hands[0];
                var me = hands[2];

                // Did I lost?
                if (opponent.Equals('A') && me.Equals('Z') ||
                    opponent.Equals('B') && me.Equals('X') ||
                    opponent.Equals('C') && me.Equals('Y'))
                {
                    roundScore = 0;
                }
                // Did I win?
                else if (me.Equals('X') && opponent.Equals('C') ||
                         me.Equals('Y') && opponent.Equals('A') ||
                         me.Equals('Z') && opponent.Equals('B'))
                {
                    roundScore = 6;
                }
                // Draw
                else if (me.Equals('X') && opponent.Equals('A') ||
                         me.Equals('Y') && opponent.Equals('B') ||
                         me.Equals('Z') && opponent.Equals('C'))
                {
                    roundScore = 3;
                }
                else
                {
                    // This should not happen
                    Console.WriteLine($"ERROR!! Opponent={opponent}, Me={me}");
                    break;
                }

                // ASCII X = 88
                roundScore += ((int)me - 87);
                score += roundScore;
            }

            Console.WriteLine($":: Final Score = {score}");

            StopExec();

            Part2(inputLines);
        }

        private static void Part2(string[] inputLines)
        {
            StartExec();
            Console.WriteLine("::: Part 2");

            // X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win
            // Scores:
            //   1 for Rock, 2 for Paper, and 3 for Scissors
            //   0 if you lost, 3 if the round was a draw, and 6 if you won
            // Hands:
            //   A for Rock, B for Paper, and C for Scissors
            // Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock.

            var score = 0;

            var roundScore = 0;
            foreach(string round in inputLines){
                var hands = round.ToCharArray();
                var opponent = hands[0];
                var result = hands[2];

                switch (result)
                {
                    case 'X':  // Lose
                        if      (opponent.Equals('A')) { roundScore = 3; }
                        else if (opponent.Equals('B')) { roundScore = 1; }
                        else if (opponent.Equals('C')) { roundScore = 2; }
                        // roundscore += 0;
                        break;
                    case 'Y':  // Draw
                        if      (opponent.Equals('A')) { roundScore = 1; }
                        else if (opponent.Equals('B')) { roundScore = 2; }
                        else if (opponent.Equals('C')) { roundScore = 3; }
                        roundScore += 3;
                        break;
                    case 'Z':  // Win
                        if      (opponent.Equals('A')) { roundScore = 2; }
                        else if (opponent.Equals('B')) { roundScore = 3; }
                        else if (opponent.Equals('C')) { roundScore = 1; }
                        roundScore += 6;
                        break;
                    default:
                        Console.WriteLine($"ERROR!! result={result}");
                        break;
                }

                score += roundScore;
            }

            Console.WriteLine($":: Final Score = {score}");

            StopExec();
        }
    }
}