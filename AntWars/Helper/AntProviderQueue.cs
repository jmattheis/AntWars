using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;
using System.Threading;

namespace AntWars.Helper
{
    internal class AntProviderQueue
    {
        private Board.Board board;
        private Ant[] currentAnts;
        private Ant[] currentAntsInProgress = new Ant[5];
        private int currentIndex;
        private object isFinished = new object();
        private object can = new object();
        public volatile bool kill = false;
        
        public void isFin()
        {
            lock(can) Monitor.Wait(can);
        }

        public AntProviderQueue(Board.Board board)
        {
            this.board = board;
        }

        public void refresh()
        { 
            lock (this)
            {
                currentAnts = board.BoardObjects.getAnts().ToArray();
                currentIndex = currentAnts.Length - 1;
                lock(isFinished) Monitor.PulseAll(isFinished);
            }
        }
        public Ant provide()
        {
            lock(this)
            {
                if(currentIndex < 0)
                {
                    return null;
                }
                int currentTry = 0;
                while(true)
                {
                    Ant ant = getLastExistingAnt(currentTry);
                    if (currentTry > currentIndex)
                    {
                        break;
                    }
                    if(ant != null && !isInViewRangeFromOtherAnt(ant)) {
                        processAnt(currentTry);
                        return ant;
                    }
                    currentTry++;
                }
                return null;
            }
        }

        private Ant getLastExistingAnt(int offset)
        {
            int index = currentIndex - offset;
            if(index < 0) { return null; }
            Ant ant = currentAnts[index];
            return ant;
        }

        private void processAnt(int offset)
        {
            if(offset == 0) { currentIndex--; }
            Ant ant = currentAnts[currentIndex - offset];
            currentAnts[currentIndex - offset] = null;
            for(int i = 0;i < currentAntsInProgress.Length; i++) {
                if(currentAntsInProgress[i] == null) {
                    currentAntsInProgress[i] = ant;
                }
            }
        }

        private void processedAnt(Ant ant)
        {
            for (int i = 0; i < currentAntsInProgress.Length; i++)
            {
                if (currentAntsInProgress[i] == ant)
                {
                    currentAntsInProgress[i] = null;
                }
            }
        }



        private bool isInViewRangeFromOtherAnt(Ant ant)
        {
            int thisViewRange = ant.ViewRange;
            for (int i = 0; i < currentAntsInProgress.Length; i++)
            {
                Ant other = currentAntsInProgress[i];
                if (other != null)
                {
                    int range = Math.Max(thisViewRange, other.ViewRange);
                    if (other.Coords.isInRange(range, ant.Coords))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void doItBro()
        {
            lockIt();
            while (true)
            {
                if(kill) { break; }
                Ant ant = this.provide();
                if(ant == null)
                {
                    lock(can) Monitor.PulseAll(can);
                    lockIt();
                    continue;
                }
                ant.TookAction = false;
                ant.AI.antTick(board.getBoardObjectsInView(ant));
                processedAnt(ant);
            }
        }

        private void lockIt()
        {
            lock (isFinished) Monitor.Wait(isFinished);
        } 
    }
}
