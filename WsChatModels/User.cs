using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WsChatModels
{
    [Serializable]
    public class User
    {
        public virtual long id { get; set; }
        public virtual string name { get; set; }
        public virtual string status { get; set; }
        public virtual string position { get; set; }
    }
}
