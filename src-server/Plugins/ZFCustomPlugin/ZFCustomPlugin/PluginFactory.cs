using Photon.Hive.Plugin;
using System;
using System.Collections.Generic;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      11/8/2017 1:58:57 PM
*  @Description:    
* ==============================================================================
*/
namespace Games
{
    public class PluginFactory : IPluginFactory
    {
        public IGamePlugin Create(
            IPluginHost gameHost, 
            string pluginName, 
            Dictionary<string, string> config, 
            out string errorMsg)
        {
            Loger.Install(gameHost);
            Loger.LogTag(Loger.TagPlugin, "插件工厂创建插件 PluginFactory.Create==================BEGIN");
            Loger.LogTagFormat(Loger.TagPlugin, string.Format("pluginName={0}, config.Count={1}", pluginName, config.Count));
            Loger.LogDictionary<string, string>("config", config);
            Loger.LogTag("PluginFactory IPluginHost" , gameHost.ToStr(false));
            Loger.LogTag(Loger.TagPlugin, "插件工厂创建插件 PluginFactory.Create------------------END");

            ZFCustomPlugin plugin = new ZFCustomPlugin();
            if(plugin.SetupInstance(gameHost, config, out errorMsg))
            {
                return plugin;
            }
            return null;
        }
    }
}
