using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI
{
    public interface IBackground
    {
        void Reconfigure(Rectangle bounds);
        void Draw(SpriteBatch batch);
    }
}