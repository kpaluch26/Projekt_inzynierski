using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klient
{
    public partial class WriteName : Form
    {
        public WriteName(string name)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            txt_nazwa_archiwum.Text = name;
        }
        public string zip_name;
        private void btn_akceptuj_Click(object sender, EventArgs e)
        {
            zip_name = txt_nazwa_archiwum.Text;
            this.Close();
        }


        private void txt_nazwa_archiwum_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 13)
                {
                    zip_name = txt_nazwa_archiwum.Text;
                    this.Close();
                }
                else if(e.KeyValue == 190 || e.KeyValue == 188 || e.KeyValue == 186 || e.KeyValue == 222 || e.KeyValue == 220 || e.KeyValue == 155 || e.KeyValue == 106
                                            || e.KeyValue == 192 || e.KeyValue == 191 || e.KeyValue == 219 || e.KeyValue == 221 || e.KeyValue == 110 || e.KeyValue == 111 || e.KeyValue == 226
                                            || e.KeyData.ToString() == "D3, Shift" || e.KeyData.ToString() == "D4, Shift" || e.KeyData.ToString() == "D5, Shift" || e.KeyData.ToString() == "D6, Shift"
                                            || e.KeyData.ToString() == "D7, Shift" || e.KeyData.ToString() == "D8, Shift" || e.KeyData.ToString() == "D1, Shift")
                {
                    txt_nazwa_archiwum.Text = txt_nazwa_archiwum.Text.Substring(0, txt_nazwa_archiwum.Text.Length - 1);
                    txt_nazwa_archiwum.SelectionStart = txt_nazwa_archiwum.Text.Length;
                }
            }
            catch
            {

            }
            //else{ MessageBox.Show(e.KeyData.ToString()); }
        }
    }
}
