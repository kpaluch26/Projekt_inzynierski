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
    public partial class ReceivingFileBar : Form
    {
        public ReceivingFileBar(NetworkStream _ns, int _b, string _p)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            ProgressBar(_ns, _b, _p);
        }

        private void ProgressBar(NetworkStream stream,  int buffer, string path)
        {
            int dec_data; //zmienna do odbierania nazwy pliku
            int receive_bytes; //zmienna do odbierania plików
            byte[] data = new byte[buffer]; //ustawienie rozmiaru bufera
            byte[] buff = new byte[1]; //pomocniczy bufer
            bool end_stream = false; //flaga informująca czy koniec pliku            
            string filename;
            long size;
            this.Show();
            try
            {
                data = System.Text.Encoding.ASCII.GetBytes("start"); //zakodowanie startu transmisji
                stream.Write(data, 0, data.Length); //wysłanie startu
                stream.Flush(); //zwolnienie strumienia
                data = new byte[buffer];
                dec_data = stream.Read(data, 0, buffer);
                filename = System.Text.Encoding.ASCII.GetString(data, 0, dec_data);
                if (filename != null && filename != "")
                {
                    lbl_file_name.Text += " " + filename;
                    lbl_file_name.Update();
                    
                    receive_bytes = stream.Read(data, 0, buffer);
                    string file_size = System.Text.Encoding.ASCII.GetString(data, 0, receive_bytes);
                    if (long.TryParse(file_size, out size))
                    {                        
                        long step = (size / buffer) + 2;

                        prb_receiving_status.Visible = true;
                        prb_receiving_status.Minimum = 1;
                        prb_receiving_status.Maximum = System.Convert.ToInt32(step);
                        prb_receiving_status.Value = 1;
                        prb_receiving_status.Step = 1;

                        FileStream filestream = new FileStream(path + @"\" + filename, FileMode.OpenOrCreate, FileAccess.Write); //utworzenie pliku do zapisu archiwum

                        while (!end_stream)
                        {
                            receive_bytes = stream.Read(data, 0, buffer);
                            string end_transfer = System.Text.Encoding.ASCII.GetString(data, 0, receive_bytes);
                            if (filename == end_transfer)
                            {
                                end_stream = true;
                                prb_receiving_status.PerformStep();
                            }
                            else
                            {
                                filestream.Write(data, 0, receive_bytes); //kopiowanie danych do pliku                               
                            }
                            prb_receiving_status.PerformStep();
                        }
                        filestream.Close(); //zamknięcie strumienia pliku
                    }                   
                }               
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
            finally
            {
                prb_receiving_status.PerformStep();
                System.Threading.Thread.Sleep(3000);
                this.Close();
            }
        }
    }
}
