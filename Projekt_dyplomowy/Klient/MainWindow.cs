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
        private TcpClient client=null;
        private NetworkStream ns = null;

        private TcpClient SetClient
        {
            set { this.client = value; }
        }
        private NetworkStream SetStream
        {
            set { this.ns = value; }
        }

        public MainWindow()
        {
            ConnectionWindow cw = new ConnectionWindow();
            cw.ShowDialog();
            this.SetClient = cw.GetClient;
            this.SetStream = cw.GetStream;

            if (this.client != null || this.ns!=null)
            {
                InitializeComponent();
            }
            else Environment.Exit(0);
        }

        private void MainWindow_Load(object sender, System.EventArgs e)
        {

        }

    }
}
