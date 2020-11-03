using HashesApp.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GostCryptography.Gost_R3411;

namespace HashesApp.Models
{
    class GOST : IHash
    {
        public string Name => "GOST";

        public string GetHash(byte[] inputText)
        {
            using (var gost = Gost_R3411_2012_256_HashAlgorithm.Create())
            {
                byte[] inputBytes = inputText;
                byte[] hash = gost.ComputeHash(inputBytes);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

        public string GetHash(string path)
        {
            using (var gost = Gost_R3411_2012_256_HashAlgorithm.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    byte[] hash = gost.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", String.Empty);
                }
            }
        }
    }
}
