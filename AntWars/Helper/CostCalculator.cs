using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;

namespace AntWars.Helper
{
    class CostCalculator
    {
        // TODO: Summary erstellen
        public static void calculateCost(ref Ant ant)
        {
            /*if (ant.isCarry())
            {
                ant.Cost = calculateCostCarry(ant.ViewRange, ant.MoveRange, ant.MaxInventory);
            }
            if (ant.isScout())
            {
                ant.Cost = calculateCostScout(ant.ViewRange, ant.MoveRange, ant.MaxInventory);
            }*/
        }

        // TODO: Summary erstellen
        public static int calculateCostScout(int viewRange, int moveRange, int inventory)
        {
            checkAttributes(viewRange, moveRange, inventory);
            double doubleViewRange = viewRange * 0.75;
            double doubleInventory = inventory * 1.25;
            return (Convert.ToInt32(Math.Ceiling((doubleViewRange + Convert.ToDouble(moveRange) + doubleInventory) / 2)));
        }
        // TODO: Summary erstellen
        public static int calculateCostCarry(int viewRange, int moveRange, int inventory)
        {
            checkAttributes(viewRange, moveRange, inventory);
            double doubleViewRange = viewRange * 1.25;
            double doubleInventory = inventory * 0.75;
            return (Convert.ToInt32(Math.Ceiling((doubleViewRange + Convert.ToDouble(moveRange) + doubleInventory) / 2)));
        }

        private static void checkAttributes(int viewRange, int moveRange, int inventory)
        {
            // TODO: Get Min and Max from CostCalculator-Form or from global const
            if (viewRange < 1 || viewRange > 10)
            {
                throw new ArgumentException(String.Format(Messages.ERROR_INVALID_VALUE, viewRange, Messages.VIEWRANGE, 1, 10));
            }
            if (moveRange < 1 || moveRange > 10)
            {
                throw new ArgumentException(String.Format(Messages.ERROR_INVALID_VALUE, moveRange, Messages.MOVERANGE, 1, 10));
            }
            if (inventory < 1 || inventory > 10)
            {
                throw new ArgumentException(String.Format(Messages.ERROR_INVALID_VALUE, inventory, Messages.INVENTORY, 1, 10));
            }
        }
    }
}
