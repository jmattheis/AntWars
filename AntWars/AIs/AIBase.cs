﻿using System;
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

        public Player Player { private get; set; }

        public Game Game { private get; set; }

        public AIBase() { }

        private Base Base = null;


        protected bool buyScout()
        {
            Scout s = new Scout();
            s.UnitsGone = 0;
            Base b = Game.Board.BoardObjects.getBase(Player);

            if (Player.money < Player.PlayerConfig.scoutCost || !resolveAntCoords(s, b))
                return false;
            else
            {
                buyAnt(s, Player.PlayerConfig.scoutCost);
                return true;
            }
        }

        protected bool buyCarrier()
        {
            Carry c = new Carry();
            c.UnitsGone = 0;
            c.Speed = Player.
            Base b = Game.Board.BoardObjects.getBase(Player);

            if (Player.money < Player.PlayerConfig.carryCost || !resolveAntCoords(c, b))
                return false;
            else
            {
                buyAnt(c, Player.PlayerConfig.carryCost);
            }
            return true;
        }

        private void buyAnt(Ant ant, int cost)
        {
            Player.money -= cost;
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
                    if(!Game.Board.BoardObjects.isValidCoords(coords))
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

        protected Base getBase()
        {
            if (Base == null)
                Base = Game.Board.BoardObjects.getBase(Player);

            return Base;
        }

        public abstract void nextTick(int currentMoney, int score, int carryCount, int scoutCount, int time);
        public abstract void antTick(AIAnt ant, List<AIBoardObject> view);

        public void nextTick()
        {
            // extra Parameter an AI übergeben
            int score = Player.currentScore;
            int time = Game.getCurrentTick();
            nextTick(Player.money, score, Player.carryCount, Player.scoutCount, time);
        }
    }
}
