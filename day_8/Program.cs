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
                Console.WriteLine(step);
                string key = step[0..3];
                string left = step[7..10];
                string right = step[12..15];
                mapDict[key] = (left, right);
            }

            int count = 0;
            int index = 0;
            string direction = "";
            string location = "AAA";

            while (location != "ZZZ")
            {
                if (index >= instructions.Length)
                {
                    index = 0;
                }

                count++;
                direction = $"{instructions[index]}";

                if (direction == "L")
                {
                    location = mapDict[location].left;
                }
                else if (direction == "R")
                {
                    location = mapDict[location].right;
                }

                index++;
            }

            Console.WriteLine(count);
        }
    }
}
