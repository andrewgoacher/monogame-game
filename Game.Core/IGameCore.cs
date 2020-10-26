using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core
{
    public interface IGameCore
    {
        GameServiceContainer Services { get; }
        GameComponentCollection Components { get; }
    }
}