using System;
using System.Collections.Generic;

namespace WsChatModels
{
    [Serializable]
    public enum WsMessageType
    {
        System, Chat, Status, AuthRequest, AuthGrant,
        User, Users, Message, Messages
    }

    [Serializable]
    public class Message
    {
        public WsMessageType type;
        public virtual string data { get; set; }
        public virtual long? user_id { get; set; }
        public long? to_user_id { get; set; }
        public virtual User User { get; set; }
        public virtual DateTime time_stamp { get; set; }

        public virtual Dictionary<string, string> parameters { get; set; } = new Dictionary<string, string>();

        public Message() { }

        public Message(long? user_id, WsMessageType type, string data)
        {
            this.user_id = user_id;
            this.type = type;
            this.data = data;
        }
    }
}
