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
            string[] movements = File.ReadAllLines(@"Input_Day12.txt");
            foreach (string line in movements)
            {
                
            }
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
