using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomEscape.Logic
{
    public abstract class Game 
    {
        public abstract bool isCompleted();
        public abstract void Restart();
        public abstract bool canPlayGame(Player player);

        public static Game Create(GameType gameType)
        {
            switch (gameType)
            {
                case GameType.Beaker:
                    return new BeakerGame();
                case GameType.Magic:
                    return new MagicGame();
                default:
                    throw new NotImplementedException("Game.Create");

            }
        }
    }

    public enum GameType
    {
        Beaker,
        Magic
    }
}
