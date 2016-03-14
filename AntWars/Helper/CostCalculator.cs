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
        /// <summary>
        /// Berechnet die Kosten anhand der übergebenen Ameise.
        /// </summary>
        /// <param name="ant">Die Ameise</param>
        public static int calculateCost(Ant ant)
        {
            // TODO: Kommentierung kann nach MoveRange-Implementierung entfernt werden.
            /*if (ant.isCarry())
            {
                return calculateCostCarry(ant.ViewRange, ant.MoveRange, ant.MaxInventory);
            }
            if (ant.isScout())
            {
                return calculateCostScout(ant.ViewRange, ant.MoveRange, ant.MaxInventory);
            }*/
        }

        /// <summary>
        /// Berechnet die Kosten der Scout-Ameise.
        /// </summary>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="moveRange">Die Reichweite der Ameise.</param>
        /// <param name="inventory">Die Inventargröße der Ameise.</param>
        /// <returns>Die berechneten Kosten der Ameise.</returns>
        public static int calculateCostScout(int viewRange, int moveRange, int inventory)
        {
            checkAttributes(viewRange, moveRange, inventory);
            double doubleViewRange = viewRange * 0.75;
            double doubleInventory = inventory * 1.25;
            return (Convert.ToInt32(Math.Ceiling((doubleViewRange + Convert.ToDouble(moveRange) + doubleInventory) / 2)));
        }
        
        /// <summary>
        /// Berechnet die Kosten der Carry-Ameise.
        /// </summary>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="moveRange">Die Reichweite der Ameise.</param>
        /// <param name="inventory">Die Inventargröße der Ameise.</param>
        /// <returns>Die berechneten Kosten der Ameise.</returns>
        public static int calculateCostCarry(int viewRange, int moveRange, int inventory)
        {
            checkAttributes(viewRange, moveRange, inventory);
            double doubleViewRange = viewRange * 1.25;
            double doubleInventory = inventory * 0.75;
            return (Convert.ToInt32(Math.Ceiling((doubleViewRange + Convert.ToDouble(moveRange) + doubleInventory) / 2)));
        }
        /// <summary>
        /// Überprüft ob die Attribute der Ameise in dem vorgegebenem Bereich sind.
        /// </summary>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="moveRange">Die Reichweite der Ameise.</param>
        /// <param name="inventory">Die Inventargröße der Ameise.</param>
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
