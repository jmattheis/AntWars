using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants
{
    public class Scout : Ant
    {
        private const int NOTIFY_COOLDOWN_IN_TICKS = 100;
        private int usedNotifyInTick = -NOTIFY_COOLDOWN_IN_TICKS;

        internal Scout(Board board, Player owner, int viewRange, int inventory, int moveRange)
            : base(board, owner, viewRange, inventory, moveRange)
        { }

        /// <summary>
        /// Notify other ants in the viewrange * 2
        /// </summary>
        /// <param name="coords">Die Koordinaten welche den anderen Ameisem mitgeteielt werden soll</param>
        /// <returns>true wenn erfolgreich false wenn noch cooldown ist</returns>
        public bool notifyOtherAnts(Coordinates coords)
        {
            if(usedNotifyInTick + NOTIFY_COOLDOWN_IN_TICKS <= board.CurrentTick)
            {
                usedNotifyInTick = board.CurrentTick;
                board.notifyAnts(coords, this);
                return true;
            }
            return false;
        }
    }
}
