using System;
using System.IO;
using System.Linq;

namespace Day3
{
    class Program6
    {
        public static void Form()
        {
            string[] data = new string[File.ReadAllLines(@"Input_Day6.txt").Length];
            int i = 0;
            foreach (string line in File.ReadAllLines(@"Input_Day6.txt"))
            {
                if (string.IsNullOrEmpty(line))
                {
                    i++;
                }
                else
                {
                    data[i] += line + "|";
                }
            }
            data = data.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            int[] answerCount = new int[data.Length];
            for (int j = 0; j < data.Length; j++)
            {
                if (string.IsNullOrEmpty(data[j]) != true)
                {
                    int persons = data[j].Split("|").Length;
                    string input = data[j].Replace("|", "");
                    var queryPre = input.GroupBy(c => c)
                                     .Where(group => group.Count() >= 1)
                                     .Select(group => group.Key);
                    var query = queryPre.ToArray();
                    if (query.Length != 0)
                    {
                        foreach (char answer in query)
                        {
                            int count = 0;
                            for (int c = 0; c < persons; c++)
                            {
                                if (data[j].Split("|")[c].Contains(answer) == true)
                                {
                                    count++;
                                }
                            }
                            if (count == persons - 1)
                            {
                                answerCount[j] += 1;
                            }
                        }
                    }
                }
            }
            int res = 0;
            foreach (int group in answerCount)
            {
                if (group != 0)
                {
                    res = res + group;
                }
            }
            //Output Result to Console
            Console.WriteLine("Result: " + res);
        }
    }
}
