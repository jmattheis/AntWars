using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board.Ants;
using System.Windows.Forms;

namespace AntWars.Helper
{
    class CostCalculator
    {
        private const double VIEWRANGE_SCOUT_QUANTIFIER = 0.75;
        private const double VIEWRANGE_CARRY_QUANTIFIER = 1.25;
        private const double VIEWRANGE_WARRIOR_QUANTIFIER = 1;

        private const double MOVERANGE_SCOUT_QUANTIFIER = 1;
        private const double MOVERANGE_CARRY_QUANTIFIER = 1;
        private const double MOVERANGE_WARRIOR_QUANTIFIER = 1;

        private const double INVENTORY_SCOUT_QUANTIFIER = 1.25;
        private const double INVENTORY_CARRY_QUANTIFIER = 0.75;
        private const double INVENTORY_WARRIOR_QUANTIFIER = 2;

        private const double ATTACKPOWER_WARRIOR_QUANTIFIER = 1;

        private const int VIEWRANGE_MIN = 1;
        private const int VIEWRANGE_MAX = 10;
        private const int MOVERANGE_MIN = 1;
        private const int MOVERANGE_MAX = 10;
        private const int INVENTORY_MIN = 1;
        private const int INVENTORY_MAX = 10;
        private const int ATTACKPOWER_MIN = 1;
        private const int ATTACKPOWER_MAX = 10;

        private const int UPGRADE_MAX = 3;
        private const int UPGRADE_MULTIPLIER = 20;

        /// <summary>
        /// Berechnet die Kosten anhand des level's
        /// </summary>
        /// <param name="currentLevel">Das momentane level von einem Basen upgrade.</param>
        /// <returns>die Kosten</returns>
        public static double calculateUpgradeCost(int currentLevel)
        {
            if(currentLevel < UPGRADE_MAX)
            {
                return ++currentLevel * UPGRADE_MULTIPLIER;
            }
            throw new ArgumentException("current level is higher than max");
        }

        /// <summary>
        /// Berechnet die Kosten anhand der übergebenen Ameise.
        /// </summary>
        /// <param name="ant">Die Ameise</param>
        public static double calculateCost(Ant ant)
        {

            if (ant.isCarry())
            {
                return calculateCostCarry(ant.ViewRange, ant.MoveRangeFactor, ant.MaxInventory, ant.Owner.AI.Playername);
            }
            else if (ant.isScout())
            {
                return calculateCostScout(ant.ViewRange, ant.MoveRangeFactor, ant.MaxInventory, ant.Owner.AI.Playername);
            }
            else if (ant.isWarrior())
            {
                return calculateCostWarrior((ant as Warrior).AttackPower, ant.ViewRange, ant.MoveRangeFactor, ant.MaxInventory, ant.Owner.AI.Playername);
            }
            throw new RuntimeException("Unknown ant type.");
        }

        /// <summary>
        /// Berechnet die Kosten der Scout-Ameise.
        /// </summary>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="moveRange">Die Reichweite der Ameise.</param>
        /// <param name="inventory">Die Inventargröße der Ameise.</param>
        /// <returns>Die berechneten Kosten der Ameise.</returns>
        public static double calculateCostScout(int viewRange, int moveRangeFactor, int inventory, string playername)
        {
            double viewRangeWithQuantifier = viewRange * VIEWRANGE_SCOUT_QUANTIFIER;
            double inventoryWithQuantifier = inventory * INVENTORY_SCOUT_QUANTIFIER;
            double moveRangeFactorWithQuantifier = moveRangeFactor * MOVERANGE_SCOUT_QUANTIFIER;
            return calculate(viewRangeWithQuantifier, moveRangeFactorWithQuantifier, inventoryWithQuantifier);
        }

        /// <summary>
        /// Berechnet die Kosten der Carry-Ameise.
        /// </summary>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="moveRange">Die Reichweite der Ameise.</param>
        /// <param name="inventory">Die Inventargröße der Ameise.</param>
        /// <returns>Die berechneten Kosten der Ameise.</returns>
        public static double calculateCostCarry(int viewRange, int moveRangeFactor, int inventory, string playername)
        {
            double viewRangeWithQuantifier = viewRange * VIEWRANGE_CARRY_QUANTIFIER;
            double inventoryWithQuantifier = inventory * INVENTORY_CARRY_QUANTIFIER;
            double moveRangeFactorWithQuantifier = moveRangeFactor * MOVERANGE_CARRY_QUANTIFIER;
            return calculate(viewRangeWithQuantifier, moveRangeFactorWithQuantifier, inventoryWithQuantifier);
        }

        /// <summary>
        /// Berechnet die Kosten der Scout-Ameise.
        /// </summary>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="moveRange">Die Reichweite der Ameise.</param>
        /// <param name="inventory">Die Inventargröße der Ameise.</param>
        /// <returns>Die berechneten Kosten der Ameise.</returns>
        public static double calculateCostWarrior(int attackPower, int viewRange, int moveRangeFactor, int inventory, string playername)
        {
            double viewRangeWithQuantifier = viewRange * VIEWRANGE_SCOUT_QUANTIFIER;
            double inventoryWithQuantifier = inventory * INVENTORY_SCOUT_QUANTIFIER;
            double moveRangeFactorWithQuantifier = moveRangeFactor * MOVERANGE_SCOUT_QUANTIFIER;
            double attackPowerWithQuantifier = attackPower * ATTACKPOWER_WARRIOR_QUANTIFIER;
            return calculate(viewRangeWithQuantifier, moveRangeFactorWithQuantifier, inventoryWithQuantifier, attackPowerWithQuantifier);
        }

        private static double calculate(params double[] numbers)
        {
            return Math.Round((numbers.Sum() / 2), 2);
        }

        /// <summary>
        /// Überprüft ob die Attribute der Ameise in dem vorgegebenem Bereich sind.
        /// </summary>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="moveRange">Die Reichweite der Ameise.</param>
        /// <param name="inventory">Die Inventargröße der Ameise.</param>
        public static void checkAttributes(int viewRange, int moveRange, int inventory, string playername)
        {
            // TODO für Warrior umschreiben, wird momentan nirgends genutzt
            if (viewRange < VIEWRANGE_MIN || viewRange > VIEWRANGE_MAX)
            {
                MessageBox.Show(String.Format(Messages.ERROR_INVALID_VALUE, viewRange, Messages.VIEWRANGE, VIEWRANGE_MIN, VIEWRANGE_MAX),
                                String.Format(Messages.ERROR_INVALID_VALUE_PLAYER_CAPTION, playername),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            if (moveRange < MOVERANGE_MIN || moveRange > MOVERANGE_MAX)
            {
                MessageBox.Show(String.Format(Messages.ERROR_INVALID_VALUE, viewRange, Messages.VIEWRANGE, MOVERANGE_MIN, MOVERANGE_MAX),
                                String.Format(Messages.ERROR_INVALID_VALUE_PLAYER_CAPTION, playername),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            if (inventory < INVENTORY_MIN || inventory > INVENTORY_MAX)
            {
                MessageBox.Show(String.Format(Messages.ERROR_INVALID_VALUE, viewRange, Messages.VIEWRANGE, INVENTORY_MIN, INVENTORY_MAX),
                                String.Format(Messages.ERROR_INVALID_VALUE_PLAYER_CAPTION, playername),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
