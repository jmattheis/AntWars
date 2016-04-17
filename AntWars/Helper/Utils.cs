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

namespace AntWars.Helper {

    static class Utils {

        public static Random random = new Random();

        public static XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));

        private const int MIN_FACTOR = 10;

        private const int MAX_FACTOR = 5;

        public static Queue<Coordinates> generateBaseCoords(int boardWidth, int boardHeight) {
            Queue<Coordinates> baseCoords = new Queue<Coordinates>();

            int rand1 = random.Next(1, 5);
            int rand2;
            do {
                rand2 = random.Next(1, 5);
            } while (rand2 == rand1);

            baseCoords.Enqueue(getRandomCoordsInQuadrant(rand1, boardWidth, boardHeight));
            baseCoords.Enqueue(getRandomCoordsInQuadrant(rand2, boardWidth, boardHeight));

            return baseCoords;
        }

        public static Coordinates getRandomCoordsInQuadrant(int quadrant, int boardWidth, int boardHeight) {
            int minX = boardWidth / MIN_FACTOR;
            int maxX = boardWidth / MAX_FACTOR;
            int minY = boardHeight / MIN_FACTOR;
            int maxY = boardHeight / MAX_FACTOR;

            switch (quadrant) {
                case 1:
                    // quadrant 1
                    return new Coordinates(random.Next(minX, maxX), random.Next(minY, maxY));
                case 2:
                    // quadrant 2
                    return new Coordinates(random.Next(boardWidth - maxX, boardWidth - minX), random.Next(minY, maxY));
                case 3:
                    // quadrant 3
                    return new Coordinates(random.Next(minX, maxX), random.Next(boardHeight - maxY, boardHeight - minY));
                case 4:
                default:
                    // quadrant 4
                    return new Coordinates(random.Next(boardWidth - maxX, boardWidth - minX), random.Next(boardHeight - maxY, boardHeight - minY));
            }
        }

        public static Coordinates generateCoords(int boardWidth, int boardHeight) {
            return new Coordinates(random.Next(boardWidth), random.Next(boardHeight));
        }

        public static void RandomizeBoardObjects<T>(IList<T> list) {
            int n = list.Count;
            while (n > 1) {
                int k = (random.Next(0, n) % n);
                n--;
                T value = list[k];
                list[k] = list[n];
                list[n] = value;

            }
        }

        public static Config deserializeConfig(String path) {
            try {
                FileStream file = new FileStream(path, FileMode.Open);
                Config config = (Config) xmlSerializer.Deserialize(file);
                file.Close();
                return config;
            } catch (System.Exception e) {
                throw new InvalidConfigurationException(e.Message);
            }
        }

        public static void saveConfigToFile(Config config) {
            FileStream file = new FileStream(config.ConfigFilePath, FileMode.Create);
            Utils.xmlSerializer.Serialize(file, config);
            file.Close();
        }
    }
}
