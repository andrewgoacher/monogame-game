using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI.Controls
{
    public class Label : ControlBase
    {
        private Vector2 _position = Vector2.Zero;

        public Label()
        {
            Text = "";
        }

        public string Text { get; set; }
        public SpriteFont Font { get; set; }
        public Color Color { get; set; } = Color.White;

        protected internal override void OnAdd(ControlBase parent)
        {
            base.OnAdd(parent);
            if (Font == null) Font = UserInterface.DefaultFont;
        }

        protected override void OnDraw(GameTime gameTime, SpriteBatch batch)
        {
            batch.DrawString(Font, Text, _position, Color);
        }

        protected override void OnUpdate(GameTime gameTime)
        {
        }

        protected override void OnReconfigureBounds(Rectangle re)
        {
            base.OnReconfigureBounds(re);
            _position = new Vector2(ViewRect.X, ViewRect.Y);
        }
    }
}