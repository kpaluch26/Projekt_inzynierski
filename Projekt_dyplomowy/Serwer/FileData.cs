using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serwer
{
    class FileData 
    {
        private string file_name;
        private string file_address;
        public FileData(string fn, string fa)
        {
            this.file_name = fn;
            this.file_address = fa;
        }

        public string GetName()
        {
            return this.file_name;
        }

        public string GetAddress()
        {
            return this.file_address;
        }

    }
}
