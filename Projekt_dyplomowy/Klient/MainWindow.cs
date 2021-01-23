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

namespace Klient
{
    public partial class MainWindow : Form
    {
        //zmienne globalne
        private TcpClient client = null;
        private NetworkStream ns = null;
        private static BackgroundWorker m_oBackgroundWorker = null; //wątek roboczy pracujacy w tle -> domyślnie niezainicjowany
        private User user = null;

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

                    if (null == m_oBackgroundWorker) //sprawdzanie czy obiekt istnieje
                    {
                        m_oBackgroundWorker = new BackgroundWorker(); //utworzenie obiektu
                        m_oBackgroundWorker.WorkerSupportsCancellation = false; //włączenie możliwości przerwania pracy wątka roboczego
                        m_oBackgroundWorker.DoWork += new DoWorkEventHandler(m_oBackgroundWorker_DoWork); //utworzenie uchwyta dla obiektu
                    }
                    m_oBackgroundWorker.RunWorkerAsync(PORT_number); //start wątka roboczego w tle
                }
            }
        }

        private void mtstr_Polaczenie_Click(object sender, EventArgs e)
        {
            gbx_Ustawienia.Visible = false;
            gbx_Ustawienia.Enabled = false;
            gbx_Polaczenie.Visible = true;
            gbx_Polaczenie.Enabled = true;
        }

        private void mtstr_Ustawienia_Click(object sender, EventArgs e)
        {
            gbx_Polaczenie.Visible = false;
            gbx_Polaczenie.Enabled = false;
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
            cbx_czy_sekcja.Checked = true;
            txt_Sekcja.Enabled = true;        
            cbx_czy_wersja.Checked = true;
            txt_Wersja.Enabled = true;
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
        }

        private void cbx_czy_sekcja_Click(object sender, EventArgs e)
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
    }
}
