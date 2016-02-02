using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Exception
{
    class ReflectionUseException : System.Exception
    {
        public ReflectionUseException(String message) : base(message)
        {

        }
    }
}
