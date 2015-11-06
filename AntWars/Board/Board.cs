﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AntWars.Config;
using AntWars.Helper;
using AntWars.Board.Ants;

namespace AntWars.Board
{
    /// <summary>
    /// Das Board ruft die boardobjects mit ki im #nextTick() auf und enthält eine liste von allen vorhandenen BoardObjects
    /// </summary>
    class Board
    {
        public List<BoardObject> BoardObjects  { get; set; }
        private Configuration conf;


        public Board(Configuration conf)
        {
            this.conf = conf;
            BoardObjects = new List<BoardObject>();
        }

        public void nextTick()
        {
            randomizeBoardObjects();

            foreach (BoardObject obj in BoardObjects)
            {
                if (obj.isAnt())
                {
                    Ant ant = (Ant)obj;
                    // TODO filter boardobjects for view range of the ant
                    ant.Owner.AI.antTick(ant, BoardObjects);
                }
            }
        }

        private List<BoardObject> getBoardObjectsInView(Ant ant)
        {
            int box_min_x = ant.Coords.X - ant.ViewRange;
            int box_min_y = ant.Coords.Y - ant.ViewRange;
            int boxMaxX = ant.Coords.X + ant.ViewRange;
            int boxMaxY = ant.Coords.Y + ant.ViewRange;
            List<Coordinates> coordinatesInsideView = new List<Coordinates>();
            for(int x = box_min_x; x <= boxMaxX; x++)
            {
                for (int y = box_min_y; x <= boxMaxY; x++)
                {
                    double abstand = Math.Sqrt((ant.Coords.X - x) ^ 2 + (ant.Coords.Y - y) ^ 2);
                    if(abstand <= ant.ViewRange)
                    {
                        coordinatesInsideView.Add(new Coordinates(x, y));
                    }
                }
            }
            List<BoardObject> result = new List<BoardObject>();
            foreach (Coordinates coords in coordinatesInsideView)
            {
                result.AddRange(getBoardObjectsForCoordinates(coords));
            }
            return result;
        }

        private List<BoardObject> getBoardObjectsForCoordinates(Coordinates coords)
        {
            List<BoardObject> results = new List<BoardObject>();
            foreach (BoardObject obj in BoardObjects)
            {
                if (obj.Coords.Equals(coords))
                {
                    results.Add(obj);
                }
            }
            return results;
        }
        public void nullTick(Player player1, Player player2)
        {
            nullTick(player1);
            nullTick(player2);
        }

        private void nullTick(Player player)
        {
            BoardObjects.Add(generateBase(player));
            player.AI.nextTick();
        }

        private Base generateBase(Player player)
        {
            Base b = new Base(player);
            b.Coords = Utils.generateBaseCords(conf.BoardWidth, conf.BoardHeight);
            return b;
        }

        private void randomizeBoardObjects()
        {
            Utils.RandomizeBoardObjects(BoardObjects);
        }


        public Base getBase(Player p)
        {
            foreach (BoardObject item in BoardObjects)
            {
                if (item.isBase() && ((Base) item).Player == p)
                    return (Base)item;
            }
            throw new RuntimeException("Could not find base.");
        }
    }
}
