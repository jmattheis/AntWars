using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;

namespace AntWars.Helper
{
    public class Utils
    {
        public static Random random = new Random();

        public static Coordinates generateBaseCoords(int boardWidth, int boardHeight)
        {
            switch(random.Next(0,4))
            {
                case 0:
                    return new Coordinates(random.Next(boardWidth + 1), 0);
                case 1:
                    return new Coordinates(boardWidth, random.Next(boardHeight + 1));
                case 2:
                    return new Coordinates(random.Next(boardWidth + 1), boardHeight);
                case 3:
                    return new Coordinates(0, random.Next(boardHeight + 1));
                default:
                    throw new RuntimeException("NO WAY");
            }
        }

        public static Coordinates generateBaseCoords(int boardWidth, int boardHeight, Base enemyBase)
        {
            return new Coordinates(boardWidth - enemyBase.Coords.X, boardHeight - enemyBase.Coords.Y);
        }

        public static Coordinates generateCoords(int boardWidth, int boardHeight)
        {
            return new Coordinates(random.Next(boardWidth + 1), random.Next(boardHeight + 1));
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

    }
}
