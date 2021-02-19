using Serwer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klient
{
    public partial class SendingFileBar : Form
    {
        private NetworkStream ns = null;
        private string fn;
        private string fa;
        private int b;

        public SendingFileBar(NetworkStream _ns,string _fn, string _fa, int _b)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;           
            InitializeComponent();
            ns = _ns;
            fn = _fn;
            fa = _fa;
            b = _b;
            ProgressBar(ns, fn, fa, b);
        }

        private void ProgressBar(NetworkStream client, string fn, string fa, int b)
        {
            byte[] data = new byte[b]; //ustawienie rozmiaru bufera
            long step = (new FileInfo(fa).Length / b) + 2;            
            //long status = 0;
            this.Show();
            //lbl_wyslane.Update();
            try
            {
                ns = client; //aktywacja strumienia
                data = System.Text.Encoding.ASCII.GetBytes(fn); //zakodowanie nazwy pliku
                ns.Write(data, 0, data.Length); //wysłanie nazwy pliku 
                ns.Flush(); //zwolnienie strumienia
                data = new byte[b]; //ustawienie rozmiaru bufera
                using (var s = File.OpenRead(fa)) //dopoki plik jest otwarty
                {
                    sending_status.Visible = true;
                    sending_status.Minimum = 1;
                    sending_status.Maximum = System.Convert.ToInt32(step); // new FileInfo(file.GetAddress()).Length;
                    sending_status.Value = 1;
                    sending_status.Step = 1;

                    int actually_read; //zmienna pomocnicza do odczytu rozmiaru
                    while ((actually_read = s.Read(data, 0, b)) > 0) //dopóki w pliku sa dane
                    {
                        ns.Write(data, 0, b); //wyslanie danych z pliku                                                
                        sending_status.PerformStep();
                        //status += actually_read;                        
                        //lbl_wyslane.Text = status.ToString();
                        //lbl_wyslane.Update();
                    }
                    ns.Flush(); //zwolnienie strumienia 
                }
                data = new byte[b]; //ustawienie rozmiaru bufera
                data = System.Text.Encoding.ASCII.GetBytes(fn);
                ns.Write(data, 0, data.Length); //wysłanie nazwy pliku 
                sending_status.PerformStep();
                ns.Flush(); //zwolnienie strumienia       
            }
            catch (Exception x)
            {
                ns.Flush();
                MessageBox.Show(x.ToString());
            }
            finally
            {
                this.Close();
                System.Threading.Thread.Sleep(3000);
            }
            
        }
    }
    
}
