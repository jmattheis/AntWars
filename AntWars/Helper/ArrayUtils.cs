using AntWars.Board;
using System;

namespace AntWars.Helper {
    static class ArrayUtils {

        /// <summary>
        /// Fügt 2 BoardObject-Array's zusammen.
        /// </summary>
        public static void merge(ref BoardObject[] array, BoardObject[] toAdd) {
            int array1OriginalLength = array.Length;
            Array.Resize<BoardObject>(ref array, array1OriginalLength + toAdd.Length);
            Array.Copy(toAdd, 0, array, array1OriginalLength, toAdd.Length);
        }

        /// <summary>
        /// Fügt ein BoardObject zu einem BoardObject array hinzu.
        /// </summary>
        public static void add(ref BoardObject[] array, BoardObject toAdd) {
            Array.Resize<BoardObject>(ref array, array.Length + 1);
            array[array.Length - 1] = toAdd;
        }

        /// <summary>
        /// Entfernt das Boardobject vom Array und passt die Größe an.
        /// </summary>
        public static void remove(ref BoardObject[] objs, BoardObject toRemove) {
            for (int i = 0;i < objs.Length;i++) {
                if (objs[i] == toRemove) {
                    objs[i] = null;
                    if (i != objs.Length - 1) {
                        BoardObject tmp = objs[objs.Length - 1];
                        objs[i] = tmp;
                    }
                }
            }
            Array.Resize<BoardObject>(ref objs, objs.Length - 1);
        }
    }
}
