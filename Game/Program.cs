using System;
using Game.Core;
using Game.Shared;

namespace Game
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var screenCollection = new GameScreenCollection(new MainScreen());
            using (var game = new GameCore(screenCollection))
                game.Run();
        }
    }
}
