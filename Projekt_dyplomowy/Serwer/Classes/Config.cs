using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Serwer
{
    class Config
    {
        string username;
        string hostname;
        string ip_address;
        int port;
        int buffer_size;

        public Config(string u, string h, string i, int p, int b)
        {
            this.username = u;
            this.ip_address = i;
            this.port = p;
            this.buffer_size = b;
            this.hostname = h;  
        }

        public override string ToString()
        {
            return $" Użytkownik: {username} || Port: {port} || Rozmiar bufera: {buffer_size} ";
        }
    }
}
