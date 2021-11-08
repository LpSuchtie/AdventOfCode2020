using System;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program5
    {
        public static void Board()
        {
            int[] passes = new int[File.ReadAllLines(@"Inputs/Input_Day5.txt").Length];
            int i = 0;
            foreach (string line in File.ReadAllLines(@"Inputs/Input_Day5.txt"))
            {
                passes[i] = Convert.ToInt32(line.Replace('F','0').Replace('B','1').Replace('R','1').Replace('L','0'), 2);
                i++;
            }
            for (int j = 0; j < passes.Max(); j++)
            {
                if (passes.Contains(j) != true && passes.Contains(j - 1) == true && passes.Contains(j + 1) == true)
                {
                    Console.WriteLine("Seat ID: " + j);
                }
            }
            Console.WriteLine("Highest Seat ID: " + passes.Max().ToString());
        }
    }
}
