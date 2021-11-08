using System;
using System.IO;

namespace Day3
{
    public class Day9
    {
        public static void XMAS()
        {
            File.WriteAllText(@"Output9.txt", string.Empty);
            long[] input = new long[File.ReadAllLines(@"Inputs/Input_Day9.txt").Length];
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = long.Parse(File.ReadAllLines(@"Inputs/Input_Day9.txt")[i]);
            }
            long sum = 0;
            for (long i = 24; i < input.Length; i++)
            {
                sum = 0;
                long res = input[i];
                File.AppendAllText(@"Output9.txt", "=======================" + Environment.NewLine);
                File.AppendAllText(@"Output9.txt", "Res: " + res + Environment.NewLine);
                File.AppendAllText(@"Output9.txt", "_______________________" + Environment.NewLine);

                SOmeFUnction(res, i, input, sum);
                /*if (sum != res)
                {
                    File.AppendAllText(@"Output9.txt", "Error Sum:" + res + Environment.NewLine);
                    Console.WriteLine("Result: " + res);
                }
                */
            }
        }

        static void SOmeFUnction(long res, long i, long[] input, long sum)
        {
            for (long j = i - 24; j < input.Length; j++)
            {
                for (long k = i - 24; k < input.Length; k++)
                {
                    if (j != k)
                    {
                        sum = input[j] + input[k];
                        if (sum == res)
                        {
                            File.AppendAllText(@"Output9.txt", "Sum: " + res + Environment.NewLine);
                            return;
                        }
                    }
                }
            }
        }
    }
}