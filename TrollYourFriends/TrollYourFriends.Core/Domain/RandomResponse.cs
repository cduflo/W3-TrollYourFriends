using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollYourFriends.Core.Domain
{
    public class RandomResponse
    {
        public string type { get; set; }
        public RVal value { get; set; }
    }

    public class RVal
    {
        public string id { get; set; }
        public string joke { get; set; }
    }

}

