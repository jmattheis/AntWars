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
        private XmlSerializer playerConfSerializer = new XmlSerializer(typeof(PlayerConfig));

        private Configuration configuration = new Configuration();
        public String Player1Path { get; set; }
        public String Player2Path { get; set; }
        public String GamePath { get; set; }

        public void loadPlayer1(String path)
        {
            Player1Path = path;
            configuration.Player1 = deserializePlayer(path);
        }

        public void loadPlayer2(String path)
        {
            Player2Path = path;
            configuration.Player2 = deserializePlayer(path);
        }

        public void loadGame(String path)
        {
            GamePath = path;
            configuration.Game = (GameConfig)deserialize(path, gameConfSerializer);
        }

        public bool isAllLoaded()
        {
            return configuration.Player1 != null && configuration.Player2 != null && configuration.Game != null;
        }

        public Configuration get()
        {
            return configuration;
        }

        public void savePlayer1()
        {
            writeToFile(Player1Path, playerConfSerializer, get().Player1);
        }

        public void savePlayer2()
        {
            writeToFile(Player2Path, playerConfSerializer, get().Player2);
        }

        public void saveGame()
        {
            writeToFile(GamePath, gameConfSerializer, get().Game);
        }

        private PlayerConfig deserializePlayer(String path)
        {
            return (PlayerConfig)deserialize(path, playerConfSerializer);
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

        public void newPlayer1()
        {
            configuration.Player1 = new PlayerConfig();
            
        } 

        public void newPlayer2()
        {
            configuration.Player2 = new PlayerConfig();
        }

        public void newGame()
        {
            configuration.Game = new GameConfig();

            // set sizes to a quarter of screen resolution
            configuration.Game.BoardHeigth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 8;
            configuration.Game.BoardWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 8;
            // set standard values
            configuration.Game.SugarMin = 5;
            configuration.Game.SugarMax = 20;
            configuration.Game.SugarAmountMin = 1;
            configuration.Game.SugarAmountMax = 5;
            // TODO: StartAntAmount hat derzeit keine Auswirkungen auf den Spielstart
            configuration.Game.StartAntAmount = 10; // Meinung? zu groß oder zu klein?
            configuration.Game.StartMoney = 20;
            configuration.Game.Time = 300;
            configuration.Game.Points = 100;
        }

        public bool isNeededPathPlayer1()
        {
            return Player1Path == null;
        }

        public bool isNeededPathPlayer2()
        {
            return Player2Path == null;
        }

        public bool isNeededPathGame()
        {
            return GamePath == null;
        }
    }
}
