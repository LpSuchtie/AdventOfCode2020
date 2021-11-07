using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    public class Day7
    {
        public static void Luggage()
        {
            Dictionary<string, List<string>> rules = new Dictionary<string, List<string>>();
            Dictionary<string, int> extra = new Dictionary<string, int>();
            Dictionary<string, ulong> allBags = new Dictionary<string, ulong>();

            foreach (string rule in File.ReadAllLines(@"Input_Day7.txt"))
            {
                if (string.IsNullOrEmpty(rule) != true)
                {
                    string[] part = rule.Replace(".", "").Split(" bags contain ");
                    rules[part[0]] = part[1].Replace("bags", "bag").Replace(" bag", "").Split(", ").ToList();
                }
            }
            int count = 0;
            foreach (var item in rules)
            {
                if (BagContains(rules, item.Key, "shiny gold"))
                {
                    count++;
                    extra[item.Key] = 0;
                }
                allBags[item.Key] = 0;
            }
            Console.WriteLine("Result: " + CountBags(rules, "shiny gold"));
        }

        static bool BagContains(Dictionary<string, List<string>> rules, string bag, string targetBag)
        {
            if (rules[bag].Where(item => item.Contains(targetBag)).Count() != 0)
            {
                return true;
            }
            foreach (var item in rules[bag])
            {
                if (item == "no other") continue;
                if (BagContains(rules, item.Substring(2), targetBag))
                {
                    return true;
                }
            }
            return false;
        }

        static ulong CountBags(Dictionary<string, List<string>> rules, string bag, Dictionary<string, ulong> cache = null)
        {
            ulong bags = 0;
            if (cache != null && cache.ContainsKey(bag))
            {
                bags = cache[bag];
            }
            else
            {
                foreach (var item in rules[bag])
                {
                    if (item == "no other") continue;
                    int bagM = item[0] - '0';
                    bags += (ulong)bagM + (ulong)bagM * CountBags(rules, item.Substring(2), cache);
                }
                if (cache != null)
                {
                    cache[bag] = bags;
                }
            }
            return bags;
        }
    }
}