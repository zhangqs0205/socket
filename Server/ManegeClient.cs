using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class ManegeClient : Form,IObserver
    {
        public ManegeClient(ISubject sub)
        {
            InitializeComponent();
            this.dgClient.AutoGenerateColumns = false;
            Init(sub);
            
        }

        /// <summary>
        /// 把本窗体作为观察者注册到Subjec
        /// </summary>
        /// <param name="sub"></param>
        private void Init(ISubject sub)
        {
            sub.registerInterest(this);
        }

        /// <summary>
        /// 接受Subject发送来的推送消息
        /// </summary>
        /// <param name="obj"></param>
        public void sendNotify(object obj)
        {
            Dictionary<string, User> clientDic= obj as Dictionary<string, User>;
            if (clientDic != null)
            {
                UpdataUserTable((from v in clientDic
                                            select v.Value).ToList());
            }
            else
            {
                string message = obj as string;
                if(!string.IsNullOrEmpty(message))
                AddMessage(message);
            }
        }

        delegate void UpdataUserTableDelegate(List<User> users);
        private void UpdataUserTable(List<User> users)
        {
            if (this.dgClient.InvokeRequired)
            {
                if (!this.IsDisposed)
                {
                    UpdataUserTableDelegate d = new UpdataUserTableDelegate(UpdataUserTable);
                    this.BeginInvoke(d, new object[] { users });
                }
            }
            else
            {
                dgClient.DataSource = users;
            }
        }

        /// <summary>
        /// 修改状态
        /// </summary>
        /// <param name="message"></param>
        delegate void AddMessageToTextDelegate(string message);

        private void AddMessage(string message)
        {
            if (this.richTextBox1.InvokeRequired)
            {
                if (!this.IsDisposed)
                {
                    AddMessageToTextDelegate d =new AddMessageToTextDelegate(AddMessage);
                    this.BeginInvoke(d, new object[]{message});
                }
            }
            else
            {
                richTextBox1.AppendText(message);
                richTextBox1.AppendText(Environment.NewLine);
            }
        }

        private void ManegeClient_Load(object sender, EventArgs e)
        {
        }

        // 代理实现异步调用以设置richTextBox控件text属性
        delegate void SetTextCallback(string text);
        private void SetRichtextBoxText(string message)
        {
            // InvokeRequired需要比较调用线程ID和创建线程ID
            // 如果它们不相同则返回true
            if (this.richTextBox1.InvokeRequired)
            {
                if (!this.IsDisposed)
                {
                    SetTextCallback d = new SetTextCallback(SetRichtextBoxText);
                    this.BeginInvoke(d, new object[] { message });
                }
            }
            else
            {
                richTextBox1.AppendText(message+Environment.NewLine);
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }
        }
       
    }
}
