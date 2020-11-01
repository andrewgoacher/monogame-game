using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI.Controls
{
    [DebuggerDisplay("{Name}")]
    public abstract class ControlBase : IEquatable<ControlBase>
    {
        private readonly Guid _controlId = Guid.NewGuid();
        private Rectangle _bounds;

        private UserInterface _userInterface;
        private string ControlName => GetType().Name;

        public string Name { get; set; }

        public IBackground Background { get; set; }
        public bool Enabled { get; set; } = true;
        public bool Visible { get; set; } = true;

        public UserInterface UserInterface
        {
            get => _userInterface;
            internal set
            {
                if (_userInterface != null) throw new ArgumentException();

                _userInterface = value;
            }
        }

        public Rectangle Bounds
        {
            get => _bounds;
            set
            {
                _bounds = value;
                Reconfigure(ParentBounds);
            }
        }

        public Rectangle ParentBounds { get; private set; }

        protected Rectangle ViewRect { get; private set; }

        public abstract bool Equals(ControlBase other);

        public void Draw(GameTime gameTime, SpriteBatch batch)
        {
            if (!Visible) return;
            
            var curr = batch.GraphicsDevice.ScissorRectangle;
            batch.GraphicsDevice.ScissorRectangle = ViewRect;
            Background?.Draw(batch);
            OnDraw(gameTime, batch);
            batch.GraphicsDevice.ScissorRectangle = curr;
        }

        public void Update(GameTime gameTime)
        {
            if (_userInterface == null) throw new ArgumentException();
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

        public int GetHashCode()
        {
            return _controlId.GetHashCode();
        }

        public void Reconfigure(Rectangle re)
        {
            ParentBounds = re;
            ViewRect = re.Configure(Bounds);

            Background?.Reconfigure(ViewRect);
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