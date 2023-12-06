namespace day_6
{
    class Program
    {
        static void Main()
        {
            string filePath = "./test.txt";
            string raceData = File.ReadAllText(filePath);
            string[] raceSections = raceData.Split("\n");

            string timeValues = raceSections[0].Split(":")[1];
            int[] timeArray = Array.ConvertAll(timeValues.Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);

            string distValues = raceSections[1].Split(":")[1];
            int[] distArray = Array.ConvertAll(distValues.Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);


        }
    }
}
