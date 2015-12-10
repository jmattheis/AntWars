using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;

namespace AntWars.Board
{
    class BoardObjects
    {
        private List<BoardObject> boardObjects = new List<BoardObject>();
        private List<Ant> ants = new List<Ant>();
        private List<Signal> signals = new List<Signal>();
        private List<Base> bases = new List<Base>();
        private List<Sugar> sugars = new List<Sugar>();
        Dictionary<Coordinates, List<BoardObject>> coordsToObjects;
        
        public void add(BoardObject boardObject)
        {
            boardObjects.Add(boardObject);
            if (boardObject.isAnt())
            {
                ants.Add((Ant) boardObject);
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
          List<BoardObject> objsInCoords
          if (!dic.TryGetValue(boardObject.Coords, out objsInCoords)) 
          {
            objsInCoords = new List<BoardObject>();
            dic.Add(boardObject.Coords, objsInCoords);
          }
          objsInCoords.Add(boardObject);
        }

        public List<BoardObject> get()
        {
          return new ReadOnlyCollection<Item>(boardObjects);
        }
        
        public List<Ant> getAnts()
        {
          return new ReadOnlyCollection<Item>(ants);
        }
        
        public List<Sugar> getSugars() 
        {
          return new ReadOnlyCollection<Item>(sugars); 
        }
        
        public List<Signal> getSignals()
        {
          return new ReadOnlyCollection<Item>(signals);
        }
        
        public List<Base> getBases() {
        {
          return new ReadOnlyCollection<Item>(bases);
        }
        
        public void move(BoardObject obj, Coordinates coords) {
        {
          List<BoardObject> objsInCoords
          if (!dic.TryGetValue(boardObject.Coords, out objsInCoords)) {
            throw new RuntimeException("No found");
          }
          objsInCoords.Remove(obj);
          obj.Coords = coords;
          addToMap(obj);
        }
    }
}
