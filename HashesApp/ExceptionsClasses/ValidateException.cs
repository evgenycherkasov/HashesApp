using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashesApp.ExceptionsClasses
{
    class ValidateException : ApplicationException
    {
        public ValidateException(string message) : base(message) { }
    }
}
