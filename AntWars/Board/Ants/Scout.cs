using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants {

    public class Scout : Ant {

        private const int NOTIFY_COOLDOWN_IN_TICKS = 100;
        private int usedNotifyInTick = -NOTIFY_COOLDOWN_IN_TICKS;

        internal Scout(Board board, Player owner, int viewRange, int inventory, int moveRange, int hp)
            : base(board, owner, viewRange, inventory, moveRange, hp, 0) { }

        /// <summary>
        /// Benachrichtigt andere Ameise in der Sichtweite * 2.
        /// </summary>
        /// <param name="coords">Die Koordinaten welche den anderen Ameisem mitgeteilt werden soll</param>
        /// <returns>true wenn erfolgreich false wenn noch cooldown ist</returns>
        public override bool notifyOtherAnts(HashSet<Coordinates> coords) {
            if (usedNotifyInTick + NOTIFY_COOLDOWN_IN_TICKS <= board.CurrentTick) {
                usedNotifyInTick = board.CurrentTick;
                board.notifyAnts(coords, this);
                return true;
            }
            return false;
        }
    }
}
