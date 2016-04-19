using AntWars.Board.Ants;
using System;
using System.Linq;
using System.Windows.Forms;

namespace AntWars.Helper {

    class CostCalculator {

        public static readonly double LOWEST_COST_VALUE = getLowestCostValue();

        private const double VIEWRANGE_SCOUT_QUANTIFIER = 0.75;
        private const double VIEWRANGE_CARRY_QUANTIFIER = 1.25;
        private const double VIEWRANGE_WARRIOR_QUANTIFIER = 1;

        private const double MOVERANGE_SCOUT_QUANTIFIER = 1;
        private const double MOVERANGE_CARRY_QUANTIFIER = 1;
        private const double MOVERANGE_WARRIOR_QUANTIFIER = 1;

        private const double INVENTORY_SCOUT_QUANTIFIER = 1.25;
        private const double INVENTORY_CARRY_QUANTIFIER = 0.75;
        private const double INVENTORY_WARRIOR_QUANTIFIER = 2;

        private const double HEALTH_SCOUT_QUANTIFIER = 1;
        private const double HEALTH_CARRY_QUANTIFIER = 1;
        private const double HEALTH_WARRIOR_QUANTIFIER = 0.75;

        private const double ATTACKPOWER_WARRIOR_QUANTIFIER = 1;

        private const int VIEWRANGE_MIN = 1;
        private const int VIEWRANGE_MAX = 10;

        private const int UPGRADE_MAX = 3;
        private const int UPGRADE_MULTIPLIER = 20;

        /// <summary>
        /// Berechnet die Kosten anhand des level's
        /// </summary>
        /// <param name="currentLevel">Das momentane level von einem Basen upgrade.</param>
        /// <returns>die Kosten</returns>
        public static double calculateUpgradeCost(int currentLevel) {
            if (currentLevel < UPGRADE_MAX) {
                return ++currentLevel * UPGRADE_MULTIPLIER;
            }
            throw new ArgumentException("current level is higher than max");
        }

        /// <summary>
        /// Berechnet die Kosten anhand der übergebenen Ameise.
        /// </summary>
        /// <param name="ant">Die Ameise</param>
        public static double calculateCost(Ant ant) {
            if (ant.ViewRange < VIEWRANGE_MIN || ant.ViewRange > VIEWRANGE_MAX) {
                throw new ArgumentException(String.Format(Messages.ERROR_INVALID_VALUE, ant.ViewRange, Messages.VIEWRANGE, VIEWRANGE_MIN, VIEWRANGE_MAX));
            }

            if (ant.isCarry()) {
                return calculateCostCarry(ant.ViewRange, ant.MoveRangeFactor, ant.MaxInventory, ant.Health, ant.Owner.AI.Playername);
            } else if (ant.isScout()) {
                return calculateCostScout(ant.ViewRange, ant.MoveRangeFactor, ant.MaxInventory, ant.Health, ant.Owner.AI.Playername);
            } else if (ant.isWarrior()) {
                return calculateCostWarrior((ant as Warrior).AttackPower, ant.ViewRange, ant.MoveRangeFactor, ant.MaxInventory, ant.Health, ant.Owner.AI.Playername);
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
        public static double calculateCostScout(int viewRange, int moveRangeFactor, int inventory, int health, string playername) {
            double viewRangeWithQuantifier = viewRange * VIEWRANGE_SCOUT_QUANTIFIER;
            double inventoryWithQuantifier = inventory * INVENTORY_SCOUT_QUANTIFIER;
            double moveRangeFactorWithQuantifier = moveRangeFactor * MOVERANGE_SCOUT_QUANTIFIER;
            double healthWithQuantifier = health * HEALTH_SCOUT_QUANTIFIER;
            return calculate(viewRangeWithQuantifier, moveRangeFactorWithQuantifier, inventoryWithQuantifier, healthWithQuantifier);
        }

        /// <summary>
        /// Berechnet die Kosten der Carry-Ameise.
        /// </summary>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="moveRange">Die Reichweite der Ameise.</param>
        /// <param name="inventory">Die Inventargröße der Ameise.</param>
        /// <returns>Die berechneten Kosten der Ameise.</returns>
        public static double calculateCostCarry(int viewRange, int moveRangeFactor, int inventory, int health, string playername) {
            double viewRangeWithQuantifier = viewRange * VIEWRANGE_CARRY_QUANTIFIER;
            double inventoryWithQuantifier = inventory * INVENTORY_CARRY_QUANTIFIER;
            double moveRangeFactorWithQuantifier = moveRangeFactor * MOVERANGE_CARRY_QUANTIFIER;
            double healthWithQuantifier = health * HEALTH_SCOUT_QUANTIFIER;
            return calculate(viewRangeWithQuantifier, moveRangeFactorWithQuantifier, inventoryWithQuantifier, healthWithQuantifier);
        }

        /// <summary>
        /// Berechnet die Kosten der Scout-Ameise.
        /// </summary>
        /// <param name="viewRange">Die Sichtweite der Ameise.</param>
        /// <param name="moveRange">Die Reichweite der Ameise.</param>
        /// <param name="inventory">Die Inventargröße der Ameise.</param>
        /// <returns>Die berechneten Kosten der Ameise.</returns>
        public static double calculateCostWarrior(int attackPower, int viewRange, int moveRangeFactor, int inventory, int health, string playername) {
            double viewRangeWithQuantifier = viewRange * VIEWRANGE_SCOUT_QUANTIFIER;
            double inventoryWithQuantifier = inventory * INVENTORY_SCOUT_QUANTIFIER;
            double moveRangeFactorWithQuantifier = moveRangeFactor * MOVERANGE_SCOUT_QUANTIFIER;
            double attackPowerWithQuantifier = attackPower * ATTACKPOWER_WARRIOR_QUANTIFIER;
            double healthWithQuantifier = health * HEALTH_WARRIOR_QUANTIFIER;
            return calculate(viewRangeWithQuantifier, moveRangeFactorWithQuantifier, inventoryWithQuantifier, attackPowerWithQuantifier, healthWithQuantifier);
        }

        private static double calculate(params double[] numbers) {
            return Math.Round((numbers.Sum() / 2), 2);
        }

        public static double getLowestCostValue()
        {
            double lowCarry = calculateCostCarry(1, 1, 1, 1, "");
            double lowScout = calculateCostScout(1, 1, 1, 1, "");
            double lowWarrior = calculateCostWarrior(1, 1, 1, 1, 1, "");
            if (lowCarry <= lowScout && lowCarry <= lowWarrior)
                return lowCarry;
            else if (lowScout <= lowCarry && lowScout <= lowWarrior)
                return lowScout;
            else // if (lowWarrior < lowCarry && lowWarrior < lowScout), Auskommentiert da alle Codepfade einen Wert zurückgeben müssen.
                return lowWarrior;
        }
    }
}
