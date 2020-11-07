using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WsChatModels;
using WsChatModels.Entities;

namespace ChatClient
{
    class WsClient
    {
        internal void WsAutenticate(string userName, string password)
        {
            WsRequest authRequest = new WsRequest(WsRequestType.Auth);
        }

        

    }
}
