using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace Server
{
    public partial class MainServer : Form
    {
        AsynchronousTcpLinstener listener;

        string serverStatus = string.Empty;
        ManegeClient manegeClient = null;
        private string IP
        {
            get { return ConfigurationManager.AppSettings["IP"]; }
        }

        private int port
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings["Port"]);
            }
        }


        public MainServer()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            //IP = ipe.AddressList[3];
            cbIPAdress.Items.Add(IP);
            cbIPAdress.SelectedIndex = 0;
            toolStripStatusLabel1.Text = "服务器未运行";
            this.pbServerStatus.Image = Resource1.stop;
            serverStatus = "服务器未运行";
        }

        private void btStartSverver_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            listener = new AsynchronousTcpLinstener();
            
            if (listener.InitServer(cbIPAdress.SelectedItem.ToString(), port))
            {
                listener.StartServer();
                this.pbServerStatus.Image = Resource1.start;
                this.toolStripStatusLabel1.Text = "服务器正在运行";
                this.notifyIcon1.Icon = Resource1.enable_server;
                btStartSverver.Enabled = false;
                btShowClient.Enabled = true;
                btStopSverver.Enabled = true;
                serverStatus = "服务器正在运行";

            }
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            this.notifyIcon1.Text = serverStatus;
        }


        private void btStopSverver_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            try
            {
                listener.StopServer();
                listener = null;
                GC.Collect();
                btStartSverver.Enabled = true;
                btShowClient.Enabled = false;
                btStopSverver.Enabled = false;
            }
            catch { }
            this.pbServerStatus.Image = Resource1.stop;
            this.toolStripStatusLabel1.Text = "服务器已停止";
            this.notifyIcon1.Icon = Resource1.desable_server;
            serverStatus = "服务器已停止";
        }

        #region 右键点击状态栏小图标
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
        }

        private void tsmiStartServer_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void tsmiStopServer_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void btShowClient_Click(object sender, EventArgs e)
        {
            manegeClient = new ManegeClient(listener);
            manegeClient.Visible = true;
        }


    }
}
