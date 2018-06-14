using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomEscape.Logic
{
    public class Director
    {
        public Director()
        {
            player = new Player(0, 0, 0, 5, false);
            _items = new List<Item>(); // 플레이어가 가진 아이템이 아닌 게임 안에 있는 아이템들
            _doors = new List<Door>();
            _itemss = new Dictionary<string, Item>();

            _items.Add(new Key("LabroomKey", 5, 5, 5, 3)); 
            _items.Add(new Key("ClassroomKey", 15, 15, 15 ,3));
            _items.Add(new Key("StaffroomKey", 25, 25, 25, 3));

            ////////////////////////////////////////////////////////////////////////

            //_itemss.Add("LabroomKey", new Key("LabroomKey", 5, 5, 5, 3));
            //_itemss.Add("ClassroomKey", new Key("ClassroomKey", 15, 15, 15, 3));
            //_itemss.Add("StaffroomKey", new Key("StaffroomKey", 25, 25, 25, 3));

            _doors.Add(new Door("Labroom", 30, 30, 30, 3));
            _doors.Add(new Door("Classroom", 40, 40, 40, 3));
            _doors.Add(new Door("Staffroom", 50, 50, 50, 3));
            //door는 List?Dictionary?
        }

        public List<Door> _doors;
        public List<Item> _items;
        public Dictionary<string, Item> _itemss; //각 아이템이 이름을 갖는다면 list, 아니라면 Dictionary?

        public Game _game; 
        public Player player;

        public void playMiniGame(GameType gameType) //나중에 컨트롤러에서 호출
        {
            _game = Game.Create(gameType);
        }

    }
}
