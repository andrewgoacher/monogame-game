using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.Graphics
{
    public class Sprite
    {
        private Rectangle _destinationRectangle;
        private Rectangle _sourceRectangle;
        private Texture2D _texture;

        public Sprite(string sprite)
        {
            Init(sprite, Vector2.Zero, null, null);
        }

        public Sprite(string sprite, Vector2 position)
        {
            Init(sprite, position, null, null);
        }

        public Sprite(string sprite, Vector2 position, Vector2 size)
        {
            Init(sprite, position, size, null);
        }

        public Sprite(string sprite, Rectangle source)
        {
            Init(sprite, Vector2.Zero, null, source);
        }

        public Sprite(string sprite, Vector2 position, Rectangle source)
        {
            Init(sprite, position, null, source);
        }

        public Sprite(string sprite, Vector2 position, Vector2 size, Rectangle source)
        {
            Init(sprite, position, size, source);
        }

        private void Init(string sprite, Vector2 position, Vector2? size, Rectangle? source)
        {
            var contentManager = GameCore.Game.Services.GetService<ContentManager>();
            _texture = contentManager.Load<Texture2D>(sprite);
            _sourceRectangle = source ?? new Rectangle(0, 0, _texture.Width, _texture.Height);

            var destSize = size ?? new Vector2(_texture.Width, _texture.Height);
            _destinationRectangle =
                new Rectangle((int) position.X, (int) position.Y, (int) destSize.X, (int) destSize.Y);
        }

        public void SetPosition(int x, int y)
        {
            _destinationRectangle = new Rectangle(x, y, _destinationRectangle.Width, _destinationRectangle.Height);
        }

        public void SetSize(int w, int h)
        {
            _destinationRectangle = new Rectangle(_destinationRectangle.X, _destinationRectangle.Y, w, h);
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(_texture, _destinationRectangle, _sourceRectangle, Color.White, 0f, Vector2.Zero,
                SpriteEffects.None, 0f);
        }
    }
}