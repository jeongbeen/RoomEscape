using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomEscape.Logic
{
    public class Player : HavingLocation
    {
        public bool isStopped { get; private set; }
        public Item playerItem = new Item();

        public Player(float x, float y, float z, float r, bool _isStopped) : base(x, y, z, r)
        {
            isStopped = _isStopped;
        }

        public void Move(float x, float y, float z)
        {
            X += x;
            Y += y;
            Z += z;

            playerItem.Move(x, y, z);
        }

        public void Release()
        {
            if (playerItem.GetType() == typeof(Cube))
                //MagicGame의 gatherCube 실행
                playerItem = null;
        }
        
        public void GripItem(Item item)
        {
            if (isTouched(this, item) && playerItem == null)
                playerItem = item;
            else
                playerItem = null;
        }

        public void GripItem(HavingLocation item)
        {
            if (isTouched(this, item)&&item is Item)
                playerItem = (item as Item);
            else
                playerItem = null;
        }

        public void OpenDoor(Door door)
        {
            if (isTouched(this, door) && door.isRightKey(playerItem.Name))
                door.Open();
        }

        public bool isTouched(Player player, HavingLocation @object) 
        {
            double distance = Math.Sqrt(((X - @object.X) * (player.X - @object.X)) + ((player.Y - @object.Y) * (player.Y - @object.Y)) + ((player.Z - @object.Z) * (player.Z - @object.Z)));

            return (player.Range + @object.Range) >= distance;
        }

        public bool isTouched(HavingLocation @object)
        {
            double distance = Math.Sqrt(((X - @object.X) * (X - @object.X)) + ((Y - @object.Y) * (Y - @object.Y)) + ((Z - @object.Z) * (Z - @object.Z)));

            return (Range + @object.Range) >= distance;
        }

    }
}
