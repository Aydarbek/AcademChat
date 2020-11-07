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
        public User To_User { get; set; }

        public string text { get; set; }

        public DateTime time_stamp { get; set; }
    }
}
