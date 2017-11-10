using Photon.Hive.Plugin;
using System;
using System.Collections.Generic;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      11/9/2017 3:46:07 PM
*  @Description:    
* ==============================================================================
*/
namespace Games
{
    public partial class Loger
    {
        public static string TagPlugin = "ZFCustomPlugin";

        private static IPluginHost gameHost;
        public static void Install(IPluginHost gameHost)
        {
            Loger.gameHost = gameHost;
        }

        public static void Log(object message)
        {
            gameHost.LogInfo(message);
        }

        public static void LogFormat(string format, params object[] args)
        {
            gameHost.LogInfo(string.Format(format, args));
        }


        public static void LogError(object message)
        {
            gameHost.LogError(message);
        }


        public static void LogErrorFormat(string format, params object[] args)
        {
            gameHost.LogError(string.Format(format, args));
        }


        public static void LogFatal(object message)
        {
            gameHost.LogFatal(message);
        }


        public static void LogFatalFormat(string format, params object[] args)
        {
            gameHost.LogFatal(string.Format(format, args));
        }


        public static void LogWarning(object message)
        {
            gameHost.LogWarning(message);
        }


        public static void LogWarninglFormat(string format, params object[] args)
        {
            gameHost.LogWarning(string.Format(format, args));
        }


        public static void LogDebug(object message)
        {
            gameHost.LogDebug(message);
        }


        public static void LogDebugFormat(string format, params object[] args)
        {
            gameHost.LogDebug(string.Format(format, args));
        }



        public static void LogTag(object tag, object message)
        {
            gameHost.LogInfo(string.Format("{0} {1}", tag, message));
        }

        public static void LogTagFormat(object tag, string format, params object[] args)
        {
            gameHost.LogInfo(string.Format("{0} {1}", tag, string.Format(format, args)));
        }

        public static void LogTagError(object tag, object message)
        {
            gameHost.LogError(string.Format("{0} {1}", tag, message));
        }
        public static void LogTagErrorFormat(object tag, string format, params object[] args)
        {
            gameHost.LogError(string.Format("{0} {1}", tag, string.Format(format, args)));
        }

        public static void LogTagWarning(object tag, object message)
        {
            gameHost.LogWarning(string.Format("{0} {1}", tag, message));
        }
        public static void LogTagWarningFormat(object tag, string format, params object[] args)
        {
            gameHost.LogWarning(string.Format("{0} {1}", tag, string.Format(format, args)));
        }

        public static void LogDictionary<Tk, Tv>(string name, Dictionary<Tk, Tv> dict)
        {
            foreach (var kvp in dict)
            {
                Loger.LogTagFormat(Loger.TagPlugin, string.Format("{0}[{1}] = {2}", name, kvp.Key, kvp.Value));
            }
        }

    }
}
