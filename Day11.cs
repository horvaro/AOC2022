namespace AOC2022
{
    public abstract class Day11 : Day
    {
        public static void Part1()
        {
            StartExec();

            // Create Monkeys
            var monkeys = new Dictionary<int, Monkey>();
            monkeys.Add(0, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 71, 56, 50, 73 }),
                Operation = x => x * 11,
                TestDivisionBy = 13,
                TargetMonkeyTestTrue = 1,
                TargetMonkeyTestFalse = 7
            });
            monkeys.Add(1, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 70, 89, 82 }),
                Operation = x => x + 1,
                TestDivisionBy = 7,
                TargetMonkeyTestTrue = 3,
                TargetMonkeyTestFalse = 6
            });
            monkeys.Add(2, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 52, 95 }),
                Operation = x => x * x,
                TestDivisionBy = 3,
                TargetMonkeyTestTrue = 5,
                TargetMonkeyTestFalse = 4
            });
            monkeys.Add(3, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 94, 64, 69, 87, 70 }),
                Operation = x => x + 2,
                TestDivisionBy = 19,
                TargetMonkeyTestTrue = 2,
                TargetMonkeyTestFalse = 6
            });
            monkeys.Add(4, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 98, 72, 98, 53, 97, 51 }),
                Operation = x => x + 6,
                TestDivisionBy = 5,
                TargetMonkeyTestTrue = 0,
                TargetMonkeyTestFalse = 5
            });
            monkeys.Add(5, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 79 }),
                Operation = x => x + 7,
                TestDivisionBy = 2,
                TargetMonkeyTestTrue = 7,
                TargetMonkeyTestFalse = 0
            });
            monkeys.Add(6, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 77, 55, 63, 93, 66, 90, 88, 71 }),
                Operation = x => x * 7,
                TestDivisionBy = 11,
                TargetMonkeyTestTrue = 2,
                TargetMonkeyTestFalse = 4
            });
            monkeys.Add(7, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 54, 97, 87, 70, 59, 82, 59 }),
                Operation = x => x + 8,
                TestDivisionBy = 17,
                TargetMonkeyTestTrue = 1,
                TargetMonkeyTestFalse = 3
            });

            Func<long, long> reliefFunc = (x) => Convert.ToInt64(Math.Floor(x/3d));

            var rounds = 20;

            for (int i = 0; i < rounds; i++)
            {
                for (int m = 0; m < monkeys.Count; m++)
                {
                    var monkey = monkeys[m];
                    while (monkey?.Items?.Count > 0)
                    {
                        var item = monkey.Items.Dequeue();
                        item = monkey.Operation(item);
                        item = reliefFunc(item);
                        var testDivision = item % monkey.TestDivisionBy;
                        if (testDivision == 0)
                        {
                            monkeys[monkey.TargetMonkeyTestTrue].Items.Enqueue(item);
                        }
                        else
                        {
                            monkeys[monkey.TargetMonkeyTestFalse].Items.Enqueue(item);
                        }
                        monkey.ItemsInspected++;
                    }
                }
            }

            var monkeyBusiness = monkeys.OrderByDescending(m => m.Value.ItemsInspected)
                                        .Take(2).Select(m => m.Value.ItemsInspected)
                                        .Aggregate( (a,b) => a * b);
            
            Console.WriteLine($":: Monkey Business = {monkeyBusiness}");

            StopExec();

            Part2();
        }

        private static void Part2()
        {
            StartExec();

            Console.WriteLine("::: Part 2");

            // Create Monkeys
            var monkeys = new Dictionary<int, Monkey>();
            monkeys.Add(0, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 71, 56, 50, 73 }),
                Operation = x => x * 11,
                TestDivisionBy = 13,
                TargetMonkeyTestTrue = 1,
                TargetMonkeyTestFalse = 7
            });
            monkeys.Add(1, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 70, 89, 82 }),
                Operation = x => x + 1,
                TestDivisionBy = 7,
                TargetMonkeyTestTrue = 3,
                TargetMonkeyTestFalse = 6
            });
            monkeys.Add(2, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 52, 95 }),
                Operation = x => x * x,
                TestDivisionBy = 3,
                TargetMonkeyTestTrue = 5,
                TargetMonkeyTestFalse = 4
            });
            monkeys.Add(3, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 94, 64, 69, 87, 70 }),
                Operation = x => x + 2,
                TestDivisionBy = 19,
                TargetMonkeyTestTrue = 2,
                TargetMonkeyTestFalse = 6
            });
            monkeys.Add(4, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 98, 72, 98, 53, 97, 51 }),
                Operation = x => x + 6,
                TestDivisionBy = 5,
                TargetMonkeyTestTrue = 0,
                TargetMonkeyTestFalse = 5
            });
            monkeys.Add(5, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 79 }),
                Operation = x => x + 7,
                TestDivisionBy = 2,
                TargetMonkeyTestTrue = 7,
                TargetMonkeyTestFalse = 0
            });
            monkeys.Add(6, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 77, 55, 63, 93, 66, 90, 88, 71 }),
                Operation = x => x * 7,
                TestDivisionBy = 11,
                TargetMonkeyTestTrue = 2,
                TargetMonkeyTestFalse = 4
            });
            monkeys.Add(7, new Monkey()
            {
                Items = new Queue<long>(new long[]{ 54, 97, 87, 70, 59, 82, 59 }),
                Operation = x => x + 8,
                TestDivisionBy = 17,
                TargetMonkeyTestTrue = 1,
                TargetMonkeyTestFalse = 3
            });

            var rounds = 10000;

            var worryMod = monkeys.Select(m => m.Value.TestDivisionBy)
                                  .Aggregate( (a,b) => a*b);

            for (int i = 0; i < rounds; i++)
            {
                for (int m = 0; m < monkeys.Count; m++)
                {
                    var monkey = monkeys[m];
                    while (monkey?.Items?.Count > 0)
                    {
                        var item = monkey.Items.Dequeue();
                        item = monkey.Operation(item);
                        item = item % worryMod;
                        var testDivision = item % monkey.TestDivisionBy;
                        if (testDivision == 0)
                        {
                            monkeys[monkey.TargetMonkeyTestTrue].Items.Enqueue(item);
                        }
                        else
                        {
                            monkeys[monkey.TargetMonkeyTestFalse].Items.Enqueue(item);
                        }
                        monkey.ItemsInspected++;
                    }
                }
            }

            var monkeyBusiness = monkeys.OrderByDescending(m => m.Value.ItemsInspected)
                                        .Take(2).Select(m => m.Value.ItemsInspected)
                                        .Aggregate( (a,b) => a * b);
            
            Console.WriteLine($":: Monkey Business Part 2 = {monkeyBusiness}");

            StopExec();
        }
    }

    internal class Monkey
    {
        public Queue<long> Items { get; set; }
        public Func<long, long> Operation { get; set; }
        public int TestDivisionBy { get; set; }
        public int TargetMonkeyTestTrue { get; set; }
        public int TargetMonkeyTestFalse { get; set; }
        public Int128 ItemsInspected { get; set; } = 0;

        public Monkey()
        {
            Items = new Queue<long>();
            Operation = (x) => x;
        }
    }
}