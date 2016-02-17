using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntWars.Config;
using AntWars.Helper;
using AntWars.Board.Ants;
using System.Threading;

namespace AntWars.Board
{
    /// <summary>
    /// Das Board ruft die boardobjects mit ki im #nextTick() auf und enthält eine liste von allen vorhandenen BoardObjects
    /// </summary>
    class Board
    {
        public BoardObjects BoardObjects { get; private set; }
        private Configuration conf;
        private QueuedLock queuedLock = new QueuedLock();
        private volatile CoordsInView[] coordsInViews = new CoordsInView[20];


        public Board(Configuration conf)
        {
            this.conf = conf;
            BoardObjects = new BoardObjects(conf.Game);
        }

        public void nextTick()
        {
            // TODO Gewinnbedingungen
            foreach (Base playerbase in BoardObjects.getBases())
            {
                playerbase.Player.AI.nextTick();
            }
            foreach (Ant ant in BoardObjects.getRandomAnts())
            {
                //Task.Factory.StartNew(() => { 
                doAntAi(ant); //});
            }
            
            queuedLock.Enter();
            queuedLock.Exit();
        }

        private void doAntAi(Ant ant)
        {
            List<Coordinates> inView = getCoordsInView(ant);
            try
            {
                queuedLock.Enter();
                ant.AI.antTick(getBoardObjectsInView(ant, inView));
            }
            finally
            {
                queuedLock.Exit();
            }

        }


        private List<BoardObject> getBoardObjectsInView(Ant ant, List<Coordinates> inView)
        {
            List<BoardObject> result = new List<BoardObject>();

            foreach (Coordinates coords in inView)
            {
                IList<BoardObject> toAdd = BoardObjects.getBoardObjectsFromCoords(coords);
                if(toAdd.Count != 0)
                {
                    result.AddRange(toAdd);
                }
            }
            return result;
        }

        public List<Coordinates> getCoordsInView(Ant ant)
        {
            CoordsInView toDo = coordsInViews[ant.ViewRange];
            if(toDo == null)
            {
                toDo = new CoordsInView(ant.ViewRange, BoardObjects);
                coordsInViews[ant.ViewRange] = toDo;
            }
            List<Coordinates> test = toDo.getCoordinatesInsideView(ant.Coords);
            return test;
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
