using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntWars.Board {

    /// <summary>
    /// Stellt die x und y coordinate vom board dar.
    /// </summary>
    public class Coordinates {
        private volatile int _x;
        private volatile int _y;
        public int X { get { return _x; } private set { _x = value; } }
        public int Y { get { return _y; } private set { _y = value; } }

        public Coordinates(int x, int y) {
            X = x;
            Y = y;
        }

        public override bool Equals(System.Object obj) {
            return Equals(obj as Coordinates);
        }

        public bool Equals(Coordinates coords) {
            return coords != null && X == coords.X && Y == coords.Y;
        }

        public override int GetHashCode() {
            return X ^ Y;
        }

        public bool isInRange(int range, Coordinates c) {
            return Math.Abs(c.X - X) <= range && Math.Abs(c.Y - Y) <= range;
        }

        /// <summary>
        /// Liste von angrenzenden Koordinaten
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public List<Coordinates> getAdjacentCoordinates(int level) {
            List<Coordinates> res = new List<Coordinates>();
            int minX = X - level;
            int maxX = X + level;
            int minY = Y - level;
            int maxY = Y + level;

            for (int x = minX;x <= maxX;x++) {
                for (int y = minY;y <= maxY;y++) {
                    // diese Koordinate überspringen
                    if (x == this.X && y == this.Y)
                        continue;

                    res.Add(new Coordinates(x, y));
                }
            }
            return res.OrderBy(coord => coord.X).ToList();
        }
    }
}
