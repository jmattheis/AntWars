using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using AntWars.Exception;

namespace AntWars.Helper
{
    static class Utils
    {
        public static Random random = new Random();

        public static XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config.GameConfig));

        public static Coordinates generateBaseCoords(int boardWidth, int boardHeight)
        {
            switch(random.Next(0,4))
            {
                case 0:
                    return new Coordinates(random.Next(boardWidth), 0);
                case 1:
                    return new Coordinates(--boardWidth, random.Next(boardHeight));
                case 2:
                    return new Coordinates(random.Next(boardWidth), --boardHeight);
                case 3:
                    return new Coordinates(0, random.Next(boardHeight));
                default:
                    throw new RuntimeException("C# is wrong.");
            }
        }

        public static Coordinates generateBaseCoords(int boardWidth, int boardHeight, Base enemyBase)
        {
            return new Coordinates(--boardWidth - enemyBase.Coords.X, --boardHeight - enemyBase.Coords.Y);
        }

        public static Coordinates generateCoords(int boardWidth, int boardHeight)
        {
            return new Coordinates(random.Next(boardWidth), random.Next(boardHeight));
        }

        public static void RandomizeBoardObjects<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                int k = (random.Next(0, n) % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
          
            }
        }

        public static Object deserializeConfig(String path)
        {
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                Object obj = xmlSerializer.Deserialize(file);
                file.Close();
                return obj;
            }
            catch (System.Exception e)
            {
                throw new InvalidConfigurationException(e.Message);
            }
        }
    }
}
