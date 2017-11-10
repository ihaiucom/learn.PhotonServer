using Photon.SocketServer;
using System;
using System.Collections.Generic;
using PhotonHostRuntimeInterfaces;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      11/9/2017 9:41:29 AM
*  @Description:    
* ==============================================================================
*/
namespace Games
{
    public class ChatPeer : ClientPeer
    {
        private static event Action<ChatPeer, EventData, SendParameters> BroadcastMessage;
        public ChatPeer(InitRequest initRequest) : base(initRequest)
        {
            BroadcastMessage += OnBroadcastMessage;
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            Loger.Log("玩家离开");
            BroadcastMessage -= OnBroadcastMessage;
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            Loger.Log("收到玩家消息 OperationCode=" + operationRequest.OperationCode + " content=" + operationRequest.Parameters[(byte)ChatMsgParameterKey.Content]);
            if (operationRequest.OperationCode == (byte)ChatOp.Msg) // Chat Custom Operation Code = 1
            {
                // broadcast chat custom event to other peers
                var eventData = new EventData((byte)ChatOp.Msg) { Parameters = operationRequest.Parameters }; // Chat Custom Event Code = 1
                BroadcastMessage(this, eventData, sendParameters);
                // send operation response (~ACK) back to peer
                var response = new OperationResponse(operationRequest.OperationCode);
                response.Parameters = operationRequest.Parameters;
                SendOperationResponse(response, sendParameters);
            }
        }



        private void OnBroadcastMessage(ChatPeer peer, EventData eventData, SendParameters sendParameters)
        {
            if (peer != this) // do not send chat custom event to peer who called the chat custom operation 
            {
                SendEvent(eventData, sendParameters);
            }
        }


    }
}
