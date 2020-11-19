using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klient
{
    public partial class MainWindow : Form
    {
        //zmienne globalne
        private TcpClient client;

        private TcpClient SetClient
        {
            set { this.client = value; }
        }
        public MainWindow()
        {
            ConnectionWindow cw = new ConnectionWindow();
            this.SetClient = cw.GetClient;
            cw.ShowDialog();
            InitializeComponent();           
        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {

        }

    }
}
