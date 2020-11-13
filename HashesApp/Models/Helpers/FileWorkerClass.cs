using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesApp.Models.Helpers
{
    public static class FileWorkerClass
    {
        public static long GetFileSizeByPath(string path)
        {
            return new FileInfo(path).Length;
        }
    }
}
