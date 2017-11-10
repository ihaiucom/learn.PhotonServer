using ExitGames.Logging;
using System;
using System.Collections.Generic;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      11/9/2017 2:31:28 PM
*  @Description:    
* ==============================================================================
*/
namespace Games
{
    public class Loger
    {
        public static readonly ILogger log = LogManager.GetCurrentClassLogger();
        
        public static void Log(string msg)
        {
            log.Info(msg);
        }
    }
}
