using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;

namespace AntWars.Helper
{
    class Utils
    {
        public static Random random = new Random();

        public static Coordinates generateBaseCords(int boardWidth, int boardHeight)
        {
            // TODO keine base nochmal an der gleichen himmelsrichtig generieren
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

        public static void RandomizeBoardObjects(List<BoardObject> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                int k = (random.Next(0, n) % n);
                n--;
                BoardObject value = list[k];
                list[k] = list[n];
                list[n] = value;
          
            }
        }

    }
}
