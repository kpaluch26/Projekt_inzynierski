using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serwer
{
    class Program :Form
    {
        private static Config config;

        [STAThread]
        static void Main(string[] args)
        {
            Menu();
            //InfoDisplay();
        }

        private static void Menu()
        {
            bool flags = false;
            string caseSwitch="";

                if (config == null)
                {
                    do
                    {
                        try
                        {
                            Console.WriteLine("Witaj użytkowniku " + Environment.UserName);
                            Console.WriteLine("Wybierz spoósb konfiguracji serwera:");
                            Console.Write("1) automatyczny z pliku .txt/.xml   2) ręczna konfiguracja");
                            ConsoleKeyInfo cki;
                            cki = Console.ReadKey();
                            caseSwitch = (cki.Key.ToString());
                            flags = false;

                            switch (caseSwitch)
                            {
                                case "D1":
                                    Console.Clear();
                                    ImportConfig();
                                    break;
                                case "D2":
                                    Console.Clear();
                                    SetConfig();
                                    break;
                                default:
                                    throw new Exception();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Nie ma takiej opcji, proszę wybrać poprawną opcję.");
                            Console.Read();
                            Console.Clear();
                            flags = true;

                        }
                    } while (flags);
                }
                else
                {
                InfoDisplay();
                }
        }

        private static void SetConfig()
        {
            string username = Environment.UserName; //odczyt nazwy konta użytkownika
            string hostName = Dns.GetHostName(); //odczyt hostname
            string ip_address = Dns.GetHostByName(hostName).AddressList[0].ToString(); // odczyt adresu IPv4
            int port = 0, buffer_size = 0;
            bool next = false; //pomocnicza flaga do sprawdzania poprawności formatu

            do
            {
                Console.WriteLine("Ręczna konfiguracja serwera.");
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
                    Console.WriteLine("Witaj użytkowniku " + username + "!");
                    Console.WriteLine("Proszę podaj port, po którym odbywać się będzię komunikacja: " + port);
                    next = true;
                }
            } while (next);

            config = new Config(username, hostName, ip_address, port, buffer_size);//utworzenie configa
            Console.WriteLine("Poprawna konfiguracja serwera.");
            //Console.WriteLine(ip_address);
            Console.ReadKey();
            Console.Clear();
        }

        private static void InfoDisplay() //ramka do wyświetlania informacji o konfiguracji użytkownika
        {
            for (int i = 0; i < config.ToString().Length + 2; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.WriteLine("*" + config + "*");
            for (int i = 0; i < config.ToString().Length + 2; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        private static void ImportConfig()
        {
            string filePath;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt|xml files (*.xml)|*.xml";
            ofd.ShowDialog();
            filePath = ofd.FileName;
        }

    }
}
