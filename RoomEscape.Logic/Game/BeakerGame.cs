using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomEscape.Logic
{
    public class BeakerGame : Game
    {   
        public BeakerGame()
        {
            _beakers = new Dictionary<string, Beaker>();

            _beakers.Add("A", new Beaker(8, 8));
            _beakers.Add("B", new Beaker(5, 0));
            _beakers.Add("C", new Beaker(3, 0));
        }

        private Dictionary<string, Beaker> _beakers;

        public void Move(string from, string to)
        {
            Move(_beakers[from], _beakers[to]);
        }

        public void Move(char from, char to)
        {
            Move(_beakers[from.ToString()], _beakers[to.ToString()]);
        }

        private void Move(Beaker from, Beaker to)
        {
            int liter = Math.Min(from.Liter, to.Capacity - to.Liter);

            to.Liter += liter;
            from.Liter -= liter;
        }

        public int this[string name]
        {
            get { return GetLiter(name); }
        }

        public int GetLiter(string name)
        {
            return _beakers[name].Liter;
        }

        public override bool isCompleted()
        {
            return _beakers["A"].Liter == 4 && _beakers["B"].Liter == 4;
        }

        public override void Restart()
        {
            _beakers["A"].Liter = 8;
            _beakers["B"].Liter = 0;
            _beakers["C"].Liter = 0;
        }

        public override bool canPlayGame(Player player)
        {
            if (player.X == 0)// player의 isTouched 호출해서 게임에 닿았으면 게임 실행(비커가 놓여진 책상 근처로 왔을때 isTouched)
                return true;
            else
                return false;
        }
    }
}
