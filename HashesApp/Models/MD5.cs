using HashesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesApp.Models
{
    class MD5 : IHash
    {
        public string Name => "MD5";
        public string GetHash(byte[] inputText)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = inputText;
                byte[] hash = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        public string GetHash(string path)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create()) 
            {
                using (var stream = File.OpenRead(path))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", String.Empty);
                }
            }
        }

    }
}
