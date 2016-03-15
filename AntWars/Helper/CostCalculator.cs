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
            if (ant.isCarry())
            {
                return calculateCostCarry(ant.ViewRange, ant.MoveRange, ant.MaxInventory);
            }
            if (ant.isScout())
            {
                return calculateCostScout(ant.ViewRange, ant.MoveRange, ant.MaxInventory);
            }
            throw new ArgumentException(Messages.ERROR_INVALID_ANTTYPE);
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
            double doubleViewRange = viewRange * 1.25;
            double doubleInventory = inventory * 0.75;
            return (Convert.ToInt32(Math.Ceiling((doubleViewRange + Convert.ToDouble(moveRange) + doubleInventory) / 2)));
        }

        /*private static int recalcMoveRange(int moveRange)
        {
            return 
        }*/
    }
}
