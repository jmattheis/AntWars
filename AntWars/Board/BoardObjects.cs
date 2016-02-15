using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;
using AntWars.Helper;
using AntWars.Config;
namespace AntWars.Board
{
    class BoardObjects
    {
        private IList<BoardObject> boardObjects = new List<BoardObject>();
        private IList<Ant> ants = new List<Ant>();
        private IList<Signal> signals = new List<Signal>();
        private IList<Base> bases = new List<Base>();
        private IList<Sugar> sugars = new List<Sugar>();
        private IDictionary<Coordinates, List<BoardObject>> coordsToObjects = new Dictionary<Coordinates, List<BoardObject>>();
        private GameConfig conf;

        public BoardObjects(GameConfig conf)
        {
            this.conf = conf;
        }

        /// <summary>
        /// Adds a entry to the boardobjects
        /// </summary>
        /// <returns>true when added false when there a already a entry with the type on this coordinate</returns>
        public bool add(BoardObject boardObject)
        {
            if (!addToMap(boardObject))
            {
                return false;
            }
            boardObjects.Add(boardObject);
            if (boardObject.isAnt())
            {
                Ant ant = (Ant)boardObject;
                ants.Add(ant);
                ant.Owner.incrementAnts(ant);
            }
            else if (boardObject.isSignal())
            {
                signals.Add((Signal)boardObject);
            }
            else if (boardObject.isBase())
            {
                bases.Add((Base)boardObject);
            }
            else if (boardObject.isSugar())
            {
                sugars.Add((Sugar)boardObject);
            }
            return true;
        }


        private bool addToMap(BoardObject boardObject)
        {
            List<BoardObject> objsInCoords;
            if (!coordsToObjects.TryGetValue(boardObject.Coords, out objsInCoords))
            {
                objsInCoords = new List<BoardObject>();
                coordsToObjects.Add(boardObject.Coords, objsInCoords);
            }
            if (!containsType(objsInCoords, boardObject))
            {
                objsInCoords.Add(boardObject);
                return true;
            }
            return false;
        }

        private bool containsType(IList<BoardObject> objs, BoardObject objectToCheck)
        {
            foreach (BoardObject obj in objs)
            {
                // the OR is a workaround due to Carry != Scout in type so we use our isAnt() method
                if (obj.GetType() == objectToCheck.GetType() || (obj.isAnt() && objectToCheck.isAnt()))
                {
                    return true;
                }
            }
            return false;
        }

        private void removeFromMap(BoardObject boardObject)
        {
            List<BoardObject> objsInCoords;
            if (!coordsToObjects.TryGetValue(boardObject.Coords, out objsInCoords))
            {
                throw new RuntimeException("Could not remove boardobject it does not exist");
            }
            objsInCoords.Remove(boardObject);
        }

        public IList<BoardObject> get()
        {
            return new ReadOnlyCollection<BoardObject>(boardObjects);
        }

        public IList<BoardObject> getRandom()
        {
            Utils.RandomizeBoardObjects(boardObjects);
            return get();
        }

        public IList<Ant> getAnts()
        {
            return new ReadOnlyCollection<Ant>(ants);
        }
        public IList<Ant> getAntsByPlayer(Player player)
        {
            List<Ant> antList = new List<Ant>();
            foreach (Ant ant in this.ants)
            {
                if (ant.Owner == player)
                {
                    antList.Add(ant);
                }
            }
            return new ReadOnlyCollection<Ant>(antList);
        }

        public IList<Ant> getRandomAnts()
        {
            Utils.RandomizeBoardObjects(ants);
            return getAnts();
        }

        public IList<Sugar> getSugars()
        {
            return new ReadOnlyCollection<Sugar>(sugars);
        }

        public IList<Signal> getSignals()
        {
            return new ReadOnlyCollection<Signal>(signals);
        }

        public IList<Base> getBases()
        {
            return new ReadOnlyCollection<Base>(bases);
        }

        public IList<Coordinates> getFilledCoordinates()
        {
            return new ReadOnlyCollection<Coordinates>(coordsToObjects.Keys.ToArray());
        }

        public IList<BoardObject> getBoardObjectsFromCoords(Coordinates coords)
        {
            List<BoardObject> objsInCoords;
            if (!coordsToObjects.TryGetValue(coords, out objsInCoords))
            {
                objsInCoords = new List<BoardObject>();
            }
            return new ReadOnlyCollection<BoardObject>(objsInCoords);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>true when moved false when the way is blocked</returns>
        public bool move(BoardObject obj, Coordinates coords)
        {
            if (!isValidCoords(coords) || containsType(getBoardObjectsFromCoords(coords), obj))
            {
                return false;
            }
            List<BoardObject> objsInCoords;
            if (!coordsToObjects.TryGetValue(obj.Coords, out objsInCoords))
            {
                throw new RuntimeException("No found");
            }
            objsInCoords.Remove(obj);
            obj.Coords = coords;
            addToMap(obj);
            return true;
        }

        public bool isValidCoords(Coordinates coords)
        {
            if (coords.X < 0) return false;
            if (coords.X > conf.BoardWidth) return false;
            if (coords.Y < 0) return false;
            if (coords.Y > conf.BoardHeigth) return false;
            return true;
        }

        public void remove(BoardObject boardObject)
        {
            boardObjects.Remove(boardObject);
            if (boardObject.isAnt())
            {
                ants.Remove((Ant)boardObject);
            }
            else if (boardObject.isSignal())
            {
                signals.Remove((Signal)boardObject);
            }
            else if (boardObject.isBase())
            {
                bases.Remove((Base)boardObject);
            }
            else if (boardObject.isSugar())
            {
                sugars.Remove((Sugar)boardObject);
            }
            removeFromMap(boardObject);
        }

        public bool hasSugarOnCoords(Coordinates coords)
        {
            foreach (BoardObject obj in getBoardObjectsFromCoords(coords))
            {
                if (obj.isSugar())
                {
                    return true;
                }
            }
            return false;
        }

        public bool hasBaseOnCoords(Coordinates coords)
        {
            foreach (BoardObject obj in getBoardObjectsFromCoords(coords))
            {
                if (obj.isBase())
                {
                    return true;
                }
            }
            return false;
        }

        public bool hasAntOnCoords(Coordinates coords)
        {
            foreach (BoardObject obj in getBoardObjectsFromCoords(coords))
            {
                if (obj.isAnt())
                {
                    return true;
                }
            }
            return false;
        }

        public bool hasSignalOnCoords(Coordinates coords)
        {
            foreach (BoardObject obj in getBoardObjectsFromCoords(coords))
            {
                if (obj.isSignal())
                {
                    return true;
                }
            }
            return false;
        }

        public Base getBase(Player p)
        {
            foreach (BoardObject item in getBases())
            {
                if (item.isBase() && ((Base)item).Player == p)
                    return (Base)item;
            }
            throw new RuntimeException("Could not find base.");
        }

        public bool getSugar(Coordinates coords, out Sugar sugar)
        {
            foreach (BoardObject boardObject in this.getBoardObjectsFromCoords(coords))
            {
                if (boardObject.isSugar())
                {
                    sugar = (Sugar)boardObject;
                    return true;
                }
            }
            sugar = null;
            return false;
        }
    }
}
