using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntWars.Config;
using AntWars.Helper;
using AntWars.Board.Ants;

namespace AntWars.Board
{
    /// <summary>
    /// Das Board ruft die boardobjects mit ki im #nextTick() auf und enthält eine liste von allen vorhandenen BoardObjects
    /// </summary>
    class Board
    {
        public BoardObjects BoardObjects { get; private set; }
        private Configuration conf;


        public Board(Configuration conf)
        {
            this.conf = conf;
            BoardObjects = new BoardObjects(conf.Game);
        }

        public void nextTick()
        {
            foreach (Base playerbase in BoardObjects.getBases())
            {
                playerbase.Player.AI.nextTick();
            }
            foreach (Ant ant in BoardObjects.getRandomAnts())
            {
                ant.AI.antTick(getBoardObjectsInView(ant));
            }
        }

        private List<BoardObject> getBoardObjectsInView(Ant ant)
        {
            int boxMinX = ant.Coords.X - ant.ViewRange;
            int boxMinY = ant.Coords.Y - ant.ViewRange;
            int boxMaxX = ant.Coords.X + ant.ViewRange;
            int boxMaxY = ant.Coords.Y + ant.ViewRange;
            List<Coordinates> coordinatesInsideView = new List<Coordinates>();
            for (int x = boxMinX; x <= boxMaxX; x++)
            {
                for (int y = boxMinY; y <= boxMaxY; y++)
                {
                    double abstand = Math.Pow(ant.Coords.X - x, 2) + Math.Pow(ant.Coords.Y - y, 2);
                    if (abstand <= Math.Pow(ant.ViewRange, 2))
                    {
                        Coordinates c = new Coordinates(x, y);
                        if (BoardObjects.isValidCoords(c))
                        {
                            coordinatesInsideView.Add(new Coordinates(x, y));
                        }
                    }
                }
            }
            List<BoardObject> result = new List<BoardObject>();
            foreach (Coordinates coords in coordinatesInsideView)
            {
                result.AddRange(BoardObjects.getBoardObjectsFromCoords(coords));
            }
            return result;
        }

        public void nullTick(Player player1, Player player2)
        {
            nullTick(player1);
            nullTick(player2);
            generateSugar(conf.Game.SugarMin, conf.Game.SugarMax);
        }

        private void nullTick(Player player)
        {
            Base b = generateBase(player);

            if (!BoardObjects.add(b))
            {
                throw new RuntimeException("Could not add base");
            }
            player.AI.nextTick();
        }

        private void generateSugar(int min, int max)
        {
            Random rand = new Random();
            int count = rand.Next(min, max + 1);
            for (int i = 0; i < count; i++)
            {
                Sugar s = new Sugar();
                s.Coords = Utils.generateCoords(conf.Game.BoardWidth, conf.Game.BoardHeigth);
                if (BoardObjects.hasBaseOnCoords(s.Coords) || BoardObjects.hasSugarOnCoords(s.Coords))
                {
                    i--;
                    continue;
                }
                s.Amount = rand.Next(conf.Game.SugarAmountMin, conf.Game.SugarAmountMax + 1);
                BoardObjects.add(s);
            }
        }

        private Base generateBase(Player player)
        {
            Base b = new Base(player);
            // Bases immer gegenüber spawnen lassen
            if (this.BoardObjects.getBases().Count == 1)
            {
                b.Coords = Utils.generateBaseCoords(conf.Game.BoardWidth, conf.Game.BoardHeigth, this.BoardObjects.getBases()[0]);
            }
            else
            {
                b.Coords = Utils.generateBaseCoords(conf.Game.BoardWidth, conf.Game.BoardHeigth);
            }
            return b;
        }
    }
}
