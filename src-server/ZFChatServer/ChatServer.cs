using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class ChatServer : ApplicationBase
    {
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            Loger.Log("创建CreatePeer:" + DateTime.Now);
            ChatPeer peer = new ChatPeer(initRequest);
            return peer;
        }

        protected override void Setup()
        {
            // log4net
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
            string path = Path.Combine(this.BinaryPath, "log4net.config");
            var file = new FileInfo(path);
            if (file.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                XmlConfigurator.ConfigureAndWatch(file);
            }

            Loger.Log("服务器启动:" + DateTime.Now);
        }

        protected override void TearDown()
        {
            Loger.Log("服务器关闭:" + DateTime.Now);
        }
    }
}
