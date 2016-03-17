using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntWars;
using AntWars.Helper;
using AntWars.Board.Ants;
using System.Threading;

namespace AntWars.Board
{
    /// <summary>
    /// Das Board enthält eine liste von allen vorhandenen BoardObjects und ruft die AI auf.
    /// </summary>
    class Board
    {
        /// <summary>
        /// Die BoardObjects welche momentan vorhanden sind.
        /// </summary>
        public BoardObjects BoardObjects { get; private set; }
        /// <summary>
        /// Die Diagonale des Spielfeldes.
        /// </summary>
        public int Diagonal { get; private set; }
        internal Config conf;
        private CoordsInView[] coordsInViews = new CoordsInView[20];
        /// <summary>
        /// Die Anzahl von Zucker die generiert wurde.
        /// </summary>
        public int SugarAmount { get; private set; }
        public List<Ant> DyingAnts { get; private set; }
        public int CurrentTick { get; internal set; }


        public Board(Config conf)
        {
            this.CurrentTick = 0;
            this.conf = conf;
            BoardObjects = new BoardObjects(conf);
            DyingAnts = new List<Ant>();
            Diagonal = Convert.ToInt32(Math.Sqrt(Math.Pow(conf.BoardHeight, 2) + Math.Pow(conf.BoardWidth, 2)));
        }

        /// <summary>
        /// Ruft die AI auf und die AI jeder Ameise.
        /// </summary>
        public void nextTick()
        {
            CurrentTick++;
            foreach (Base playerbase in BoardObjects.getBases())
            {
                playerbase.Player.AI.nextTick();
            }
            foreach (Ant ant in BoardObjects.getRandomAnts())
            {
                ant.MovedThisTick = false;
                ant.AI.antTick(getBoardObjectsInView(ant));
            }

            foreach (Ant ant in DyingAnts)
            {
                if(ant.Inventory > 0)
                {
                    Sugar s = new Sugar();
                    s.Coords = new Coordinates(ant.Coords.X, ant.Coords.Y);
                    s.Amount = ant.Inventory;
                    BoardObjects.add(s);
                }
                BoardObjects.remove(ant);
            }

            DyingAnts.Clear();
        }

        /// <summary>
        /// Generiert Zucker und Base's
        /// </summary>
        /// <param name="player1">Der Spieler 1</param>
        /// <param name="player2">Der Spieler 2</param>
        public void nullTick(Player player1, Player player2)
        {
            nullTick(player1);
            nullTick(player2);
            generateSugar(conf.SugarMin, conf.SugarMax);
        }

        /// <summary>
        /// Benachrichtigt andere Ameisen.
        /// </summary>
        /// <param name="coords">Die Koordinaten welche den anderen Ameisen mitgeteilt werden soll</param>
        /// <param name="ant">Die Ameise welche mitteilt</param>
        public void notifyAnts(HashSet<Coordinates> coords, Ant ant)
        {
            BoardObject[] objs = getBoardObjectsInView(ant.Coords, ant.ViewRange * 2);
            for (int i = 0; i < objs.Length; i++)
            {
                BoardObject obj = objs[i];
                if(obj == ant)
                {
                    continue;
                }

                if (obj.isAnt())
                {
                    Ant antToNotify = obj as Ant;
                    antToNotify.AI.notify(coords);
                }
            }
        }

        private BoardObject[] getBoardObjectsInView(Ant ant)
        {
            return getBoardObjectsInView(ant.Coords, ant.ViewRange);
        }

        private BoardObject[] getBoardObjectsInView(Coordinates antCoords, int viewRange)
        {
            BoardObject[] result = new BoardObject[0];
            Coordinates[] coords = getCoordsInView(viewRange).circle;
            for (int i = 0; i < coords.Length; i++)
            {
                Coordinates c = coords[i];
                Coordinates toAdd = new Coordinates(c.X + antCoords.X, c.Y + antCoords.Y);
                if (BoardObjects.isValidCoords(toAdd))
                {
                    BoardObject[] boardobjectsformcoords = BoardObjects.getBoardObjectsFromCoords(toAdd);
                    if (boardobjectsformcoords.Length != 0)
                    {
                        merge(ref result, boardobjectsformcoords);
                    }
                }
            }

            return result;
        }

        private void merge(ref BoardObject[] result, BoardObject[] add)
        {
            int array1OriginalLength = result.Length;
            Array.Resize<BoardObject>(ref result, array1OriginalLength + add.Length);
            Array.Copy(add, 0, result, array1OriginalLength, add.Length);
        }

        private CoordsInView getCoordsInView(int range)
        {
            CoordsInView coordsInView = coordsInViews[range];
            if (coordsInView == null)
            {
                coordsInView = new CoordsInView(range, BoardObjects);
                coordsInViews[range] = coordsInView;
            }
            return coordsInView;
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
                s.Coords = Utils.generateCoords(conf.BoardWidth, conf.BoardHeight);
                if (BoardObjects.hasBaseOnCoords(s.Coords) || BoardObjects.hasSugarOnCoords(s.Coords))
                {
                    i--;
                    continue;
                }
                s.Amount = rand.Next(conf.SugarAmountMin, conf.SugarAmountMax + 1);
                BoardObjects.add(s);
                SugarAmount += s.Amount;
            }
        }

        private Base generateBase(Player player)
        {
            Base b = new Base(player);
            // Bases immer gegenüber spawnen lassen
            if (this.BoardObjects.getBases().Count == 1)
            {
                b.Coords = Utils.generateBaseCoords(conf.BoardWidth, conf.BoardHeight, this.BoardObjects.getBases()[0]);
            }
            else
            {
                b.Coords = Utils.generateBaseCoords(conf.BoardWidth, conf.BoardHeight);
            }
            return b;
        }
    }
}
