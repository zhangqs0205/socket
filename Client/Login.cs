using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.Threading;
using System.IO;

namespace Client
{
    public partial class Login : Form
    {
        TcpClient client = null;
        IPEndPoint ipEndPoint = null;
        private string IP
        {
            get
            {
                return ConfigurationManager.AppSettings["IP"];
            }
        }
        private int port
        {
            get
            {
                return Int32.Parse(ConfigurationManager.AppSettings["Port"]);
            }
        }
        private string UserName
        {
            get
            {
                return Environment.UserDomainName;
            }
        }
        BackgroundWorker connectWork = new BackgroundWorker();
        public Login()
        {
            InitializeComponent();
            connectWork.DoWork += new DoWorkEventHandler(connectWork_DoWork);
            connectWork.RunWorkerCompleted += new RunWorkerCompletedEventHandler(connectWork_RunWorkerCompleted);
        }

        private void connectWork_DoWork(object sender, DoWorkEventArgs e)
        {
            client = new TcpClient();
            SetLable1Text(false);
            IAsyncResult result = client.BeginConnect(IP, port, null, null);
            while (!result.IsCompleted)
            {
                Thread.Sleep(100);
            }
            try
            {
                client.EndConnect(result);
                e.Result = "success";
            }
            catch (Exception ex)
            {
                e.Result = ex.Message;
                return;
            }
        }

        private void connectWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() == "success")
            {
                ClientMain main = new ClientMain(client, this.txtUserName.Text);
                this.Visible = false;
                main.ShowDialog();
                
            }
            else
            {
                SetLable1Text(true);
                //AddStatus("连接失败:" + e.Result);
                //btn_Login.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connectWork.RunWorkerAsync();
        }



        private void Login_Load(object sender, EventArgs e)
        {
            this.cbServerIP.Items.Add(IP);
            this.cbServerIP.SelectedItem = IP;
            this.txtUserName.Text = UserName;

        }

        // 代理实现异步调用以设置richTextBox控件text属性
        delegate void SetTextCallback(bool flag);
        private void SetLable1Text(bool flag)
        {
            // InvokeRequired需要比较调用线程ID和创建线程ID
            // 如果它们不相同则返回true
            if (this.progressBar1.InvokeRequired)
            {
                if (!this.IsDisposed)
                {
                    SetTextCallback d = new SetTextCallback(SetLable1Text);
                    this.BeginInvoke(d, flag);
                }
            }
            else
            {
                progressBar1.Enabled = flag;
            }
        }
    }
}
