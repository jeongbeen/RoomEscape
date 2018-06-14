using System;
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
            MaigcGame game = new MaigcGame();
            for (int i = 0; i < 9; i++)
            {
                game.gatherCube(new Cube(i + 1, 5, i * 2, i * 3, 3));
            }

            Assert.AreEqual(true, game.canPlayGame(player));
        }

        [TestMethod]
        public void 큐브를_9개_모았나()
        {
            MaigcGame game = new MaigcGame();

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

       

    }
}
