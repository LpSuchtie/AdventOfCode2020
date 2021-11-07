using System;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            userInput = DisplayMenu();
            Console.WriteLine();
            Console.WriteLine("_______________________");
            switch (userInput)
            {
                case 3:
                    Console.WriteLine("Day 3 Output:");
                    Console.WriteLine("_______________________");
                    Program3.Trees();
                    break;

                case 4:
                    Console.WriteLine("Day 4 Output:");
                    Console.WriteLine("_______________________");
                    Program4.Passport();
                    break;

                case 5:
                    Console.WriteLine("Day 5 Output:");
                    Console.WriteLine("_______________________");
                    Program5.Board();
                    break;

                case 6:
                    Console.WriteLine("Day 6 Output:");
                    Console.WriteLine("_______________________");
                    Program6.Form();
                    break;

                case 7:
                    Console.WriteLine("Day 7 Output:");
                    Console.WriteLine("_______________________");
                    Day7.Luggage();
                    break;

                case 8:
                    Console.WriteLine("Day 8 Output:");
                    Console.WriteLine("_______________________");
                    Day8.Game();
                    break;

                case 9:
                    Console.WriteLine("Day 9 Output:");
                    Console.WriteLine("_______________________");
                    Day9.XMAS();
                    break;
            }
        }

        static public int DisplayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine();
            Console.WriteLine("3. Day 3: Trees");
            Console.WriteLine("4. Day 4: Passports");
            Console.WriteLine("5. Day 5: Boarding Passports");
            Console.WriteLine("6. Day 6: Customs Forms");
            Console.WriteLine("7. Day 7: Luggage Processing");
            Console.WriteLine("8. Day 8: Game Code");
            Console.WriteLine("9. Day 9: XMAS Protocol");
            Console.WriteLine("0. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}

