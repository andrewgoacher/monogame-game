using Game.Core.UI.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI
{
    public class UserInterface
    {
        private readonly Panel _panel;

        internal UserInterface()
        {
            _panel = new Panel() { Name = "Root"};
            _panel.UserInterface = this;
        }

        public bool Visible { get; set; } = true;

        public bool Enabled { get; set; } = true;
        
        public Rectangle Bounds { get; private set; }

        public SpriteFont DefaultFont { get; internal set; }

        public void AddChild(ControlBase element)
        {
            _panel.AddChild(element);
            Reconfigure(Bounds);
        }

        public void RemoveChild(ControlBase element)
        {
            _panel.RemoveChild(element);
        }

        public void Reconfigure(Rectangle vp)
        {
            Bounds = vp;
            _panel.Reconfigure(vp);
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