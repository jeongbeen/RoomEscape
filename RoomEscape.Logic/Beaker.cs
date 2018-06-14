using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomEscape.Logic
{
    public class Beaker : Item
    {
        public Beaker(int capacity, int liter,float x, float y, float z,float r) : base(x, y, z, r)
        {
            Capacity = capacity;
            Liter = liter;
        }

        public Beaker(int capacity, int liter) : base(0,0,0,3)
        {
            Capacity = capacity;
            Liter = liter;
        }

        public int Capacity { get; private set; }

        public int Liter { get; set; }
    }
}
