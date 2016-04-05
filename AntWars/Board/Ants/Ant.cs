using AntWars.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants {

    /// <summary>
    /// Die Ameise.
    /// </summary>
    public abstract class Ant : ControllableBoardObject {

        /// <summary>
        /// Das Maximale Inventar der Ant.
        /// </summary>
        public int MaxInventory { get; protected set; }

        /// <summary>
        /// Das Inventar von der Ameise, welches aussagt wieviel Zucker die Ameise momentan trägt.
        /// </summary>
        public int Inventory { get; protected set; }

        public BoardObject[] View {
            get {
                return board.getBoardObjectsInView(this);
            }
        }

        internal Player Owner { get; private set; }
        internal IAIAnt AI { get; set; }
        private Base Base;

        internal Ant(Board board, Player owner, int viewRange, int maxInventory, int moveRangeFactor, int hp, int attackPower)
            : base(board, viewRange, moveRangeFactor, hp, attackPower) {
            MaxInventory = maxInventory;
            Owner = owner;
            Inventory = 0;
        }

        /// <summary>
        /// Zucker aufnehmen. Die Ameise muss auf dem Zucker stehen.
        /// </summary>
        /// <returns>True bei Erfolg, false wenn kein Zucker gefunden wurde.</returns>
        public bool pickUpSugar() {
            Sugar sugar;

            if (board.BoardObjects.getSugar(Coords, out sugar) && Inventory < MaxInventory) {
                int tempSugarAmount = sugar.Amount;
                int maxPickUpSugar = MaxInventory - Inventory;

                if (sugar.Amount - maxPickUpSugar <= 0) {
                    // Zucker bei 0 entfernen
                    sugar.Amount = 0;
                    board.BoardObjects.remove(sugar);
                } else {
                    sugar.Amount = sugar.Amount - maxPickUpSugar;
                }
                Inventory += (tempSugarAmount - sugar.Amount);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Zucker bei der Base abgeben. Die Ameise muss auf der Base stehen.
        /// </summary>
        /// <returns>True bei Erfolg, false wenn die Ameise nicht auf der Base steht.</returns>
        public bool dropSugarOnBase() {
            if (!TookAction && isInBase()) {
                Owner.addMoney(Inventory);
                Owner.Points += Inventory;
                Inventory = 0;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Verringert die UnitsGone einer Ameise um einen bestimmten Prozentsatz.
        /// </summary>
        /// <returns>True bei Regenerierung, false wenn Ameise nicht in der Base steht oder bereits eine Aktion ausgeführt hat.</returns>
        public bool recover() {
            if (!TookAction && isInBase()) {
                UnitsGone = Convert.ToInt32(Math.Ceiling(UnitsGone * (1d - (getBase().RecoverLevel / 10d))));
                // TODO: Nach Implementierung von Health, hier Health regenerieren.
                TookAction = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Ameise isst ein Stück Zucker aus ihrem Inventar.
        /// Verringert die UnitsGone der Ameise um einen bestimmten Prozentsatz.
        /// Verringert die MoveRange der Ameise um einen bestimmten Prozentsatz.
        /// </summary>
        /// <returns>true bei Regenerierung, fals wenn Ameise keinen Zucker bei sich trägt oder bereits eine Aktion ausgeführt hat.</returns>
        public bool eatSugar() {
            if (!TookAction && Inventory > 0) {
                Inventory--;
                UnitsGone = Convert.ToInt32(Math.Ceiling(UnitsGone * (1 - 0.1)));
                MoveRange = Convert.ToInt32(Math.Ceiling(MoveRange * (1 - 0.05)));
                TookAction = true;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Überprüft ob die Ameise innerhalb der Base steht.
        /// </summary>
        /// <returns>true, wenn die Ameise innerhalb der Base steht, ansonsten false</returns>
        public bool isInBase() {
            int range = getBase().RangeLevel;
            return Coords.isInRange(range, getBaseCoords());
        }

        private Base getBase() {
            if (Base == null) {
                Base = board.BoardObjects.getBase(Owner);
            }
            return Base;
        }

        /// Gibt die Koordinaten von der zugehörigen Base zurück.
        /// </summary>
        /// <returns>Die Koordinaten von der Base</returns>
        public Coordinates getBaseCoords() {
            return getBase().Coords;
        }

        /// <summary>
        /// Benachrichtigt andere Ameise in der Sichtweite * 2.
        /// </summary>
        /// <param name="coords">Die Koordinaten welche den anderen Ameisem mitgeteilt werden soll</param>
        /// <returns>true wenn erfolgreich false wenn noch cooldown ist</returns>
        public virtual bool notifyOtherAnts(HashSet<Coordinates> coords) {
            throw new NotImplementedException("Das Objekt darf die Methode nicht aufrufen.");
        }

        public override void die() {
            base.die();
            Owner.decreaseAnts(this);
        }

    }

}
