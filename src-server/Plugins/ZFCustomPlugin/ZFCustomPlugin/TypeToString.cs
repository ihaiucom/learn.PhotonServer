using Newtonsoft.Json;
using Photon.Hive.Plugin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
/** 
* ==============================================================================
*  @Author      	曾峰(zengfeng75@qq.com) 
*  @Web      		http://blog.ihaiu.com
*  @CreateTime      11/9/2017 4:23:29 PM
*  @Description:    
* ==============================================================================
*/
namespace Games
{
    public static class TypeToString
    {


        public static string ToStr<T>(this T[] list, string name)
        {
            StringBuilder builder = new StringBuilder();
            if (list == null)
            {
                builder.AppendLine(string.Format("{0}=null", name));
            }
            else
            {
                builder.AppendLine(string.Format("{0}.Length = {1}", name, list.Length));

                for (int i = 0, count = list.Length; i < count; i++)
                {
                    object item = list[i];
                    builder.AppendLine(string.Format("{0}[{1}] = {2}", name, i, item));
                }
            }
            return builder.ToString();
        }

        public static string ToStr(this ArrayList list, string name)
        {
            StringBuilder builder = new StringBuilder();
            if (list == null)
            {
                builder.AppendLine(string.Format("{0}=null", name));
            }
            else
            {
                builder.AppendLine(string.Format("{0}.Count = {1}", name, list.Count));

                for (int i = 0, count = list.Count; i < count; i++)
                {
                    object item = list[i];
                    builder.AppendLine(string.Format("{0}[{1}] = {2}", name, i, item));
                }
            }
            return builder.ToString();
        }


        public static string ToStr<T>(this List<T> list, string name, Func<T, string> ToStrFun = null)
        {
            StringBuilder builder = new StringBuilder();
            if (list == null)
            {
                builder.AppendLine(string.Format("{0}=null", name));
            }
            else
            {
                builder.AppendLine(string.Format("{0}.Count = {1}", name, list.Count));

                for (int i = 0, count = list.Count; i < count; i ++)
                {
                    T item = list[i];
                    object val = item;
                    if(ToStrFun != null)
                    {
                        val = ToStrFun(item);
                    }
                    builder.AppendLine(string.Format("{0}[{1}] = {2}", name,i, val));
                    CheckVal(val, builder, name + "[" + i + "]");
                }
            }
            return builder.ToString();
        }

        public static string ToStr<Tk, Tv>(this Dictionary<Tk, Tv> dict, string name)
        {
            StringBuilder builder = new StringBuilder();
            if(dict == null)
            {
                builder.AppendLine(string.Format("{0}=null", name));
            }
            else
            {
                builder.AppendLine(string.Format("{0}.Count = {1}", name, dict.Count));

                foreach (var kvp in dict)
                {
                    builder.AppendLine(string.Format("{0}[{1}] = {2}", name, kvp.Key, kvp.Value));
                    CheckVal(kvp.Value, builder, name + "[" + kvp.Key + "]");
                }
            }
            return builder.ToString();
        }



        public static string ToStr(this Hashtable hashtable, string name)
        {
            StringBuilder builder = new StringBuilder();
            if (hashtable == null)
            {
                builder.AppendLine(string.Format("{0}=null", name));
            }
            else
            {
                builder.AppendLine(string.Format("{0}.Count = {1}", name, hashtable.Count));

                foreach(var key in hashtable.Keys)
                {
                    builder.AppendLine(string.Format("{0}[{1}] = {2}", name, key, hashtable[key]));
                    CheckVal(hashtable[key], builder, name + "[" + key + "]");
                }
            }

            return builder.ToString();
        }

        public static void CheckVal(object val, StringBuilder builder, string name)
        {
            if(val is Hashtable)
            {
                builder.AppendLine(((Hashtable)val).ToStr(name));
            }
            else if (val is IDictionary)
            {
                builder.AppendLine(((Dictionary<object, object>)val).ToStr(name));
            }
            else if(val is IList)
            {
                if(val is string[])
                {
                    builder.AppendLine(((string[]) val).ToStr(name));
                }
                else if(val is int[])
                {
                    builder.AppendLine(((int[])val).ToStr(name));
                }
                else if (val is byte[])
                {
                    builder.AppendLine(((byte[])val).ToStr(name));
                }
                else if (val is long[])
                {
                    builder.AppendLine(((long[])val).ToStr(name));
                }
                else if (val is float[])
                {
                    builder.AppendLine(((float[])val).ToStr(name));
                }
                else if (val is double[])
                {
                    builder.AppendLine(((double[])val).ToStr(name));
                }
                else if(val is List<byte>)
                {
                    builder.AppendLine(((List<byte>)val).ToStr(name));
                }
                else if (val is List<string>)
                {
                    builder.AppendLine(((List<string>)val).ToStr(name));
                }
                else if (val is List<int>)
                {
                    builder.AppendLine(((List<int>)val).ToStr(name));
                }
                else if (val is List<long>)
                {
                    builder.AppendLine(((List<long>)val).ToStr(name));
                }
                else if (val is List<float>)
                {
                    builder.AppendLine(((List<float>)val).ToStr(name));
                }
                else if (val is List<double>)
                {
                    builder.AppendLine(((List<double>)val).ToStr(name));
                }

               
            }
        }

        public static string ToStr(this Version version, string name)
        {
            StringBuilder builder = new StringBuilder();
            if (version == null)
            {
                builder.AppendLine(string.Format("{0}=null", name));
            }
            else
            {
                builder.AppendLine(string.Format("{0}: {1}", name, version));
            }

            return builder.ToString();
        }

            
        public static string ToStr(this EnvironmentVersion version)
        {
            StringBuilder builder = new StringBuilder();
            if (version == null)
            {
                builder.AppendLine(string.Format("EnvironmentVersion=null"));
            }
            else
            {
                builder.AppendLine(version.BuiltWithVersion.ToStr("EnvironmentVersion.BuiltWithVersion"));

                builder.AppendLine(version.HostVersion.ToStr("EnvironmentVersion.HostVersion"));

            }

            return builder.ToString();
        }

        public static string ToStr(SerializableActor info)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(string.Format("SerializableActor.ActorNr={0}", info.ActorNr));
            builder.AppendLine(string.Format("SerializableActor.IsActive={0}", info.IsActive));
            builder.AppendLine(string.Format("SerializableActor.Nickname={0}", info.Nickname));
            builder.AppendLine(string.Format("SerializableActor.UserId={0}", info.UserId));
            builder.AppendLine(string.Format("SerializableActor.Binary={0}", info.Binary));
            builder.AppendLine(string.Format("SerializableActor.DeactivationTime={0}", info.DeactivationTime));
            builder.AppendLine( info.DEBUG_BINARY.ToStr<byte, object>("SerializableActor.DEBUG_BINARY"));

            
            return builder.ToString();
        }

        public static string ToStr(this SerializableGameState info)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(string.Format("SerializableGameState.ActorCounter={0}", info.ActorCounter));
            builder.AppendLine(string.Format("SerializableGameState.CheckUserOnJoin={0}", info.CheckUserOnJoin));
            builder.AppendLine(string.Format("SerializableGameState.DeleteCacheOnLeave={0}", info.DeleteCacheOnLeave));
            builder.AppendLine(string.Format("SerializableGameState.EmptyRoomTTL={0}", info.EmptyRoomTTL));
            builder.AppendLine(string.Format("SerializableGameState.IsOpen={0}", info.IsOpen));
            builder.AppendLine(string.Format("SerializableGameState.IsVisible={0}", info.IsVisible));
            builder.AppendLine(string.Format("SerializableGameState.LobbyId={0}", info.LobbyId));
            builder.AppendLine(string.Format("SerializableGameState.LobbyType={0}", info.LobbyType));
            builder.AppendLine(string.Format("SerializableGameState.MaxPlayers={0}", info.MaxPlayers));
            builder.AppendLine(string.Format("SerializableGameState.PlayerTTL={0}", info.PlayerTTL));
            builder.AppendLine(string.Format("SerializableGameState.PublishUserId={0}", info.PublishUserId));
            builder.AppendLine(string.Format("SerializableGameState.Slice={0}", info.Slice));
            builder.AppendLine(string.Format("SerializableGameState.SuppressRoomEvents={0}", info.SuppressRoomEvents));
            builder.AppendLine(info.ActorList.ToStr<SerializableActor>("SerializableGameState.ActorList", ToStr));
            builder.AppendLine(info.Binary.ToStr<string, object>("SerializableGameState.Binary"));
            builder.AppendLine(info.CustomProperties.ToStr<string, object>("SerializableGameState.CustomProperties"));
            builder.AppendLine(info.DebugInfo.ToStr<string, object>("SerializableGameState.DebugInfo"));
            builder.AppendLine(info.ExcludedActors.ToStr<ExcludedActorInfo>("SerializableGameState.ExcludedActors", ToStr));
            builder.AppendLine(info.ExpectedUsers.ToStr("SerializableGameState.ExpectedUsers"));
            builder.AppendLine(info.LobbyProperties.ToStr("SerializableGameState.LobbyProperties"));
            

            return builder.ToString();
        }

        public static string ToStr(this ExcludedActorInfo state)
        {
            StringBuilder builder = new StringBuilder();
            if (state == null)
            {
                builder.AppendLine(string.Format("ExcludedActorInfo=null"));
            }
            else
            {
                builder.AppendLine(string.Format("ExcludedActorInfo.UserId={0}", state.UserId));
                builder.AppendLine(string.Format("ExcludedActorInfo.Reason={0}", state.Reason));
            }

            return builder.ToString();
        }



        public static string ToStr(this IJoinGameRequest info, bool isFromOp = true)
        {
            StringBuilder builder = new StringBuilder();
            if (info == null)
            {
                builder.AppendLine(string.Format("IJoinGameRequest=null"));
            }
            else
            {
                if (!isFromOp)  ToStr((IOperationRequest)info, true);
                builder.AppendLine(string.Format("IJoinGameRequest.ActorNr={0}", info.ActorNr));
                builder.AppendLine(string.Format("IJoinGameRequest.GameId={0}", info.GameId));
                builder.AppendLine(string.Format("IJoinGameRequest.BroadcastActorProperties={0}", info.BroadcastActorProperties));
                builder.AppendLine(string.Format("IJoinGameRequest.CreateIfNotExists={0}", info.CreateIfNotExists));
                builder.AppendLine(string.Format("IJoinGameRequest.EmptyRoomLiveTime={0}", info.EmptyRoomLiveTime));
                builder.AppendLine(string.Format("IJoinGameRequest.JoinMode={0}", info.JoinMode));
                builder.AppendLine(string.Format("IJoinGameRequest.LobbyName={0}", info.LobbyName));
                builder.AppendLine(string.Format("IJoinGameRequest.SuppressRoomEvents={0}", info.SuppressRoomEvents));
                builder.AppendLine(info.ActorProperties.ToStr("IJoinGameRequest.ActorProperties"));
                builder.AppendLine(info.GameProperties.ToStr("IJoinGameRequest.GameProperties"));
            }

            return builder.ToString();
        }



        public static string ToStr(this ILeaveGameRequest info, bool isFromOp = true)
        {
            StringBuilder builder = new StringBuilder();
            if (info == null)
            {
                builder.AppendLine(string.Format("ILeaveGameRequest=null"));
            }
            else
            {
                if (!isFromOp) ToStr((IOperationRequest)info, true);
                builder.AppendLine(string.Format("ILeaveGameRequest.IsCommingBack={0}", info.IsCommingBack));
            }

            return builder.ToString();
        }


        public static string ToStr(this IRaiseEventRequest info, bool isFromOp = true)
        {
            StringBuilder builder = new StringBuilder();
            if (info == null)
            {
                builder.AppendLine(string.Format("IRaiseEventRequest=null"));
            }
            else
            {
                if (!isFromOp) ToStr((IOperationRequest)info, true);
                builder.AppendLine(string.Format("IRaiseEventRequest.Cache={0}", info.Cache));
                builder.AppendLine(string.Format("IRaiseEventRequest.CacheSliceIndex={0}", info.CacheSliceIndex));
                builder.AppendLine(string.Format("IRaiseEventRequest.Data={0}", info.Data));
                builder.AppendLine(string.Format("IRaiseEventRequest.EvCode={0}", info.EvCode));
                builder.AppendLine(string.Format("IRaiseEventRequest.GameId={0}", info.GameId));
                builder.AppendLine(string.Format("IRaiseEventRequest.Group={0}", info.Group));
                builder.AppendLine(string.Format("IRaiseEventRequest.HttpForward={0}", info.HttpForward));
                builder.AppendLine(string.Format("IRaiseEventRequest.ReceiverGroup={0}", info.ReceiverGroup));
                builder.AppendLine(string.Format(info.Actors.ToStr<int>("IRaiseEventRequest.Actors")));
            }

            return builder.ToString();
        }



        public static string ToStr(this ISetPropertiesRequest info, bool isFromOp = true)
        {
            StringBuilder builder = new StringBuilder();
            if (info == null)
            {
                builder.AppendLine(string.Format("ISetPropertiesRequest=null"));
            }
            else
            {
                if (!isFromOp) ToStr((IOperationRequest)info, true);
                builder.AppendLine(string.Format("ISetPropertiesRequest.ActorNumber={0}", info.ActorNumber));
                builder.AppendLine(string.Format("ISetPropertiesRequest.HttpForward={0}", info.HttpForward));
                builder.AppendLine(string.Format(info.ExpectedValues.ToStr("ISetPropertiesRequest.ExpectedValues")));
                builder.AppendLine(string.Format(info.Properties.ToStr("ISetPropertiesRequest.Properties")));
            }

            return builder.ToString();
        }


        public static string ToStr(this ICloseRequest info, bool isFromOp = true)
        {
            StringBuilder builder = new StringBuilder();
            if (info == null)
            {
                builder.AppendLine(string.Format("ICloseRequest=null"));
            }
            else
            {
                if (!isFromOp) ToStr((IOperationRequest)info, true);
                builder.AppendLine(string.Format("ICloseRequest.EmptyRoomTTL={0}", info.EmptyRoomTTL));
            }

            return builder.ToString();
        }

        public static string ToStr(this IOperationRequest info, bool isForParent = false) 
        {
            StringBuilder builder = new StringBuilder();
            if (info == null)
            {
                builder.AppendLine(string.Format("IOperationRequest=null"));
            }
            else
            {
                builder.AppendLine(string.Format("IOperationRequest.OperationCode={0}", info.OperationCode));
                builder.AppendLine(string.Format("IOperationRequest.WebFlags={0}", info.WebFlags));
                builder.AppendLine(info.Parameters.ToStr<byte, object>("IOperationRequest.Parameters"));

                if(!isForParent)
                {

                    if (info is IJoinGameRequest)
                    {
                        ToStr((IJoinGameRequest) info, true);
                    }



                    if (info is ILeaveGameRequest)
                    {
                        ToStr((ILeaveGameRequest)info, true);
                    }


                    if (info is IRaiseEventRequest)
                    {
                        ToStr((IRaiseEventRequest)info, true);
                    }


                    if (info is ISetPropertiesRequest)
                    {
                        ToStr((ISetPropertiesRequest)info, true);
                    }

                    if (info is ICloseRequest)
                    {
                        ToStr((ICloseRequest)info, true);
                    }
                    

                }
            }

            return builder.ToString();
        }


        public static string ToStr<T>(this ITypedCallInfo<T> info) where T : IOperationRequest
        {
            StringBuilder builder = new StringBuilder();
            if (info == null)
            {
                builder.AppendLine(string.Format("ITypedCallInfo=null"));
            }
            else
            {
                builder.AppendLine(string.Format("ITypedCallInfo.UserId={0}", info.UserId));
                builder.AppendLine(string.Format("ITypedCallInfo.Nickname={0}", info.Nickname));
                builder.AppendLine(info.AuthCookie.ToStr<string, object>("ITypedCallInfo.AuthCookie"));
                builder.AppendLine((info.Request as IOperationRequest).ToStr());
            }

            return builder.ToString();
        }



        public static string ToStr(this ICallInfo info)
        {
            StringBuilder builder = new StringBuilder();
            if (info == null)
            {
                builder.AppendLine(string.Format("ICallInfo=null"));
            }
            else
            {
                builder.AppendLine(string.Format("ICallInfo.Status={0}", info.Status));
                builder.AppendLine(string.Format("ICallInfo.IsNew={0}", info.IsNew));
                builder.AppendLine(string.Format("ICallInfo.IsProcessed={0}", info.IsProcessed));
                builder.AppendLine(string.Format("ICallInfo.IsCanceled={0}", info.IsCanceled));
                builder.AppendLine(string.Format("ICallInfo.IsDeferred={0}", info.IsDeferred));
                builder.AppendLine(string.Format("ICallInfo.IsFailed={0}", info.IsFailed));
                builder.AppendLine(string.Format("ICallInfo.IsSucceeded={0}", info.IsSucceeded));
                builder.AppendLine(info.OperationRequest.ToStr());
            }

            return builder.ToString();
        }


        public static string ToStr(this ProcessJoinParams info)
        {
            StringBuilder builder = new StringBuilder();
            if (info == null)
            {
                builder.AppendLine(string.Format("ProcessJoinParams=null"));
            }
            else
            {
                builder.AppendLine(string.Format("ProcessJoinParams.PublishCache={0}", info.PublishCache));
                builder.AppendLine(string.Format("ProcessJoinParams.PublishJoinEvents={0}", info.PublishJoinEvents));
                builder.AppendLine(info.ResponseExtraParameters.ToStr<byte, object>("ProcessJoinParams.ResponseExtraParameters"));
            }

            return builder.ToString();
        }

        public static string ToStr(this IPluginHost gameHost, bool isPrintMetho = true)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine(string.Format("gameHost.GameId={0}", gameHost.GameId));
            builder.AppendLine(string.Format("gameHost.MasterClientId={0}", gameHost.MasterClientId));

            builder.AppendLine(gameHost.CustomGameProperties.ToStr<string, object>("gameHost.CustomGameProperties"));

            builder.AppendLine(gameHost.Environment.ToStr<string, object>("gameHost.Environment"));

            builder.AppendLine(string.Format("gameHost.GameActors.Count={0}", gameHost.GameActors.Count));

            builder.AppendLine(string.Format("gameHost.GameActorsActive.Count={0}", gameHost.GameActorsActive.Count));

            builder.AppendLine(string.Format("gameHost.GameActorsInactive.Count={0}", gameHost.GameActorsInactive.Count));
            builder.AppendLine(gameHost.GameProperties.ToStr("gameHost.GameProperties"));

            if(isPrintMetho)
            {
                builder.AppendLine(gameHost.GetEnvironmentVersion().ToStr());
                builder.AppendLine(gameHost.GetSerializableGameState().ToStr());
            }

            return builder.ToString();
        }

        

        public static string ToStr(this ICreateGameCallInfo info)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("ICreateGameCallInfo =========== BEGIN");
            builder.AppendLine(string.Format("ICreateGameCallInfo.CreateIfNotExists={0}", info.CreateIfNotExists));
            builder.AppendLine(string.Format("ICreateGameCallInfo.IsJoin={0}", info.IsJoin));
            builder.AppendLine(info.CreateOptions.ToStr<string, object>("ICreateGameCallInfo.CreateOptions"));
            builder.AppendLine(((ITypedCallInfo<IJoinGameRequest>)info).ToStr<IJoinGameRequest>());
            builder.AppendLine(((ICallInfo)info).ToStr());

            builder.AppendLine("ICreateGameCallInfo ----------- END");
            return builder.ToString();
        }


        public static string ToStr(this IBeforeJoinGameCallInfo info)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("IBeforeJoinGameCallInfo =========== BEGIN");
            builder.AppendLine(((ITypedCallInfo<IJoinGameRequest>)info).ToStr<IJoinGameRequest>());
            builder.AppendLine(((ICallInfo)info).ToStr());

            builder.AppendLine("IBeforeJoinGameCallInfo ----------- END");
            return builder.ToString();
        }


        public static string ToStr(this IJoinGameCallInfo info)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("IJoinGameCallInfo =========== BEGIN");
            builder.AppendLine(string.Format("ICreateGameCallInfo.ActorNr={0}", info.ActorNr));
            builder.AppendLine(info.JoinParams.ToStr());
            builder.AppendLine(((ITypedCallInfo<IJoinGameRequest>)info).ToStr<IJoinGameRequest>());
            builder.AppendLine(((ICallInfo)info).ToStr());

            builder.AppendLine("IJoinGameCallInfo ----------- END");
            return builder.ToString();
        }



        public static string ToStr(this ILeaveGameCallInfo info)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("ILeaveGameCallInfo =========== BEGIN");
            builder.AppendLine(string.Format("ILeaveGameCallInfo.ActorNr={0}", info.ActorNr));
            builder.AppendLine(string.Format("ILeaveGameCallInfo.Details={0}", info.Details));
            builder.AppendLine(string.Format("ILeaveGameCallInfo.IsInactive={0}", info.IsInactive));
            builder.AppendLine(string.Format("ILeaveGameCallInfo.Reason={0}", info.Reason));
            builder.AppendLine(((ITypedCallInfo<ILeaveGameRequest>)info).ToStr<ILeaveGameRequest>());
            builder.AppendLine(((ICallInfo)info).ToStr());

            builder.AppendLine("ILeaveGameCallInfo ----------- END");
            return builder.ToString();
        }


        public static string ToStr(this IRaiseEventCallInfo info)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("IRaiseEventCallInfo =========== BEGIN");
            builder.AppendLine(string.Format("IRaiseEventCallInfo.ActorNr={0}", info.ActorNr));
            builder.AppendLine(((ITypedCallInfo<IRaiseEventRequest>)info).ToStr<IRaiseEventRequest>());
            builder.AppendLine(((ICallInfo)info).ToStr());

            builder.AppendLine("IRaiseEventCallInfo ----------- END");
            return builder.ToString();
        }


        public static string ToStr(this IBeforeSetPropertiesCallInfo info)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("IBeforeSetPropertiesCallInfo =========== BEGIN");
            builder.AppendLine(string.Format("IBeforeSetPropertiesCallInfo.ActorNr={0}", info.ActorNr));
            builder.AppendLine(((ITypedCallInfo<ISetPropertiesRequest>)info).ToStr<ISetPropertiesRequest>());
            builder.AppendLine(((ICallInfo)info).ToStr());

            builder.AppendLine("IBeforeSetPropertiesCallInfo ----------- END");
            return builder.ToString();
        }


        public static string ToStr(this ISetPropertiesCallInfo info)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("ISetPropertiesCallInfo =========== BEGIN");
            builder.AppendLine(string.Format("ISetPropertiesCallInfo.ActorNr={0}", info.ActorNr));
            builder.AppendLine(((ITypedCallInfo<ISetPropertiesRequest>)info).ToStr<ISetPropertiesRequest>());
            builder.AppendLine(((ICallInfo)info).ToStr());

            builder.AppendLine("ISetPropertiesCallInfo ----------- END");
            return builder.ToString();
        }

        public static string ToStr(this ISetPropertiesFailedCallInfo info)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("ISetPropertiesFailedCallInfo =========== BEGIN");
            builder.AppendLine(string.Format("ISetPropertiesFailedCallInfo.ActorNr={0}", info.ActorNr));
            builder.AppendLine(((ITypedCallInfo<ISetPropertiesRequest>)info).ToStr<ISetPropertiesRequest>());
            builder.AppendLine(((ICallInfo)info).ToStr());

            builder.AppendLine("ISetPropertiesFailedCallInfo ----------- END");
            return builder.ToString();
        }
        public static string ToStr(this ICloseGameCallInfo info)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("ICloseGameCallInfo =========== BEGIN");
            builder.AppendLine(string.Format("ICloseGameCallInfo.ActorCount={0}", info.ActorCount));
            builder.AppendLine(string.Format("ICloseGameCallInfo.FailedOnCreate={0}", info.FailedOnCreate));
            builder.AppendLine(((ITypedCallInfo<ICloseRequest>)info).ToStr<ICloseRequest>());
            builder.AppendLine(((ICallInfo)info).ToStr());

            builder.AppendLine("ICloseGameCallInfo ----------- END");
            return builder.ToString();
        }

    }
}
