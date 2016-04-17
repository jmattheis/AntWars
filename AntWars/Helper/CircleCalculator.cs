using AntWars.Board;
using System;
using System.Collections.Generic;

namespace AntWars.Helper {

    /// <summary>
    /// Eine Hilfsklasse für die Kreisberechnung.
    /// </summary>
    class CircleCalculator {
        private const int MAX_VIEWRANGE = 20;

        private static Coordinates[][] calculatedPartCircles = new Coordinates[MAX_VIEWRANGE + 1][];

        /// <summary>
        /// Gibt den Teilkreis von der Viewrange zurück
        /// </summary>
        /// <param name="viewRange">Die Sichtweite</param>
        /// <returns>Koordinaten von einem Virtelkreis</returns>
        public static Coordinates[] calculatePartCircle(int viewRange) {
            Coordinates[] partCircle = calculatedPartCircles[viewRange];
            if(partCircle == null) {
                partCircle = calculate(viewRange);
                calculatedPartCircles[viewRange] = partCircle;
            }
            return partCircle;
        }

        private static Coordinates[] calculate(int viewRange) {
            // this generates the upper left quarter from the circle
            // for generating the whole circle add the viewrange to boxMaxX and boxMaxY
            int boxMinX = 0 - viewRange;
            int boxMinY = 0 - viewRange;
            int boxMaxX = 0;
            int boxMaxY = 0;
            List<Coordinates> coordinatesInsideView = new List<Coordinates>();
            for (int x = boxMinX;x <= boxMaxX;x++) {
                for (int y = boxMinY;y <= boxMaxY;y++) {
                    double abstand = Math.Pow(0 - x, 2) + Math.Pow(0 - y, 2);
                    if (abstand <= Math.Pow(viewRange, 2)) {
                        coordinatesInsideView.Add(new Coordinates(x, y));
                    }
                }
            }
            return coordinatesInsideView.ToArray();
        }
    }
}
