using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AntWars.AIs.Converter.Classes;
using AntWars.Exception;

namespace AntWars.AIs
{
    class AI
    {
        private static String CLASS_PLAYERAI = "PlayerAI.AI";
        private static String METHOD_ANT_TICK = "antTick";
        private static String METHOD_NEXT_TICK = "nextTick";
        private static String PROPERTY_GAME = "Game";
        private static String PROPERTY_PLAYER = "Player";

        private Type playerAI;
        private object instance;

        public AI(String path, Game game, Player player)
        {
            try
            {
                String content = System.IO.File.ReadAllText(path);

                // So there is no real way for detecting the use of reflection,
                // so we searching for the import, that is atleast needed when using the BindingFlag.NonPublic for get/set value for private properties.
                if(content.Contains("System.Reflection"))
                {
                    throw new ReflectionUseException(path);
                }
                Assembly DLL = Assembly.LoadFile(path);
                playerAI = DLL.GetType(CLASS_PLAYERAI);
                instance = Activator.CreateInstance(playerAI);

                setProperty(PROPERTY_PLAYER, player);
                setProperty(PROPERTY_GAME, game);
            } catch(ReflectionUseException e)
            {
                throw e;
            }
            catch (System.Exception e)
            {
                throw new InvalidDLLFileException();
            }
        }

        private void setProperty(string name, object value)
        {
            PropertyInfo playerProperty = playerAI.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            playerProperty.SetValue(instance, value);
        }

        public void antTick(AIAnt ant, List<AIBoardObject> view)
        {
            try
            {
                playerAI.InvokeMember(METHOD_ANT_TICK, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, instance, new Object[] { ant, view });
            }
            catch (System.Exception e)
            {
                throw new InvalidDLLFileException();
            }
        }

        public void nextTick()
        {
            try
            {
                playerAI.InvokeMember(METHOD_NEXT_TICK, BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public, null, instance, new Object[0]);
            }
            catch (System.Exception e)
            {
                throw new InvalidDLLFileException();
            }
        }
    }
}
