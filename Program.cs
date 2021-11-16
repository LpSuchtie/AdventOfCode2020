using System;

namespace Day3 {
    class Program {
        static void Main (string[] args) {
            int userInput = 0;
            userInput = DisplayMenu ();
            Console.WriteLine ();
            Console.WriteLine ("_______________________");
            Console.WriteLine ("Output:");
            Console.WriteLine ("_______________________");
            switch (userInput) {
                case 3:

                    Program3.Trees ();
                    break;

                case 4:
                    Program4.Passport ();
                    break;

                case 5:
                    Program5.Board ();
                    break;

                case 6:
                    Program6.Form ();
                    break;

                case 7:
                    Day7.Luggage ();
                    break;

                case 8:
                    Day8.Game ();
                    break;

                case 9:
                    Day9.XMAS ();
                    break;

                case 10:
                    Day10.Joltage();
                    break;

                case 11:
                    Day11.Seats();
                    break;

                case 12:
                    Day12.NavSys();
                    break;

                case 13:
                    Day13.Shuttle();
                    break;

                case 14:
                    Day14.Bitmask();
                    break;

                case 15:
                    Day15.Recitation();
                    break;
                    case
            }
        }

        static public int DisplayMenu () {
            Console.WriteLine ("");
            Console.WriteLine ();
            Console.WriteLine ("3. Day 3: Trees");
            Console.WriteLine ("4. Day 4: Passports");
            Console.WriteLine ("5. Day 5: Boarding Passports");
            Console.WriteLine ("6. Day 6: Customs Forms");
            Console.WriteLine ("7. Day 7: Luggage Processing");
            Console.WriteLine ("8. Day 8: Game Code");
            Console.WriteLine ("9. Day 9: XMAS Protocol");
            Console.WriteLine ("10. Day 10: Joltage Adapter");
            Console.WriteLine ("11. Day 11: Seating System");
            Console.WriteLine ("12. Day 12: Nav System");
            Console.WriteLine ("13. Day 13: Shuttle Search");
            Console.WriteLine ("14. Day 14: Docking Data");
            Console.WriteLine ("15. Day 15: Rambunctious Recitation");
            Console.WriteLine ("0. Exit");
            var result = Console.ReadLine ();
            return Convert.ToInt32 (result);
        }
    }
}