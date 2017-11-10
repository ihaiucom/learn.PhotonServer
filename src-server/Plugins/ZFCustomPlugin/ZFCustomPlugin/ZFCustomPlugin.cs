using Newtonsoft.Json;
using Photon.Hive.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class ZFCustomPlugin : PluginBase
    {
        public override string Name
        {
            get
            {
                return "ZFCustomPlugin";
            }
        }

        public override void OnCreateGame(ICreateGameCallInfo info)
        {
            Loger.LogTagFormat(Loger.TagPlugin, "OnCreateGame===============BEGIN");
            Loger.LogTagFormat(Loger.TagPlugin,  info.ToStr());
          

            base.OnCreateGame(info);
            Loger.LogTagFormat(Loger.TagPlugin, "OnCreateGame---------------END");
        }

        public override void BeforeJoin(IBeforeJoinGameCallInfo info)
        {
            Loger.LogTagFormat(Loger.TagPlugin, "BeforeJoin===============BEGIN");
            Loger.LogTagFormat(Loger.TagPlugin, info.ToStr());
            base.BeforeJoin(info);
            Loger.LogTagFormat(Loger.TagPlugin, "BeforeJoin---------------END");
        }

        public override void OnJoin(IJoinGameCallInfo info)
        {
            Loger.LogTagFormat(Loger.TagPlugin, "OnJoin===============BEGIN");
            Loger.LogTagFormat(Loger.TagPlugin, info.ToStr());

            base.OnJoin(info);
            Loger.LogTagFormat(Loger.TagPlugin, "OnJoin---------------END");
        }

        public override void OnLeave(ILeaveGameCallInfo info)
        {
            Loger.LogTagFormat(Loger.TagPlugin, "OnLeave===============BEGIN");
            Loger.LogTagFormat(Loger.TagPlugin, info.ToStr());

            base.OnLeave(info);
            Loger.LogTagFormat(Loger.TagPlugin, "OnLeave---------------END");
        }

        public override void OnRaiseEvent(IRaiseEventCallInfo info)
        {
            Loger.LogTagFormat(Loger.TagPlugin, "OnRaiseEvent===============BEGIN");
            Loger.LogTagFormat(Loger.TagPlugin, info.ToStr());

            base.OnRaiseEvent(info);
            Loger.LogTagFormat(Loger.TagPlugin, "OnRaiseEvent---------------END");
        }

        public override void BeforeSetProperties(IBeforeSetPropertiesCallInfo info)
        {
            Loger.LogTagFormat(Loger.TagPlugin, "BeforeSetProperties===============BEGIN");
            Loger.LogTagFormat(Loger.TagPlugin, info.ToStr());

            base.BeforeSetProperties(info);
            Loger.LogTagFormat(Loger.TagPlugin, "BeforeSetProperties---------------END");
        }

        public override void OnSetProperties(ISetPropertiesCallInfo info)
        {
            Loger.LogTagFormat(Loger.TagPlugin, "OnSetProperties===============BEGIN");
            Loger.LogTagFormat(Loger.TagPlugin, info.ToStr());

            base.OnSetProperties(info);
            Loger.LogTagFormat(Loger.TagPlugin, "OnSetProperties---------------END");
        }

        public override void OnSetPropertiesFailed(ISetPropertiesFailedCallInfo info)
        {
            Loger.LogTagFormat(Loger.TagPlugin, "OnSetPropertiesFailed===============BEGIN");
            Loger.LogTagFormat(Loger.TagPlugin, info.ToStr());

            base.OnSetPropertiesFailed(info);
            Loger.LogTagFormat(Loger.TagPlugin, "OnSetPropertiesFailed---------------END");
        }

        public override void OnCloseGame(ICloseGameCallInfo info)
        {
            Loger.LogTagFormat(Loger.TagPlugin, "OnCloseGame===============BEGIN");
            Loger.LogTagFormat(Loger.TagPlugin, info.ToStr());

            base.OnCloseGame(info);
            Loger.LogTagFormat(Loger.TagPlugin, "OnCloseGame---------------END");
        }
    }
}
