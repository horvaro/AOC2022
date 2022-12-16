using System.Text.Json;

namespace AOC2022
{
    public abstract class Day13 : Day
    {
        public static void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day13.txt");

            var listPairs = new List<string[]>();

            var pair = new string[2];
            var pairCount = 0;
            foreach (string line in inputLines)
            {
                if (string.IsNullOrEmpty(line.Trim()))
                {
                    listPairs.Add(pair);
                    pair = new string[2];
                    pairCount = 0;
                }
                else
                {
                    pair[pairCount] = line;
                    pairCount++;
                }
            }
            listPairs.Add(pair);

            var sumOfInOrder = 0;
            var i = 1;
            foreach (var dataPair in listPairs)
            {
                var isPairInOrder = IsInputInOrder(dataPair, 0);
                Console.WriteLine($"Is in order = {isPairInOrder}");
                Console.WriteLine();

                if (isPairInOrder)
                {
                    sumOfInOrder += i;
                }

                i++;
            }

            Console.WriteLine($"Sum of indicies of pairs in order = {sumOfInOrder}");

            StopExec();
        }

        private static bool IsInputInOrder(string[] dataPair, int depth)
        {
            var indent = new String(' ', depth*2);
            var leftRaw = dataPair[0];
            var rightRaw = dataPair[1];

            var left = JsonSerializer.Deserialize<JsonElement>(leftRaw);
            var right = JsonSerializer.Deserialize<JsonElement>(rightRaw);

            Console.WriteLine($"{indent}- Comparing {leftRaw} vs {rightRaw}");
            
            return Compare(left, right, depth+1) < 0 ? true : false;
        }

        private static int Compare(JsonElement left, JsonElement right, int depth)
        {
            var indent = new String(' ', depth*2);
            Console.WriteLine($"{indent}- {left} vs {right}");

            switch (left.ValueKind, right.ValueKind)
            {
                case (JsonValueKind.Number, JsonValueKind.Number):
                    return left.GetInt32() - right.GetInt32();
                case (JsonValueKind.Number, _):
                    return DoCompare(JsonSerializer.Deserialize<JsonElement>($"[{left.GetInt32()}]"), right, depth);
                case (_, JsonValueKind.Number):
                    return DoCompare(left, JsonSerializer.Deserialize<JsonElement>($"[{right.GetInt32()}]"), depth);
                default:
                    return DoCompare(left, right, depth);
            }
        }

        private static int DoCompare(JsonElement left, JsonElement right, int depth)
        {
            int res;
            JsonElement.ArrayEnumerator leftArr = left.EnumerateArray();
            JsonElement.ArrayEnumerator rightArr = right.EnumerateArray();
            while (leftArr.MoveNext() && rightArr.MoveNext())
                if ((res = Compare(leftArr.Current, rightArr.Current, depth+1)) != 0)
                    return res;
            return left.GetArrayLength() - right.GetArrayLength();
        }
    }
}