using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Exception {

    public class InvalidConfigurationException : System.Exception {

        public InvalidConfigurationException(String message) : base(message) { }

    }
}
