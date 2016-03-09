using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AntWars.Exception;
using AntWars.Board;
using AntWars.Board.Ants;

namespace AntWars.AI
{
    /// <summary>
    /// Diese Klasse läd die DLL und initialisiert AIAnt und AI instancen.
    /// </summary>
    class AILoader
    {
        private static String CLASS_PLAYERAI = "PlayerAI.AI";
        private static String CLASS_ANTAI = "PlayerAI.AIAnt";

        private Type playerAI;
        private Type antAI;

        /// <summary>
        /// Initialisiert den loader.
        /// </summary>
        /// <param name="path">Der Pfad zu der DLL.</param>
        public AILoader(String path)
        {
            Assembly DLL = null;
            try
            {
                DLL = Assembly.LoadFile(path);
                playerAI = DLL.GetType(CLASS_PLAYERAI);
                antAI = DLL.GetType(CLASS_ANTAI);
            }
            catch (System.Exception)
            {
                throw new InvalidDLLFileException();
            }
            if (antAI == null || playerAI == null || 
                playerAI.BaseType != typeof(AIBase) || antAI.BaseType != typeof(AIAntBase))
            {
                throw new InvalidDLLFileException();
            }
        }

        /// <summary>
        /// Erstellt eine neue AI instance und setzt die game und player property.
        /// </summary>
        /// <param name="game">Das game</param>
        /// <param name="player">Der player</param>
        /// <returns>Die AI instance</returns>
        public IAI createAIInstance(Game game, Player player)
        {
            try
            {
                AIBase obj = (AIBase)Activator.CreateInstance(playerAI);
                obj.Game = game;
                obj.Player = player;
                return obj;
            }
            catch (System.Exception)
            {
                throw new InvalidDLLFileException();
            }

        }

        /// <summary>
        /// Erstellt eine neue AIAnt instance und setzt die zugewiesene Ameise und conf property.
        /// </summary>
        /// <param name="ant">Die Ameise</param>
        /// <param name="conf">Die Gameconfig</param>
        /// <returns>die AIANt instance</returns>
        public IAIAnt createAIAntInstance(Ant ant, Config.GameConfig conf)
        {
            try
            {
                AIAntBase obj = (AIAntBase)Activator.CreateInstance(antAI);
                obj.Ant = ant;
                obj.Conf = conf;
                return obj;
            }
            catch (System.Exception)
            {
                throw new InvalidDLLFileException();
            }
        }

    }
}
