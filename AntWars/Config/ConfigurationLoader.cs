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
        private String player1Path = null;
        private String player2Path = null;
        private String gamePath = null;

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
            return player1Path != null && player2Path != null && gamePath != null;
        }

        public Configuration get()
        {
            return configuration;
        }

        public void setPlayer1Config(PlayerConfig player1, String pathToFile)
        {
            configuration.Player1 = player1;
            player1Path = pathToFile;
        }

        public void setPlayer2Config(PlayerConfig player2, String pathToFile)
        {
            configuration.Player2 = player2;
            player2Path = pathToFile;
        }

        public void setGameConfig(GameConfig game, String pathToFile)
        {
            configuration.Game = game;
            gamePath = pathToFile;
        }

        public void save(Configuration conf)
        {
            // TODO Check which files are given and only save them
            writeToFile(gamePath, gameConfSerializer, conf.Game);
            writeToFile(player1Path, playerConfSerializer, conf.Player1);
            writeToFile(player2Path, playerConfSerializer, conf.Player2);
        }

        public void save()
        {
            save(get());
        }

        public void save(String path, Object config)
        {
            if(config.GetType() == typeof(PlayerConfig)) {
                writeToFile(path, playerConfSerializer, config);
            } else if(config.GetType() == typeof(GameConfig))
            {
                writeToFile(path, gameConfSerializer, config);
            } else
            {
                throw new RuntimeException(config.GetType() + " is not a valid type for saving");
            }
        }

        private PlayerConfig deserializePlayer(String path)
        {
            return (PlayerConfig)deserialize(path, playerConfSerializer);
        }

        private Object deserialize(String path, XmlSerializer ser)
        {
            FileStream file = new FileStream(path, FileMode.Open);
            Object obj = ser.Deserialize(file);
            file.Close();
            return obj;
        }

        private void writeToFile(string path, XmlSerializer serializer, object config)
        {
            // TODO check if exists and then create or edit the file.
            FileStream file = new FileStream(path, FileMode.Create);
            serializer.Serialize(file, config);
            file.Close();
        }
    }
}
