using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Day3
{
    public class Day15
    {
        public static void Recitation()
        {
            int[] input = new int[] { 19, 0, 5, 1, 10, 13 };
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            for (int i = 0; i < input.Length; i++)
            {
                numbers.Add(i, input[i]);
            }
            for (int i = input.Length; i < 2020/*30000000 Very bad, do not run*/; i++)
            {
                if (numbers.Values.Count(v => v == (numbers[i - 1])) == 1)
                {
                    numbers.Add(i, 0);
                }
                else if (numbers.Values.Count(v => v == (numbers[i - 1])) > 1)
                {
                    int key1 = numbers.LastOrDefault(x => x.Value == (numbers[i - 1])).Key;
                    int key2 = 0;
                    if (key1 == 0)
                    {
                        key2 = numbers.SkipLast(1).LastOrDefault(x => x.Value == (numbers[i - 1])).Key;
                    }
                    else
                    {
                        key2 = numbers.SkipLast(numbers.Count - key1).LastOrDefault(x => x.Value == (numbers[i - 1])).Key;
                    }
                    numbers.Add(i, (key1 - key2));
                }
            }
            Console.WriteLine("Result Part 1: " + numbers[2019]);
            //Takes over 10 minutes to compute, what the hell
            //Console.WriteLine("Result Part 2: " + numbers[29999999]);
        }
    }
}