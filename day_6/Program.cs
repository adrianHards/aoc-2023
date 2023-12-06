namespace day_6
{
    class Program
    {
        static void Main()
        {
            string filePath = "./input.txt";
            string raceData = File.ReadAllText(filePath);
            string[] raceSections = raceData.Split("\n");

            string timeValues = raceSections[0].Split(":")[1];
            int[] timeArray = Array.ConvertAll(timeValues.Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);

            string distValues = raceSections[1].Split(":")[1];
            int[] distArray = Array.ConvertAll(distValues.Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);

            List<int> noOfWinsList = new List<int>();

            for (int i = 0; i < timeArray.Length; i++)
            {
                int wins = 0;
                int distToBeat = distArray[i];
                int start = (int)Math.Ceiling((double)distArray[i] / timeArray[i]);
                int end = timeArray[i] - 1;

                for (int timeHeld = start; timeHeld <= end; timeHeld++)
                {
                    int timeRemain = timeArray[i] - timeHeld;
                    if (timeHeld * timeRemain > distToBeat)
                    {
                        wins++;
                    }
                }
                noOfWinsList.Add(wins);
            }

            int productOfWins = noOfWinsList.Aggregate(1, (acc, x) => acc * x);
            Console.WriteLine($"wins: {productOfWins}");
        }
    }
}
