using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntWars
{
    class Board
    {
        public List<BoardObject> BoardObjects  { get; set; }
        public Board()
        {
            BoardObjects = new List<BoardObject>();
        }
        public void nextTick()
        {
            foreach (BoardObject obj in BoardObjects)
            {
                if (obj.GetType() == typeof(Ant))
                {
                    Ant a = (Ant)obj;
                    
                }
            }
        }

        public void nullTick()
        {
            // base generieren
            
        }

        private void nullTick(Player player)
        {
            Base b = new Base(player);
            BoardObjects.Add(b);

        }

        public Base getBase(Player p)
        {
            foreach (BoardObject item in BoardObjects)
            {
                if (item.GetType() == typeof(Base) && ((Base) item).Player == p)
                    return (Base)item;
            }
            throw new RuntimeException("Could not find base.");
        }
    }
}
