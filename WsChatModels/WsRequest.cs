using System;
using System.Collections.Generic;
using System.Text;

namespace WsChatModels
{
    public enum WsRequestType { Auth, Register, User, Chatroom }


    [Serializable]
    public class WsRequest
    {
        public string userId;
        public WsRequestType type;

        public WsRequest(WsRequestType type, string userId = "")
        {
            this.userId = userId;
            this.type = type;
        }
    }
}
