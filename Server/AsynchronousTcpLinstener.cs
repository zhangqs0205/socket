using Contract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    delegate void ListenClientDelegate(out TcpClient client);
    delegate void ReceiveMessageDelegate(User user, out string messageString);
    delegate void SendToClientDelegate(User user,string message);
    public class AsynchronousTcpLinstener :ISubject,  IDisposable
    {
        private TcpListener tcpListener = null;
        private const int port = 11100;
        private string IP = string.Empty;
        Dictionary<string, User> userDic = new Dictionary<string, User>();
        private ArrayList observers;
        private static ManualResetEvent manualEvent = new ManualResetEvent(false);
        private bool isRun = false;
        public AsynchronousTcpLinstener()
        {
            observers = new ArrayList();
        }

        #region 初始化服务器数据
        public bool InitServer(string IP)
        {
            return InitServer(IP,port);
        }
        public bool InitServer(string IP, int port)
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(IP);
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);
                tcpListener = new TcpListener(ipEndPoint);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        public bool StartServer()
        {
            tcpListener.Start();
            try
            {
                Thread listenThread = new Thread(startListening);
                listenThread.IsBackground = true;
                isRun = true;
                listenThread.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void startListening()
        {
            while (isRun)
            {
                manualEvent.Reset();
                //ListenClientDelegate listenerDelegate=new ListenClientDelegate();
                tcpListener.BeginAcceptTcpClient(new AsyncCallback(tcpListenerCallback), tcpListener);
                manualEvent.WaitOne();
            }
        }

        public bool StopServer()
        {
            try
            {
                isRun = false;
                tcpListener.Stop();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void tcpListenerCallback(IAsyncResult ar)
        {
            if (isRun)
            {
                manualEvent.Set();
                TcpListener handle = (TcpListener)ar.AsyncState;
                TcpClient client = handle.EndAcceptTcpClient(ar);
                if (client != null)
                {
                    User user = new User(client);
                    Thread receiveThread = new Thread(receiveData);
                    receiveThread.IsBackground = true;
                    receiveThread.Start(user);
                    string clientIP = client.Client.RemoteEndPoint.ToString();
                    user.IP = clientIP;
                    user.ConnectTime = DateTime.Now;
                    userDic.Add(clientIP, user);
                    sendChange(userDic);
                }
            }
        }

        private void receiveData(object userState)
        {
            User user = (User)userState;
            TcpClient client = user.client;
            string messageString = string.Empty;
            while (isRun)
            {
                ReceiveMessageDelegate rmdelgate = ReceiveMessage;
                IAsyncResult result = rmdelgate.BeginInvoke(user, out messageString, null, null);
                while (!result.IsCompleted)
                {
                    if (isRun)
                        break;
                    Thread.Sleep(250);
                }
                rmdelgate.EndInvoke(out messageString, result);
                if (messageString == null)
                {
                    if (isRun)
                    {
                        //与此用户失去连接
                        sendChange(string.Format("与用户{0}失去连接", user.UserName));
                        userDic.Remove(userDic.Where(i => i.Value == user).ToArray()[0].Key);
                    }
                    break;
                }
                else
                {
                    string[] splitString = messageString.Split('^');
                    switch (splitString[0])
                    {
                        case "Login":
                            user.UserName = splitString[1];
                            AsyncSendToClient(user, "Login^Server^OK");
                            sendChange(string.Format("用户{0}连接至服务器",user.UserName));
                            break;
                        case "Logout":
                            userDic.Remove(userDic.Where(i => i.Value == user).ToArray()[0].Key);
                            return;
                        case "Talk":
                            string talkString = messageString.Substring(splitString[0].Length + splitString[1].Length + 2);
                            sendChange(string.Format("{0}对{1}说：{2}", user.UserName, splitString[1], talkString));

                            User target = (from v in userDic
                                           where v.Value.UserName == splitString[1]
                                           select v.Value).ToArray()[0];
                            AsyncSendToClient(target, "talk^" + user.UserName + "^" + talkString);
                            break;
                        default:
                            ///
                            break;
                    }
                }
            }
        }

        private void AsyncSendToClient(User target, string p)
        {
            SendToClientDelegate stcDelegate = new SendToClientDelegate(SendToClient);
        }

        private void SendToClient(User user, string message)
        {
            user.bw.Write(message);
            user.bw.Flush();
        }

        private void ReceiveMessage(User user, out string receiveMessage)
        {
            try
            {
                receiveMessage = user.br.ReadString();
            }
            catch (Exception ex)
            {
                sendChange(ex.Message);
                receiveMessage = null;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 观察者模式中的注册
        /// </summary>
        /// <param name="obs"></param>
        public void registerInterest(IObserver obs)
        {
            observers.Add(obs);
            obs.sendNotify(userDic);
        }

        /// <summary>
        /// 向观察者发送更新推送
        /// </summary>
        /// <param name="obj"></param>
        public void sendChange(object obj)
        {
            foreach (IObserver v in observers)
            {
                v.sendNotify(obj);
            }
        }
    }
}
