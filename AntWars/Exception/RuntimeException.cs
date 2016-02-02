using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars
{
     class RuntimeException : System.Exception
    {
        public RuntimeException(string message) : base(message)
        { }
    }
}
