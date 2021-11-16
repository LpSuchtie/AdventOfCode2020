using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day3
{
    public class Day14
    {
        public static void Bitmask()
        {
            char[] mask = new char[36];
            char[] binValue = new char[36];
            string[] input = File.ReadAllLines(@"Inputs/Input_Day14.txt");
            int[] allMemAddress = new int[input.Length];
            for (int i = 0; i < allMemAddress.Length; i++)
            {
                if (input[i].Contains("mem"))
                {
                    allMemAddress[i] = int.Parse(input[i].Split('[', ']')[1]);
                }
            }
            long[] mem = new long[allMemAddress.Max() + 1];

            foreach (string line in input)
            {
                string[] fields = line.Split(" = ");
                if (fields[0] == "mask")
                {
                    mask = fields[1].ToCharArray();
                }
                else if (fields[0].Contains("mem"))
                {
                    binValue = Convert.ToString(int.Parse(fields[1]), 2).PadLeft(36, '0').ToCharArray();
                    for (int i = 0; i < binValue.Length; i++)
                    {
                        switch (mask[i])
                        {
                            case 'X':
                                break;

                            case '1':
                                binValue[i] = '1';
                                break;
                            case '0':
                                binValue[i] = '0';
                                break;
                        }
                    }
                    mem[int.Parse(fields[0].Split('[', ']')[1])] = Convert.ToInt64(new string(binValue), 2);
                }
            }
            long sum = 0;
            foreach (long value in mem)
            {
                sum += value;
            }
            Console.WriteLine("Result Part 1: " + sum);
            Part2();
        }
        static void Part2()
        {
            char[] mask = new char[36];
            char[] binValue = new char[36];
            string[] input = File.ReadAllLines(@"Inputs/Input_Day14.txt");

            Dictionary<long, long> mem = new Dictionary<long, long>();

            foreach (string line in input)
            {
                string[] fields = line.Split(" = ");
                if (fields[0] == "mask")
                {
                    mask = fields[1].ToCharArray();
                }
                else if (fields[0].Contains("mem"))
                {
                    int[] floatingBinsIndexes = new int[mask.Count(x => x == 'X')];
                    int j = 0;
                    binValue = Convert.ToString(int.Parse(fields[0].Split('[', ']')[1]), 2).PadLeft(36, '0').ToCharArray();
                    for (int i = 0; i < binValue.Length; i++)
                    {
                        switch (mask[i])
                        {
                            case 'X':
                                binValue[i] = 'X';
                                floatingBinsIndexes[j] = i;
                                j++;
                                break;

                            case '1':
                                binValue[i] = '1';
                                break;
                            case '0':
                                break;
                        }

                    }
                    int n = mask.Count(x => x == 'X');
                    for (int i = 0; i <= ~(-1 << n); i++)
                    {
                        string s = Convert.ToString(i, 2).PadLeft(n, '0');
                        for (int k = 0; k < n; k++)
                        {
                            binValue[floatingBinsIndexes[k]] = s.ToCharArray()[k];
                        }
                        mem[Convert.ToInt64(new string(binValue), 2)] = long.Parse(fields[1]);
                    }
                }
            }
            long sum = 0;
            foreach (var item in mem)
            {
                sum += item.Value;
            }
            Console.WriteLine("Result Part 2: " + sum);
        }
    }
}