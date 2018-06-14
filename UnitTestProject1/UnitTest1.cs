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
            Door door = new Door("a", 2, 10, 5, 2);

            bool b = player.isTouched(player, door);

            Assert.AreEqual(b, false);
        }

        [TestMethod]
        public void 키의_이름과_문의_이름이_일치하면_열리는가()
        {
            Door door = new Door("Labroom", 5, 5, 5, 3);

            Key key = new Key("LabroomKey", 10, 10, 10, 3);
            Player player = new Player(0, 0, 0, 3, false);

            bool b = door.isRightKey(key.KeyName);
            if (b) door.Open();

            Assert.AreEqual(door.isOpened, true);
        }

        [TestMethod]
        public void 키의_이름과_문의_이름이_일치하지_않으면_열리지않는가()
        {
            Door door = new Door("ClassRoom", 5, 5, 5, 3);
            Key key = new Key("LabroomKey", 10, 10, 10, 3);
            Player player = new Player(0, 0, 0, 3, false);

            bool b = door.isRightKey(key.KeyName);
            if (b) door.Open();

            Assert.AreEqual(door.isOpened, false);
        }

        [TestMethod]
        public void 큐브를_9개_모아야_마방진게임이_시작하는가()
        {
            Player player = new Player(0, 0, 0, 3, false);
            MaigcGame game = new MaigcGame();
            for (int i = 0; i < 9; i++)
            {
                game.gatherCube(new Cube(i + 1, 5, i * 2, i * 3, 3));
            }

            Assert.AreEqual(game.canPlayGame(player), true);
        }

        [TestMethod]
        public void 큐브를_9개_모였나()
        {
            MaigcGame game = new MaigcGame();

            for (int i = 0; i < 9; i++)
            {
                game.gatherCube(new Cube(i,5,5,5,5));
            }

            Assert.AreEqual(9, game._collectedCubes.Count);
        }

        [TestMethod]
        public void 비커게임_위치에_도착해야_비커게임이_시작하는가()
        {
            Player player = new Player(0, 0, 0, 3, false);
            BeakerGame game = new BeakerGame();

            Assert.AreEqual(game.canPlayGame(player), true);
        }
    }
}
