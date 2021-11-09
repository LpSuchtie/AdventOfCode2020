using System;
using System.IO;
using System.Linq;

namespace Day3
{
    public class Day13
    {
        static public void Shuttle()
        {
            string[] input = File.ReadAllLines(@"Inputs/Input_Day13.txt");
            int timestamp = int.Parse(input[0]);
            int len = input[1].Replace("x,", "").Split(',').Length;
            int[] busIDs = new int[len];
            int[] nextBus = new int[len];
            string[] IDs = input[1].Replace("x,", "").Split(',');
            for (int i = 0; i < len; i++)
            {
                busIDs[i] = int.Parse(IDs[i]);
            }

            bool isWhole = false;
            int j = 0;
            foreach (int busID in busIDs)
            {
                int i = 0;
                int workingTimestamp = 0;
                isWhole = false;
                while (isWhole == false)
                {
                    workingTimestamp = timestamp + i;
                    if (workingTimestamp % busID == 0)
                    {
                        nextBus[j] = workingTimestamp;
                        isWhole = true;
                    }
                    else
                    {
                        isWhole = false;
                    }
                    i++;
                }
                j++;
            }
            int[,] res = new int[2, busIDs.Length];

            for (int i = 0; i < busIDs.Length; i++)
            {
                res[0, i] = busIDs[i];
                res[1, i] = nextBus[i] - timestamp;
                nextBus[i] = res[1, i];
            }

            int minWaitTimeIndex = nextBus.ToList().IndexOf(nextBus.Min());
            Console.WriteLine("BusID: " + res[0, minWaitTimeIndex] + " |  Bus Timestamp: " + res[1, minWaitTimeIndex]);
            Console.WriteLine("Result: " + (res[0, minWaitTimeIndex] * res[1, minWaitTimeIndex]));
        }
    }
}