namespace AOC2022
{
    public class Day6 : Day
    {
        public void Part1()
        {
            StartExec();

            var content = File.ReadAllText("./puzzles/Day6.txt");

            var packetMarkerPos = FindStartMarker(content, 4);
            var messageMarkerPos = FindStartMarker(content, 14);

            Console.WriteLine($":: start-of-packet marker found at position {packetMarkerPos}");
            Console.WriteLine($":: start-of-message marker found at position {messageMarkerPos}");

            StopExec();
        }

        private int FindStartMarker(string datastream, int markerLength)
        {
            var markerQueue = new Queue<char>();

            var cursor = 1;
            foreach(char ch in datastream)
            {
                if (markerQueue.Count < markerLength)
                {
                    markerQueue.Enqueue(ch);
                }
                else 
                {
                    _ = markerQueue.Dequeue();
                    markerQueue.Enqueue(ch);
                    if(IsQueueUnique(markerQueue))
                    {
                        // marker found
                        break;
                    }
                }
                cursor++;
            }

            return cursor;
        }

        private bool IsQueueUnique(Queue<char> queue)
        {
            return queue.Distinct().Count() == queue.Count;
            // var array = queue.ToArray();
            // for (int i = 0; i < array.Length; i++)
            // {
            //     var ch = array[i];
            //     var occurence = 0;
            //     for (int j = 0; j < array.Length; j++)
            //     {
            //         if (array[j].Equals(ch)) { occurence++; }
            //         if (occurence > 1) {
            //             return false;
            //         }
            //     }
            // }

            // return true;
        }
    }
}