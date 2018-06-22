using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoomEscape.Logic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void 플레이어가_특정_오브젝트를_건들때_닿았다는_결과가_참인가()
        {
            Player player = new Player(0, 0, 0, 3, false);
            HavingLocation door = new Door("a", 0, 0, 4, 3);
                                
                                            //플레이어를 매개변수로 받아야 하나
            Assert.AreEqual(true, player.isTouched(player, door));
        }

        [TestMethod]
        public void 키의_이름과_문의_이름이_일치하면_열리는가()
        {
            Door door = new Door("Labroom", 0, 0, 5, 3);
            Item key = new Key("LabroomKey", 0, 0, 2, 3);
            Player player = new Player(0, 0, 0, 3, false);

            player.GripItem(key);
            player.Move(0, 0, 3);
            player.OpenDoor(door);

            Assert.AreEqual(true, door.isOpened);
        }

        [TestMethod]
        public void 키의_이름과_문의_이름이_일치하지_않으면_열리지않는가()
        {
            Door door = new Door("ClassRoom", 0, 0, 5, 3);
            Key key = new Key("LabroomKey", 0, 0, 0, 3);
            Player player = new Player(0, 0, 0, 3, false);

            player.GripItem(key);
            player.Move(0, 0, 3);
            player.OpenDoor(door);

            Assert.AreEqual(false, door.isOpened);
        }

        [TestMethod]
        public void 큐브를_9개_모으고_지정된_위치로_와야_마방진게임이_시작하는가()
        {
            Player player = new Player(0, 0, 0, 3, false);
            MagicGame game = new MagicGame();
            for (int i = 0; i < 9; i++)
            {
                                 //player가 큐브를 모으는게 맞을수도 없고 아닐수도 있습니다.
                game.gatherCube(new Cube(i + 1, 5, i * 2, i * 3, 3));
            }

            Assert.AreEqual(true, game.canPlayGame(player));
        }

        [TestMethod]
        public void 큐브를_9개_모았나()
        {
            MagicGame game = new MagicGame();

            for (int i = 0; i < 9; i++)
            {
                game.gatherCube(new Cube(i, 5, 5, 5, 5));
            }

            Assert.AreEqual(9, game._collectedCubes.Count);
        }

        [TestMethod]
        public void 비커게임_위치에_도착해야_비커게임이_시작하는가()
        {
            Player player = new Player(0, 0, 0, 3, false);
            BeakerGame game = new BeakerGame();

            Assert.AreEqual(true, game.canPlayGame(player));
        }

        [TestMethod]
        public void 잡은_것이_아이템일_경우만_플레이어아이템이_되는가()
        {
            Player player = new Player(0, 0, 0, 3, false);
            Item item = new Key("Key", 0, 0, 4, 3);

            player.GripItem(item);

            Assert.AreEqual((item as Key).Name, player.playerItem.Name);
        }

        [TestMethod]
        public void 게임이_재시작_되었는지()
        {
            BeakerGame game = new BeakerGame();

            game.Move("A", "B");
            game.Restart();
            int liter = game.GetLiter("A");
            Assert.AreEqual(8, liter);
        }

        [TestMethod]
        public void 비커의_액체가_4_4로_나뉘어지면_비커게임이_끝나는가()
        {
            BeakerGame game = new BeakerGame();

            game.Move("A", "B");//3 5 0
            game.Move("B", "C");//3 2 3
            game.Move("C", "A");//6 2 0
            game.Move("B", "C");//6 0 2
            game.Move("A", "B");//1 5 2
            game.Move("B", "C");//1 4 3
            game.Move("C", "A");//4 4 0

            Assert.AreEqual(true, game.isCompleted());
        }

        [TestMethod]
        public void 마방진_게임이_완료되었는가()
        {
            MagicGame game = new MagicGame();

            game.Put(1, 4);
            game.Put(2, 9);
            game.Put(3, 2);
            game.Put(4, 3);
            game.Put(5, 5);
            game.Put(6, 7);
            game.Put(7, 8);
            game.Put(8, 1);
            game.Put(9, 6);

            Assert.AreEqual(true, game.isCompleted());
        }

        [TestMethod]
        public void 큐브를_스테이지에_두면_putCube에_들어가는가()
        {

        }

        [TestMethod]
        public void 마방진을_맞추지_못_하였습니다()
        {
            
            MagicGame magicGame = new MagicGame();
            //가로&&세로&&대각의 값이 !=15면 magic.Restart()를 호출
            
            
                
           
        }
    }
}
