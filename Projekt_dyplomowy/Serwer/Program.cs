using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;
using System.ComponentModel;
using System.Net.Sockets;
using System.Windows.Forms.VisualStyles;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Security;
//using Ionic.Zip;

namespace Serwer
{
    class Program : Form
    {
        //zmienne globalne
        private static ServerOptions server_option = ServerOptions.locked; //tryb pracy serwera -> domyślnie locked
        private static Config config; //konfiguracja serwera -> domyślnie pusta
        private static BackgroundWorker m_oBackgroundWorker = null; //wątek roboczy pracujacy w tle -> domyślnie niezainicjowany
        private static FileData file; //plik do udostepnienia -> domyslnie pusty
        private static string save_address; //ścieżka zapisu przychodzących plików ->domyslnie pusta
        private static int active_clients = 0; //liczba aktywnych połączeń -> domyślnie zero
        private static List<String> history = new List<String>(); //historia działań serwera i klientow -> domyślnie pusta
        private static ServerHistory server_history = new ServerHistory(); //obiekt do wywoływania odpowiednich komunikatow historii -> domyślnie utworzony

        [STAThread]
        static void Main(string[] args) //główna funckja programu
        {           
            InitConfig(); //wczytanie lub stworzenie konfiguracji serwera
            history.Add(DateTime.Now.TimeOfDay.ToString() + " Rozpoczęcie pracy serwera."); //dodanie do historii godziny startu serwera
            OptionsMenu(); //wybór funkcji programu
            BackgroundWorkerClose(); //zamknięcie wątka roboczego o ile istnieje
        }

        private static void ShowHistory() //funkcja do wyświetlania historii operacji
        {
            foreach (var x in history)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("Naciśnij dowolny klawisz by zamknąć historię."); //komunikat
            Console.ReadKey(true); //czekanie na potwierdzenie
        }

        private static void SetFont() //funkcja do wyświetlania menu opcji
        {
            Console.WriteLine("1) Export konfiguracji serwera do pliku .txt/.xml"); //komunikat
            Console.WriteLine("2) Stwórz archiwum .zip."); //komunikat
            if (file == null) //jeśli nie wybrano jeszcze pliku do udostępnienia
            {
                Console.WriteLine("3) Wybierz archiwum .zip do udostępnienia."); //komunikat
            }
            else
            {
                Console.WriteLine("3) Zmień archiwum .zip do udostępnienia."); //komunikat
            }
            Console.WriteLine("4) Zmień ścieżkę dostępu."); //komunikat
            Console.WriteLine("5) Zmień tryb pracy serwera."); //komunikat
            Console.WriteLine("6) Wyświetl historie operacji."); //komunikat
            Console.WriteLine("7) Export historii operacji."); //komunikat
            Console.WriteLine("9) Wyjście"); //komunikat
        }

        private static void OptionsMenu() //wybór funkcji programu
        {
            bool work = true; //zmienna pomocnicza
            while (work)
            {
                InfoDisplay(); //wyświetlenie informacji o serwerze i jego konfiguracji
                try
                {
                    string caseSwitch; //zmienna do odczytywania wybranej przez użytkownika opcji
                    ConsoleKeyInfo cki; //zmienna pomocnicza do odczytywania wybranej przez użytkownika opcji
                    SetFont(); //wyświetlenie menu opcji
                    cki = Console.ReadKey(true); //odczyt opcji użytkownika
                    caseSwitch = (cki.Key.ToString()); //konwertowanie opcji na konkretny klawisz

                    switch (caseSwitch) //wywołanie funkcji programu zgodnie z wyborem użytkownika
                    {
                        case "D1": //1
                            ExportConfig(); //eksportowanie pliku konfiguracyjnego
                            Console.Clear(); //czyszczenie konsoi
                            break;
                        case "D2": //2
                            Console.WriteLine("Czy chcesz dodać hasło do archiwum? (T/N)");
                            cki = Console.ReadKey(true); //odczyt opcji użytkownika
                            string help = (cki.Key.ToString()); //konwertowanie opcji na konkretny klawisz
                            if (help == "T")
                            {
                                CreateZIP(true); //tworzenie archiwum ZIP
                                Console.Clear(); //czyszczenie konsoli
                            }
                            else if(help == "N")
                            {
                                CreateZIP(false); //tworzenie archiwum ZIP
                                Console.Clear(); //czyszczenie konsoli
                            }
                            else 
                            {
                                Console.WriteLine("Nie wybrano prawidłowej opcji. Powrót do menu głównego.");
                                Console.ReadKey(true);
                                Console.Clear(); //czyszczenie konsoli
                            }
                                break;
                        case "D3": //3
                            SetSendingFile(); //wybranie pliku do udostępnienia
                            Console.Clear(); //czyszczenie konsoli
                            break;
                        case "D4": //4
                            ChangeFilePath(); //zmiana ścieżki zapisu otrzymanych plików
                            Console.Clear(); //czyszczenie konsoli
                            break;
                        case "D5": //5
                            SetServerOptions(); //zmiana trybu pracy serwera
                            Console.Clear(); //czyszczenie konsoli
                            break;
                        case "D6": //6
                            ShowHistory(); //wyświetlanie historii
                            Console.Clear(); //czyszczenie konsoli
                            break;
                        case "D7": //7
                            HistoryExport(); //export historii
                            Console.Clear(); //czyszczenie konsoli
                            break;
                        case "D9": //9
                            work = false; //przerwanie pętli == koniec pracy programu
                            break;
                        default: //w przypadku wybrania nieistniejącej opcji przez użytkownika
                            throw new Exception(); //wyrzuca wyjątek
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    //Console.WriteLine("Nie ma takiej opcji, proszę wybrać poprawną opcję."); //komunikat
                    Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                    Console.Clear(); //czyszczenie konsoli
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
            Console.WriteLine("*" + config + "*"); //wyswietlenie bieżącej konfiguracji serwera
            for (int i = 0; i < config.ToString().Length + 2; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            InfoUsers(); //wyśiwetlenie informacji o serwerze
        }

        private static void InfoUsers() //ramka do wyświetlania informacji o serwerze
        {
            string users_info = "Aktywni użytkownicy: "; //komunikat
            string server_info = "Tryb pracy serwera:  "; //komunikat
            string file_info = "Wybrany plik do udostępnienia: "; //komunikat
            Console.Write("|");
            for(int i = 0; i < active_clients.ToString().Length+ users_info.Length+2; i++)
            {
                Console.Write("-");
            }
            Console.Write("||");
            for (int i=0; i<server_info.Length+2 + server_option.ToString().Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("|");
            Console.WriteLine("| " + users_info + active_clients + " || " + server_info + server_option + " |"); //wyśiwetlenie aktywnych połączeń || wyświetlenie aktualnego trybu pracy serwera
            Console.Write("|");
            for (int i = 0; i < active_clients.ToString().Length + users_info.Length + 2; i++)
            {
                Console.Write("-");
            }
            Console.Write("||");
            for (int i = 0; i < server_info.Length + 2 + server_option.ToString().Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("|");
            if (file != null) //jeśli wybrano plik do udostępnienia
            {
                Console.Write("|");
                for (int i = 0; i < file_info.Length + 2 + file.GetName().Length; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("|");
                Console.WriteLine("| " + file_info + file.GetName() + " |"); //wyświetlenie wybranego pliku do udostępnienia
                Console.Write("|");
                for (int i = 0; i < file_info.Length + 2 + file.GetName().Length; i++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("|");
            }
        }

        private static void InitConfig() //wybór sposobu konfiguracji serwera
        {           
            do
            {
                try
                {
                    string caseSwitch; //zmienna do odczytywania wybranej przez użytkownika opcji
                    ConsoleKeyInfo cki; //zmienna pomocnicza do odczytywania wybranej przez użytkownika opcji
                    Console.WriteLine("Witaj użytkowniku " + Environment.UserName); //komunikat
                    Console.WriteLine("Wybierz spoósb konfiguracji serwera:"); //komunikat
                    Console.WriteLine("1) Automatyczny z pliku .txt/.xml   2) Ręczna konfiguracja   3) Wyjście"); //komunikat
                    cki = Console.ReadKey(true); //odczyt opcji użytkownika
                    caseSwitch = (cki.Key.ToString()); //konwertowanie opcji na konkretny klawisz

                    switch (caseSwitch) //wywołanie sposobu konfiguracji serwera zgodnie z wyborem użytkownika
                    {
                        case "D1": //1
                            ImportConfig(); //importowanie konfiguracji serwera z pliku
                            Console.Clear(); //czyszczenie konsoli
                            break;
                        case "D2": //2
                            SetConfig(); //ustawienie konfiguracji serwera w sposób ręczny
                            Console.Clear(); //czyszczenie konsoli
                            break;
                        case "D3": //3
                            Environment.Exit(0); //wyjście z programu
                            break;
                        default: //w przypadku wybrania nieistniejącej opcji
                            throw new FormatException(); //wyrzuca wyjątek
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Nie ma takiej opcji, proszę wybrać poprawną opcję."); //komunikat
                    Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                    Console.Clear(); //czyszczenie konsoli
                }
            } while (config == null); //dopóki nie ustawiono konfiguracji serwera
        }

        private static void SetConfig() //funkcja ręcznej konfiguracji serwera
        {
            string username = Environment.UserName; //odczyt nazwy konta użytkownika
            string hostName = Dns.GetHostName(); //odczyt hostname
            string ip_address = Dns.GetHostByName(hostName).AddressList[0].ToString(); // odczyt adresu IPv4
            string archive_address = ""; //zmienna pomocnicza do odczytu ścieżki zapisu otrzymanych plików
            int port = 0, buffer_size = 0; //zmienne pomocnicze do odczytu portu i rozmiaru buffera 
            bool next = false; //pomocnicza flaga do sprawdzania poprawności formatu

            do
            {
                Console.WriteLine("Ręczna konfiguracja serwera."); //komunikat
                Console.Write("Proszę podaj port, po którym odbywać się będzię komunikacja: "); //komunikat
                try
                {
                    port = Convert.ToInt32(Console.ReadLine()); //ręczne ustawienie portu komunikacji
                    next = false; //poprawny format wprowadzonych danych
                }
                catch
                {
                    Console.WriteLine("Niepoprawny numer portu!"); //komunikat
                    Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                    Console.Clear(); //czyszczenie konsoli
                    next = true; //błędny format
                }
            } while (next); //dopóki błędny format

            do
            {
                Console.Write("Proszę podaj rozmiar buforowania: "); //komunikat
                try
                {
                    buffer_size = Convert.ToInt32(Console.ReadLine()); //ręczne ustawienie rozmiaru bufera
                    next = false; //poprawny format wprowadzonych danych
                }
                catch
                {
                    Console.WriteLine("Niepoprawny rozmiar bufera!"); //komunikat
                    Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                    Console.Clear(); //czyszczenie konsoli
                    Console.WriteLine("Witaj użytkowniku " + username + "!"); //komunikat
                    Console.WriteLine("Proszę podaj port, po którym odbywać się będzię komunikacja: " + port); //komunikat
                    next = true; //błędny format
                }
            } while (next); //dopóki błędny format

            do
            {
                Console.Write("Proszę podaj ścieżkę dostępu: "); //komunikat
                FolderBrowserDialog fbd = new FolderBrowserDialog(); //utworzenie okna dialogowego do wybrania ścieżki zapisu otrzymanych plików
                fbd.Description = "Wybierz ścieżkę dostępu."; //tytuł utworzonego okna
                fbd.ShowNewFolderButton = true; //włączenie mozliwości tworzenia nowych folderów

                if (fbd.ShowDialog() == DialogResult.OK) //jeśli wybrano ścieżkę
                {
                    archive_address = fbd.SelectedPath; //przypisanie wybranej ścieżki do zmiennej globalnej
                    Console.Write(archive_address); //wyświetlenie wybranej ściezki
                    next = false; //poprawny format wprowadzonych danych
                }
                else
                {
                    Console.WriteLine("Niepoprawny rozmiar bufera!"); //komunikat
                    Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                    Console.Clear(); //czyszczenie konsoli
                    Console.WriteLine("Witaj użytkowniku " + username + "!"); //komunikat
                    Console.WriteLine("Proszę podaj port, po którym odbywać się będzię komunikacja: " + port); //komunikat
                    Console.WriteLine("Proszę podaj rozmiar buforowania: " + buffer_size); //komunikat
                    next = true; //błędny format
                }
            } while (next); //dopóki błędny format

            config = new Config(username, hostName, ip_address,archive_address, port, buffer_size);//utworzenie configa
            save_address = config.GetArchiveAddress(); //przypisanie adresu otrzymywanych plików
            Console.WriteLine(); //nowa linia
            Console.WriteLine("Poprawna konfiguracja serwera."); //komunikat
            Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
            Console.Clear(); //czyszczenie konsoli
        }

        private static void ImportConfig() //funkcja do automatycznej konfiguracji serwera
        {
            StreamReader file; //zmienna do odczytu pliku
            string[] result = new string[2]; //tablica zmiennych do odczytu konfiguracji
            string filePath, line,archive_address=""; //zmienne pomocnicze do konfiguracji serwera
            int port = 0, buffer_size = 0, counterp = 0, counterb = 0,countera=0; //zmienne pomocnicze sprawdzające poprawność importowanych danych
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
                        while ((line = file.ReadLine()) != null) //dopóki są linie w pliku
                        {
                            line = String.Concat(line.Where(x => !Char.IsWhiteSpace(x))); //usunięcie wszelkich znaków białych z linii
                            result = line.Split('='); //podzielenie odczytanej linii wykorzystując separator
                            switch (result[0].ToLower()) //zmiana liter na małe w poleceniu
                            {
                                case "port_tcp": //polecenie
                                    port = Convert.ToInt32(result[1].Substring(1,result[1].Length-2)); //przypisanie numeru portu odczytanego z pliku txt
                                    counterp = 1; //poprawny format
                                    break;
                                case "buffer_size": //polecenie
                                    buffer_size = Convert.ToInt32(result[1].Substring(1, result[1].Length - 2)); //przypisanie rozmiaru buffera odczytanego z pliku txt
                                    counterb = 1; //poprawny format
                                    break;
                                case "archive_address": //polecenie
                                    archive_address = Convert.ToString(result[1].Substring(1, result[1].Length - 2)); //przypisanie ścieżki zapisu otrzymanych plików
                                    countera = 1; //poprawny format
                                    break;
                            }
                            if (counterp + counterb + countera == 3) //jeśli wczytano wszystkie niezbędne dane
                            {
                                break; //przerwij dalsze wczytywanie
                            }
                        }
                        file.Close(); //zamknięcie pliku
                        if (counterp + counterb +countera != 3) //jeśli nie wczytano wszystkich niezbędnych danych
                        {
                            file.Close(); //zamknięcie pliku
                            throw new FileLoadException(); //wyrzucenie wyjątku
                        }
                        config = new Config(username, hostName, ip_address,archive_address, port, buffer_size);//utworzenie configa
                        save_address = config.GetArchiveAddress(); //przypisanie adresu otrzymywanych plików
                        Console.WriteLine("Poprawna konfiguracja serwera."); //komunikat
                        Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                        Console.Clear(); //czyszczenie konsoli
                    }
                    catch (FileLoadException)
                    {
                        Console.WriteLine("Plik konfiguracyjny jest uszkodzony! Spróbuj z innym plikiem lub skorzystaj z ręcznej konfiguracji!"); //komunikat
                        Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                        Console.Clear(); //czyszczenie konsoli
                    }
                }
                else if (ofd.FilterIndex == 2)//odczyt dla pliku xml
                {
                    try
                    {
                        bool serwer = false; //zmienna pomocnicza do odczytu konfiguracji dla serwera
                        bool configure = false; //zmienna pomocnicza sprawdzająca poprawność importowanych danych
                        file = new StreamReader(filePath); //utworzenie odczytu pliku
                        while ((line = file.ReadLine()) != null) //dopóki są linie w pliku
                        {
                            line = String.Concat(line.Where(x => !Char.IsWhiteSpace(x))); //usunięcie wszelkich znaków białych z linii
                            if (line.ToLower() == "<serwer>") //początek konfiguracji serwera
                            {
                                serwer = true; //ustawienie odczytu danych dla serwera
                            }
                            else if (line.ToLower() == "</serwer>") //koniec konfiguracji serwera
                            {
                                serwer = false; //przerwanie odczytu danych
                                break;
                            }
                            else if(line.ToLower() == "<configure>" && serwer) //początek konfiguracji
                            {
                                configure = true; //ustawienie odczytu konfiguracji
                            }
                            else if(line.ToLower() == "</configure>" && serwer) //koniec konfiguracji
                            {
                                configure = false; //przerwanie konfiguracji
                            }
                            else if(serwer && configure) //jeśli konfiguracja obowiązuje dla serwera
                            {
                                result = line.Split('='); //podzielenie odczytanej linii wykorzystując separator
                                switch (result[0].ToLower()) //ustawienie małych liter poleceń
                                {
                                    case "port_tcp": //polecenie
                                        port = Convert.ToInt32(result[1].Substring(1, result[1].Length - 2)); //przypisanie numeru portu odczytanego z pliku xml
                                        counterp = 1; //poprawny format
                                        break;
                                    case "buffer_size": //polecenie
                                        buffer_size = Convert.ToInt32(result[1].Substring(1, result[1].Length - 2)); //przypisanie numeru portu odczytanego z pliku xml
                                        counterb = 1; //poprawny format
                                        break;
                                    case "archive_address": //polecenie 
                                        archive_address = Convert.ToString(result[1].Substring(1, result[1].Length - 2)); //przypisanie ścieżki zapisu otrzymanych plików
                                        countera = 1; //poprawny format
                                        break;
                                }
                            }
                        }
                        file.Close(); //zamknięcie pliku
                        if (counterp + counterb + countera != 3) //jeśli niepoprawny format konfiguracji
                        {
                            file.Close(); //zamknięcie pliku
                            throw new FileLoadException(); //wyrzuca wyjątek
                        }
                        config = new Config(username, hostName, ip_address,archive_address, port, buffer_size); //utworzenie configa
                        save_address = config.GetArchiveAddress(); //przypisanie adresu otrzymywanych plików
                        Console.WriteLine("Poprawna konfiguracja serwera."); //komunikat
                        Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                        Console.Clear(); //czyszczenie konsoli
                    }
                    catch (FileLoadException)
                    {
                        Console.WriteLine("Plik konfiguracyjny jest uszkodzony! Spróbuj z innym plikiem lub skorzystaj z ręcznej konfiguracji!"); //komunikat
                        Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                        Console.Clear(); //czyszczenie konsoli
                    }
                }
            }
            else
            {
                Console.WriteLine("Nie wybrano pliku. Powrót do menu głównego."); //komunikat
                Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                Console.Clear(); //czyszczenie konsoli
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
                        File.WriteAllText(sfg.FileName, "port_tcp=" + '"' + config.GetPort() + '"' + 
                        Environment.NewLine + "buffer_size=" + '"' + config.GetBufferSize() + '"' +
                        Environment.NewLine + "archive_address=" + '"' + config.GetArchiveAddress() + '"'); //stworzenie lub nadpisanie pliku        
                }
                else if (sfg.FilterIndex == 2) //zapis dla pliku xml
                {
                    File.WriteAllText(sfg.FileName, "<serwer>" + 
                        Environment.NewLine + "    <configure>" + 
                        Environment.NewLine + "        port_tcp=" + '"' + config.GetPort() + '"' + 
                        Environment.NewLine + "        buffer_size=" + '"' + config.GetBufferSize() + '"' +
                        Environment.NewLine + "        archive_address=" + '"' + config.GetArchiveAddress() + '"' +
                        Environment.NewLine + "    </configure>" + 
                        Environment.NewLine + "</serwer>"); //stworzenie lub nadpisanie pliku 
                }
                Console.WriteLine("Wyeksportowano konfiguracja: "+sfg.FileName); //komunikat
                Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
            }
            else
            {
                Console.WriteLine("Nie zapisano pliku. Powrót do menu głównego."); //komunikat
                Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                Console.Clear(); //czyszczenie konsoli
            }
        }

        private static void CreateZIP(bool _password) //funkcja do tworzenia archiwum zip
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
                    string password = null;

                    if (File.Exists(sfg.FileName)) //sprawdzanie czy archiwum o takiej nazwie istnieje
                    {
                        File.Delete(sfg.FileName); //usuwanie istniejącego archiwum
                    }

                    if (_password == true)
                    {
                        Console.Write("Proszę podać hasło: ");
                        while (true)
                        {
                            var key = System.Console.ReadKey(true); //czytanie hasła bez pokazywania znakow
                            if (key.Key == ConsoleKey.Enter)
                            {
                                Console.WriteLine();
                                break;
                            }
                            password += key.KeyChar;
                        }
                        using (Ionic.Zip.ZipFile _zip = new Ionic.Zip.ZipFile()) //utworzenie archiwum
                        {
                            foreach (string file in ofd.FileNames)
                            {
                                _zip.Password = password; //dodanie hasła
                                _zip.AddFile(file, ""); //dodanie pliku do archiwum
                            }
                            _zip.Save(sfg.FileName); //zapis archiwum
                        }
                    }
                    else
                    {
                        var zip = ZipFile.Open(sfg.FileName, ZipArchiveMode.Create); //utworzenie archiwum        
                        foreach (string file in ofd.FileNames)
                        {

                            zip.CreateEntryFromFile(file, ofd.SafeFileNames[counter], CompressionLevel.Optimal); //zapis do utworzonego archiwum plików wybranych przez użytkownika                     
                            counter++;
                        }
                        zip.Dispose(); //zwolnienie zasobu
                    }
                    
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

        private static void ChangeFilePath()//funkcja do zmiany ścieżki dostepu
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); //utworzenie okna dialogowego do wybrania nowej ścieżki dostępu
            fbd.Description = "Wybierz nową ścieżkę dostępu."; //tytuł utworzonego okna
            fbd.ShowNewFolderButton = true; //włączenie mozliwości tworzenia nowych folderów

            if (fbd.ShowDialog() == DialogResult.OK) //jeśli wybrano ścieżkę 
            {
                save_address=config.SetArchiveAddress(fbd.SelectedPath);//przypisanie nowej ścieżki i zwrócenie jej do zmiennej globalnej               
            }
            else
            {
                Console.WriteLine("Nie wybrano ścieżki."); //komunikat
                Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                Console.Clear(); //czyszczenie konsoli
            }
        }

        private static void ConnectionListen() //funkcja do nasłuchiwania połączeń w tle
        {
            if (null == m_oBackgroundWorker) //sprawdzanie czy obiekt istnieje
            {
                m_oBackgroundWorker = new BackgroundWorker(); //utworzenie obiektu
                m_oBackgroundWorker.WorkerSupportsCancellation = true; //włączenie możliwości przerwania pracy wątka roboczego
                m_oBackgroundWorker.DoWork += new DoWorkEventHandler(m_oBackgroundWorker_DoWork); //utworzenie uchwyta dla obiektu
            }
            m_oBackgroundWorker.RunWorkerAsync(config.GetPort()); //start wątka roboczego w tle
        }

        private static void m_oBackgroundWorker_DoWork(object sender, DoWorkEventArgs e) //funkcja odpowiadająca za pracę wątka roboczego w tle
        {
            /*TcpListener listener = new TcpListener(IPAddress.Any, config.GetPort());
            System.Text.Decoder decoder = System.Text.Encoding.UTF8.GetDecoder();
            byte[] receive_data = new byte[config.GetBufferSize()];
            int receive_bytes;
            listener.Start();

            while(true){
                TcpClient client = null;
                NetworkStream stream = null;

                if (listener.Pending())
                {
                    client = listener.AcceptTcpClient();
                    updateCounterOfActiveUsers(true);
                    stream = client.GetStream();
          
                    int dec_data = stream.Read(receive_data, 0, receive_data.Length);
                    char[] chars = new char[dec_data];
                    decoder.GetChars(receive_data, 0, dec_data, chars, 0);
                    System.String enc_data = new System.String(chars);
                    FileStream filestream = new FileStream(save_address+enc_data, FileMode.OpenOrCreate, FileAccess.Write);
                    while ((receive_bytes = stream.Read(receive_data, 0, receive_data.Length)) > 0)
                    {
                        filestream.Write(receive_data, 0, receive_bytes);
                    }
                    filestream.Close();
                    stream.Close();
                    client.Close();
                    updateCounterOfActiveUsers(false);
                }
            }*/
            TcpListener listener = new TcpListener(IPAddress.Any, config.GetPort()); //ustawienie nasłuchiwania na porcie z konfiguracji i dla dowolnego adresu IP
            TcpClient client = null; //utworzenie pustego klienta
            listener.Start(); //rozpoczęcie nasłuchiwania     
            bool do_work = true; //zmienna określające prace wątka w tle

            while (do_work)
            {
                if (server_option == ServerOptions.wait) //działa jesli tryb pracy serwera jest ustawiony na oczekiwanie
                {
                    if (listener.Pending()) //jeśli jakieś zapytanie przychodzi
                    {
                        client = listener.AcceptTcpClient(); //zaakceptowanie przychodzącego połączenia                           
                        ThreadPool.QueueUserWorkItem(TransferThread, client); //Dodanie do kolejki klienta
                    }
                }
                if (m_oBackgroundWorker.CancellationPending) //jeśli przerwano prace wątka
                {
                    listener.Stop(); //stop nasłuchiwania
                    e.Cancel = true; //przerwanie obiektu
                    do_work = false; //koniec pracy
                    return;
                }
            }
        }

        private static void SetSendingFile() //funkcja do wybrania pliku do udostępnienia
        {
            OpenFileDialog ofd = new OpenFileDialog(); //utworzenie okna dialogowego
            ofd.Filter = "zip file(*.zip)|*.zip|all files(*.*) | *.*"; //ustawienie filtrów na pliki
            ofd.FilterIndex = 1; //ustawienie domyślnego filtru na archiwum .zip
            ofd.RestoreDirectory = true; //przywracanie wcześniej zamkniętego katalogu
            ofd.Title = "Wybierz plik do udostępnienia."; //tytuł okna
            ofd.Multiselect = false; //wyłączenie opcji multi plików

            if(ofd.ShowDialog() == DialogResult.OK) //jeśli wybrano plik
            {
                file = new FileData(ofd.SafeFileName, ofd.FileName); //utworzenie pliku do wysłania
            }
            else
            {
                Console.WriteLine("Nie wybrano pliku."); //komunikat
                Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                Console.Clear(); //czyszczenie konsoli
            }
        }

        private static void TransferThread(object obj) //nasłuchiwanie dla jednego klienta 
        {
            TcpClient client = (TcpClient)obj; //przejęcie kontroli nad klientem
            System.Text.Decoder decoder = System.Text.Encoding.UTF8.GetDecoder(); //zmienna pomocnicza do odkodowania nazwy pliku
            int buffer_size = config.GetBufferSize(); //wczytanie rozmiaru buffera z konfiguracji
            byte[] data = new byte[buffer_size]; //ustawienie rozmiaru bufera
            int receive_bytes; //zmienna do odbierania plików
            NetworkStream stream = null; //utworzenie kanału do odbioru
            string client_hostname = null; //zmienna do identyfikacji połączenia
            string client_filename = null; //zmienna do identyfikacji nazwy pliku
            bool help = true; //zmienna omocnicza określająca czy nowy klient się podłączył

            try
            {
                while (client.Connected) //dopóki klient podłączony
                {
                    if (server_option != ServerOptions.wait && help) //jeśli !(tryb pracy ustawiony na nasłuchiwanie i nowy klient)
                    {
                        client.Close(); //zamknij klienta
                    }
                    else if (server_option == ServerOptions.wait && help) //jeśli (tryb pracy ustawiony na nasłuchiwanie i nowy klient)
                    {
                        updateCounterOfActiveUsers(true); //aktualizacja aktywnych użytkowników
                        stream = client.GetStream(); //określenie rodzaju połączenia na odbiór danych
                        int dec_data = stream.Read(data, 0, data.Length);//oczekiwanie na nazwę pliku klienta       
                        char[] chars = new char[dec_data]; //zmienna pomocnicza do odkodowania nazwy pliku
                        decoder.GetChars(data, 0, dec_data, chars, 0); //dekodowanie otrzymanej nazwy pliku
                        client_hostname= new System.String(chars); //przypisanie odkodowanej nazwy do nowej zmiennej
                        history.Add(server_history.ServerStartConnection(client_hostname)); //komunikat do historii
                        help = false; //wyłączenie właściwości nowego klienta
                    }
                    else if (server_option == ServerOptions.receive && !help) //sprawdzanie czy serwer jest ustawiony na odbiór plików
                    {
                        if (Directory.Exists(save_address) == false) //sprawdzanie czy ścieżka dostępu z pliku konfiguracyjnego istnieje
                        {
                            Directory.CreateDirectory(save_address); //utworzenie ścieżki dostępu z pliku konfiguracyjnego
                        }

                        stream = client.GetStream(); //określenie rodzaju połączenia na odbiór danych
                        int dec_data = stream.Read(data, 0, data.Length);//oczekiwanie na nazwę pliku klienta       
                        /* char[] chars = new char[dec_data]; //zmienna pomocnicza do odkodowania nazwy pliku
                        decoder.GetChars(data, 0, dec_data, chars, 0); //dekodowanie otrzymanej nazwy pliku
                        client_filename = new System.String(chars); //przypisanie odkodowanej nazwy do nowej zmiennej*/
                        client_filename= System.Text.Encoding.ASCII.GetString(data, 0, dec_data); ;
                        history.Add(server_history.ServerBeginReceive(client_hostname, client_filename)); //komunikat do historii
                        FileStream filestream = new FileStream(save_address + @"\" + client_filename, FileMode.OpenOrCreate, FileAccess.Write); //utworzenie pliku do zapisu archiwum                        
                        while ((receive_bytes = stream.Read(data, 0, data.Length)) > 0) //dopóki przychodzą dane
                        {
                            filestream.Write(data, 0, receive_bytes); //kopiowanie danych do pliku
                        }
                        filestream.Close(); //zamknięcie strumienia pliku
                        stream.Close(); //zakmnięcie strumienia połączenia
                        history.Add(server_history.ServerEndReceive(client_hostname, client_filename)); //komunikat do historii
                        client_filename = null; //wyczyszczenie nazwy pliku
                    }
                    else if (server_option == ServerOptions.send && !help) //jeśli (tryb pracy ustawiony na wysłanie i !nowy klient)
                    {
                        if (file!=null) //jeśli wybrany plik istnieje
                        {
                            /*Socket socket = client.Client; //przypisanie klienta do socketa
                            byte[] byData = System.Text.Encoding.ASCII.GetBytes(file.GetName()); //przygotowanie nazwy pliku do wysłania
                            socket.Send(byData); //wysłanie nazwy pliku
                            Thread.Sleep(1000); //krótkie uśpienie
                            socket.SendFile(file.GetAddress()); //wysłanie pliku
                            socket.Close(); //zamknięcie socketu
                            server_option = ServerOptions.locked; //ustawienie trybu pracy serwera na domyślny*/
                            try
                            {
                                stream = client.GetStream(); //aktywacja strumienia
                                data = System.Text.Encoding.ASCII.GetBytes(file.GetName()); //zakodowanie nazwy pliku
                                stream.Write(data, 0, data.Length); //wysłanie nazwy pliku 
                                stream.Flush(); //zwolnienie strumienia
                                data = new byte[buffer_size]; //ustawienie rozmiaru bufera
                                history.Add(server_history.ServerStartSend(client_hostname, file.GetName())); //komunikat do historii
                                using (var s = File.OpenRead(file.GetAddress())) //dopoki plik jest otwarty
                                {
                                    int actually_read; //zmienna pomocnicza do odczytu rozmiaru
                                    while ((actually_read = s.Read(data, 0, buffer_size)) > 0) //dopóki w pliku sa dane
                                    {
                                        stream.Write(data, 0, actually_read); //wyslanie danych z pliku
                                    }
                                }
                                stream.Flush(); //zwolnienie strumienia
                                stream.Close(); //zamkniecie strumienia
                                history.Add(server_history.ServerEndSend(client_hostname, file.GetName())); //komunikat do historii
                            }
                            catch(Exception e)
                            {
                                stream.Flush();
                                stream.Close();
                                history.Add(server_history.ServerTransferError(client_hostname, file.GetName())); //komunikat do historii
                                throw new SocketException();
                            }
                        }
                    }
                    else if (client.Client.Poll(0, SelectMode.SelectRead)) //jeśli klient odpowiada
                    {
                        byte[] buff = new byte[1]; //pomocniczy bufer
                        if (client.Client.Receive(buff, SocketFlags.Peek) == 0) //jeśli nagle przestał odpowiadać
                        {
                            client.Client.Disconnect(true); //rozłącz klienta
                            //history.Add(server_history.ServerEndConnection(client_hostname)); //komunikat do historii
                        }
                        else
                        {
                            throw new SocketException();
                        }                        
                    }
                }
                client.Close(); //zamknięcie klienta
                updateCounterOfActiveUsers(false); //aktualizacja aktywnych użytkowników
                history.Add(server_history.ServerEndConnection(client_hostname)); //komunikat do historii
            }
            catch (SocketException)
            {
                client.Close(); //zamknięcie klienta
                updateCounterOfActiveUsers(false); //aktualizacja aktywnych użytkowników
                history.Add(server_history.ServerConnectionError(client_hostname)); //komunikat do historii
            }
            catch (IOException)
            {
                history.Add(server_history.ServerTransferError(client_hostname, client_filename)); //komunikat do historii
                client.Close(); //zamknięcie klienta
                updateCounterOfActiveUsers(false); //aktualizacja aktywnych użytkowników
            }
            catch (Exception e)
            {
                Console.WriteLine(e); //komunikat o błędzie
            }
        }

        private static void BackgroundWorkerClose() //funkcja do przerywania wątka w tle
        {
            if (m_oBackgroundWorker != null) //jeśli obiekt istnieje
            {
                if (m_oBackgroundWorker.IsBusy) //sprawdzanie czy taki wątek istnieje
                {
                    m_oBackgroundWorker.CancelAsync();//przerwanie wątka roboczego
                }
            }
        }

        private static void updateCounterOfActiveUsers(bool x) //funkcja do aktualizowania aktywnych połączeń
        {
            if (x) //jeśli true
            {
                active_clients++; //zwiększenie listy aktywnych klientów
                Console.Clear(); //czyszczenie konsoli 
                InfoDisplay(); //wyświetlanie informacji o konfiguracji serwera i o serwerze
                SetFont(); //wyświetlanie menu opcji

            }
            else
            {
                active_clients--; //zmniejszenie liczby aktywnych klientów
                Console.Clear(); //czyszczenie konsoli 
                InfoDisplay(); //wyświetlanie informacji o konfiguracji serwera i o serwerze
                SetFont(); //wyświetlanie menu opcji
            }
        }

        private static void SetServerOptions() //funkcja do ustawiania trybu pracy serwera
        {
            bool correct = true; //zmienna pomocnicza sprawdzająca czy wybrano jakąś opcje
            do
            {
                try
                {
                    string caseSwitch; //zmienna do odczytywania wybranej przez użytkownika opcji
                    ConsoleKeyInfo cki; //zmienna pomocnicza do odczytywania wybranej przez użytkownika opcji
                    Console.WriteLine("Wybierz nowy tryb pracy serwera."); //komunikat
                    Console.WriteLine("1) wstrzymaj pracę serwera.    2) oczekiwanie na nawiązanie połączeń.    3) odbiór plików.    4) wysłanie plików.    5) powrót."); //komunikat
                    cki = Console.ReadKey(true); //odczyt opcji użytkownika
                    caseSwitch = (cki.Key.ToString()); //konwertowanie opcji na konkretny klawisz

                    switch (caseSwitch) //wywołanie funkcji programu zgodnie z wyborem użytkownika
                    {
                        case "D1":
                            server_option = ServerOptions.locked; //ustawienie trybu pracy serwera na domyślny
                            BackgroundWorkerClose(); //zamknięcie wątka roboczego o ile istnieje
                            Console.Clear(); //czyszczenie konsoli
                            correct = false; //poprawna opcja
                            history.Add(server_history.ServerStatusChange(server_option.ToString())); //dodanie zmiany stanu do historii
                            break;
                        case "D2":
                            server_option = ServerOptions.wait; //ustawienie trybu pracy serwera na oczekiwanie na połączenia
                            ConnectionListen(); //start nasłuchiwania
                            Console.Clear(); //czyszczenie konsoli                       
                            correct = false; //poprawna opcja
                            history.Add(server_history.ServerStatusChange(server_option.ToString())); //dodanie zmiany stanu do historii
                            break;
                        case "D3":
                            server_option = ServerOptions.receive; //ustawienie trybu pracy serwera na odbiór plików
                            BackgroundWorkerClose(); //zamknięcie wątka roboczego o ile istnieje
                            Console.Clear(); //czyszczenie konsoli
                            correct = false; //poprawna opcja
                            history.Add(server_history.ServerStatusChange(server_option.ToString())); //dodanie zmiany stanu do historii
                            break;
                        case "D4":
                            server_option = ServerOptions.send; //ustawienie trybu pracy serwera na wysłanie pliku
                            BackgroundWorkerClose(); //zamknięcie wątka roboczego o ile istnieje
                            Console.Clear(); //czyszczenie konsoli
                            correct = false; //poprawna opcja
                            history.Add(server_history.ServerStatusChange(server_option.ToString())); //dodanie zmiany stanu do historii
                            break;
                        case "D5":
                            correct = false; //poprawna opcja
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Nie ma takiej opcji, proszę wybrać poprawną opcję. " + e); //komunikat
                    Console.ReadKey(true); //czekanie na potwierdzenie komunikatu
                    Console.Clear(); //czyszczenie konsoli
                    InfoDisplay(); //wyświetlanie informacji o konfiguracji serwera i o serwerze
                    SetFont(); //wyświetlanie menu opcji
                }
            } while (correct); //dopóki nie wybrano poprawnej opcji
        }

        private static void HistoryExport() //funkcja do eksportowania historii pracy serwera i akcji klientów
        {
            string caseSwitch; //zmienna do odczytywania wybranej przez użytkownika opcji
            ConsoleKeyInfo cki; //zmienna pomocnicza do odczytywania wybranej przez użytkownika opcji
            StreamWriter sw; //zmienna do przechowywania adresu zapisu

            Console.WriteLine("1) Export zgodnie z konfiguracją.    2) Export niestandardowy."); //komunikat    
            cki = Console.ReadKey(true); //odczyt opcji użytkownika
            caseSwitch = (cki.Key.ToString()); //konwertowanie opcji na konkretny klawisz

            switch (caseSwitch) //wywołanie funkcji programu zgodnie z wyborem użytkownika
            {
                case "D1":
                    sw = new StreamWriter(Path.Combine(save_address, "Historia_operacji.txt")); //utworzenie streama do zapisu danych
                    foreach(string x in history)
                    {
                        sw.WriteLine(x); //zapis do pliku
                    }
                    sw.Close(); //zamknięcie streama
                    Console.WriteLine("Export zakończony."); //komunikat
                    Console.ReadKey(true); //potwierdzenie komunikatu
                    break;
                case "D2":
                    SaveFileDialog sfg = new SaveFileDialog(); //utworzenie okna do przeglądania plików
                    sfg.Filter = "txt files (*.txt)|*.txt"; //ustawienie filtrów okna na pliki txt i xml
                    sfg.FilterIndex = 1; //ustawienie domyślnego filtru na plik txt
                    sfg.RestoreDirectory = true; //przywracanie wcześniej zamkniętego katalogu
                    sfg.Title="Wybierz lub utwórz plik do zapisu historii."; //nadanie nazwy okna

                    if (sfg.ShowDialog() == DialogResult.OK)//wyświetlenie okna ze sprawdzeniem, czy plik został zapisany
                    {
                        sw = new StreamWriter(Path.Combine(sfg.FileName)); //utworzenie streama do zapisu danych
                        foreach (string x in history)
                        {
                            sw.WriteLine(x); //zapis do pliku
                        }
                        sw.Close(); //zamknięcie streama
                        Console.WriteLine("Export zakończony."); //komunikat
                        Console.ReadKey(true); //potwierdzenie komunikatu
                    }
                    else
                    {
                        Console.WriteLine("Nie wybrano pliku do zapisu, powrót do menu."); //komunikat
                        Console.ReadKey(true); //potwierdzenie komunikatu
                    }
                    break;
                default:
                    Console.WriteLine("Nie wybrano żadnej opcji, powrót do menu."); //komunikat
                    Console.ReadKey(true); //potwierdzenie komunikatu
                    break;
            }
        }
        
    }
}
