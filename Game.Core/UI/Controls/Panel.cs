using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI.Controls
{
    public class Panel : ContainerBase
    {
        protected override void OnReconfigureBounds(Rectangle re)
        {
            foreach (var child in Children) child.Reconfigure(re);
        }

        protected override void OnDraw(GameTime gameTime, SpriteBatch batch)
        {
            foreach (var child in Children) child.Draw(gameTime, batch);
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            foreach (var child in Children) child.Update(gameTime);
        }
    }
}