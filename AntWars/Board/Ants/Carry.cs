using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants
{
    public class Carry : Ant
    {
        internal Carry(Board board, Player owner) : base(board, owner)
        {
            ViewRange = owner.PlayerConfig.CarryViewRange;
            MaxInventory = owner.PlayerConfig.CarryInventory;
            Cost = owner.PlayerConfig.CarryCost;
        }
    }
}
