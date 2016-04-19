using System;

namespace AntWars.Exception {

    public class InvalidConfigurationException : System.Exception {

        public InvalidConfigurationException(String message) : base(message) { }

    }
}
