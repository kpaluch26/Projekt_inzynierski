using System;
using System.Net;
using System.Security.Principal;

namespace Serwer
{
    class Program
    {

        private static Config config;

         private static void Main(string[] args)
        {
            SetConfig();
            InfoDisplay();
        }

        private static void SetConfig()
        {
            string username = Environment.UserName; //odczyt nazwy konta użytkownika
            string hostName = Dns.GetHostName(); //odczyt hostname
            string ip_address = Dns.GetHostByName(hostName).AddressList[1].ToString(); // odczyt adresu IPv4
            int port = 0, buffer_size = 0;
            bool next = false; //pomocnicza flaga do sprawdzania poprawności formatu

            do
            {
                Console.WriteLine("Witaj użytkowniku " + username);
                Console.Write("Proszę podaj port, po którym odbywać się będzię komunikacja: ");
                try
                {
                    port = Convert.ToInt32(Console.ReadLine()); //ręczne ustawienie portu komunikacji
                    next = false;
                }
                catch
                {
                    Console.WriteLine("Niepoprawny numer portu!");
                    Console.ReadKey(); //czekanie na potwierdzenie błedu
                    Console.Clear();
                    next = true;
                }
            } while (next);

            do
            {
                Console.Write("Proszę podaj rozmiar buforowania: ");
                try
                {
                    buffer_size = Convert.ToInt32(Console.ReadLine()); //ręczne ustawienie rozmiaru bufera
                    next = false;
                }
                catch
                {
                    Console.WriteLine("Niepoprawny rozmiar bufera!");
                    Console.ReadKey(); //czekanie na potwierdzenie błedu
                    Console.Clear();
                    Console.WriteLine("Witaj użytkowniku " + username);
                    Console.WriteLine("Proszę podaj port, po którym odbywać się będzię komunikacja: " + port);
                    next = true;
                }
            } while (next);

            config = new Config(username, hostName, ip_address, port, buffer_size);//utworzenie configa
            Console.Clear();
        }

        private static void InfoDisplay()
        {
            for(int i=0;i< config.ToString().Length+2; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.WriteLine("*" + config + "*");
            for (int i = 0; i < config.ToString().Length+2; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}
