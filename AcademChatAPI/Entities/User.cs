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
    public class User
    {
        [Required]
        public long id { get; set; }

        [Required]
        [StringLength(10)]
        public string name { get; set; }

        [StringLength (30)]
        public string status { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        [StringLength(32)]
        public virtual string secret { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        [NotMapped]
        public virtual string password
        {
            get { return EncryptionHelper.Decrypt(secret); }
            set { secret = EncryptionHelper.Encrypt(value); }
        }

        [StringLength(30)]
        public string position { get; set; }
    }
}
