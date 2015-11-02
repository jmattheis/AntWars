using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars
{
    class BoardObject
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool signalPlayer1 { get; set; }
        public bool signalPlayer2 { get; set; }

        public bool isAnt()
        {
            return this.GetType() == typeof(Ant);
        }

        public bool isSugar()
        {
            return this.GetType() == typeof(Sugar);
        }

        public bool isBase()
        {
            return this.GetType() == typeof(Base);
        }

        public Ant getAnt()
        {
            if (!isAnt()) { return null; }
            return (Ant)this;
        }

        public Base getBase()
        {
            if (!isBase()) { return null; }
            return (Base)this;
        }

        public Sugar getSugar()
        {
            if (!isSugar()) { return null; }
            return (Sugar)this;
        }
    }
}
