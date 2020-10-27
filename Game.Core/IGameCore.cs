using Microsoft.Xna.Framework;

namespace Game.Core
{
    public interface IGameCore
    {
        GameServiceContainer Services { get; }
        GameComponentCollection Components { get; }
    }
}