using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI.Controls
{
    public class Panel : IUIContainer, IUIElement
    {
        private readonly HashSet<IUIElement> _children;

        private Rectangle _parentRect;
        private Rectangle _bounds;
        private Rectangle _amendedBounds;

        public Panel()
        {
            _children = new HashSet<IUIElement>();
        }

        public IBackground Background { get; set; }

        public void AddChild(IUIElement element)
        {
            _children.Add(element);
            Reconfigure(_amendedBounds);
        }

        public void RemoveChild(IUIElement element)
        {
            _children.Remove(element);
        }

        public void Reconfigure(Rectangle re)
        {
            _parentRect = re;
            _amendedBounds = re.Configure(Bounds);
            Background?.Reconfigure(_amendedBounds);
            foreach (var child in _children) child.Reconfigure(_amendedBounds);
        }

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
            if (!Visible) return;

            Background?.Draw(batch);

            foreach (var child in _children) child.Draw(gameTime, batch);
        }

        public void Update(GameTime gameTime)
        {
            if (!Enabled) return;

            foreach (var child in _children) child.Update(gameTime);
        }

        public bool Enabled { get; set; } = true;
        public bool Visible { get; set; } = true;

        public bool Equals(IUIElement other)
        {
            if (other is Panel == false) return false;

            var otherPanel = other as Panel;
            return Equals(_children, otherPanel._children)
                   && Enabled == otherPanel.Enabled
                   && Visible == otherPanel.Visible
                   && Equals(Background, otherPanel.Background);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Panel) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_children, Enabled, Visible, Background);
        }
    }
}