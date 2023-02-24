using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class Client
    {
        public string name { get; set; }

        public List<string> history { get; set; } = new List<string>();

        public Client(string name) 
        {
            this.name = name;
        }
    }
}
