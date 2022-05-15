using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class ConnectedClient
    {
        public TcpClient Client { get; set;}
        public string Name { get; set; }
        public ConnectedClient(TcpClient client, string name)
        {
            Client = client;
            Name = name;
        }
    }
}
