﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;
using System.Security.Permissions;

namespace AntWars.AI
{
    /// <summary>
    /// Die Basis der AI welcher Ameisen kaufen kann.
    /// </summary>
    public abstract class AIBase : IAI
    {
        internal Player Player { get; set; }
        internal Game Game { get; set; }
        internal Base Base = null;

        public abstract void nextTick();

        /// <summary>
        /// Deine derzeitigen Punkte.
        /// </summary>
        protected int CurrentScore
        {
            get { return Player.Points; }
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

        /// <summary>
        /// Kauft einen Scout.
        /// </summary>
        /// <returns>>true wenn der Scout erfolgreich gekauft wird andernfalls wenn man nicht genug Geld hat false.</returns>
        protected bool buyScout(int viewRange, int inventory)
        {
            Scout s = new Scout(Game.Board, Player, viewRange, inventory);
            return buyAnt(s);
        }

        /// <summary>
        /// Kauft einen Carry
        /// </summary>
        /// <returns>true wenn der Carry erfolgreich gekauft wird andernfalls wenn man nicht genug Geld hat false.</returns>
        protected bool buyCarrier(int viewRange, int inventory)
        {
            Carry c = new Carry(Game.Board, Player, viewRange, inventory);
            return buyAnt(c);
        }

        private bool buyAnt(Ant ant)
        {
            Base b = Game.Board.BoardObjects.getBase(Player);
            if (Player.Money < ant.Cost || !resolveAntCoords(ant, b))
            {
                return false;
            }

            Player.Money -= ant.Cost;
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
    }
}
