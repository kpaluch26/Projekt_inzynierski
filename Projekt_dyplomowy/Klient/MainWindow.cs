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
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {

        }

        private void btn_change_save_path_Click(object sender, EventArgs e)
        {

        }

        private void btn_confirm_config_Click(object sender, EventArgs e)
        {

        }

        private void btn_change_work_path_Click(object sender, EventArgs e)
        {

        }

        private void btn_CONNECT_Click(object sender, EventArgs e)
        {
            string IP_text, PORT_text;
            IPAddress IP_address;
            int PORT_number;

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
                byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(Dns.GetHostName());
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
                mtstr_Polaczenie.Enabled = false;
                gbx_Polaczenie.Visible = false;
                gbx_Polaczenie.Enabled = false;
                gbx_Ustawienia.Visible = true;
                gbx_Ustawienia.Enabled = true;
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
    }
}
