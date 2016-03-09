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

        private Configuration configuration = new Configuration();
        public String GamePath { get; set; }

        public void loadGame(String path)
        {
            GamePath = path;
            configuration.Game = (GameConfig)deserialize(path, gameConfSerializer);
        }

        public bool isAllLoaded()
        {
            return configuration.Game != null;
        }

        public Configuration get()
        {
            return configuration;
        }

        public void saveGame()
        {
            writeToFile(GamePath, gameConfSerializer, get().Game);
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
            configuration.Game = new GameConfig();

            // set sizes to a quarter of screen resolution
            configuration.Game.BoardHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 8;
            configuration.Game.BoardWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 8;
            // set standard values
            configuration.Game.SugarMin = 5;
            configuration.Game.SugarMax = 20;
            configuration.Game.SugarAmountMin = 1;
            configuration.Game.SugarAmountMax = 5;
            configuration.Game.StartMoney = 20;
            configuration.Game.Ticks = 10;
            configuration.Game.MaxTicks = 5000;
            configuration.Game.Points = 100;
        }

        public bool isNeededPathGame()
        {
            return GamePath == null;
        }
    }
}
