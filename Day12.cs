using System;
using System.IO;

namespace Day3
{
    public class Waypoint
    {
        public int x = 0;
        public int y = 0;
    }
    public class Ship
    {
        public int x = 0;
        public int y = 0;
        public int dir = 0;
    }
    public class Day12
    {
        public static void NavSys()
        {
            string[] movements = File.ReadAllLines(@"Inputs/Input_Day12.txt");
            Part1(movements);
            Part2(movements);
        }
        static void Part1(string[] movements)
        {
            Ship ship = new Ship();
            int value = 0;
            foreach (string line in movements)
            {
                value = int.Parse(line.Remove(0, 1));
                switch (line[0])
                {
                    case 'N':
                        ship.y = ship.y + value;
                        break;

                    case 'S':
                        ship.y = ship.y - value;
                        break;

                    case 'E':
                        ship.x = ship.x + value;
                        break;

                    case 'W':
                        ship.x = ship.x - value;
                        break;

                    case 'L':
                        ship.dir = normalize((ship.dir - value));
                        break;

                    case 'R':
                        ship.dir = normalize((ship.dir + value));
                        break;

                    case 'F':
                        switch (ship.dir)
                        {
                            case 0:
                                ship.x = ship.x + value;
                                break;

                            case 90:
                                ship.y = ship.y - value;
                                break;

                            case 180:
                                ship.x = ship.x - value;
                                break;

                            case 270:
                                ship.y = ship.y + value;
                                break;

                            default:
                                Console.WriteLine("Error Direction: " + ship.dir);
                                break;
                        }
                        break;
                }
            }
            int manhattanDist = posNum(ship.x) + posNum(ship.y);
            Console.WriteLine("Result Part 1: " + manhattanDist);
        }

        static void Part2(string[] movements)
        {
            Ship ship = new Ship();
            Waypoint way = new Waypoint();
            way.y = ship.y + 1;
            way.x = ship.x + 10;

            int value = 0;
            foreach (string line in movements)
            {
                value = int.Parse(line.Remove(0, 1));
                switch (line[0])
                {
                    case 'N':
                        way.y = way.y + value;
                        break;

                    case 'S':
                        way.y = way.y - value;
                        break;

                    case 'E':
                        way.x = way.x + value;
                        break;

                    case 'W':
                        way.x = way.x - value;
                        break;

                    case 'L':
                        ChangeWaypointDir(way, value, line[0]);
                        break;

                    case 'R':
                        ChangeWaypointDir(way, value, line[0]);
                        break;

                    case 'F':
                        for (int i = 0; i < value; i++)
                        {
                            ship.x = ship.x + way.x;
                            ship.y = ship.y + way.y;
                        }
                        break;
                }
            }
            int manhattanDist = posNum(ship.x) + posNum(ship.y);
            Console.WriteLine("Result Part 2: " + manhattanDist);
        }
        static void ChangeWaypointDir(Waypoint waypoint, int value, char dir)
        {
            int tempX = waypoint.x;
            int tempY = waypoint.y;
            bool was270 = false;
            if (value == 180)
            {
                waypoint.x = tempX * -1;
                waypoint.y = tempY * -1;
                return;
            }
            else
            {
                if (dir == 'L' && value == 270)
                {
                    value = 90;
                    was270 = true;
                }
                else if (dir == 'R' && value == 270)
                {
                    value = -90;
                    was270 = true;
                }
                if (dir == 'L' && was270 == false)
                {
                    value = value * -1;
                }
                switch (value)
                {
                    case 90:
                        waypoint.x = tempY;
                        waypoint.y = tempX * -1;
                        break;
                    case -90:
                        waypoint.x = tempY * -1;
                        waypoint.y = tempX;
                        break;
                }
                return;
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
