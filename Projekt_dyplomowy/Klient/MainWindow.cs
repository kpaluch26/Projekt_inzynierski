using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace Klient
{
    public partial class MainWindow : Form
    {
        //zmienne globalne
        private TcpClient client = null;
        private NetworkStream ns = null;
        private static BackgroundWorker m_oBackgroundWorker = null; //wątek roboczy pracujacy w tle -> domyślnie niezainicjowany
        private User user = null;
        private bool encrypetd = false;

        //private TcpClient SetClient //właściwość do odbioru klienta tcp
        //{
        //    set { this.client = value; }
        //}
        //private NetworkStream SetStream //właściwość do odbioru strumienia klienta tcp
        //{
        //    set { this.ns = value; }
        //}

        public MainWindow()
        {
            /*ConnectionWindow cw = new ConnectionWindow();
            cw.ShowDialog();
            this.SetClient = cw.GetClient;
            this.SetStream = cw.GetStream;

            if (this.client != null && this.ns!=null)
            {
                InitializeComponent();
            }
            else Environment.Exit(0);*/
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = true;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            SetDefaultOption();
        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {
            //clbx_lista_plikow.AllowDrop = true;
            //clbx_lista_plikow.DragDrop += clbx_lista_plikow_DragDrop;
            //clbx_lista_plikow.DragEnter += clbx_lista_plikow_DragEnter;
        }

        private void btn_CONNECT_Click(object sender, EventArgs e)
        {
            if (user != null)
            {
                string IP_text, PORT_text;
                IPAddress IP_address;
                int PORT_number = 0;

                IP_text = txt_IP.Text.Trim();
                PORT_text = txt_PORT.Text.Trim();
                try
                {
                    bool ValidateIP = IPAddress.TryParse(IP_text, out IP_address);
                    bool ValidatePORT = Int32.TryParse(PORT_text, out PORT_number);

                    if (ValidateIP && ValidatePORT)
                    {
                        client = new TcpClient(IP_address.ToString(), PORT_number);
                    }
                    else if (!ValidateIP && !ValidatePORT)
                    {
                        MessageBox.Show("Wprowadzone złe dane, spróbuj ponownie.", "Błędny format danych");
                        throw new FormatException();
                    }
                    else if (!ValidateIP && ValidatePORT)
                    {
                        MessageBox.Show("Wprowadzone zły adres IP, spróbuj ponownie.", "Błędny format danych");
                        throw new FormatException();
                    }
                    else
                    {
                        MessageBox.Show("Wprowadzone zły numer portu, spróbuj ponownie.", "Błędny format danych");
                        throw new FormatException();
                    }

                    ns = client.GetStream();
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(user.ToString());
                    ns.Write(bytesToSend, 0, bytesToSend.Length);

                    ns.Flush();
                }
                catch (SocketException x)
                {
                    MessageBox.Show("Serwer odmawia nawiązania połączenia. Możliwe, że wprowadzono błędne dane serwera lub serwer pracuje w trybie uniemożliwiającym nawiązanie połączenia.",
                        "Odmowa nawiązania połączenia.");
                }
                catch (FormatException)
                {

                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString());
                }

                if (client != null && client.Connected)
                {
                    //Widok Połączenia
                    mtstr_Polaczenie.Enabled = false;
                    gbx_Polaczenie.Visible = false;
                    gbx_Polaczenie.Enabled = false;
                    //Widok Ustawień
                    gbx_Ustawienia.Visible = true;
                    gbx_Ustawienia.Enabled = true;
                    //status belka
                    tssl_label.Visible = true;
                    //przycisk belka
                    tssb_Rozlacz.Visible = true;
                    tssb_Rozlacz.Enabled = true;
                    //Dane Uzytkownika
                    gbx_DaneUzytkownika.Enabled = false;
                    //Ustawienia połączenia
                    gbx_Ustawienia_polaczenia.Enabled = false;

                    if (null == m_oBackgroundWorker) //sprawdzanie czy obiekt istnieje
                    {
                        m_oBackgroundWorker = new BackgroundWorker(); //utworzenie obiektu
                        m_oBackgroundWorker.WorkerSupportsCancellation = false; //włączenie możliwości przerwania pracy wątka roboczego
                        m_oBackgroundWorker.DoWork += new DoWorkEventHandler(m_oBackgroundWorker_DoWork); //utworzenie uchwyta dla obiektu
                    }
                    m_oBackgroundWorker.RunWorkerAsync(PORT_number); //start wątka roboczego w tle
                }
            }
            else
            {
                MessageBox.Show("Nie wprowadzono wszystkich danych w zakładce ustawienia.", "Błąd dane użytkownika.");
            }
        }

        private void mtstr_Polaczenie_Click(object sender, EventArgs e)
        {
            gbx_Ustawienia.Visible = false;
            gbx_Ustawienia.Enabled = false;
            gbx_Plik.Enabled = false;
            gbx_Plik.Visible = false;
            gbx_Polaczenie.Visible = true;
            gbx_Polaczenie.Enabled = true;
        }

        private void mtstr_Ustawienia_Click(object sender, EventArgs e)
        {
            gbx_Polaczenie.Visible = false;
            gbx_Polaczenie.Enabled = false;
            gbx_Plik.Enabled = false;
            gbx_Plik.Visible = false;
            gbx_Ustawienia.Visible = true;
            gbx_Ustawienia.Enabled = true;
        }

        private void rozłączToolStripMenuItem_Click(object sender, EventArgs e)
        {
            client.Close();
            SetDefaultOption();
        }

        private void m_oBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool do_work = true; //zmienna określające prace wątka w tle

            while (do_work)
            {
                try
                {
                    if (client.Client.Poll(0, SelectMode.SelectRead)) //jeśli klient odpowiada
                    {
                        byte[] buff = new byte[1]; //pomocniczy bufer
                        try
                        {
                            if (client.Client.Receive(buff, SocketFlags.Peek) == 0) //jeśli nagle przestał odpowiadać
                            {
                                client.Client.Disconnect(true); //rozłącz klienta   
                                this.Invoke(new MethodInvoker(delegate { ServerConnectionError(); }));
                            }
                            else
                            {
                                throw new SocketException();
                            }
                        }
                        catch (SocketException)
                        {
                            client.Close();
                            this.Invoke(new MethodInvoker(delegate { ServerConnectionError(); }));
                            do_work = false;
                            return;
                        }
                    }
                }
                catch
                {
                    do_work = false;
                    return;
                }
            }
        }

        private void SetDefaultOption()
        {
            client = null;
            mtstr_Polaczenie.Enabled = true;
            //status belka
            tssl_label.Visible = false;
            //przycisk belka
            tssb_Rozlacz.Visible = false;
            tssb_Rozlacz.Enabled = false;
            tssb_Rozlacz.Text = "Połączenie aktywne";
            tssb_Rozlacz.Image = Klient.Properties.Resources.Status_OK;
            //Dane Użytkownika
            gbx_DaneUzytkownika.Enabled = true;
            cbx_czy_sekcja.Checked = true;
            txt_Sekcja.Enabled = true;
            cbx_czy_wersja.Checked = true;
            txt_Wersja.Enabled = true;
            //Backup
            rbtn_backup_off.Checked = true;
            lbl_backup_workspace.Enabled = false;
            lbl_backup_zapis.Enabled = false;
            cbx_interwal_zapisu.Enabled = false;
            cbx_szyfrowanie.Enabled = false;
            //Plik
            gbx_Plik.Enabled = false;
            gbx_Plik.Visible = false;
            cbx_czy_haslo.Checked = false;
            txt_haslo.Enabled = false;
            txt_haslo.Visible = false;
            cbx_zaznacz_pliki.Checked = false;
            btn_utworz.Enabled = false;
        }

        private void ServerConnectionError()
        {
            tssl_label.Text = "Błąd połączenia";
            tssb_Rozlacz.Image = Klient.Properties.Resources.Status_ERROR;
            MessageBox.Show("Błąd po stronie serwera. Połączenie zostało nagle przerwane.", "Połączenie");
            SetDefaultOption();
        }

        private void btn_Potwierdz_Click(object sender, EventArgs e)
        {
            string firstname, lastname, group, section, version;

            if (user == null)
            {
                user = new User();
            }

            firstname = txt_Imie.Text.Trim();
            if (firstname != null && firstname != "")
            {
                user.firstname = firstname;
            }
            else
            {
                MessageBox.Show("Nie wprowadzono imienia użytkownika.", "Ustawienia");
            }
            lastname = txt_Nazwisko.Text.Trim();
            if (lastname != null && lastname != "")
            {
                user.lastname = lastname;
            }
            else
            {
                MessageBox.Show("Nie wprowadzono nazwiska użytkownika.", "Ustawienia");
            }

            group = txt_Grupa.Text.Trim();
            if (group != null && group != "")
            {
                user.group = group;
            }
            else
            {
                MessageBox.Show("Nie wprowadzono grupy użytkownika.", "Ustawienia");
            }

            if (cbx_czy_sekcja.Checked == true)
            {
                section = txt_Sekcja.Text.Trim();
                if (section != null && section != "")
                {
                    user.section = section;
                }
                else
                {
                    MessageBox.Show("Nie wprowadzono sekcji użytkownika.", "Ustawienia");
                }
            }
            else
            {
                user.section = "";
            }
            if (cbx_czy_wersja.Checked == true)
            {
                version = txt_Wersja.Text.Trim();
                if (version != null && version != "")
                {
                    user.version = version;
                }
                else
                {
                    MessageBox.Show("Nie wprowadzono wersji.", "Ustawienia");
                }
            }
            else
            {
                user.version = "";
            }

            lbl_ID.Text = user.ToString();

            //Ustawienia połączenia
            if (lbl_path_polaczenie.Text == "Wybierz...")
            {
                MessageBox.Show("Nie podano miejsca zapisu przychodzących plików.", "Ustawienia");
            }

            if (rbtn_backup_on.Checked == true)
            {

            }
        }

        private void cbx_czy_wersja_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_Wersja.Enabled == false)
            {
                txt_Wersja.Enabled = true;
            }
            else
            {
                txt_Wersja.Enabled = false;
            }
        }

        private void lbl_path_polaczenie_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); //utworzenie okna dialogowego do wybrania nowej ścieżki dostępu
            fbd.Description = "Wybierz nową ścieżkę dostępu."; //tytuł utworzonego okna
            fbd.ShowNewFolderButton = true; //włączenie mozliwości tworzenia nowych folderów

            if (fbd.ShowDialog() == DialogResult.OK) //jeśli wybrano ścieżkę 
            {
                lbl_path_polaczenie.Text = fbd.SelectedPath;//przypisanie nowej ścieżki do labela             
            }
        }

        private void lbl_backup_workspace_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); //utworzenie okna dialogowego do wybrania nowej ścieżki dostępu
            fbd.Description = "Wybierz nową ścieżkę dostępu."; //tytuł utworzonego okna
            fbd.ShowNewFolderButton = true; //włączenie mozliwości tworzenia nowych folderów

            if (fbd.ShowDialog() == DialogResult.OK) //jeśli wybrano ścieżkę 
            {
                lbl_backup_workspace.Text = fbd.SelectedPath;//przypisanie nowej ścieżki do labela             
            }
        }

        private void lbl_backup_zapis_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); //utworzenie okna dialogowego do wybrania nowej ścieżki dostępu
            fbd.Description = "Wybierz nową ścieżkę dostępu."; //tytuł utworzonego okna
            fbd.ShowNewFolderButton = true; //włączenie mozliwości tworzenia nowych folderów

            if (fbd.ShowDialog() == DialogResult.OK) //jeśli wybrano ścieżkę 
            {
                lbl_backup_zapis.Text = fbd.SelectedPath;//przypisanie nowej ścieżki do labela             
            }
        }

        private void rbtn_backup_on_Click(object sender, EventArgs e)
        {
            lbl_backup_workspace.Enabled = true;
            lbl_backup_zapis.Enabled = true;
            cbx_interwal_zapisu.Enabled = true;
            cbx_szyfrowanie.Enabled = true;
        }

        private void rbtn_backup_off_Click(object sender, EventArgs e)
        {
            lbl_backup_workspace.Enabled = false;
            lbl_backup_zapis.Enabled = false;
            cbx_interwal_zapisu.Enabled = false;
            cbx_szyfrowanie.Enabled = false;
        }

        private void cbx_szyfrowanie_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_szyfrowanie.Checked == true)
            {
                encrypetd = true;
            }
        }

        private void cbx_czy_sekcja_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_Sekcja.Enabled == false)
            {
                txt_Sekcja.Enabled = true;
            }
            else
            {
                txt_Sekcja.Enabled = false;
            }
        }

        private void mtstr_Plik_Click(object sender, EventArgs e)
        {
            //Ustawienia
            gbx_Ustawienia.Enabled = false;
            gbx_Ustawienia.Visible = false;
            //Połączenie
            gbx_Polaczenie.Enabled = false;
            gbx_Polaczenie.Visible = false;
            //Plik
            gbx_Plik.Enabled = true;
            gbx_Plik.Visible = true;
        }

        private void cbx_zaznacz_pliki_Click(object sender, EventArgs e)
        {
            clbx_lista_plikow.SelectedIndex = -1;

            if (cbx_zaznacz_pliki.Checked == true)
            {
                for (int i = 0; i < clbx_lista_plikow.Items.Count; i++)
                {
                    clbx_lista_plikow.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < clbx_lista_plikow.Items.Count; i++)
                {
                    clbx_lista_plikow.SetItemChecked(i, false);
                }
            }
            CanCreateZip(0);
        }

        private void clbx_lista_plikow_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int counter = 0;
            int check = 0;

            if (clbx_lista_plikow.SelectedIndex > -1)
            {
                if (clbx_lista_plikow.GetItemChecked(clbx_lista_plikow.SelectedIndex) == false) //&& cbx_zaznacz_pliki.Checked == false
                {
                    counter++;
                    check = 1;
                }
                if (clbx_lista_plikow.GetItemChecked(clbx_lista_plikow.SelectedIndex) == true) //&& cbx_zaznacz_pliki.Checked == true
                {
                    counter--;
                    check = -1;
                }
                for (int i = 0; i < clbx_lista_plikow.Items.Count; i++)
                {
                    if (clbx_lista_plikow.GetItemChecked(i))
                    {
                        counter++;
                    }
                }
                if (counter != 0 && counter == clbx_lista_plikow.Items.Count)
                {
                    cbx_zaznacz_pliki.Checked = true;
                }
                else
                {
                    cbx_zaznacz_pliki.Checked = false;
                }
            }
            CanCreateZip(check);

        }

        private void cbx_czy_haslo_Click(object sender, EventArgs e)
        {
            if (cbx_czy_haslo.Checked == true)
            {
                txt_haslo.Enabled = true;
                txt_haslo.Visible = true;
                txt_haslo.PasswordChar = '*';
            }
            else
            {
                txt_haslo.Enabled = false;
                txt_haslo.Visible = false;
                txt_haslo.Text = "";
            }
        }

        private void lbl_zip_path_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog(); //utworzenie okna dialogowego do wybrania nowej ścieżki dostępu
            fbd.Description = "Wybierz nową ścieżkę dostępu."; //tytuł utworzonego okna
            fbd.ShowNewFolderButton = true; //włączenie mozliwości tworzenia nowych folderów

            if (fbd.ShowDialog() == DialogResult.OK) //jeśli wybrano ścieżkę 
            {
                lbl_zip_path.Text = fbd.SelectedPath;//przypisanie nowej ścieżki do labela             
            }
            CanCreateZip(0);
        }

        private void lbl_wybierz_nazwe_DoubleClick(object sender, EventArgs e)
        {
            if (lbl_wybierz_nazwe.Text != "Wybierz...")
            {
                WriteName wn = new WriteName(lbl_wybierz_nazwe.Text.Substring(0, lbl_wybierz_nazwe.Text.Length - 4));
                wn.ShowDialog();
                if (wn.zip_name == "")
                {
                    lbl_wybierz_nazwe.Text = "Wybierz...";
                }
                else
                {
                    lbl_wybierz_nazwe.Text = wn.zip_name + ".zip";
                }
            }
            else
            {
                WriteName wn = new WriteName("");
                wn.ShowDialog();
                if (wn.zip_name == "")
                {
                    lbl_wybierz_nazwe.Text = "Wybierz...";
                }
                else
                {
                    lbl_wybierz_nazwe.Text = wn.zip_name + ".zip";
                }
            }
            CanCreateZip(0);
        }

        private void btn_wybierz_pliki_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); //utworzenie okna do przeglądania plików
            ofd.Filter = "all files (*.*)|*.*"; //ustawienie filtrów okna na dowolne pliki
            ofd.FilterIndex = 1; //ustawienie domyślnego filtru
            ofd.RestoreDirectory = true; //przywracanie wcześniej zamkniętego katalogu
            ofd.Multiselect = true; //ustawienie możliwości wyboru wielu plików z poziomu okna

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in ofd.FileNames)
                {
                    clbx_lista_plikow.Items.Add(file);
                }
                clbx_lista_plikow.HorizontalScrollbar = true;
            }
        }

        private void btn_wyczysc_pliki_Click(object sender, EventArgs e)
        {
            clbx_lista_plikow.Items.Clear();
            CanCreateZip(0);
        }

        private void clbx_lista_plikow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 46 && clbx_lista_plikow.SelectedIndex > -1)
            {
                clbx_lista_plikow.Items.Remove(clbx_lista_plikow.SelectedItem);
            }
        }

        private void clbx_lista_plikow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void clbx_lista_plikow_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
                clbx_lista_plikow.Items.Add(file);
        }

        private void btn_utworz_Click(object sender, EventArgs e)
        {           
            string password = null;
            string filepath = lbl_zip_path.Text + "\\" + lbl_wybierz_nazwe.Text;

            if (File.Exists(filepath)) //sprawdzanie czy archiwum o takiej nazwie istnieje
            {
                File.Delete(filepath); //usuwanie istniejącego archiwum
            }

            if (cbx_czy_haslo.Checked==true && txt_haslo.Text != "" && txt_haslo.Text != null)
            {               
               password = txt_haslo.Text;
                
                using (Ionic.Zip.ZipFile _zip = new Ionic.Zip.ZipFile()) //utworzenie archiwum
                {
                    foreach (string file in clbx_lista_plikow.CheckedItems)
                    {                    
                        _zip.Password = password; //dodanie hasła
                        _zip.AddFile(file, ""); //dodanie pliku do archiwum
                    }
                    _zip.Save(filepath); //zapis archiwum
                }
            }
            else
            {
                using (Ionic.Zip.ZipFile _zip = new Ionic.Zip.ZipFile()) //utworzenie archiwum
                {
                    foreach (string file in clbx_lista_plikow.CheckedItems)
                    {
                        _zip.AddFile(file, ""); //dodanie pliku do archiwum
                    }
                    _zip.Save(filepath); //zapis archiwum
                }
            }
        }

        private void CanCreateZip(int check)
        {
            if (clbx_lista_plikow.CheckedItems.Count + check > 0  && lbl_wybierz_nazwe.Text != "Wybierz..." && lbl_zip_path.Text != "Wybierz...")
            {
                btn_utworz.Enabled = true;
            }
            else btn_utworz.Enabled = false;
        }
    }
}
