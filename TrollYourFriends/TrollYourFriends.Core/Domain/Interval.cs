using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollYourFriends.Core.Domain
{
    public class Interval
    {
        public string UOM { get; set; }
        public int multiplier { get; set; }
    }

    public class IntervalList
    {
        public static ObservableCollection<Interval> iList = new ObservableCollection<Interval>
            {
                 new Interval {UOM = "Seconds", multiplier = 1000 },
                 new Interval {UOM = "Minutes", multiplier = 60000 },
                 new Interval {UOM = "Hours", multiplier = 3600000 }
            };
    }


    public static class Quantity
    {
        public static ObservableCollection<int> quantity = new ObservableCollection<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };
    }
}
