using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;
using AntWars.AIs.Converter.Classes;

namespace AntWars.AI
{
    abstract class AIBase : IAI
    {

        public Player Player {private get; set; }

        public Game Game {private get; set; }

        public AIBase() { }

        private Base Base = null;


        protected bool buyScout() {
            Scout s = new Scout();

            if (Player.money < Player.scoutCost)
                return false;
            else
                Player.money -= Player.scoutCost;

            buyAnt(s);

            return true;
        }

        protected bool buyCarrier() {
            Carry c = new Carry();

            if (Player.money < Player.carryCost)
                return false;
            else
                Player.money -= Player.carryCost;

            buyAnt(c);

            return true;
        }

        private void buyAnt(Ant ant)
        {
            Base b = Game.Board.BoardObjects.getBase(Player);
            ant.Owner = Player;
            resolveAntCoords(ant, b);
            Game.Board.BoardObjects.add(ant);
        }

        private void resolveAntCoords(Ant ant, Base b)
        {
            if (!Game.Board.BoardObjects.hasAntOnCoords(b.Coords))
                ant.Coords = b.Coords;
            else
            {
                List<Coordinates> adjCoords = b.Coords.getAdjacentCoordinates(3);
                foreach (Coordinates coords in adjCoords)
                {
                    if (!Game.Board.BoardObjects.hasAntOnCoords(coords))
                    {
                        ant.Coords = coords;
                        break;
                    }
                }
                // todo Exception (?)
            }
        }

        protected Base getBase()
        {
            if(Base == null)
                Base = Game.Board.BoardObjects.getBase(Player);
            
            return Base;
        }

        public abstract void nextTick(int currentMoney);
        public abstract void antTick(AIAnt ant, List<AIBoardObject> view);

        public void nextTick()
        {
            nextTick(Player.money);
        }
    }
}
