using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI
{
    public class ColorBackground : IBackground
    {
        private readonly Texture2D _texture;
        private Rectangle _bounds;
        
        public ColorBackground(Color color)
        {
            var graphcisDevice = GameCore.Game.Services.GetService<IGraphicsDeviceService>();

            _texture = new Texture2D(graphcisDevice.GraphicsDevice, 1, 1);
            _texture.SetData(new Color[1] { color});
            _bounds = Rectangle.Empty;
        }

        public void Reconfigure(Rectangle bounds)
        {
            _bounds = bounds;
        }

        public void Draw(SpriteBatch batch)
        {
            if (_bounds.IsEmpty)
            {
                return;
            }
            
            batch.Draw(_texture, _bounds, Color.White);
        }
    }
}