using System;

namespace Queestion1
{
    /*
     * 2 класса Ping и Pong
    один уведомляет другого, о том, что "произошёл пинг", другой - о том, что "произошёл понг",
    одна пара объектов "играют" между собой, другая пара - между собой и т.д.
    и выводить на консоль соответсвующие сообщения, что-то вроди такого:

    Ping received Pong.
    Pong received Ping.
    Ping received Pong.
    Pong received Ping.
    Ping received Pong*/

    class Ping
    {
        public delegate void PingShoot(string message);
        public event PingShoot Notify;

        public Ping()
        {
            
        }

        public void Shoot()
        {
            Notify?.Invoke("Pong received Ping.");
        }
    }

    class Pong
    {
        public delegate void PongShoot(string message);
        public event PongShoot Notify;

        public Pong()
        {

        }

        public void Shoot()
        {
            Notify?.Invoke("Ping received Pong.");
        }
    }

    class Program
    {
        public static bool checkerName;

        static void ShottersMessage(string mes)
        {
            Console.WriteLine(mes);
        }

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

        static void Main(string[] args)
        {
            bool pingDo;
            bool pongDo;
            bool mainDo;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter which you want shoot(type ping or pong): ");
                Console.ResetColor();
                string choice = ChoiceChecker();

                switch (choice)
                {
                    case "ping":
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Ping ping = new Ping();
                            ping.Notify += ShottersMessage;
                            ping.Shoot();
                            Console.ResetColor();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Would you try again ? (Y/y) or (N/n): ");
                            do
                            {
                                string otvet = ChoiceChecker();
                                switch (otvet)
                                {
                                    case "Y":
                                        {
                                            mainDo = false;
                                            pingDo = true;
                                            break;
                                        }
                                    case "y":
                                        {
                                            mainDo = false;
                                            pingDo = true;
                                            break;
                                        }
                                    case "N":
                                        {
                                            Console.WriteLine("Have a good day :)");
                                            mainDo = true;
                                            pingDo = true;
                                            break;
                                        }
                                    case "n":
                                        {
                                            Console.WriteLine("Have a good day :)");
                                            mainDo = true;
                                            pingDo = true;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.Write("You enter incorrect symbol, please enter Y/y or N/n: ");
                                            mainDo = false;
                                            pingDo = false;
                                            continue;
                                        }
                                }
                            }
                            while (pingDo == false);

                            break;
                        }
                    case "pong":
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Pong pong = new Pong();
                            pong.Notify += ShottersMessage;
                            pong.Shoot();

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("Would you try again ? (Y/y) or (N/n): ");
                            do
                            {
                                string otvet = ChoiceChecker();
                                switch (otvet)
                                {
                                    case "Y":
                                        {
                                            mainDo = false;
                                            pongDo = true;
                                            break;
                                        }
                                    case "y":
                                        {
                                            mainDo = false;
                                            pongDo = true;
                                            break;
                                        }
                                    case "N":
                                        {
                                            Console.WriteLine("Have a good day :)");
                                            mainDo = true;
                                            pongDo = true;
                                            break;
                                        }
                                    case "n":
                                        {
                                            Console.WriteLine("Have a good day :)");
                                            mainDo = true;
                                            pongDo = true;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.Write("You enter incorrect symbol, please enter Y/y or N/n: ");
                                            mainDo = false;
                                            pongDo = false;
                                            continue;
                                        }
                                }
                            }
                            while (pongDo == false);


                            break;
                        }
                    default:
                        {
                            Console.Write("Incorrect type\n");
                            mainDo = false;
                            break;
                        }
                }
            } while (mainDo == false);

            

            Console.ReadKey();
        }
    }
}
