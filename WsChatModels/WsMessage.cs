using System;
using System.Collections.Generic;

namespace WsChatModels
{
    [Serializable]
    public enum WsMessageType
    {
        System, Chat, AuthRequest, AuthGrant,
        Request,  User, Users, Message, Messages, ChatGroup, ChatGroups
    }

    [Serializable]
    public class WsMessage
    {
        public WsMessageType type;
        public string data;
        public long? fromUserId;

        public Dictionary<string, string> parameters = new Dictionary<string, string>();

        public WsMessage() { }

        public WsMessage(long? fromUserId, WsMessageType type, string data)
        {
            this.fromUserId = fromUserId;
            this.type = type;
            this.data = data;
        }
    }
}
