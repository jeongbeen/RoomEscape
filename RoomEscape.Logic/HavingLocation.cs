using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomEscape.Logic
{
    public class HavingLocation
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }
        public float Range { get; private set; }

        public HavingLocation(float x,float y,float z,float r)
        {
            X = x;
            Y = y;
            Z = z;
            Range = r;
        }
    }
}
