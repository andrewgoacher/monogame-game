using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI.Controls
{
    public abstract class ControlBase : IEquatable<ControlBase>
    {
        private Rectangle _bounds;
        private Rectangle _parentRect;

        private readonly Guid _controlId = Guid.NewGuid();
        private string ControlName => GetType().Name;

        public bool Enabled { get; set; } = true;
        public bool Visible { get; set; } = true;

        public Rectangle Bounds
        {
            get => _bounds;
            set
            {
                _bounds = value;
                Reconfigure(_parentRect);
            }
        }

        protected Rectangle ViewRect { get; private set; }

        public abstract bool Equals(ControlBase other);

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (!Visible) return;

            OnDraw(gameTime, batch);
        }

        public void Update(GameTime gameTime)
        {
            if (!Enabled) return;

            OnUpdate(gameTime);
        }

        protected abstract void OnDraw(GameTime gameTime, SpriteBatch batch);
        protected abstract void OnUpdate(GameTime gameTime);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ControlBase) obj);
        }

        public int GetHashCode() => _controlId.GetHashCode();

        public void Reconfigure(Rectangle re)
        {
            _parentRect = re;
            ViewRect = re.Configure(Bounds);
            OnReconfigureBounds(ViewRect);
        }

        protected internal virtual void OnAdd(ControlBase parent)
        {
        }

        protected internal virtual void OnRemove(ControlBase parent)
        {
        }

        protected virtual void OnReconfigureBounds(Rectangle re)
        {
        }
    }
}