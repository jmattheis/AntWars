using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board
{
    /// <summary>
    /// Stellt die x und y coordinate vom board dar.
    /// </summary>
    class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates() { }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Coordinates p = obj as Coordinates;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (X == p.X) && (Y == p.Y);
        }

        public bool Equals(Coordinates coords)
        {
            if ((object)coords == null)
            {
                return false;
            }

            return (X == coords.X) && (Y == coords.Y);
        }

        public override int GetHashCode()
        {
            return X ^ Y;
        }

        public Coordinates clone()
        {
            return new Coordinates(X, Y);
        }
    }
}
