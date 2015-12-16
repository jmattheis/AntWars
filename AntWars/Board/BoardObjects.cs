using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;
using AntWars.Helper;

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

        public void add(BoardObject boardObject)
        {
            boardObjects.Add(boardObject);
            if (boardObject.isAnt())
            {
                ants.Add((Ant)boardObject);
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
            addToMap(boardObject);

        }

        private void addToMap(BoardObject boardObject)
        {
            List<BoardObject> objsInCoords;
            if (!coordsToObjects.TryGetValue(boardObject.Coords, out objsInCoords))
            {
                objsInCoords = new List<BoardObject>();
                coordsToObjects.Add(boardObject.Coords, objsInCoords);
            }
            objsInCoords.Add(boardObject);
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

        public List<BoardObject> getBoardObjectsFromCoords(Coordinates coords)
        {

            List<BoardObject> objsInCoords;
            if (!coordsToObjects.TryGetValue(coords, out objsInCoords))
            {
                objsInCoords = new List<BoardObject>();
            }
            return objsInCoords;
        }

        public void move(BoardObject obj, Coordinates coords)
        {
            List<BoardObject> objsInCoords;
            if (!coordsToObjects.TryGetValue(obj.Coords, out objsInCoords))
            {
                throw new RuntimeException("No found");
            }
            objsInCoords.Remove(obj);
            obj.Coords = coords;
            addToMap(obj);
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
    }
}
