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
            if (e.KeyValue == 13)
            {
                zip_name = txt_nazwa_archiwum.Text;
                this.Close();
            }
            else if (e.KeyValue == 190 || e.KeyValue == 188 || e.KeyValue == 186)
            {
                txt_nazwa_archiwum.Text = txt_nazwa_archiwum.Text.Substring(0, txt_nazwa_archiwum.Text.Length - 1);
                txt_nazwa_archiwum.SelectionStart = txt_nazwa_archiwum.Text.Length;
            }
            else{ MessageBox.Show(e.KeyValue.ToString()); }
        }
    }
}
