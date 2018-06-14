using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomEscape.Logic
{
    public class MaigcGame:Game
    {
        public MaigcGame()
        {
            _cubes = new List<Cube>();
            _putCubes = new Dictionary<int, Cube>();
            _collectedCubes = new List<Cube>();

            for (int i = 0; i < 9; i++)
            {
                _cubes.Add(new Cube(0, i, i + 10, i + 15, 2));
                _putCubes.Add(i + 1, _cubes[i]);
            }
        }

        private List<Cube> _cubes; 
        private Dictionary<int, Cube> _putCubes;
        public List<Cube> _collectedCubes; //플레이어가 게임을 할수있는 상황인지 아닌지만을 판단하기 위함

        public int GetNum(int num)
        {
            return _putCubes[num].CubeNum;
        }

        public void gatherCube(Cube cube)
        {
            if (cube.X == 5) // 큐브를 스테이지 근처로 가져오면 _collectedCubes에 큐브를 추가 =>추가된 큐브가 9개여야 마방진게임을 시작할수있음!! 스테이지라는 필드..?를 만들까 아니면 특정 범위 이내에 가져올까..
                _collectedCubes.Add(cube);
            
        }

        public void Put(int putPosition, int cubeNum)
        {
            int count = 0;

            for (int i = 0; i < 9; i++)
            {
                if (cubeNum == _putCubes[i + 1].CubeNum) count++;
            }
            if (count == 0)
            {
                _cubes[putPosition - 1].CubeNum = cubeNum;
                _putCubes[putPosition] = _cubes[putPosition - 1];
            }
        }
        public int this[int cubeNum]
        {
            get { return GetNum(cubeNum); }
        }

        public override bool isCompleted()
        {
            return ((_putCubes[1].CubeNum + _putCubes[5].CubeNum + _putCubes[9].CubeNum) == 15) && ((_putCubes[3].CubeNum + _putCubes[5].CubeNum + _putCubes[7].CubeNum) == 15) && ((_putCubes[1].CubeNum + _putCubes[2].CubeNum + _putCubes[3].CubeNum) == 15);
        }

        public override void Restart()
        {
            for (int i = 0; i < 9; i++)
            {
                _cubes[i].CubeNum = 0;
                _putCubes[i + 1] = _cubes[i];
            }
        }

        public override bool canPlayGame(Player player)
        {
            if (player.X == 0 && _collectedCubes.Count == 9) //플레이어 위치가 마방진 게임 스테이지가 놓여진 책상에 도달하고 모은 큐브가 9개면 게임 실행
                return true;
            else
                return false;
        }
    }
}
