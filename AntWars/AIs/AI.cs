using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AntWars.Exception;
using AntWars.Board;
using AntWars.Board.Ants;
using System.Security.Permissions;
using System.Collections;
using System.Security;
using System.Security.Policy;
using System.IO;
using System.Runtime.Remoting;

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




                Assembly DLL = Assembly.LoadFile(path);
                
                PermissionSet permSet = new PermissionSet(PermissionState.None);
                permSet.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));

                StrongName fullTrustAssembly = DLL.Evidence.GetHostEvidence<StrongName>();
            AppDomainSetup adSetup = new AppDomainSetup();
                adSetup.ApplicationBase = Path.GetFullPath(path);
                playerAI = DLL.GetType(CLASS_PLAYERAI);
                AppDomain newDomain = AppDomain.CreateDomain("Sandbox", null, adSetup, permSet, fullTrustAssembly);

            

                ObjectHandle handle = Activator.CreateInstanceFrom(
newDomain, DLL.ManifestModule.FullyQualifiedName,
       playerAI.FullName);

                
                instance = handle.Unwrap();

                setProperty(PROPERTY_PLAYER, player);
                setProperty(PROPERTY_GAME, game);
            } catch(ReflectionUseException e)
            {
                throw e;
            }
        }

        private void setProperty(string name, object value)
        {
            PropertyInfo playerProperty = playerAI.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            playerProperty.SetValue(instance, value);
        }

        public void antTick(Ant ant, List<BoardObject> view)
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
