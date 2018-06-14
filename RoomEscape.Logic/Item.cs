using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomEscape.Logic
{
    public class Item : HavingLocation
    {
        public string Name { get; private set; } //필요한가?
        //public float X { get; set; }
        //public float Y { get; set; }
        //public float Z { get; set; }
        //public float Range { get; private set; }

        public Item(string name, float x, float y, float z, float r) : this(x, y, z, r)
        {
            Name = name;
        }

        public Item(float x, float y, float z, float r) : base(x, y, z, r)
        { }

        public Item() : base(0, 0, 0, 0)
        { }

        public void Move(float x, float y, float z)
        {
            X += x;
            Y += y;
            Z += z;
        }

    }
}
