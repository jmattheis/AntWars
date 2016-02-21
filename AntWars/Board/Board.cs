﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntWars.Config;
using AntWars.Helper;
using AntWars.Board.Ants;
using System.Threading;

namespace AntWars.Board
{
    /// <summary>
    /// Das Board ruft die boardobjects mit ki im #nextTick() auf und enthält eine liste von allen vorhandenen BoardObjects
    /// </summary>
    class Board
    {
        public BoardObjects BoardObjects { get; private set; }
        private Configuration conf;
        private CoordsInView[] coordsInViews = new CoordsInView[20];


        public Board(Configuration conf)
        {
            this.conf = conf;
            BoardObjects = new BoardObjects(conf.Game);
        }

        public void nextTick()
        {
            // TODO Gewinnbedingungen
            foreach (Base playerbase in BoardObjects.getBases())
            {
                playerbase.Player.AI.nextTick();
            }
            foreach (Ant ant in BoardObjects.getRandomAnts())
            {
                ant.AI.antTick(getBoardObjectsInView(ant));
            }

        }

        private BoardObject[] getBoardObjectsInView(Ant ant)
        {
            BoardObject[] result = new BoardObject[0];
            Coordinates[] coords = getCoordsInView(ant.ViewRange).circle;
            for (int i = 0; i < coords.Length; i++)
            {
                Coordinates c = coords[i];
                Coordinates toAdd = new Coordinates(c.X + ant.Coords.X, c.Y + ant.Coords.Y);
                if (BoardObjects.isValidCoords(toAdd))
                {
                    BoardObject[] boardobjectsformcoords = BoardObjects.getBoardObjectsFromCoords(toAdd);
                    if (boardobjectsformcoords.Length != 0)
                    {
                        merge(ref result, boardobjectsformcoords);
                    }
                }
            }

            return result;
        }

        private void merge(ref BoardObject[] result, BoardObject[] add)
        { 
            int array1OriginalLength = result.Length;
            Array.Resize<BoardObject>(ref result, array1OriginalLength + add.Length);
            Array.Copy(add, 0, result, array1OriginalLength, add.Length);
        }

        public CoordsInView getCoordsInView(int range)
        {
            CoordsInView coordsInView = coordsInViews[range];
            if (coordsInView == null)
            {
                coordsInView = new CoordsInView(range, BoardObjects);
                coordsInViews[range] = coordsInView;
            }
            return coordsInView;
        }

        public void nullTick(Player player1, Player player2)
        {
            nullTick(player1);
            nullTick(player2);
            generateSugar(conf.Game.SugarMin, conf.Game.SugarMax);
        }

        private void nullTick(Player player)
        {
            Base b = generateBase(player);

            if (!BoardObjects.add(b))
            {
                throw new RuntimeException("Could not add base");
            }
            player.AI.nextTick();
        }

        private void generateSugar(int min, int max)
        {
            Random rand = new Random();
            int count = rand.Next(min, max + 1);
            for (int i = 0; i < count; i++)
            {
                Sugar s = new Sugar();
                s.Coords = Utils.generateCoords(conf.Game.BoardWidth, conf.Game.BoardHeight);
                if (BoardObjects.hasBaseOnCoords(s.Coords) || BoardObjects.hasSugarOnCoords(s.Coords))
                {
                    i--;
                    continue;
                }
                s.Amount = rand.Next(conf.Game.SugarAmountMin, conf.Game.SugarAmountMax + 1);
                BoardObjects.add(s);
            }
        }

        private Base generateBase(Player player)
        {
            Base b = new Base(player);
            // Bases immer gegenüber spawnen lassen
            if (this.BoardObjects.getBases().Count == 1)
            {
                b.Coords = Utils.generateBaseCoords(conf.Game.BoardWidth, conf.Game.BoardHeight, this.BoardObjects.getBases()[0]);
            }
            else
            {
                b.Coords = Utils.generateBaseCoords(conf.Game.BoardWidth, conf.Game.BoardHeight);
            }
            return b;
        }
    }
}
