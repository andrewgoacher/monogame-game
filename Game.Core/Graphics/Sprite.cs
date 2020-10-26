using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.Graphics
{
    public class Sprite
    {
        private readonly Texture2D texture;
        private Rectangle rect;

        public Sprite(IGameCore game, string sprite) : this(game, sprite, Vector2.Zero)
        {
        }

        public Sprite(IGameCore game, string sprite, Vector2 size)
        {
            var contentManager = game.Services.GetService<ContentManager>();
            texture = contentManager.Load<Texture2D>(sprite);
            var textureSize = new Vector2(texture.Width, texture.Height);
            if (size != Vector2.Zero)
            {
                textureSize = size;
            }
            rect = new Rectangle(0,0, (int)textureSize.X, (int) textureSize.Y);
        }
        
        public Vector2 Position { get; set; } = Vector2.Zero;

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(texture, Position, rect, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
        }
    }
}