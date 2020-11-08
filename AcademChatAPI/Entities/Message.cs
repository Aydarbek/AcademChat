using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WsChatModels;

namespace AcademChatAPI.Entities
{
    [Serializable]
    public class Message
    {
        [Required]
        public long id { get; set; }

        public WsMessageType type { get; set; }

        public string data { get; set; }

        [Required]
        public long? user_id { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }

        public long? to_user_id { get; set; }

        [ForeignKey("to_user_id")]
        public User To_User { get; set; }

        public DateTime time_stamp { get; set; }

        [NotMapped]
        public Dictionary<string, string> parameters { get; set; }

    }
}
