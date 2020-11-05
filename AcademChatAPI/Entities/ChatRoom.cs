using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AcademChatAPI.Entities
{
    [Serializable]
    public class ChatRoom
    {
        [Required]
        public long id { get; set; }
        public string name { get; set; }

        [NotMapped]
        public List<User> Users { get; set; }
        public List<Message> Messages { get; set; }
    }
}
