using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Contract
{
    // State object for reading client data asynchronously
    public class User
    {
        // Client  socket.
        public TcpClient client = null;
        // Size of receive buffer.
        public const int BufferSize = 1024;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public string IP { get; set; }
        public DateTime ConnectTime { get; set; }
        public BinaryReader br { get; private set; }

        public BinaryWriter bw { get; private set; }

        public string UserName { get; set; }

        public User(TcpClient client)
        {
            this.client = client;
            NetworkStream networkStream = this.client.GetStream();
            br = new BinaryReader(networkStream);
            bw = new BinaryWriter(networkStream);
        }

        public void Close()
        {
            br.Close();
            bw.Close();
            client.Close();
        }
    }
}
