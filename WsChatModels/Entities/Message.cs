using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WsChatModels.Entities
{
    [Serializable]
    public class Message
    {
        public long id { get; set; }
        public long? to_user_id { get; set; }
        public string text { get; set; }
        public DateTime time_stamp { get; set; }
    }
}
