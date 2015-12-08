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
        public List<BoardObject> BoardObjects  { get; set; }
        private Configuration conf;
        // TODO speichern von nur ant?


        public Board(Configuration conf)
        {
            this.conf = conf;
            BoardObjects = new List<BoardObject>();
        }

        public void nextTick()
        {
            randomizeBoardObjects();

            foreach (BoardObject obj in BoardObjects)
            {
                if (obj.isAnt())
                {
                    Ant ant = (Ant)obj;
                    ant.Owner.AI.antTick(ant, getBoardObjectsInView(ant));
                }
            }
        }

        // TODO testen
        private List<BoardObject> getBoardObjectsInView(Ant ant)
        {
            int boxMinX = ant.Coords.X - ant.ViewRange;
            int boxMinY = ant.Coords.Y - ant.ViewRange;
            int boxMaxX = ant.Coords.X + ant.ViewRange;
            int boxMaxY = ant.Coords.Y + ant.ViewRange;
            List<Coordinates> coordinatesInsideView = new List<Coordinates>();
            for(int x = boxMinX; x <= boxMaxX; x++)
            {
                for (int y = boxMinY; y <= boxMaxY; y++)
                {
                    double abstand = Math.Sqrt((ant.Coords.X - x) ^ 2 + (ant.Coords.Y - y) ^ 2);
                    if(abstand <= ant.ViewRange)
                    {
                        coordinatesInsideView.Add(new Coordinates(x, y));
                    }
                }
            }
            List<BoardObject> result = new List<BoardObject>();
            foreach (Coordinates coords in coordinatesInsideView)
            {
                result.AddRange(getBoardObjectsForCoordinates(coords));
            }
            return result;
        }

        private List<BoardObject> getBoardObjectsForCoordinates(Coordinates coords)
        {
            List<BoardObject> results = new List<BoardObject>();
            foreach (BoardObject obj in BoardObjects)
            {
                if (obj.Coords.Equals(coords))
                {
                    results.Add(obj);
                }
            }
            return results;
        }
        public void nullTick(Player player1, Player player2)
        {
            nullTick(player1);
            nullTick(player2);
            generateSugar(conf.Game.sugarMin, conf.Game.sugarMax);
        }

        private void nullTick(Player player)
        {
            BoardObjects.Add(generateBase(player));
            player.AI.nextTick();
        }

        private void generateSugar(int min, int max)
        {
            int count = new Random().Next(min, max + 1);
            for (int i = 0; i < count; i++)
            {
                Sugar s = new Sugar();
                s.Coords = Utils.generateCoords(conf.Game.boardWidth, conf.Game.boardHeigth);
                BoardObjects.Add(s);
            }
        }

        private Base generateBase(Player player)
        {
            Base b = new Base(player);
            b.Coords = Utils.generateBaseCoords(conf.Game.boardWidth, conf.Game.boardHeigth);
            return b;
        }

        private void randomizeBoardObjects()
        {
            Utils.RandomizeBoardObjects(BoardObjects);
        }


        public Base getBase(Player p)
        {
            foreach (BoardObject item in BoardObjects)
            {
                if (item.isBase() && ((Base) item).Player == p)
                    return (Base)item;
            }
            throw new RuntimeException("Could not find base.");
        }
    }
}
