using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomEscape.Logic
{
    public class Cube : Item
    {
        public Cube(int cubeNum,float x, float y, float z,float r) : base(x, y, z, r)
        {
            CubeNum = cubeNum;
        }

        public int CubeNum { get; set; }
    }
}
