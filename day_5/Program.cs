using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace day_5
{
    class Program
    {
        static async Task Main()
        {
            string filePath = "./input.txt";
            // string filePath = "./testData.txt";

            try
            {
                string seedContent = File.ReadAllText(filePath);
                string[] sections = seedContent.Split("\n\n");

                string seedString = sections[0].Split(":")[1].Trim();
                BigInteger[] seedsArray = Array.ConvertAll(seedString.Split(' '), BigInteger.Parse);

                BigInteger[][] seedToSoilMap = GetMap(sections[1]);
                BigInteger[][] soilToFertMap = GetMap(sections[2]);
                BigInteger[][] fertToWaterMap = GetMap(sections[3]);
                BigInteger[][] waterToLightMap = GetMap(sections[4]);
                BigInteger[][] lightToTempMap = GetMap(sections[5]);
                BigInteger[][] tempToHumidMap = GetMap(sections[6]);
                BigInteger[][] humidToLocationMap = GetMap(sections[7]);

                Dictionary<BigInteger, BigInteger> seedValueDict = new Dictionary<BigInteger, BigInteger>();

                foreach (BigInteger element in seedsArray)
                {
                    seedValueDict[element] = element;
                }

                Dictionary<BigInteger, BigInteger>[] dicts = new Dictionary<BigInteger, BigInteger>[]
                {
                    MakeDict(seedToSoilMap),
                    MakeDict(soilToFertMap),
                    MakeDict(fertToWaterMap),
                    MakeDict(waterToLightMap),
                    MakeDict(lightToTempMap),
                    MakeDict(tempToHumidMap),
                    MakeDict(humidToLocationMap)
                };

                for (int i = 0; i < seedsArray.Length; i++)
                {
                    BigInteger startingValue = seedsArray[i];

                    foreach (Dictionary<BigInteger, BigInteger> dict in dicts)
                    {
                        if (dict.ContainsKey(startingValue))
                        {
                            startingValue = dict[startingValue];
                        }
                    }
                    seedValueDict[seedsArray[i]] = startingValue;
                }
                Console.WriteLine("lowest value: " + seedValueDict.Values.Min());
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
        }
        static BigInteger[][] GetMap(string mapString)
        {
            return mapString.Split(':')[1].Trim().Split('\n')
                .Select(line => line.Split(' ')
                .Select(BigInteger.Parse).ToArray())
                .ToArray();
        }

        static Dictionary<BigInteger, BigInteger> MakeDict(BigInteger[][] mapArray)
        {
            Dictionary<BigInteger, BigInteger> newDict = new Dictionary<BigInteger, BigInteger>();

            foreach (BigInteger[] row in mapArray)
            {
                BigInteger value = row[0];
                BigInteger key = row[1];
                BigInteger rangeLength = row[2];
                BigInteger modifier = 0;

                for (BigInteger i = key; i < (key + rangeLength); i++)
                {
                    if (!newDict.ContainsKey(i))
                    {
                        newDict[i] = (value + modifier);
                    }
                    modifier++;
                }
            }
            return newDict;
        }
    }
}
