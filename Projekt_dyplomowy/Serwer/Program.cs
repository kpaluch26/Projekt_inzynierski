using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace Serwer
{
    class Program : Form
    {
        private static Config config;

        [STAThread]
        static void Main(string[] args) //główna funckja programu
        {
            InitConfig();
            OptionsMenu();
        }

        private static void OptionsMenu()
        {
            bool work = true;
            while (work)
            {
                InfoDisplay();
                try
                {
                    string caseSwitch;
                    ConsoleKeyInfo cki;

                    Console.WriteLine("1) Export konfiguracji serwera do pliku .txt/.xml");
                    Console.WriteLine("2) Stwórz archiwum .zip i wyślij aktywnym klientom.");
                    Console.WriteLine("3) Wyjście");
                    cki = Console.ReadKey(true);
                    caseSwitch = (cki.Key.ToString());

                    switch (caseSwitch)
                    {
                        case "D1":
                            ExportConfig();
                            Console.Clear();
                            break;
                        case "D2":
                            CreateZIP();
                            Console.Clear();
                            break;
                        case "D3":
                            work = false;
                            break;
                        default:
                            throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Nie ma takiej opcji, proszę wybrać poprawną opcję.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
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

        private static void InitConfig() //wybór funkcji użytkownika
        {           
            do
            {
                try
                {
                    string caseSwitch;
                    ConsoleKeyInfo cki;

                    Console.WriteLine("Witaj użytkowniku " + Environment.UserName);
                    Console.WriteLine("Wybierz spoósb konfiguracji serwera:");
                    Console.WriteLine("1) Automatyczny z pliku .txt/.xml   2) Ręczna konfiguracja   3) Wyjście");
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
                        case "D3":
                            Environment.Exit(0);
                            break;
                        default:
                            throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nie ma takiej opcji, proszę wybrać poprawną opcję.");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            } while (config == null);
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
            ofd.Filter = "txt files (*.txt)|*.txt|xml files (*.xml)|*.xml"; //ustawienie filtrów okna na pliki txt i xml
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
                            result = line.Split('='); //podzielenie odczytanej linii wykorzystując separator
                            switch (result[0].ToLower())
                            {
                                case "port_tcp":
                                    port = Convert.ToInt32(result[1].Substring(1,result[1].Length-2)); //przypisanie numeru portu odczytanego z pliku txt
                                    counterp = 1;
                                    break;
                                case "buffer_size":
                                    buffer_size = Convert.ToInt32(result[1].Substring(1, result[1].Length - 2)); //przypisanie rozmiaru buffera odczytanego z pliku txt
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
                else if (ofd.FilterIndex == 2)//odczyt dla pliku xml
                {
                    try
                    {
                        bool serwer = false; 
                        bool configure = false;
                        file = new StreamReader(filePath); //utworzenie odczytu pliku
                        while ((line = file.ReadLine()) != null)
                        {
                            line = String.Concat(line.Where(x => !Char.IsWhiteSpace(x))); //usunięcie wszelkich znaków białych z linii
                            if (line.ToLower() == "<serwer>")
                            {
                                serwer = true;
                            }
                            else if (line.ToLower() == "</serwer>")
                            {
                                serwer = false;
                                break;
                            }
                            else if(line.ToLower() == "<configure>" && serwer)
                            {
                                configure = true;
                            }
                            else if(line.ToLower() == "</configure>" && serwer)
                            {
                                configure = false;
                            }
                            else if(serwer && configure)
                            {
                                result = line.Split('='); //podzielenie odczytanej linii wykorzystując separator
                                switch (result[0].ToLower())
                                {
                                    case "port_tcp":
                                        port = Convert.ToInt32(result[1].Substring(1, result[1].Length - 2)); //przypisanie numeru portu odczytanego z pliku xml
                                        counterp = 1;
                                        break;
                                    case "buffer_size":
                                        buffer_size = Convert.ToInt32(result[1].Substring(1, result[1].Length - 2)); //przypisanie numeru portu odczytanego z pliku xml
                                        counterb = 1;
                                        break;
                                }
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
            }
            else
            {
                Console.WriteLine("Nie wybrano pliku. Powrót do menu głównego.");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        private static void ExportConfig() //funkcja do eskportu konfiguracji serwera do pliku
        {
            SaveFileDialog sfg = new SaveFileDialog(); //utworzenie okna do przeglądania plików
            sfg.Filter = "txt files (*.txt)|*.txt|xml files (*.xml)|*.xml"; //ustawienie filtrów okna na pliki txt i xml
            sfg.FilterIndex = 1; //ustawienie domyślnego filtru na plik txt
            sfg.RestoreDirectory = true; //przywracanie wcześniej zamkniętego katalogu

            if (sfg.ShowDialog() == DialogResult.OK)//wyświetlenie okna ze sprawdzeniem, czy plik został zapisany
            {
                if (sfg.FilterIndex == 1) //zapis dla pliku txt
                {
                    File.WriteAllText(sfg.FileName, "port_tcp=" + '"' + config.Port() + '"' + 
                        Environment.NewLine + "buffer_size=" + '"' + config.BufferSize() + '"'); //stworzenie lub nadpisanie pliku        
                }
                else if (sfg.FilterIndex == 2)
                {
                    File.WriteAllText(sfg.FileName, "<serwer>" + 
                        Environment.NewLine + "    <configure>" + 
                        Environment.NewLine + "        port_tcp=" + '"' + config.Port() + '"' + 
                        Environment.NewLine + "        buffer_size=" + '"' + config.BufferSize() + '"' + 
                        Environment.NewLine + "    </configure>" + 
                        Environment.NewLine + "</serwer>"); //stworzenie lub nadpisanie pliku 
                }
                Console.WriteLine("Wyeksportowano konfiguracja: "+sfg.FileName);
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("Nie zapisano pliku. Powrót do menu głównego.");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        private static void CreateZIP() //funkcja do tworzenia archiwum zip
        {
            OpenFileDialog ofd = new OpenFileDialog(); //utworzenie okna do przeglądania plików
            ofd.Filter = "all files (*.*)|*.*"; //ustawienie filtrów okna na dowolne pliki
            ofd.FilterIndex = 1; //ustawienie domyślnego filtru
            ofd.RestoreDirectory = true; //przywracanie wcześniej zamkniętego katalogu
            ofd.Multiselect = true; //ustawienie możliwości wyboru wielu plików z poziomu okna

            SaveFileDialog sfg = new SaveFileDialog(); //utworzenie okna do przeglądania plików
            sfg.Filter = "zip file(*.zip)|*.zip"; //ustawienie filtrów okna na pliki .zip
            sfg.FilterIndex = 1; //ustawienie domyślnego filtru na plik .zip
            sfg.RestoreDirectory = true; //przywracanie wcześniej zamkniętego katalogu

            try
            {
                if (ofd.ShowDialog() == DialogResult.OK && sfg.ShowDialog() == DialogResult.OK)//sprawdzenie czy otworzone okna zwracają prawidłowe dane
                {
                    int counter = 0; //licznik do odczytywania odpowiednich nazw plików

                    if (File.Exists(sfg.FileName)) //sprawdzanie czy archiwum o takiej nazwie istnieje
                    {
                        File.Delete(sfg.FileName); //usuwanie istniejącego archiwum
                    }

                    var zip = ZipFile.Open(sfg.FileName, ZipArchiveMode.Create); //utworzenie archiwum
                    foreach (string file in ofd.FileNames)
                    {
                        zip.CreateEntryFromFile(file, ofd.SafeFileNames[counter], CompressionLevel.Optimal); //zapis do utworzonego archiwum plików wybranych przez użytkownika
                        counter++;
                    }
                    zip.Dispose(); //zwolnienie zasobu
                    Console.WriteLine("Zarchiwizowano pliki.");
                    Console.ReadKey(true);
                }
                else if(ofd.ShowDialog()!=DialogResult.OK)
                {
                    Console.WriteLine("Nie wybrano plików do zarchiwizowania.");
                    Console.ReadKey(true);
                }
                else
                {
                    Console.WriteLine("Nie podano nazwy archiwum.");
                    Console.ReadKey(true);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey(true);
            }

        }
    }
}
