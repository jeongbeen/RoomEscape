
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RoomEscape.Logic;

namespace RoomEscape.Cui
{
    class Program
    {
        static void Main(string[] args)
        {
            Director init = new Director();
            string position;
            string[] positionXYZ;
            while (init.player.isStopped)
            {
                Console.WriteLine("현재 위치 : " + init.player.X + "," + init.player.Y + "," + init.player.Z);
                position = Console.ReadLine();
                positionXYZ = position.Split(',');
                init.player.Move(Int32.Parse(positionXYZ[0]), Int32.Parse(positionXYZ[1]), Int32.Parse(positionXYZ[2]));

                if (init.player.CanGripItem(init._items) != null)
                {
                    Item item = init.player.CanGripItem(init._items);

                    Console.WriteLine(item.Name + "을 찾았습니다. 주울까요?(Y/N)");
                    string answer = Console.ReadLine();

                    if (answer == "Y" || answer == "y")
                    {
                        init.player.Grip(item);
                        Console.WriteLine(item.Name + "을 획득!");
                    }
                }

                if (init.player.CanOpenDoor(init._doors) != null)
                {
                    Door door = init.player.CanOpenDoor(init._doors);
                    Console.WriteLine(door.RoomName + "문을 발견했습니다. 열까요?(Y/N)");
                    string answer = Console.ReadLine();

                    if (answer == "Y" || answer == "y")
                    {
                        if (door.isRightKey(init.player.playerItem.Name)) // 뒤에 이름3개 빼는건 로직에서 해줘야지
                        {
                            door.Open();
                            Console.WriteLine(door.RoomName + "이 열렸습니다.");
                        }
                        else
                        {
                            Console.WriteLine("맞는키가 아닙니다.");
                        }
                    }
                }
            }
        }
    }
}
