using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.KI
{
    public abstract class KI
    {

        public Player Player { get; set; }

        private Game Game { get; set; }

        public KI(Player player)
        {
            Player = player;
        }
        public abstract void nextTick(int currentPoints,);
        public abstract void antTick(Ant ant, List<BoardObject> view);

        public sealed void buyScout() {
            Scout s = new Scout();
            s.Owner = Player;
            // TODO währung abziehen
            BoardObject b = Game.Board.getBase(Player);
            s.x = b.x;
            s.y = b.y;
        }

        public sealed void buyCarrier() {

        }
    }
}
