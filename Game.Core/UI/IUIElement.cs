using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI
{
    public interface IUIElement : IEquatable<IUIElement>
    {
        bool Enabled { get; }
        bool Visible { get; }
        Rectangle Bounds { get; }
        void Draw(GameTime gameTime, SpriteBatch batch);
        void Update(GameTime gameTime);
        void Reconfigure(Rectangle re);
    }
}