using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademChatAPI.Entities
{
    [Serializable]
    public class Message
    {
        [Required]
        public long id { get; set; }

        [Required]
        public long user_id { get; set; }

        [ForeignKey("user_id")]
        public User User { get; set; }

        public long to_user_id { get; set; }

        [ForeignKey("to_user_id")]
        public User to_user { get; set; }

        public long chat_room_id { get; set; }

        [ForeignKey("chat_room_id")]
        public ChatRoom ChatRoom { get; set; }

        public int? message_num { get; set; }

        public string text { get; set; }

        public DateTime time_stamp { get; set; }
    }
}
