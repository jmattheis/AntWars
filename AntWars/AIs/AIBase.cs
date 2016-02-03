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
    [ReflectionPermission(SecurityAction
        .Assert)]
    public abstract class AIBase : IAI
    {

        internal Player Player { get; set; }

        internal Game Game { get; set; }

        internal Base Base = null;

        protected bool buyScout()
        {
            Scout s = new Scout(Game.Board);
            Base b = Game.Board.BoardObjects.getBase(Player);

            if (Player.Money < Player.PlayerConfig.ScoutCost || !resolveAntCoords(s, b))
            {
                return false;
            }

            buyAnt(s, Player.PlayerConfig.ScoutCost);
            return true;
        }

        protected bool buyCarrier()
        {
            Carry c = new Carry(Game.Board);
            Base b = Game.Board.BoardObjects.getBase(Player);

            if (Player.Money < Player.PlayerConfig.CarryCost || !resolveAntCoords(c, b))
            {
                return false;
            }

            buyAnt(c, Player.PlayerConfig.CarryCost);
            return true;
        }

        private void buyAnt(Ant ant, int cost)
        {
            Player.Money -= cost;
            ant.Owner = Player;
            ant.ViewRange = 10; // TODO get out of player or something else
            Game.Board.BoardObjects.add(ant);
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
        public abstract void antTick(Ant ant, List<BoardObject> view);

        public void nextTick()
        {
            // extra Parameter an AI übergeben
            int score = Player.CurrentScore;
            int time = Game.getCurrentTick();
            nextTick(Player.Money, score, Player.CarryCount, Player.ScoutCount, time);
        }
    }
}
