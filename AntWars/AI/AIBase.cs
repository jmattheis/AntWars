using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;
using System.Security.Permissions;

namespace AntWars.AI
{
    public abstract class AIBase : IAI
    {

        internal Player Player { get; set; }
        internal Game Game { get; set; }
        internal Base Base = null;

        protected bool buyScout()
        {
            Scout s = new Scout(Game.Board, Player);      
            return buyAnt(s, Player.PlayerConfig.ScoutCost);
        }

        protected bool buyCarrier()
        {
            Carry c = new Carry(Game.Board, Player);
            return buyAnt(c, Player.PlayerConfig.CarryCost);
        }

        private bool buyAnt(Ant ant, int cost)
        {
            Base b = Game.Board.BoardObjects.getBase(Player);
            if (Player.Money < cost || !resolveAntCoords(ant, b))
            {
                return false;
            }

            Player.Money -= cost;
            ant.AI = Player.AILoader.createAIAntInstance(ant);
            ant.ViewRange = 10; // TODO get out of player or something else
            return Game.Board.BoardObjects.add(ant);
        }

        private bool resolveAntCoords(Ant ant, Base b)
        {
            if (!Game.Board.BoardObjects.hasAntOnCoords(b.Coords))
            {
                ant.Coords = b.Coords;
                return true;
            }
            else
            {
                List<Coordinates> adjCoords = b.Coords.getAdjacentCoordinates(3);
                foreach (Coordinates coords in adjCoords)
                {
                    if (!Game.Board.BoardObjects.isValidCoords(coords))
                    {
                        continue;
                    }
                    if (!Game.Board.BoardObjects.hasAntOnCoords(coords))
                    {
                        ant.Coords = coords;
                        return true;
                    }
                }
                return false;
            }
        }

        private Base getBase()
        {
            if (Base == null)
                Base = Game.Board.BoardObjects.getBase(Player);

            return Base;
        }

        public abstract void nextTick(int currentMoney, int score, int carryCount, int scoutCount, int time);

        public void nextTick()
        {
            // extra Parameter an AI übergeben
            int score = Player.CurrentScore;
            int time = Game.getCurrentTick();
            nextTick(Player.Money, score, Player.CarryCount, Player.ScoutCount, time);
        }
    }
}
