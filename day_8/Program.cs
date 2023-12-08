namespace day_8
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "./testinput.txt";
            string fileContent = File.ReadAllText(filePath);

            string[] sections = fileContent.Split("\n\n");

            string instructions = sections[0];
            string[] steps = sections[1].Split("\n");

            Dictionary<string, (string left, string right)> mapDict = new();

            foreach (string step in steps)
            {
                string key = step[0..2];
                string left = step[7..9];
                string right = step[12..14];
                mapDict[key] = (left, right);
            }
        }
    }
}
