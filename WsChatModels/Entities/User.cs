using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WsChatModels.Entities
{
    [Serializable]
    public class User
    {
        public long id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public string position { get; set; }
    }
}
