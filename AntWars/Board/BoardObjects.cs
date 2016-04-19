using AntWars.Board.Ants;
using AntWars.Helper;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AntWars.Board {

    /// <summary>
    /// Ein Wrapper für die BoardObject's mit Helfermethoden.
    /// </summary>
    class BoardObjects {

        private BoardObject[] boardObjects = new BoardObject[0];
        private IList<Ant> ants = new List<Ant>();
        private IList<Base> bases = new List<Base>();
        private IList<Sugar> sugars = new List<Sugar>();
        private Config conf;
        private BoardObject[,][] boardObjectList;

        public BoardObjects(Config conf) {
            this.conf = conf;
            boardObjectList = new BoardObject[conf.BoardWidth + 1, conf.BoardHeight + 1][];
        }

        /// <summary>
        /// Fügt ein BoardObject hinzu.
        /// </summary>
        /// <returns>true wenn er hinzugefügt wurde andernfalls false</returns>
        public bool add(BoardObject boardObject) {

            if (!addToMap(boardObject)) {
                return false;
            }
            
            ArrayUtils.add(ref boardObjects, boardObject);
            if (boardObject.isAnt()) {
                Ant ant = (Ant) boardObject;
                ants.Add(ant);
                ant.Owner.incrementAnts(ant);
            } else if (boardObject.isBase()) {
                bases.Add((Base) boardObject);
            } else if (boardObject.isSugar()) {
                sugars.Add((Sugar) boardObject);
            }
            return true;
        }

        /// <summary>
        /// </summary>
        /// <returns>Alle BoardObjects</returns>
        public BoardObject[] get() {
            return boardObjects;
        }

        /// <summary>
        /// </summary>
        /// <returns>Alle BoardObject in eine zufälligen reihenfolge.</returns>
        public IList<BoardObject> getRandom() {
            Utils.RandomizeBoardObjects(boardObjects);
            return get();
        }

        /// <summary>
        /// </summary>
        /// <returns>Alle Ameise</returns>
        public IList<Ant> getAnts() {
            return new ReadOnlyCollection<Ant>(ants);
        }

        /// <summary>
        /// </summary>
        /// <param name="player">The Player</param>
        /// <returns>Alle Ameise von einem Player</returns>
        public IList<Ant> getAntsByPlayer(Player player) {
            List<Ant> antList = new List<Ant>();
            foreach (Ant ant in this.ants) {
                if (ant.Owner == player) {
                    antList.Add(ant);
                }
            }
            return new ReadOnlyCollection<Ant>(antList);
        }

        /// <summary>
        /// </summary>
        /// <returns>Alle Ameisen in zufälliger reihenfolge</returns>
        public IList<Ant> getRandomAnts() {
            Utils.RandomizeBoardObjects(ants);
            return getAnts();
        }

        /// <summary>
        /// </summary>
        /// <returns>Alle Zuckerhaufen</returns>
        public IList<Sugar> getSugars() {
            return new ReadOnlyCollection<Sugar>(sugars);
        }

        /// <summary>
        /// </summary>
        /// <returns>Alle Bases</returns>
        public IList<Base> getBases() {
            return new ReadOnlyCollection<Base>(bases);
        }

        /// <summary>
        /// Gibt die Boardobjects von einer bestimmten Koordinate wieder.
        /// </summary>
        /// <param name="x">Die X Koordinate</param>
        /// <param name="y">Die Y Koordinate</param>
        /// <returns>Die BoardObjects von den Koordinaten</returns>
        public BoardObject[] getBoardObjectsFromCoords(int x, int y) {
            BoardObject[] objsInCoords = boardObjectList[x, y];
            if (objsInCoords == null) {
                objsInCoords = new BoardObject[0];
                boardObjectList[x, y] = objsInCoords;
            }
            return objsInCoords;
        }

        public BoardObject[] getBoardObjectsFromCoords(Coordinates coords) {
            return getBoardObjectsFromCoords(coords.X, coords.Y);
        }



        /// <summary>
        /// </summary>
        /// <returns>true wenn das BoardObject gemoved wurde andernfalls false.</returns>
        public bool move(BoardObject obj, Coordinates coords) {
            if (!isValidCoords(coords) || containsType(getBoardObjectsFromCoords(coords.X, coords.Y), obj)) {
                return false;
            }
            removeFromMap(obj);
            obj.Coords = coords;
            addToMap(obj);
            return true;
        }

        /// <returns>true wenn die Koordinaten nicht außerhalb des Spielfeldes sind.</returns>
        public bool isValidCoords(Coordinates coords) {
            return isValidCoords(coords.X, coords.Y);
        }

        /// <returns>true wenn die Koordinaten nicht außerhalb des Spielfeldes sind.</returns>
        public bool isValidCoords(int x, int y) {
            return !(x < 0 || x > (conf.BoardWidth - 1) || y < 0 || y > (conf.BoardHeight - 1));
        }

        /// <summary>
        /// Entfernt ein BoardObject vom Spielfeld
        /// </summary>
        /// <param name="boardObject">Das Boardobject was gelöscht werden soll.</param>
        public void remove(BoardObject boardObject) {
            ArrayUtils.remove(ref boardObjects, boardObject);
            if (boardObject.isAnt()) {
                ants.Remove((Ant) boardObject);
            } else if (boardObject.isBase()) {
                bases.Remove((Base) boardObject);
            } else if (boardObject.isSugar()) {
                sugars.Remove((Sugar) boardObject);
            }
            removeFromMap(boardObject);
        }

        /// <summary>
        /// Überprüft ob Zucker auf den Koordinaten sind.
        /// </summary>
        /// <param name="coords">Die Koordinaten</param>
        /// <returns>true wenn Zucker auf den Koordinaten liegt</returns>
        public bool hasSugarOnCoords(Coordinates coords) {
            foreach (BoardObject obj in getBoardObjectsFromCoords(coords)) {
                if (obj.isSugar()) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Überprüft ob Base auf den Koordinaten sind.
        /// </summary>
        /// <param name="coords">Die Koordinaten</param>
        /// <returns>true wenn eine Base auf den Koordinaten liegt</returns>
        public bool hasBaseOnCoords(Coordinates coords) {
            foreach (BoardObject obj in getBoardObjectsFromCoords(coords)) {
                if (obj.isBase()) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="coords">Die Koordinaten</param>
        /// <returns>true wenn eine Ameise auf den Koordinaten ist.</returns>
        public bool hasAntOnCoords(Coordinates coords) {
            foreach (BoardObject obj in getBoardObjectsFromCoords(coords)) {
                if (obj.isAnt()) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="p">Den Speiler</param>
        /// <returns>Die Base vom Player</returns>
        public Base getBase(Player p) {
            foreach (BoardObject item in getBases()) {
                if (item.isBase() && ((Base) item).Player == p)
                    return (Base) item;
            }
            throw new RuntimeException("Could not find base.");
        }

        /// <summary>
        /// </summary>
        /// <param name="coords">Die Koordinaten</param>
        /// <param name="sugar">out den Zucker der gefunden wurde oder null</param>
        /// <returns>true wenn Zucker gefunden wurde</returns>
        public bool getSugar(Coordinates coords, out Sugar sugar) {
            BoardObject[] objs = getBoardObjectsFromCoords(coords);
            for (int i = 0; i < objs.Length; i++) {
                BoardObject boardObject = objs[i];
                if (boardObject.isSugar()) {
                    sugar = (Sugar) boardObject;
                    return true;
                }
            }
            sugar = null;
            return false;
        }

        private bool addToMap(BoardObject boardObject) {
            BoardObject[] objsInCoords = boardObjectList[boardObject.Coords.X, boardObject.Coords.Y];
            if (objsInCoords == null) {
                objsInCoords = new BoardObject[0];
            }
            if (!containsType(objsInCoords, boardObject)) {
                ArrayUtils.add(ref objsInCoords, boardObject);
                boardObjectList[boardObject.Coords.X, boardObject.Coords.Y] = objsInCoords;
                return true;
            }
            return false;
        }

        private bool containsType(IList<BoardObject> objs, BoardObject objectToCheck) {
            foreach (BoardObject obj in objs) {
                if (obj == null)
                    continue;
                // the OR is a workaround due to Carry != Scout in type so we use our isAnt() method
                if (obj.GetType() == objectToCheck.GetType() || (obj.isAnt() && objectToCheck.isAnt())) {
                    return true;
                }
            }
            return false;
        }

        private void removeFromMap(BoardObject boardObject) {
            BoardObject[] objsInCoords = boardObjectList[boardObject.Coords.X, boardObject.Coords.Y];
            ArrayUtils.remove(ref objsInCoords, boardObject);
            boardObjectList[boardObject.Coords.X, boardObject.Coords.Y] = objsInCoords;
        }

    }
}
