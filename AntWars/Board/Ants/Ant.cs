using AntWars.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board.Ants
{
    /// <summary>
    /// Die Ameise.
    /// </summary>
    public abstract class Ant : BoardObject
    {
        /// <summary>
        /// Gibt an, ob die Ameise sich in diesem Tick schon bewegt hat. 
        /// </summary>
        public bool TookAction { get; internal set; }

        /// <summary>
        /// Der Faktor für die Berechnung der Bewegungsreichweite.
        /// </summary>
        public int MoveRangeFactor { get; internal set; }

        /// <summary>
        /// Wie weit die Ameise schon gegangen ist.
        /// </summary>
        public int UnitsGone { get; internal set; }
       
        /// <summary>
        /// Das Maximale Inventar der Ant.
        /// </summary>
        public int MaxInventory { get; protected set; }

        /// <summary>
        /// Das Inventar von der Ameise, welches aussagt wieviel Zucker die Ameise momentan trägt.
        /// </summary>
        public int Inventory { get; protected set; }

        /// <summary>
        /// Wie weit die Ameise sehen kann.
        /// </summary>
        public int ViewRange { get; protected set; }

        /// <summary>
        /// Lebenspunkte der Ameisen.
        /// </summary>
        public int Health { get; protected set; }

        /// <summary>
        /// Wie weit die Ameise gehen kann. 
        /// </summary>
        public int MoveRange { get; protected set; }

        internal Player Owner { get; private set; }
        internal IAIAnt AI { get; set; }
        internal Board board;
        private Base Base;

        internal Ant(Board board, Player owner, int viewRange, int maxInventory, int moveRangeFactor, int hp)
        {
            ViewRange = viewRange;
            MaxInventory = maxInventory;
            this.board = board;
            this.UnitsGone = 0;
            Owner = owner;
            Inventory = 0;
            MoveRangeFactor = moveRangeFactor;
            MoveRange = MoveRangeFactor * board.Diagonal;
            Health = hp;
            TookAction = false;
        }

        /// <summary>
        /// Lässt die Ameise nach links bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveLeft()
        {
            Coordinates newCoords = new Coordinates(Coords.X - 1, Coords.Y);
            return move(newCoords);
        }
        /// <summary>
        /// Lässt die Ameise diagonal nach links oben bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveUpperLeft()
        {
            Coordinates newCoords = new Coordinates(Coords.X - 1, Coords.Y - 1);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise diagonal nach links unten bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveLowerLeft()
        {
            Coordinates newCoords = new Coordinates(Coords.X - 1, Coords.Y + 1);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise nach rechts bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveRight()
        {
            Coordinates newCoords = new Coordinates(Coords.X + 1, Coords.Y);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise diagonal nach rechts oben bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveUpperRight()
        {
            Coordinates newCoords = new Coordinates(Coords.X + 1, Coords.Y - 1);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise diagonal nach rechts unten bewegen.
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist.</returns>
        public bool moveLowerRight()
        {
            Coordinates newCoords = new Coordinates(Coords.X + 1, Coords.Y + 1);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise nach oben bewegen
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist</returns>
        public bool moveUp()
        {
            Coordinates newCoords = new Coordinates(Coords.X, Coords.Y - 1);
            return move(newCoords);
        }

        /// <summary>
        /// Lässt die Ameise nach unten bewegen
        /// </summary>
        /// <returns>true wenn das Bewegen erfolgreich war, false wenn etwas im Weg ist</returns>
        public bool moveDown()
        {
            Coordinates newCoords = new Coordinates(Coords.X, Coords.Y + 1);
            return move(newCoords);
        }

        private bool move(Coordinates to)
        {
            if (!canMove())
            {
                die();
            }
            else if (!TookAction && board.BoardObjects.move(this, to))
            {
                TookAction = true;
                UnitsGone++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Prüfen, ob die Ameise sich noch bewegen kann.
        /// </summary>
        /// <returns>True wenn ja, False wenn nicht</returns>
        public bool canMove()
        {
            if (UnitsGone >= MoveRange)
                return false;
            return true;
        }

        /// <summary>
        /// Zucker aufnehmen. Die Ameise muss auf dem Zucker stehen.
        /// </summary>
        /// <returns>True bei Erfolg, false wenn kein Zucker gefunden wurde.</returns>
        public bool pickUpSugar()
        {
            Sugar sugar;

            if (board.BoardObjects.getSugar(Coords, out sugar) && Inventory < MaxInventory)
            {
                int tempSugarAmount = sugar.Amount;
                int maxPickUpSugar = MaxInventory - Inventory;

                if (sugar.Amount - maxPickUpSugar <= 0)
                {
                    // Zucker bei 0 entfernen
                    sugar.Amount = 0;
                    board.BoardObjects.remove(sugar);
                }
                else
                {
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
        public bool dropSugarOnBase()
        {
            if (!TookAction && isInBase())
            {
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
        public bool restore()
        {
            if (!TookAction && isInBase())
            {
                // 0.2 kann später durch den bestimmten oder aufgewerteten Prozentsatz der Base ersetzt werden.
                UnitsGone = Convert.ToInt32(Math.Ceiling(UnitsGone * (1 - 0.2)));
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
        public bool eatSugar()
        {
            if (!TookAction && Inventory > 0)
            {
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
        public bool isInBase()
        {
            int range = getBase().Range;
            return Coords.isInRange(range, getBaseCoords());
        }

        private Base getBase()
        {
            if(Base == null)
            {
                Base = board.BoardObjects.getBase(Owner);
            }
            return Base;
        }

        /// <summary>
        /// Die Ameise am Ende des Zuges sterben lassen.
        /// </summary>
        public void die()
        {
            if(!board.DyingAnts.Contains(this))
                board.DyingAnts.Add(this);

            Owner.decreaseAnts(this);
        }

        /// Gibt die Koordinaten von der zugehörigen Base zurück.
        /// </summary>
        /// <returns>Die Koordinaten von der Base</returns>
        public Coordinates getBaseCoords()
        {
            return getBase().Coords;
        }
    }

}
