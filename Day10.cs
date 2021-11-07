using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day3
{
    class Day10
    {
        public static void Joltage()
        {
            int[] input = new int[File.ReadAllLines(@"Input_Day10.txt").Length];

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = int.Parse(File.ReadAllLines(@"Input_Day10.txt")[i]);
            }
            Array.Sort(input);

            int currentJolts = 0;
            int diffs1 = 0;
            int diffs3 = 0;
            int maxJolts = input.Max() + 3;

            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i] - currentJolts)
                {
                    case 0:
                        currentJolts = input[i];
                        break;

                    case 1:
                        diffs1++;
                        currentJolts = input[i];
                        break;

                    case 2:
                        currentJolts = input[i];
                        break;

                    case 3:
                        diffs3++;
                        currentJolts = input[i];
                        break;
                }
            }
            //Internal adapter difference of device
            diffs3++;

            List<int> oneJoltLenghts = new List<int>();
            int contRuns = 0;

            List<int> inputList = new List<int>();

            inputList.Add(0);

            foreach (int i in input)
            {
                inputList.Add(i);
            }

            inputList.Sort();

            inputList.Add(inputList[inputList.Count - 1] + 3);

            for (int i = 0; i < inputList.Count - 1; i++)
            {
                if (inputList[i + 1] - inputList[i] == 1)
                {
                    contRuns++;
                }
                else
                {
                    contRuns--;
                    if (contRuns >= 1)
                    {
                        oneJoltLenghts.Add(contRuns);
                    }
                    contRuns = 0;
                }
            }

            long totalCombs = 1;
            int[] runCombs = { 1, 2, 4, 7 };

            foreach (int comb in oneJoltLenghts)
            {
                totalCombs *= runCombs[comb];
            }
            Console.WriteLine("Result Diffs: " + (diffs1 * diffs3));
            Console.WriteLine("Result Combs: " + totalCombs);
        }
    }
}