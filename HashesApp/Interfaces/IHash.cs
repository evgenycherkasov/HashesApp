using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesApp.Interfaces
{
    public interface IHash
    {
        string Name { get; }
        string GetHash(byte[] input);
        string GetHash(string path);
    }
}
