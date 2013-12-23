using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Client
{
    public class AsynchronousTcpClient
    {
        TcpClient client = null;
        User user = null;
        private BinaryReader br;
        private BinaryWriter bw;
        
        private bool isRun;
        delegate void SendMessageDelegate(string message);
        delegate void ReceiveMessageDelegate(out string receiveMessage);

        public AsynchronousTcpClient(User user)
        {
            this.user = user;
            br = user.br;
            bw = user.bw;
            //将网络流作为二进制读写对象
            AsyncSendMessage("Login^" + user.UserName);
            Thread threadReceive = new Thread(new ThreadStart(ReceiveData));
            threadReceive.IsBackground = true;
            threadReceive.Start();
        }



        /// <summary>
        /// 处理接收的服务器收据
        /// </summary>
        private void ReceiveData()
        {
            string receiveString = null;
            while (isRun)
            {
                ReceiveMessageDelegate d = new ReceiveMessageDelegate(receiveMessage);
                IAsyncResult result = d.BeginInvoke(out receiveString, null, null);
                //使用轮询方式来盘点异步操作是否完成
                while (!result.IsCompleted)
                {
                    if (isRun)
                        break;
                    Thread.Sleep(250);
                }
                //获取Begin方法的返回值所有输入/输出参数
                d.EndInvoke(out receiveString, result);
                if (receiveString == null)
                {
                    if (isRun)
                        //MessageBox.Show("与服务器失去联系");
                    break;
                }
                string[] splitString = receiveString.Split(',');
                string command = splitString[0].ToLower();
                switch (command)
                {
                    //case "login":   //格式： login,用户名
                    //    AddOnline(splitString[1]);
                    //    break;
                    //case "logout":  //格式： logout,用户名
                    //    RemoveUserName(splitString[1]);
                    //    break;
                    //case "talk":    //格式： talk,用户名,对话信息
                    //    AddTalkMessage(splitString[1] + "：\r\n");
                    //    AddTalkMessage(receiveString.Substring(splitString[0].Length + splitString[1].Length + 2));
                    //    break;
                }
            }
        }

        /// <summary>
        /// 读取服务器发过来的信息
        /// </summary>
        /// <param name="receiveMessage"></param>
        private void receiveMessage(out string receiveMessage)
        {
            receiveMessage = null;
            try
            {
                receiveMessage = br.ReadString();
            }
            catch (Exception ex)
            {
                //AddStatus(ex.Message);
            }
        }

        /// <summary>
        /// 异步向服务器发送数据
        /// </summary>
        /// <param name="message"></param>
        private void AsyncSendMessage(string message)
        {
            SendMessageDelegate d = new SendMessageDelegate(SendMessage);
            IAsyncResult result = d.BeginInvoke(message, null, null);
            while (!result.IsCompleted)
            {
                if (isRun)
                    return;
                Thread.Sleep(50);
            }
            SendMessageStates states = new SendMessageStates();
            states.d = d;
            states.result = result;
            Thread t = new Thread(FinishAsyncSendMessage);
            t.IsBackground = true;
            t.Start(states);
        }

        /// <summary>
        /// 处理接收的服务端数据
        /// </summary>
        /// <param name="obj"></param>
        private void FinishAsyncSendMessage(object obj)
        {
            SendMessageStates states = (SendMessageStates)obj;
            states.d.EndInvoke(states.result);
        }

        /// <summary>
        /// 发送信息状态的数据结构
        /// </summary>
        private struct SendMessageStates
        {
            public SendMessageDelegate d;
            public IAsyncResult result;
        }

        /// <summary>
        /// 向服务端发送数据
        /// </summary>
        /// <param name="message"></param>
        private void SendMessage(string message)
        {
            try
            {
                bw.Write(message);
                bw.Flush();
            }
            catch
            {
                //AddStatus("发送失败");
            }
        }
    }
}
