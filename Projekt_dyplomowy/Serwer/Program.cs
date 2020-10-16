using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Serwer
{
    class Program : Form
    {
        private static Config config;

        [STAThread]
        static void Main(string[] args) //główna funckja programu
        {
            Menu();
        }

        private static void Menu() //wybór funkcji użytkownika
        {
            string caseSwitch = "";
            do
            {
                try
                {
                    Console.WriteLine("Witaj użytkowniku " + Environment.UserName);
                    Console.WriteLine("Wybierz spoósb konfiguracji serwera:");
                    Console.WriteLine("1) automatyczny z pliku .txt/.xml   2) ręczna konfiguracja");
                    ConsoleKeyInfo cki;
                    cki = Console.ReadKey(true);
                    caseSwitch = (cki.Key.ToString());

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
                            throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nie ma takiej opcji, proszę wybrać poprawną opcję.");
                    Console.Read();
                    Console.Clear();
                }
            } while (config == null);
            InfoDisplay();
        }

        private static void SetConfig() //funkcja ręcznej konfiguracji serwera
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
                    Console.ReadKey(true); //czekanie na potwierdzenie błedu
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
                    Console.ReadKey(true); //czekanie na potwierdzenie błedu
                    Console.Clear();
                    Console.WriteLine("Witaj użytkowniku " + username + "!");
                    Console.WriteLine("Proszę podaj port, po którym odbywać się będzię komunikacja: " + port);
                    next = true;
                }
            } while (next);

            config = new Config(username, hostName, ip_address, port, buffer_size);//utworzenie configa
            Console.WriteLine("Poprawna konfiguracja serwera.");
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

        private static void ImportConfig() //funkcja do automatycznej konfiguracji serwera
        {
            StreamReader file;
            string[] result = new string[2];
            string filePath, line;
            int port = 0, buffer_size = 0, counterp = 0, counterb = 0;
            string username = Environment.UserName; //odczyt nazwy konta użytkownika
            string hostName = Dns.GetHostName(); //odczyt hostname
            string ip_address = Dns.GetHostByName(hostName).AddressList[0].ToString(); // odczyt adresu IPv4

            OpenFileDialog ofd = new OpenFileDialog(); //utworzenie okna do przeglądania plików konfiguracji
            ofd.Filter = "txt files (*.txt)|*.txt|xml files (*.xml)|*.xml"; //filtry na pliki txt i xml
            ofd.FilterIndex = 1; //ustawienie domyślnego filtru na plik txt
            ofd.RestoreDirectory = true; //przywracanie wcześniej zamkniętego katalogu

            if (ofd.ShowDialog() == DialogResult.OK) //wyświetlenie okna ze sprawdzeniem, czy plik został wybrany
            {                
                filePath = ofd.FileName; //przypisanie ścieżki wybranego pliku do zmiennej

                if (ofd.FilterIndex == 1)//odczyt dla pliku txt
                {
                    try
                    {
                        file = new StreamReader(filePath); //utworzenie odczytu pliku
                        while ((line = file.ReadLine()) != null)
                        {
                            line = String.Concat(line.Where(x => !Char.IsWhiteSpace(x))); //usunięcie wszelkich znaków białych z linii
                            result = line.Split(':'); //podzielenie odczytanej linii wykorzystując separator
                            switch (result[0])
                            {
                                case "port":
                                    port = Convert.ToInt32(result[1].TrimEnd(':')); //przypisanie numeru portu odczytanego z pliku txt
                                    counterp = 1;
                                    break;
                                case "buffer_size":
                                    buffer_size = Convert.ToInt32(result[1].TrimEnd(':')); //przypisanie rozmiaru buffera odczytanego z pliku txt
                                    counterb = 1;
                                    break;
                            }
                            if (counterp + counterb == 2)
                            {
                                break;
                            }
                        }
                        file.Close(); //zamknięcie pliku
                        if (counterp + counterb != 2)
                        {
                            file.Close(); //zamknięcie pliku
                            throw new FileLoadException();
                        }
                        config = new Config(username, hostName, ip_address, port, buffer_size);//utworzenie configa
                        Console.WriteLine("Poprawna konfiguracja serwera.");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    catch (FileLoadException)
                    {
                        Console.WriteLine("Plik konfiguracyjny jest uszkodzony! Spróbuj z innym plikiem lub skorzystaj z ręcznej konfiguracji!");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                }
                else if (ofd.FilterIndex == 2)
                {

                }
            }
            else
            {
                Console.WriteLine("Nie wybrano pliku. Powrót do menu głównego.");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
