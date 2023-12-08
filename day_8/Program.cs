namespace day_8
{
    class Program
    {
        static void Main()
        {
            Dictionary<string, string> directionDict = new()
            {
                { "L", "left" },
                { "R", "right" }
            };

            string filePath = "./input.txt";
            string fileContent = File.ReadAllText(filePath);

            string[] sections = fileContent.Split("\n\n");

            string instructions = sections[0];
            string[] steps = sections[1].Split("\n");

            Dictionary<string, (string left, string right)> mapDict = new();

            foreach (string step in steps)
            {
                string key = step[0..3];
                string left = step[7..10];
                string right = step[12..15];
                mapDict[key] = (left, right);
            }

            int count = 0;
            int index = 0;
            string direction = "";
            string location = "";

            HashSet<string> locationHashSet = new HashSet<string>();
            var startingPoints = mapDict.Keys.Where(key => key.EndsWith("A")).ToList();
            Dictionary<string, string> previousLocations = startingPoints.ToDictionary(key => key, _ => string.Empty);

            bool allFinished = false;

            while (!allFinished)
            {
                count++;

                foreach (var startingPoint in startingPoints)
                {
                    if (count == 1)
                    {
                        location = startingPoint;
                    }
                    else
                    {
                        location = previousLocations[startingPoint];
                    }

                    Console.WriteLine("starting point: " + startingPoint + " previous: " + previousLocations[startingPoint] + "index: " + index + " location: " + location + "count " + count);

                    direction = $"{instructions[index]}";

                    if (direction == "L")
                    {
                        location = mapDict[location].left;
                    }
                    else if (direction == "R")
                    {
                        location = mapDict[location].right;
                    }

                    previousLocations[startingPoint] = location;
                    locationHashSet.Add(location);
                }

                if (locationHashSet.All(item => item.EndsWith("Z")))
                {
                    allFinished = true;
                }
                else
                {
                    locationHashSet.Clear();
                }

                index++;

                if (index >= instructions.Length)
                {
                    index = 0;
                }
            }
            Console.WriteLine(count);
        }
    }
}

// PART 1:
// string location = "AAA";
// while (location != "ZZZ")
// {
//     if (index >= instructions.Length)
//     {
//         index = 0;
//     }

//     count++;
//     direction = $"{instructions[index]}";

//     if (direction == "L")
//     {
//         location = mapDict[location].left;
//     }
//     else if (direction == "R")
//     {
//         location = mapDict[location].right;
//     }

//     index++;
// }

// Console.WriteLine(count);