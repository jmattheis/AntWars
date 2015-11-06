using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Exception;

namespace AntWars.Config
{
    class ConfigurationLoader
    {
        /// <summary>
        /// Erstellt ein Config object mithilfe des pfades zur config.xml
        /// </summary>
        /// <param name="path">der Pfad zu config</param>
        /// <returns>ein Config object</returns>
        /// <exception cref="InvalidConfigurationException">Wird geworfen wenn eine Invalide configuration datei gesetzt wurde.</exception>
        public static Configuration getConfig(String path)
        {
            Configuration config = new Configuration();
            config.Player1 = new PlayerConfig();
            config.Player2 = new PlayerConfig();

            if(false)
            {
                throw new InvalidConfigurationException();
            }

            return config;
        }
    }
}
