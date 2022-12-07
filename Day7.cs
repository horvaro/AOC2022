namespace AOC2022
{
    public class Day7 : Day
    {
        public void Part1()
        {
            StartExec();

            var inputLines = LoadInputFile("./puzzles/Day7.txt");

            var sum = 0;
            // Find all of the directories with a total size of at most 100000.
            // What is the sum of the total sizes of those directories?
            var fsTree = new FSTree();
            FSTreeNode currentNode = fsTree.Root;
            foreach(string line in inputLines.Skip(1))  // We want to skip "cd /" because we already created root
            {
                var terminalOutput = line.Split(' ');
                // Check if current line is a command (starting with $)
                if (terminalOutput[0].Equals("$"))
                {
                    switch (terminalOutput[1])
                    {
                        case "cd":
                            if (terminalOutput[2].Equals(".."))
                            {
                                currentNode = currentNode.Parent;
                            }
                            else
                            {
                                currentNode = currentNode.Directories.Find(d => d.Name.Equals(terminalOutput[2]));
                            }
                            break;
                        case "ls":
                            // Do we need to do someting with this? ¯\_(ツ)_/¯
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    // Load Directories or Folders
                    if (terminalOutput[0].Equals("dir"))
                    {
                        var newDirectory = new FSTreeNode(currentNode, terminalOutput[1]);
                        currentNode.Directories.Add(newDirectory);
                    }
                    else
                    {
                        var filesSize = ParseInt(terminalOutput[0]);
                        var file = new FSTreeLeaf(currentNode, terminalOutput[1], filesSize);
                        currentNode.Files.Add(file);
                    }
                }
            }

            sum = FindSmallDirectories(fsTree.Root);

            Console.WriteLine($":: Final Score = {sum}");

            StopExec();



            StartExec();

            Console.WriteLine("::: Part 2");

            // calc minimal folder size for deletion
            var diskSize = 70_000_000;
            var spaceNeededForUpdate = 30_000_000;
            var usedSpace = fsTree.Root.Size();
            var unusedSpace = diskSize - usedSpace;
            var spaceToFreeUp = spaceNeededForUpdate - unusedSpace;

            if (spaceToFreeUp <= 0)
            {
                Console.WriteLine($"This should not happen. Space needed = {spaceNeededForUpdate}, Unused Space = {unusedSpace}, Therefore: Space needed to free up = {spaceToFreeUp}");
            }

            // find folder with that size
            var bigBoyDirectory = FindDirectoryToDelete(fsTree.Root, spaceToFreeUp);

            Console.WriteLine($":: Size of folder to delete = {bigBoyDirectory}");

            StopExec();
        }

        private int FindSmallDirectories(FSTreeNode node)
        {
            return  node.Directories.Select(d => FindSmallDirectories(d))
                                    .DefaultIfEmpty(0)
                                    .Aggregate((a,b)=>a+b) +
                    node.Directories.Select(d => d.Size())
                                    .Where(s => s < 100000)
                                    .DefaultIfEmpty(0)
                                    .Aggregate((a,b) => a+b);
        }

        private int FindDirectoryToDelete(FSTreeNode node, int minSpaceNeeded)
        {
            var subDirectories = node.Directories.Select(d => FindDirectoryToDelete(d, minSpaceNeeded))
                                                       .DefaultIfEmpty(int.MaxValue).Min();
            var nodeSize = node.Size();
            if (nodeSize < minSpaceNeeded)
            {
                return int.MaxValue;
            }
            else if (nodeSize < subDirectories)
            {
                return nodeSize;
            }
            else
            {
                return subDirectories;
            }
        }


        internal class FSTree
        {
            public FSTreeNode Root { get; }

            public FSTree()
            {
                Root = new FSTreeNode("/");
            }
        }

        internal class FSTreeNode
        {
            public FSTreeNode Parent { get; }
            public List<FSTreeNode> Directories { get; }
            public List<FSTreeLeaf> Files { get; }
            public string Name { get; }

            public FSTreeNode(string name)
            {
                Parent = this;
                Directories = new List<FSTreeNode>();
                Files = new List<FSTreeLeaf>();
                Name = name;
            }

            public FSTreeNode(FSTreeNode parent, string name)
            {
                Parent = parent;
                Directories = new List<FSTreeNode>();
                Files = new List<FSTreeLeaf>();
                Name = name;
            }

            public int Size()
            {
                return Files.Select(f => f.Size).DefaultIfEmpty(0).Aggregate((a,b)=>a+b) +
                       Directories.Select(d => d.Size()).DefaultIfEmpty(0).Aggregate((a,b)=>a+b);
            }
        }

        internal class FSTreeLeaf
        {
            public FSTreeNode Parent { get; }
            public string Name { get; }
            public int Size { get; }

            public FSTreeLeaf(FSTreeNode parent, string name, int size)
            {
                Parent = parent;
                Name = name;
                Size = size;
            }
        }
    }
}