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

        public override bool Equals(ControlBase other)
        {
            if (other == null) return false;
            if (other is Label lbl)
                return lbl.Font == Font &&
                       lbl.Enabled == Enabled &&
                       lbl.Visible == Visible &&
                       lbl.Text?.Equals(Text) == true &&
                       lbl.Bounds == Bounds &&
                       lbl.Color == Color;

            return false;
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