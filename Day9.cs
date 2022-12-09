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
            var prevHead = new RopeEnd();
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
                    prevHead.UpdatePos(head.X, head.Y);
                    // Move Head
                    switch (direction)
                    {
                        case "U":
                            head.UpdatePos(head.X-1,head.Y);
                            break;
                        case "D":
                            head.UpdatePos(head.X+1,head.Y);
                            break;
                        case "L":
                            head.UpdatePos(head.X,head.Y-1);
                            break;
                        case "R":
                            head.UpdatePos(head.X,head.Y+1);
                            break;
                        default:
                            break;
                    }

                    // Move Tail
                    MoveTail(tail, head, prevHead);
                    //PrintMap(map,head,tail);

                    visitedPositions.Add(tail.Position);
                }
            }

            Console.WriteLine($":: Tail visited {visitedPositions.Count()} positions");
            StopExec();
        }

        private static void MoveTail(RopeEnd tail, RopeEnd head, RopeEnd prevHead)
        {
            if (IsTailTouchingHead(tail, head))
            {
                return;
            }
            else
            {
                tail.UpdatePos(prevHead.X, prevHead.Y);
            }
        }

        private static bool IsTailTouchingHead(RopeEnd tail, RopeEnd head)
        {
            return (tail.X+1 == head.X && tail.Y == head.Y) ||
                   (tail.X-1 == head.X && tail.Y == head.Y) ||
                   (tail.X+1 == head.X && tail.Y+1 == head.Y) ||
                   (tail.X-1 == head.X && tail.Y+1 == head.Y) ||
                   (tail.X+1 == head.X && tail.Y-1 == head.Y) ||
                   (tail.X-1 == head.X && tail.Y-1 == head.Y) ||
                   (tail.X == head.X && tail.Y+1 == head.Y) ||
                   (tail.X == head.X && tail.Y-1 == head.Y) ||
                   (tail.X == head.X && tail.Y == head.Y);
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