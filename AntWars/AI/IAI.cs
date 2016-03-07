using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AntWars.Board;
using AntWars.Board.Ants;
namespace AntWars.AI
{
    /// <summary>
    /// Das interface für die AI.
    /// </summary>
    interface IAI
    {
        /// <summary>
        /// Wird in jedem Tick einmal aufgerufen.
        /// </summary>
        void nextTick();
    }
}
