using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace Day3
{
    class Program4
    {
        public static void Passport()
        {
            File.WriteAllText(@"Output4.txt", string.Empty);
            int valid = 0;
            string[] data = new string[File.ReadAllLines(@"Inputs/Input_day4.txt").Length];
            int i = 0;
            foreach (string line in File.ReadAllLines(@"Inputs/Input_day4.txt"))
            {
                if (string.IsNullOrEmpty(line))
                {
                    i++;
                }
                else
                {
                    data[i] += line;
                    data[i] += " ";
                }
            }
            data = data.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            string[] fieldData;
            string validationCheck;
            foreach (string passport in data)
            {
                File.AppendAllText(@"Output4.txt", "Input: " + passport + Environment.NewLine);
                validationCheck = "";
                if (string.IsNullOrEmpty(passport) != true)
                {
                    foreach (string field in passport.Split(" "))
                    {
                        if (string.IsNullOrEmpty(field) != true)
                        {
                            fieldData = field.Split(':');
                            bool passed = false;
                            switch (fieldData[0])
                            {
                                case "byr":
                                    if (1920 <= int.Parse(fieldData[1]) && int.Parse(fieldData[1]) <= 2002) { validationCheck += "v"; passed = true; }
                                    else { validationCheck += "i"; passed = false; }
                                    break;

                                case "iyr":
                                    if (2010 <= int.Parse(fieldData[1]) && int.Parse(fieldData[1]) <= 2020) { validationCheck += "v"; passed = true; }
                                    else { validationCheck += "i"; passed = false; }
                                    break;

                                case "eyr":
                                    if (2020 <= int.Parse(fieldData[1]) && int.Parse(fieldData[1]) <= 2030) { validationCheck += "v"; passed = true; }
                                    else { validationCheck += "i"; passed = false; }
                                    break;

                                case "hgt":
                                    string height;
                                    string key = Regex.Replace(fieldData[1], @"[\d-]", string.Empty);
                                    switch (key)
                                    {
                                        case "cm":
                                            height = fieldData[1].Replace("cm", "");
                                            Console.WriteLine("Height cm: " + height);
                                            if (150 <= int.Parse(height) && int.Parse(height) <= 193) { validationCheck += "v"; passed = true; }
                                            else { validationCheck += "i"; passed = false; }
                                            break;
                                        case "in":
                                            height = fieldData[1].Replace("in", "");
                                            Console.WriteLine("Height in: " + height);
                                            if (59 <= int.Parse(height) && int.Parse(height) <= 76) { validationCheck += "v"; passed = true; }
                                            else { validationCheck += "i"; passed = false; }
                                            break;
                                    }
                                    break;

                                case "hcl":
                                    Regex rx = new Regex(@"[#][a-f0-9]{6}");
                                    if (rx.IsMatch(fieldData[1])) { validationCheck += "v"; passed = true; }
                                    else { validationCheck += "i"; passed = false; }
                                    break;

                                case "ecl":
                                    Regex ex = new Regex(@"(amb)$|(blu)$|(brn)$|(gry)$|(grn)$|(hzl)$|(oth)$");
                                    if (ex.IsMatch(fieldData[1])) { validationCheck += "v"; passed = true; }
                                    else { validationCheck += "i"; passed = false; }
                                    break;

                                case "pid":
                                    Regex px = new Regex(@"[0-9]{9}");
                                    if (px.IsMatch(fieldData[1])) { validationCheck += "v"; passed = true; }
                                    else { validationCheck += "i"; passed = false; }
                                    break;

                                case "cid":
                                    break;
                            }
                            File.AppendAllText(@"Output4.txt", fieldData[0] + ": " + fieldData[1] + " | Result: " + (passed ? "Passed" : "Failed") + Environment.NewLine);
                        }
                    }
                    Regex fx = new Regex(@"[v]{7}");
                    if (fx.IsMatch(validationCheck))
                    {
                        Console.WriteLine("Validation Result: Passed | Result: " + validationCheck);
                        valid++;
                        File.AppendAllText(@"Output4.txt", "Validation Result: Passed | Result: " + validationCheck + Environment.NewLine);
                    }
                    else
                    {
                        Console.WriteLine("Validation Result: Failed | Result: " + validationCheck);
                        File.AppendAllText(@"Output4.txt", "Validation Result: Failed | Result: " + validationCheck + Environment.NewLine);
                    }
                    File.AppendAllText(@"Output4.txt", "_________________" + Environment.NewLine);
                }
            }
            Console.WriteLine("Result: " + valid);
            File.AppendAllText(@"Output4.txt", "Result: " + valid);
        }
    }
}

