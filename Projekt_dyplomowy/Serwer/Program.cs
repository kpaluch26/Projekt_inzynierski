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

namespace Serwer
{
    class Program : Form
    {
        enum ServerOptions
        {
            locked,
            wait,
            send,
            receive
        }

        //zmienne globalne
        private static ServerOptions server_option = ServerOptions.locked;
        private static Config config;
        private static BackgroundWorker m_oBackgroundWorker = null;
        private static FileData file;
        private static string save_address;
        private static int active_clients = 0;

        [STAThread]
        static void Main(string[] args) //główna funckja programu
        {
            
            InitConfig();
            OptionsMenu();
        }

        private static void SetFont() //funkcja do wyświetlania menu
        {
            Console.WriteLine("1) Export konfiguracji serwera do pliku .txt/.xml");
            Console.WriteLine("2) Stwórz archiwum .zip.");
            if (file == null)
            {
                Console.WriteLine("3) Wybierz archiwum .zip do udostępnienia.");
            }
            else
            {
                Console.WriteLine("3) Zmień archiwum .zip do udostępnienia.");
            }
            Console.WriteLine("4) Zmień ścieżkę dostępu.");
            Console.WriteLine("5) Zmień tryb pracy serwera.");
            Console.WriteLine("6) Wyjście");
        }

        private static void OptionsMenu() //wybór funkcji programu
        {
            bool work = true;
            while (work)
            {
                InfoDisplay();
                try
                {
                    string caseSwitch;
                    ConsoleKeyInfo cki;
                    SetFont();
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
                            SetSendingFile();
                            Console.Clear();
                            break;
                        case "D4":
                            ChangeFilePath();
                            Console.Clear();
                            break;
                        case "D5":
                            SetServerOptions();
                            Console.Clear();
                            break;
                        case "D6":
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
            InfoUsers();
        }

        private static void InfoUsers() //ramka do wyświetlania aktywnych użytkowników
        {
            string users_info = "Aktywni użytkownicy: ";
            string server_info = "Tryb pracy serwera:  ";
            string file_info = "Wybrany plik do udostępnienia: ";
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
            Console.WriteLine("| " + users_info + active_clients + " || " + server_info + server_option + " |");
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
            if (file != null)
            {
                Console.WriteLine(file_info + file.GetAddress());
            }
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
                            ImportConfig();
                            Console.Clear();
                            break;
                        case "D2":
                            SetConfig();
                            Console.Clear();
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
            string archive_address = "";
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

            do
            {
                Console.Write("Proszę podaj ścieżkę dostępu: ");
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Wybierz ścieżkę dostępu.";
                fbd.ShowNewFolderButton = true;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    archive_address = fbd.SelectedPath;
                    Console.Write(archive_address);
                    next = false;
                }
                else
                {
                    Console.WriteLine("Niepoprawny rozmiar bufera!");
                    Console.ReadKey(true); //czekanie na potwierdzenie błedu
                    Console.Clear();
                    Console.WriteLine("Witaj użytkowniku " + username + "!");
                    Console.WriteLine("Proszę podaj port, po którym odbywać się będzię komunikacja: " + port);
                    Console.WriteLine("Proszę podaj rozmiar buforowania: " + buffer_size);
                    next = true;
                }
            } while (next);

            config = new Config(username, hostName, ip_address,archive_address, port, buffer_size);//utworzenie configa
            save_address = config.GetArchiveAddress(); //przypisanie adresu otrzymywanych plików
            Console.WriteLine();
            Console.WriteLine("Poprawna konfiguracja serwera.");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ImportConfig() //funkcja do automatycznej konfiguracji serwera
        {
            StreamReader file;
            string[] result = new string[2];
            string filePath, line,archive_address="";
            int port = 0, buffer_size = 0, counterp = 0, counterb = 0,countera=0;
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
                                case "archive_address":
                                    archive_address = Convert.ToString(result[1].Substring(1, result[1].Length - 2)); //przypisanie ścieżki zapisu otrzymanych plików
                                    countera = 1;
                                    break;
                            }
                            if (counterp + counterb + countera == 3)
                            {
                                break;
                            }
                        }
                        file.Close(); //zamknięcie pliku
                        if (counterp + counterb +countera != 3)
                        {
                            file.Close(); //zamknięcie pliku
                            throw new FileLoadException();
                        }
                        config = new Config(username, hostName, ip_address,archive_address, port, buffer_size);//utworzenie configa
                        save_address = config.GetArchiveAddress(); //przypisanie adresu otrzymywanych plików
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
                                    case "archive_address":
                                        archive_address = Convert.ToString(result[1].Substring(1, result[1].Length - 2)); //przypisanie ścieżki zapisu otrzymanych plików
                                        countera = 1;
                                        break;
                                }
                            }
                        }
                        file.Close(); //zamknięcie pliku
                        if (counterp + counterb + countera != 3)
                        {
                            file.Close(); //zamknięcie pliku
                            throw new FileLoadException();
                        }
                        config = new Config(username, hostName, ip_address,archive_address, port, buffer_size);//utworzenie configa
                        save_address = config.GetArchiveAddress(); //przypisanie adresu otrzymywanych plików
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
                        File.WriteAllText(sfg.FileName, "port_tcp=" + '"' + config.GetPort() + '"' + 
                        Environment.NewLine + "buffer_size=" + '"' + config.GetBufferSize() + '"' +
                        Environment.NewLine + "archive_address=" + '"' + config.GetArchiveAddress() + '"'); //stworzenie lub nadpisanie pliku        
                }
                else if (sfg.FilterIndex == 2)
                {
                    File.WriteAllText(sfg.FileName, "<serwer>" + 
                        Environment.NewLine + "    <configure>" + 
                        Environment.NewLine + "        port_tcp=" + '"' + config.GetPort() + '"' + 
                        Environment.NewLine + "        buffer_size=" + '"' + config.GetBufferSize() + '"' +
                        Environment.NewLine + "        archive_address=" + '"' + config.GetArchiveAddress() + '"' +
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

        private static void ChangeFilePath()//funkcja do zmiany ścieżki dostepu
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Wybierz nową ścieżkę dostępu.";
            fbd.ShowNewFolderButton = true;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                save_address=config.SetArchiveAddress(fbd.SelectedPath);//przypisanie nowej ścieżki i zwrócenie jej do zmiennej globalnej               
            }
        }

        private static void ConnectionListen() //funkcja do nasłuchiwania połączeń w tle
        {
            if (null == m_oBackgroundWorker) //sprawdzanie czy obiekt istnieje
            {
                m_oBackgroundWorker = new BackgroundWorker(); //utworzenie obiektu
                m_oBackgroundWorker.WorkerSupportsCancellation = true;
                m_oBackgroundWorker.DoWork += new DoWorkEventHandler(m_oBackgroundWorker_DoWork);
            }
            m_oBackgroundWorker.RunWorkerAsync(config.GetPort());
        }

        private static void m_oBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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
                    if (listener.Pending())
                    {
                        client = listener.AcceptTcpClient(); //zaakceptowanie przychodzącego połączenia                        
                        ThreadPool.QueueUserWorkItem(TransferThread, client); //Dodanie do kolejki klienta
                    }
                }
                if (m_oBackgroundWorker.CancellationPending)
                {
                    listener.Stop();
                    e.Cancel = true;
                    do_work = false;
                    return;
                }
            }
        }

        private static void SetSendingFile()
        {
            OpenFileDialog ofd = new OpenFileDialog(); //utworzenie okna dialogowego
            ofd.Filter = "zip file(*.zip)|*.zip|all files(*.*) | *.*"; //ustawienie filtrów na pliki
            ofd.FilterIndex = 1; //ustawienie domyślnego filtru na archiwum .zip
            ofd.RestoreDirectory = true; //przywracanie wcześniej zamkniętego katalogu
            ofd.Title = "Wybierz plik do udostępnienia."; //tytuł okna
            ofd.Multiselect = false; //wyłączenie opcji multi plików

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                file = new FileData(ofd.SafeFileName, ofd.FileName);
            }
            else
            {
                Console.WriteLine("Nie wybrano pliku.");
            }
        }

        private static void TransferThread(object obj) //nasłuchiwanie dla jednego klienta 
        {
            TcpClient client = (TcpClient)obj; //przejęcie kontroli nad klientem
            System.Text.Decoder decoder = System.Text.Encoding.UTF8.GetDecoder(); //zmienna pomocnicza do odkodowania nazwy pliku
            byte[] receive_data = new byte[config.GetBufferSize()]; //ustawienie rozmiaru bufera
            int receive_bytes; //zmienna do odbierania plików
            NetworkStream stream = null; //utworzenie kanału do odbioru
            bool help = true;

            try
            {
                while (client.Connected)
                {
                    if (server_option != ServerOptions.wait && help)
                    {
                        client.Close();
                    }
                    else if (server_option == ServerOptions.wait && help)
                    {
                        updateCounterOfActiveUsers(true); //aktualizacja aktywnych użytkowników
                        help = false;
                    }
                    else if (server_option == ServerOptions.receive && !help) //sprawdzanie czy serwer jest ustawiony na odbiór plików
                    {
                        if (Directory.Exists(save_address) == false) //sprawdzanie czy ścieżka dostępu z pliku konfiguracyjnego istnieje
                        {
                            Directory.CreateDirectory(save_address); //utworzenie ścieżki dostępu z pliku konfiguracyjnego
                        }

                        stream = client.GetStream(); //określenie rodzaju połączenia na odbiór danych
                        int dec_data = stream.Read(receive_data, 0, receive_data.Length);//oczekiwanie na nazwę pliku klienta       
                        char[] chars = new char[dec_data]; //zmienna pomocnicza do odkodowania nazwy pliku
                        decoder.GetChars(receive_data, 0, dec_data, chars, 0); //dekodowanie otrzymanej nazwy pliku
                        System.String enc_data = new System.String(chars); //przypisanie odkodowanej nazwy do nowej zmiennej
                        FileStream filestream = new FileStream(save_address + @"\" + enc_data, FileMode.OpenOrCreate, FileAccess.Write); //utworzenie pliku do zapisu archiwum 
                        while ((receive_bytes = stream.Read(receive_data, 0, receive_data.Length)) > 0)
                        {
                            filestream.Write(receive_data, 0, receive_bytes); //kopiowanie danych do pliku
                        }
                        filestream.Close();
                        stream.Close();
                    }
                    else if (server_option == ServerOptions.send && !help)
                    {
                        if (file!=null)
                        {
                            Socket socket = client.Client;
                            byte[] byData = System.Text.Encoding.ASCII.GetBytes(file.GetName());
                            socket.Send(byData);
                            Thread.Sleep(1000);
                            socket.SendFile(file.GetAddress());
                            socket.Close();
                            server_option = ServerOptions.locked;
                        }
                    }
                    else if (client.Client.Poll(0, SelectMode.SelectRead))
                    {
                        byte[] buff = new byte[1];
                        if (client.Client.Receive(buff, SocketFlags.Peek) == 0)
                        {
                            client.Client.Disconnect(true);
                        }
                    }
                }
                client.Close();
                updateCounterOfActiveUsers(false); //aktualizacja aktywnych użytkowników
            }
            catch (SocketException)
            {
                client.Close();
                updateCounterOfActiveUsers(false); //aktualizacja aktywnych użytkowników
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void BackgroundWorkerClose() //funkcja do przerywania wątka w tle
        {
            if (m_oBackgroundWorker != null)
            {
                if (m_oBackgroundWorker.IsBusy) //sprawdzanie czy taki wątek istnieje
                {
                    m_oBackgroundWorker.CancelAsync();//przerwanie wątka roboczego
                }
            }
        }
        private static void updateCounterOfActiveUsers(bool x) //funkcja do aktualizowania aktywnych połączeń
        {
            if (x)
            {
                active_clients++;
                Console.Clear();
                InfoDisplay();
                SetFont();

            }
            else
            {
                active_clients--;
                Console.Clear();
                InfoDisplay();
                SetFont();
            }
        }

        private static void SetServerOptions() //funkcja do ustawiania trybu pracy serwera
        {
            bool correct = true;
            do
            {
                try
                {
                    string caseSwitch;
                    ConsoleKeyInfo cki;

                    Console.WriteLine("Wybierz nowy tryb pracy serwera.");
                    Console.WriteLine("1) wstrzymaj pracę serwera.    2) oczekiwanie na nawiązanie połączeń.    3) odbiór plików.    4) wysłanie plików.    5) powrót.");
                    cki = Console.ReadKey(true);
                    caseSwitch = (cki.Key.ToString());

                    switch (caseSwitch)
                    {
                        case "D1":
                            server_option = ServerOptions.locked;
                            BackgroundWorkerClose();
                            Console.Clear();
                            correct = false;
                            break;
                        case "D2":
                            server_option = ServerOptions.wait;
                            ConnectionListen();
                            Console.Clear();                        
                            correct = false;
                            break;
                        case "D3":
                            server_option = ServerOptions.receive;
                            BackgroundWorkerClose();
                            Console.Clear();
                            correct = false;
                            break;
                        case "D4":
                            server_option = ServerOptions.send;
                            BackgroundWorkerClose();
                            Console.Clear();
                            correct = false;
                            break;
                        case "D5":
                            correct = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Nie ma takiej opcji, proszę wybrać poprawną opcję. " + e);
                    Console.ReadKey(true);
                    Console.Clear();
                    InfoDisplay();
                    SetFont();
                }
            } while (correct);
        }
        
    }
}
