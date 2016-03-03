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

        /// <summary>
        /// Deine derzeitigen Punkte.
        /// </summary>
        protected int CurrentScore
        {
            get { return Player.CurrentScore; }
        }

        /// <summary>
        /// Die bisher vergangenen Ticks.
        /// </summary>
        protected int CurrentTick
        {
            get { return Game.getCurrentTick(); }
        }

        /// <summary>
        /// Dein aktuelles Geld.
        /// </summary>
        protected int CurrentMoney
        {
            get { return Player.Money; }
        }

        /// <summary>
        /// Anzahl deiner Carries.
        /// </summary>
        protected int CurrentCarryCount
        {
            get { return Player.CarryCount; }
        }

        /// <summary>
        /// Anzahl deiner Scouts.
        /// </summary>
        protected int CurrentScoutScount
        {
            get { return Player.ScoutCount; }
        }

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
            ant.AI = Player.AILoader.createAIAntInstance(ant, Game.Conf.Game);
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

        public abstract void nextTick();
    }
}
