using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Game.Core
{
    public abstract class GameScreen : IDrawable, IUpdateable
    {
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        private int _drawOrder = 0;
        private bool _visible = true;
        private bool _enabled = true;
        private int _updateOrder = 0;
        private bool _loaded = false;

        public GameScreen()
        {
            
        }

        internal void LoadContent()
        {
            if (!_loaded)
            {
                OnLoad();
                _loaded = true;
            }
        }

        protected abstract void OnLoad();
        
        public int DrawOrder
        {
            get { return _drawOrder; }
            set
            {
                _drawOrder = value;
                DrawOrderChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool Visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                VisibleChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                EnabledChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        
        public int UpdateOrder
        {
            get { return _updateOrder; }
            set
            {
                _updateOrder = value;
                UpdateOrderChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        
        public Color DrawColor { get; protected set; } = Color.CornflowerBlue;

        public abstract void Draw(GameTime gameTime);


        public abstract void Update(GameTime gameTime);
    }
}