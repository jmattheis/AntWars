using System;
namespace AntWars.AI {

    /// <summary>
    /// Das interface für die AI.
    /// </summary>
    interface IAI {

        /// <summary>
        /// Wird in jedem Tick einmal aufgerufen.
        /// </summary>
        void nextTick();

        String Playername { get; }
    }
}
