using System;
using Game.Core;

namespace Game
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var screenCollection = new GameScreenCollection();
            using (var game = new GameCore(screenCollection))
                game.Run();
        }
    }
}
