namespace day_6
{
    class Program
    {
        static void Main()
        {
            string filePath = "./input.txt";
            string raceData = File.ReadAllText(filePath);
            string[] raceSections = raceData.Split("\n");

            string timeValues = raceSections[0].Split(":")[1].Trim();
            string[] timeArray = timeValues.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string concatTime = string.Join("", timeArray);
            long timeAsInteger = long.Parse(concatTime);

            string distValues = raceSections[1].Split(":")[1].Trim();
            string[] distArray = distValues.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string concatDist = string.Join("", distArray);
            long distAsInteger = long.Parse(concatDist);

            int wins = 0;
            long distToBeat = distAsInteger;
            long start = (long)Math.Ceiling((double)distAsInteger / timeAsInteger);
            long end = timeAsInteger - 1;

            for (long timeHeld = start; timeHeld <= end; timeHeld++)
            {
                long timeRemain = timeAsInteger - timeHeld;
                if (timeHeld * timeRemain > distAsInteger)
                {
                    wins++;
                }
            }

            Console.WriteLine($"wins: {wins}");
        }
    }
}
