using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Exception;
using System.Xml.Serialization;
using System.IO;

namespace AntWars.Config
{
    class ConfigurationLoader
    {
        static string configPath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// Erstellt ein Config object mithilfe des pfades zur config.xml
        /// </summary>
        /// <param name="path">der Pfad zu config</param>
        /// <returns>ein Config object</returns>
        /// <exception cref="InvalidConfigurationException">Wird geworfen wenn eine Invalide configuration datei gesetzt wurde.</exception>
        public static Configuration loadConfig(String path)
        {
            Configuration config = new Configuration();
            if (!string.IsNullOrEmpty(path))
            {
                if (false)
                {
                    throw new InvalidConfigurationException();
                }
            }
            return config;
        }
        public static void writeConfig(Configuration config, string gamefilepath, string player1filepath, string player2filepath)
        {
            XmlSerializer gameSerial = new XmlSerializer(typeof(GameConfig));
            XmlSerializer playerSerial = new XmlSerializer(typeof(PlayerConfig));



            FileStream file = new FileStream(gamefilepath, FileMode.Create);
            gameSerial.Serialize(file, config.Game);
            file.Close();

            writeToFile(gamefilepath, gameSerial, config.Game);
            writeToFile(player1filepath, playerSerial, config.Player1); 
            writeToFile(player2filepath, playerSerial, config.Player2);
        }

        private static void writeToFile(string path, XmlSerializer serializer, object config)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            serializer.Serialize(file, config);
            file.Close();
        }
    }
}
