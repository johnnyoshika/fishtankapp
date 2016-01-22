using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishTankApp.Models
{
    public class IntHistory
    {
        public IntHistory(DateTime timeStamp, int value)
        {
            TimeStamp = timeStamp;
            Value = value;
        }

        public DateTime TimeStamp { get; }
        public int Value { get; }
    }
}
