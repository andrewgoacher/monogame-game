using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core
{
    public interface IGameCore
    {
        GameServiceContainer Services { get; }
        Rectangle Viewport { get; }
        event EventHandler<Rectangle> ViewportChanged;
    }
}