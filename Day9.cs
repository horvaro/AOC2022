namespace AOC2022
{
    public class Day9 : Day
    {
        public static void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day9.txt");
            var visitedPositions = new HashSet<string>();
            var map = new int[100,100];
            var head = new RopeEnd();
            var tail = new RopeEnd();

            head.UpdatePos(50,50);
            tail.UpdatePos(50,50);
            visitedPositions.Add(tail.Position);
            //PrintMap(map,head,tail);

            foreach (string line in inputLines)
            {
                var command = line.Split(' ');
                var steps = Convert.ToInt16(command[1]);
                var direction = command[0];

                //Console.WriteLine($"=== {line}");

                for (int i=0; i<steps; i++)
                {
                    var isLastStep = i+1 == steps;
                    // Move Head
                    switch (direction)
                    {
                        case "U":
                            head.UpdatePos(head.X-1,head.Y);
                            UpdateTail(tail, head, tail.X-1, tail.Y, isLastStep);
                            break;
                        case "D":
                            head.UpdatePos(head.X+1,head.Y);
                            UpdateTail(tail, head, tail.X+1, tail.Y, isLastStep);
                            break;
                        case "L":
                            head.UpdatePos(head.X,head.Y-1);
                            UpdateTail(tail, head, tail.X, tail.Y-1, isLastStep);
                            break;
                        case "R":
                            head.UpdatePos(head.X,head.Y+1);
                            UpdateTail(tail, head, tail.X, tail.Y+1, isLastStep);
                            break;
                        default:
                            break;
                    }

                    // Move Tail

                    //PrintMap(map,head,tail);

                    visitedPositions.Add(tail.Position);
                }
            }

            Console.WriteLine($":: Tail visited {visitedPositions.Count()} positions");
            StopExec();
        }

        private static void UpdateTail(RopeEnd tail, RopeEnd head, int proposedX, int proposedY, bool isLastStep)
        {
            // Check if Tail touches Head before moving
            if (IsTailTouchingHead(tail, head))
            {
                return;
            }
            // Check for diagonal
            else if ((Math.Abs(tail.X - head.X) == 1) && (Math.Abs(tail.Y - head.Y) == 1))
            {
                //Console.WriteLine("DIAGONAL HEAD and TAIL");

                if (isLastStep)
                {
                    //Console.WriteLine("... but last step = no change");
                    return;
                }
                else if (proposedX != tail.X)
                {
                    var proposedTail = new RopeEnd();
                    proposedTail.UpdatePos(tail.X, head.Y);

                    //Console.WriteLine($"Head={head.Position}, x={proposedX}, y={proposedY}, Tail={tail.Position}, ProposedTail={proposedTail.Position}");

                    tail.UpdatePos(proposedTail.X, proposedTail.Y);
                }
                else if (proposedY != tail.Y)
                {
                    var proposedTail = new RopeEnd();
                    proposedTail.UpdatePos(head.X, tail.Y);

                    //Console.WriteLine($"Head={head.Position}, x={proposedX}, y={proposedY}, Tail={tail.Position}, ProposedTail={proposedTail.Position}");

                    tail.UpdatePos(proposedTail.X, proposedTail.Y);
                }
            }
            else if (!(proposedX == head.X && proposedY == head.Y))
            {
                tail.UpdatePos(proposedX, proposedY);
            }
        }

        private static bool IsTailTouchingHead(RopeEnd tail, RopeEnd head)
        {
            var down = (tail.X+1 == head.X && tail.Y == head.Y);
            var up = (tail.X-1 == head.X && tail.Y == head.Y);
            var right = (tail.Y-1 == head.Y && tail.X == head.X);
            var left = (tail.Y+1 == head.Y && tail.X == head.X);
            return down || up || left || right;
        }

        private static bool IsTailAdjToHead(RopeEnd head, RopeEnd tail)
        {
            return IsNeighbourInt(tail.X, head.X) && IsNeighbourInt(tail.Y, head.Y);
        }

        private static bool IsNeighbourInt(int a, int b)
        {
            return (b+1 == a) || (b-1 == a);
        }

        private static void PrintMap(int[,] map, RopeEnd head, RopeEnd tail)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    var point = (tail.X==i && tail.Y==j) ? "T" : ".";
                    point = (head.X==i && head.Y==j) ? "H" : point;
                    Console.Write(point);
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
        }

        internal class RopeEnd
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string Position => $"{X},{Y}";

            public void UpdatePos(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}