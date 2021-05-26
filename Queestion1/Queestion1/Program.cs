using System;

namespace Queestion1
{
    class Ping
    {
        public delegate void PingShoot(string message);
        public event PingShoot Notify;

        public void Shoot()
        {
            Notify?.Invoke("Pong received Ping.");
        }
    }

    class Pong
    {
        public delegate void PongShoot(string message);
        public event PongShoot Notify;

        public void Shoot()
        {
            Notify?.Invoke("Ping received Pong.");
        }
    }

    class Program
    {
        public static bool checkerPingPong;

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
                        checkerPingPong = false;
                        Console.Write("Incorrect name type, please enter correct name: ");
                        break;
                    }
                    else
                    {
                        checkerPingPong = true;
                    }
                }
            }
            while (checkerPingPong == false);

            return pingPong;
        }

        public static void ShottersMessage(string mes)
        {
            Console.WriteLine(mes);
        }

        public static int counterPing;
        public static int counterPong;


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

                            if (counterPing == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                Ping ping = new Ping();
                                ping.Notify += ShottersMessage;
                                ping.Shoot();
                                Console.Beep(500, 250);

                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Would you try again ? (Y/y) or (N/n): ");
                                do
                                {
                                    string continueYesOrNo = ChoiceChecker();
                                    switch (continueYesOrNo)
                                    {
                                        case "Y":
                                            {
                                                mainDo = false;
                                                pingDo = true;
                                                counterPing++;
                                                counterPong = 0;

                                                break;
                                            }
                                        case "y":
                                            {
                                                mainDo = false;
                                                pingDo = true;
                                                counterPing++;
                                                counterPong = 0;

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
                                } while (pingDo == false);
                            }
                            else
                            {
                                Console.WriteLine("Ping can't shoot, right now Pong turn");
                                mainDo = false;
                            }
                            break;
                        }

                    case "pong":
                        {
                            if (counterPong == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;

                                Pong pong = new Pong();
                                pong.Notify += ShottersMessage;
                                pong.Shoot();
                                Console.Beep(1000, 250);

                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Would you try again ? (Y/y) or (N/n): ");
                                do
                                {
                                    string continueYesOrNo = ChoiceChecker();
                                    switch (continueYesOrNo)
                                    {
                                        case "Y":
                                            {
                                                mainDo = false;
                                                pongDo = true;
                                                counterPong++;
                                                counterPing = 0;

                                                break;
                                            }
                                        case "y":
                                            {
                                                mainDo = false;
                                                pongDo = true;
                                                counterPong++;
                                                counterPing = 0;

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
                            }
                            else
                            {
                                Console.WriteLine("Pong can't shoot, right now Ping turn");
                                mainDo = false;
                            }
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