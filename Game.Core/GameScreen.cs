using System;
using Microsoft.Xna.Framework;

namespace Game.Core
{
    public abstract class GameScreen : IDrawable, IUpdateable
    {
        private int _drawOrder;
        private bool _enabled = true;
        private bool _loaded;
        private int _updateOrder;
        private bool _visible = true;

        public Color DrawColor { get; protected set; } = Color.CornflowerBlue;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public int DrawOrder
        {
            get => _drawOrder;
            set
            {
                _drawOrder = value;
                DrawOrderChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool Visible
        {
            get => _visible;
            set
            {
                _visible = value;
                VisibleChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public abstract void Draw(GameTime gameTime);
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled
        {
            get => _enabled;
            set
            {
                _enabled = value;
                EnabledChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public int UpdateOrder
        {
            get => _updateOrder;
            set
            {
                _updateOrder = value;
                UpdateOrderChanged?.Invoke(this, EventArgs.Empty);
            }
        }


        public abstract void Update(GameTime gameTime);

        internal void LoadContent()
        {
            if (!_loaded)
            {
                OnLoad();
                _loaded = true;
            }
        }

        protected abstract void OnLoad();
    }
}