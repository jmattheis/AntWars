using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntWars.Config;
using AntWars.Helper;
using AntWars.Board.Ants;
using AntWars.AIs.Converter;
using AntWars.AIs.Converter.Classes;

namespace AntWars.Board
{
    /// <summary>
    /// Das Board ruft die boardobjects mit ki im #nextTick() auf und enthält eine liste von allen vorhandenen BoardObjects
    /// </summary>
    class Board
    {
        public BoardObjects BoardObjects  { get; private set; }
        private Configuration conf;
        private Converter converter;


        public Board(Configuration conf)
        {
            converter = new Converter(this);
            this.conf = conf;
            BoardObjects = new BoardObjects();
        }

        public void nextTick()
        {
            // TODO Gewinnbedingungen
            // TODO zucker check ob der weg kann
            foreach (Ant ant in BoardObjects.getRandomAnts())
            {
                ant.Owner.AI.antTick(ant, getBoardObjectsInView(ant));
            }
        }

        // TODO testen
        private List<AIBoardObject> getBoardObjectsInView(Ant ant)
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
            List<AIBoardObject> AIresult = converter.getAIObjects(result);
            return AIresult;
        }

        public List<BoardObject> getBoardObjectsForCoordinates(Coordinates coords)
        {
            List<BoardObject> results = new List<BoardObject>();
            foreach (BoardObject obj in BoardObjects.get())
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
            BoardObjects.add(generateBase(player));
            player.AI.nextTick();
        }

        private void generateSugar(int min, int max)
        {
            Random rand =  new Random();
            int count = rand.Next(min, max + 1);
            for (int i = 0; i < count; i++)
            {
                Sugar s = new Sugar();
                s.Coords = Utils.generateCoords(conf.Game.boardWidth, conf.Game.boardHeigth);
                if(hasSugarOnCoords(s.Coords)) {
                    i--;
                    continue;
                }
                s.amount = rand.Next(conf.Game.sugarAmountMin, conf.Game.sugarAmountMax + 1);
                BoardObjects.add(s);
            }
        }

        private bool hasSugarOnCoords(Coordinates coords)
        {
            foreach (BoardObject obj in getBoardObjectsForCoordinates(coords))
            {
                if (obj.isSugar() || obj.isBase())
                {
                    return true;
                }
            }
            return false;
        }

        private Base generateBase(Player player)
        {
            Base b = new Base(player);
            b.Coords = Utils.generateBaseCoords(conf.Game.boardWidth, conf.Game.boardHeigth);
            return b;
        }


        public Base getBase(Player p)
        {
            foreach (BoardObject item in BoardObjects.getBases())
            {
                if (item.isBase() && ((Base) item).Player == p)
                    return (Base)item;
            }
            throw new RuntimeException("Could not find base.");
        }
    }
}
