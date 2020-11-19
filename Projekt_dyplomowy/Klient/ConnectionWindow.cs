using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klient
{
    public partial class ConnectionWindow : Form
    {
        private TcpClient client = null;
        public ConnectionWindow()
        {
            InitializeComponent();
        }

        private void ConnectionWindow_Load(object sender, EventArgs e)
        {

        }

        public TcpClient GetClient
        {
            get{ return client; }
        }


        private void btn_CONNECT_Click(object sender, EventArgs e)
        {
            string IP_text, PORT_text;
            IPAddress IP_address;
            int PORT_number;
            NetworkStream ns;

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
                else if (!ValidateIP&&!ValidatePORT)
                {
                    MessageBox.Show("Wprowadzone złe dane, spróbuj ponownie.","Błędny format danych");
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
                byte[] bytesToSend= ASCIIEncoding.ASCII.GetBytes(Dns.GetHostName());
                ns.Write(bytesToSend, 0, bytesToSend.Length);
               
                this.Close();
                //ns.Close();
            }
            catch(SocketException x)
            {
                MessageBox.Show("Serwer odmawia nawiązania połączenia. Możliwe, że wprowadzono błędne dane serwera lub serwer pracuje w trybie uniemożliwiającym nawiązanie połączenia.",
                    "Odmowa nawiązania połączenia.");
            }
            catch (FormatException)
            {

            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString());
            }

        }
    }
}
