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
            Console.WriteLine ("0. Exit");
            var result = Console.ReadLine ();
            return Convert.ToInt32 (result);
        }
    }
}