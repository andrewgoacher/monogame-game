using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI.Controls
{
    public class Label : IUIElement
    {
        private Rectangle _parentRect;
        private Rectangle _bounds;
        private Rectangle _amendedBounds;
        private Vector2 _position = Vector2.Zero;

        public Label()
        {
            Text = "";
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Panel) obj);
        }
        
        public bool Equals(IUIElement other)
        {
            if (other == null)
            {
                return false;
            }
            if (other is Label lbl)
            {
                return lbl.Font == Font &&
                       lbl.Enabled == Enabled &&
                       lbl.Visible == Visible &&
                       lbl.Text?.Equals(Text) == true &&
                       lbl.Bounds == Bounds &&
                       lbl.Color == Color;
            }

            return false;
        }

        public string Text { get; set; }
        public SpriteFont Font { get; set; }
        public Color Color { get; set; } = Color.White;
        public bool Enabled { get; set; } = true;
        public bool Visible { get; set; } = true;
        public Rectangle Bounds
        {
            get { return _bounds; }
            set
            {
                _bounds = value;
                Reconfigure(_parentRect);
            }
        }
        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (!Visible)
            {
                return;
            }
            
            batch.DrawString(Font, Text, _position, Color);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Reconfigure(Rectangle re)
        {
            _parentRect = re;
            _amendedBounds = re.Configure(Bounds);
            _position = new Vector2(_amendedBounds.X, _amendedBounds.Y);
        }
    }
}