using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Exception;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace AntWars.Config
{
    class ConfigurationLoader
    {
        private XmlSerializer gameConfSerializer = new XmlSerializer(typeof(GameConfig));

        private GameConfig configuration = new GameConfig();
        public String GamePath { get; set; }

        public void loadGame(String path)
        {
            GamePath = path;
            configuration = (GameConfig)deserialize(path, gameConfSerializer);
        }

        public GameConfig get()
        {
            return configuration;
        }

        public void saveGame()
        {
            writeToFile(GamePath, gameConfSerializer, get());
        }

        private Object deserialize(String path, XmlSerializer ser)
        {
            try {
                FileStream file = new FileStream(path, FileMode.Open);
                Object obj = ser.Deserialize(file);
                file.Close();
                return obj;
            } catch (System.Exception e)
            {
                throw new InvalidConfigurationException(e.Message);
            }
        }

        private void writeToFile(string path, XmlSerializer serializer, object config)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            serializer.Serialize(file, config);
            file.Close();
        }

        public void newGame()
        {
            configuration = new GameConfig();

            // set sizes to a quarter of screen resolution
            configuration.BoardHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 8;
            configuration.BoardWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 8;
            // set standard values
            configuration.SugarMin = 5;
            configuration.SugarMax = 20;
            configuration.SugarAmountMin = 1;
            configuration.SugarAmountMax = 5;
            configuration.StartMoney = 20;
            configuration.Ticks = 10;
            configuration.MaxTicks = 5000;
            configuration.Points = 100;
        }

        public bool isNeededPathGame()
        {
            return GamePath == null;
        }
    }
}
