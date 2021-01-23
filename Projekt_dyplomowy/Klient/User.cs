using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klient
{
    class User
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string group { get; set; }
        public string section { get; set; }
        public string version { get; set; }
        public override string ToString()
        {
            return $"{firstname} {lastname} {group}{section}{version}";
        }
    }
}
