using System;
using System.Diagnostics;
using System.IO;

namespace Day3
{
    class Program3
    {
        public static string[] treeMap;

        public static int[] slopeX = { 1, 3, 5, 7, 1 };
        public static int[] slopeY = { 1, 1, 1, 1, 2 };
        public static int coordX = 0;
        public static int counter = 0;
        public static void Trees()
        {
            long[] res = new long[5];
            treeMap = File.ReadAllLines(@"Input_Day3.txt");
            for (int i = 0; i < slopeX.Length; i++)
            {
                counter = 0;
                coordX = 0;
                for (int y = slopeY[i]; y < treeMap.Length; y += slopeY[i])
                {
                    int bound = treeMap[y].Length;
                    if ((coordX + slopeX[i]) >= bound)
                    {
                        coordX = coordX + slopeX[i] - bound;
                    }
                    else
                    {
                        coordX = coordX + slopeX[i];
                    }
                    if (treeMap[y].ToCharArray()[coordX] == '#')
                    {
                        counter++;
                    }
                }
                Console.WriteLine("X: " + slopeX[i] + " Y: " + slopeY[i] + " | Trees: " + counter);
                res[i] = counter;
            }
            Console.WriteLine("Result: " + (res[0] * res[1] * res[2] * res[3] * res[4]));
        }
    }
}

