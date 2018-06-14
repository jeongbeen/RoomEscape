using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomEscape.Logic
{
    public class Player : HavingLocation
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get; private set; }
        public float Range { get; private set; }

        public bool isStopped { get; private set; }
        //public List<Item> playerItem = new List<Item>(); //아이템은 하나만 들고 다닐 수 있게 다시 변경
        public Item playerItem = new Item();

        public Player(float x, float y, float z,float r, bool _isStopped):base(x,y,z,r)
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

        public void Grip(Item item) // CanGripItem을 사용하는게 나을듯
        {
            playerItem = item;
        }

        public void Release() // 플레이어가 가진 아이템은 어차피 하나니까 매개변수 필요없음
        {
            if(playerItem.GetType()==typeof(Cube))
                //MagicGame의 gatherCube 실행
                playerItem = null;
            
        }

        public Item CanGripItem(List<Item> items) // 유니티에서 필요..? =>isTouched의 값이 참일때 Cangrip하도록 바꾸자
        {
            foreach (Item item in items)
            {
                if ((X == item.X && Y == item.Y && Z == item.Z) && (playerItem != item))
                {
                    return item;
                }
            }
            return null;
        }

        public void CanGripItem(HavingLocation item)//CanGripItem과 Grip을 합침 위의 두개는 유니티에서 필요없으면 삭제합니다
        {
            if (isTouched(this, item) && item is Item) // 터치하고 터치한게 아이템이라면
                playerItem = item as Item;//item(HavingLocation)을 Item형으로 캐스팅
        }

        public Door CanOpenDoor(List<Door> doors)
        {
            foreach (Door door in doors)
            {
                if (X == door.X && Y == door.Y && Z == door.Z)
                {
                    return door;
                }
            }
            return null;
        }

        //public double CalculateDistance(Player player, HavingLocation @object)
        //{
        //    double distance = (player.X - @object.X) * (player.X - @object.X) + (player.Y - @object.Y) * (player.Y - @object.Y) + (player.Z - @object.Z) * (player.Z - @object.Z);

        //    return Math.Sqrt(distance);
        //}

        public bool isTouched(Player player, HavingLocation @object) // 물건을 집거나 문을 열거나 할때 사용
        {
            double distance = (player.X - @object.X) * (player.X - @object.X) + (player.Y - @object.Y) * (player.Y - @object.Y) + (player.Z - @object.Z) * (player.Z - @object.Z);

            return (player.Range + @object.Range) > distance;
        }
    }
}
