using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientMain : Form
    {
        TcpClient client = null;
        User user=null;
        public ClientMain()
        {
            InitializeComponent();
        }
        public ClientMain(TcpClient client,string userName)
        {
            user = new User(client); 
            user.UserName = userName;
            AsynchronousTcpClient AsyncClient = new AsynchronousTcpClient(user);
            
           
        }
    }
}
