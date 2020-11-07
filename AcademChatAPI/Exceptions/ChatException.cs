using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademChatAPI.Exceptions
{
    public class ChatException : Exception
    {
        public ChatException(string message) : base(message) { }
    }
}
