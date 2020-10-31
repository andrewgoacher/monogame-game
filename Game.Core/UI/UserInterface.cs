using Game.Core.UI.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI
{
    public class UserInterface :
        IUIContainer
    {
        private readonly Panel _panel;

        internal UserInterface()
        {
            _panel = new Panel();
        }

        public bool Visible { get; set; } = true;

        public bool Enabled { get; set; } = true;

        public SpriteFont DefaultFont { get; internal set; }

        public void AddChild(IUIElement element)
        {
            _panel.AddChild(element);
        }

        public void RemoveChild(IUIElement element)
        {
            _panel.RemoveChild(element);
        }

        public void Reconfigure(Rectangle vp)
        {
            _panel.Bounds = vp;
        }

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            _panel.Draw(gameTime, batch);
        }

        public void Update(GameTime gameTime)
        {
            _panel.Update(gameTime);
        }
    }
}