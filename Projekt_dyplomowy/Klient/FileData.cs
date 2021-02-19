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
        private long file_size;
        public FileData(string fn, string fa, long fs)
        {
            this.file_name = fn;
            this.file_address = fa;
            this.file_size = fs;
        }

        public string GetName()
        {
            return this.file_name;
        }

        public string GetAddress()
        {
            return this.file_address;
        }

        public long GetFileSize()
        {
            return this.file_size;
        }

    }
}
