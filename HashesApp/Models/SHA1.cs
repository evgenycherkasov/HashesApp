using HashesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace HashesApp.Models
{
    class SHA1 : IHash
    {
        public string Name => "SHA1";

        public string GetHash(byte[] inputText)
        {
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                byte[] inputBytes = inputText;
                byte[] hash = sha1.ComputeHash(inputBytes);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        public string GetHash(string path)
        {
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    byte[] hash = sha1.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", String.Empty);
                }
            }
        }
    }
}

