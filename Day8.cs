using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Day3
{
    public class Day8
    {
        public static void Game()
        {
            File.WriteAllText(@"Output8.txt", string.Empty);
            string[] inst = File.ReadAllLines(@"Inputs/Input_Day8.txt");

            GetLoop(inst);
            FixProgram(inst);
        }

        static void FixProgram(string[] inst)
        {
            for (int i = 0; i < inst.Length - 1; i++)
            {
                string original = inst[i];

                if (inst[i].Split(" ")[0] == "jmp")
                {
                    inst[i] = inst[i].Replace("jmp", "nop");
                }
                else if (inst[i].Split(" ")[0] == "nop")
                {
                    inst[i] = inst[i].Replace("nop", "jmp");
                }
                else
                {
                    continue;
                }

                if (Terminates(inst))
                {
                    Console.WriteLine("Program Terminated!");
                    break;
                }
                inst[i] = original;
            }
        }

        static bool Terminates(string[] inst)
        {
            int acc = 0;
            int programCounter = 0;
            HashSet<int> executed = new HashSet<int>();

            while (true)
            {
                if (executed.Contains(programCounter))
                {
                    return false;
                }
                executed.Add(programCounter);

                switch (inst[programCounter].Split(" ")[0])
                {
                    case "nop":
                        programCounter++;
                        break;

                    case "acc":
                        acc += int.Parse(inst[programCounter].Split(" ")[1]);
                        programCounter++;
                        break;

                    case "jmp":
                        programCounter += int.Parse(inst[programCounter].Split(" ")[1]);
                        break;
                }

                if (programCounter == inst.Length)
                {
                    Console.WriteLine("Acc: " + acc);
                    return true;
                }
            }
        }

        static void GetLoop(string[] inst)
        {
            int acc = 0;
            int[] runLines = new int[File.ReadAllLines(@"Inputs/Input_Day8.txt").Length];
            int order = 0;
            for (int i = 0; i < runLines.Length;)
            {
                runLines[order] = i;
                switch (inst[i].Split(" ")[0])
                {
                    case "nop":
                        i++;
                        order++;
                        break;

                    case "acc":
                        order++;
                        acc += int.Parse(inst[i].Split(" ")[1]);
                        i++;
                        break;

                    case "jmp":
                        order++;
                        i += int.Parse(inst[i].Split(" ")[1]);
                        if (runLines.Contains(i) == true)
                        {
                            Console.WriteLine("Loop Found! Acc: " + acc);
                            return;
                        }
                        break;
                }
            }
        }
    }
}