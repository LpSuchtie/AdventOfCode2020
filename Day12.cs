using System;
using System.IO;

namespace Day3
{
    public class Day12
    {
        static int x = 0;
        static int y = 0;
        static int dir = 0;
        public static void NavSys()
        {
            string[] movements = File.ReadAllLines(@"Inputs/Input_Day12.txt");
            Part1(movements);
        }
        static void Part1(string[] movements)
        {
            int value = 0;
            foreach (string line in movements)
            {
                value = int.Parse(line.Remove(0,1));
                switch (line[0])
                {
                    case 'N':
                    y = y + value;
                        break;

                    case 'S':
                    y = y - value;
                        break;

                    case 'E':
                    x = x + value;
                        break;

                    case 'W':
                    x = x - value;
                        break;

                    case 'L':
                    dir = normalize((dir - value));
                        break;

                    case 'R':
                    dir = normalize((dir + value));
                        break;

                    case 'F':
                    switch (dir)
                    {
                        case 0:
                            x = x + value;
                            break;
                        
                        case 90:
                            y = y - value;
                            break;

                        case 180:
                            x = x - value;
                            break;

                        case 270:
                            y = y + value;
                            break;

                        default:
                            Console.WriteLine("Error Direction: " + dir);
                            break;
                    }
                        break;
                }
            }
            int manhattanDist = posNum(x) + posNum(y);
            Console.WriteLine("Result Part 1: " + manhattanDist);
        }

        static void Part2(string[] movements)
        {

        }
        static int normalize(int value)
        {
            return (value % 360) + (value < 0 ? 360 : 0);
        }
        static int posNum(int num)
        {
            if (num < 0)
            {
                return (num - (num * 2));
            }
            else
            {
                return num;
            }
        }
    }
}
