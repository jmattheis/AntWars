using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntWars;
using AntWars.Helper;
using AntWars.Board.Ants;
using System.Threading;

namespace AntWars.Board {

    /// <summary>
    /// Das Board enthält eine liste von allen vorhandenen BoardObjects und ruft die AI auf.
    /// </summary>
    class Board {

        /// <summary>
        /// Die BoardObjects welche momentan vorhanden sind.
        /// </summary>
        public BoardObjects BoardObjects { get; private set; }

        /// <summary>
        /// Die Diagonale des Spielfeldes.
        /// </summary>
        public int Diagonal { get; private set; }
        internal Config conf;

        /// <summary>
        /// Die Anzahl von Zucker die generiert wurde.
        /// </summary>
        public int SugarAmount { get; private set; }
        public int CurrentTick { get; internal set; }

        public Board(Config conf) {
            this.CurrentTick = 0;
            this.conf = conf;
            BoardObjects = new BoardObjects(conf);
            Diagonal = Convert.ToInt32(Math.Sqrt(Math.Pow(conf.BoardHeight, 2) + Math.Pow(conf.BoardWidth, 2)));
        }

        /// <summary>
        /// Ruft die AI auf und die AI jeder Ameise.
        /// </summary>
        public void nextTick() {
            CurrentTick++;
            foreach (Base playerbase in BoardObjects.getBases()) {
                playerbase.Player.AI.nextTick();
            }
            IList<Ant> antList = BoardObjects.getRandomAnts();
            for (int i = 0;i < antList.Count;i++) {
                Ant ant = antList[i];
                ant.TookAction = false;
                ant.AI.antTick(getBoardObjectsInView(ant));
            }
        }

        /// <summary>
        /// Generiert Zucker und Base's
        /// </summary>
        /// <param name="player1">Der Spieler 1</param>
        /// <param name="player2">Der Spieler 2</param>
        public void nullTick(Player player1, Player player2) {
            Queue<Coordinates> baseCoords = Utils.generateBaseCoords(conf.BoardWidth, conf.BoardHeight);
            nullTick(player1, baseCoords.Dequeue());
            nullTick(player2, baseCoords.Dequeue());
            generateSugar(conf.SugarMin, conf.SugarMax);
        }

        /// <summary>
        /// Benachrichtigt andere Ameisen.
        /// </summary>
        /// <param name="coords">Die Koordinaten welche den anderen Ameisen mitgeteilt werden soll</param>
        /// <param name="ant">Die Ameise welche mitteilt</param>
        public void notifyAnts(HashSet<Coordinates> coords, Ant ant) {
            BoardObject[] objs = getBoardObjectsInView(ant.Coords, ant.ViewRange * 2);
            for (int i = 0;i < objs.Length;i++) {
                BoardObject obj = objs[i];
                if (obj == ant) {
                    continue;
                }

                if (obj.isAnt()) {
                    Ant antToNotify = obj as Ant;
                    antToNotify.AI.notify(coords);
                }
            }
        }

        private BoardObject[] getBoardObjectsInView(Ant ant) {
            return getBoardObjectsInView(ant.Coords, ant.ViewRange);
        }

        private BoardObject[] getBoardObjectsInView(Coordinates antCoords, int viewRange) {
            BoardObject[] result = new BoardObject[0];
            Coordinates[] coords = CircleCalculator.calculatePartCircle(viewRange);
            for (int i = 0;i < coords.Length;i++) {
                addBoardObjectsToArrayForPartCoordinates(coords[i], antCoords, viewRange, ref result);
            }

            return result;
        }

        private void addBoardObjectsToArrayForPartCoordinates(Coordinates coords, Coordinates current, int viewrange, ref BoardObject[] result) {
            int x1 = coords.X;
            int x2 = Math.Abs(x1);

            int y1 = coords.Y;
            int y2 = Math.Abs(y1);


            merge(x1 + current.X, y1 + current.Y, ref result); // upper left
            viewrange++;
            if (coords.X == 0 && coords.Y == 0)
                return; // on the ant
            if (coords.X == 0) {
                merge(current.X, y2 + current.Y, ref result);
                return;
            }
            if (coords.Y == 0) {
                merge(x2 + current.X, current.Y, ref result);
                return;
            }
            merge(x2 + current.X, y1 + current.Y, ref result); // upper right
            merge(x1 + current.X, y2 + current.Y, ref result); // lower left
            merge(x2 + current.X, y2 + current.Y, ref result); // lower right
        }

        private void merge(int x, int y, ref BoardObject[] result) {
            if (!BoardObjects.isValidCoords(x, y))
                return;
            BoardObject[] boardObjectsFromCoords = BoardObjects.getBoardObjectsFromCoords(x, y);
            if (boardObjectsFromCoords.Length != 0) {
                ArrayUtils.merge(ref result, boardObjectsFromCoords);
            }
        }

        private void nullTick(Player player, Coordinates baseCoords) {
            Base b = new Base(player);
            b.Coords = baseCoords;

            if (!BoardObjects.add(b)) {
                throw new RuntimeException("Could not add base");
            }
            player.AI.nextTick();
        }

        private void generateSugar(int min, int max) {
            Random rand = new Random();
            int count = rand.Next(min, max + 1);
            for (int i = 0;i < count;i++) {
                Sugar s = new Sugar();
                s.Coords = Utils.generateCoords(conf.BoardWidth, conf.BoardHeight);
                if (BoardObjects.hasBaseOnCoords(s.Coords) || BoardObjects.hasSugarOnCoords(s.Coords)) {
                    i--;
                    continue;
                }
                s.Amount = rand.Next(conf.SugarAmountMin, conf.SugarAmountMax + 1);
                BoardObjects.add(s);
                SugarAmount += s.Amount;
            }
        }

        internal void killBoardObject(ControllableBoardObject obj) {
            Ant ant = (obj as Ant);
            if (obj.isAnt() && ant.Inventory > 0) {
                Sugar s = new Sugar();
                s.Coords = ant.Coords;
                s.Amount = ant.Inventory;
                BoardObjects.add(s);
            }
            BoardObjects.remove(obj);
        }
    }
}
