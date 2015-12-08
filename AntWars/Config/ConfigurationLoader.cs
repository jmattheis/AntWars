using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Exception;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace AntWars.Config
{
    class ConfigurationLoader
    {
        private XmlSerializer gameConfSerializer = new XmlSerializer(typeof(GameConfig));
        private XmlSerializer playerConfSerializer = new XmlSerializer(typeof(PlayerConfig));

        private Configuration configuration = new Configuration();
        public String player1Path { get; set; }
        public String player2Path { get; set; }
        public String gamePath { get; set; }

        public void loadPlayer1(String path)
        {
            player1Path = path;
            configuration.Player1 = deserializePlayer(path);
        }

        public void loadPlayer2(String path)
        {
            player2Path = path;
            configuration.Player2 = deserializePlayer(path);
        }

        public void loadGame(String path)
        {
            gamePath = path;
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

        public void save(Configuration conf)
        {
            // TODO Check which files are given and only save them
            writeToFile(gamePath, gameConfSerializer, conf.Game);
            writeToFile(player1Path, playerConfSerializer, conf.Player1);
            writeToFile(player2Path, playerConfSerializer, conf.Player2);
        }

        public void savePlayer1()
        {
            writeToFile(player1Path, playerConfSerializer, get().Player1);
        }

        public void savePlayer2()
        {
            writeToFile(player2Path, playerConfSerializer, get().Player2);
        }

        public void saveGame()
        {
            writeToFile(gamePath, gameConfSerializer, get().Game);
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
        }

        public bool isNeededPathPlayer1()
        {
            return player1Path == null;
        }

        public bool isNeededPathPlayer2()
        {
            return player2Path == null;
        }

        public bool isNeededPathGame()
        {
            return gamePath == null;
        }
    }
}
