using System;

namespace Queestion1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool firstDo;

            Console.Write("Enter which you want shoot(type ping or pong): ");
            do
            {
                string choice = ChoiceChecker();

                switch (choice)
                {
                    case "ping":
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ping");
                            firstDo = true;
                            break;
                        }
                    case "pong":
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Pong");
                            firstDo = true;
                            break;
                        }
                    default:
                        {
                            Console.Write("Incorrect type ping or pong: ");
                            firstDo = false;
                            break;
                        }
                }
            } while (firstDo == false);

            Console.ReadKey();
        }

        //public static bool firstDo;

        public static bool checkerName;

        public static string NameForCompare;

        public static string ChoiceChecker()
        {
            string pingPong;
            do
            {
                pingPong = Convert.ToString(Console.ReadLine());

                for (int i = 0; i < pingPong.Length; i++)
                {
                    char element = pingPong[i];

                    if (!Char.IsLetter(element))
                    {
                        checkerName = false;
                        Console.Write("Incorrect name type, please enter correct name: ");
                        break;
                    }
                    else
                    {
                        checkerName = true;
                    }
                }
            }
            while (checkerName == false);

            return pingPong;
        }
    }
}
