using System;
using Microsoft.Xna.Framework;

namespace Game.Core
{
    public class GameScreenCollection : IGameComponent, IDrawable, IUpdateable
    {
        private IGameCore gameCore;

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        private int drawOrder = 0;
        private bool visible = true;
        private bool enabled = true;
        private int updateOrder = 0;
        
        internal Color DrawColor { get; private set; } = Color.Beige;

        public GameScreenCollection()
        {
        }

        public int DrawOrder
        {
            get { return drawOrder; }
            set
            {
                drawOrder = value;
                DrawOrderChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                VisibleChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                enabled = value;
                EnabledChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        public int UpdateOrder
        {
            get { return updateOrder; }
            set
            {
                updateOrder = value;
                UpdateOrderChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        internal void SetGameCore(IGameCore gameCore)
        {
            this.gameCore = gameCore;
        }

        public void Initialize()
        {
        }

        public void Draw(GameTime gameTime)
        {
            if (!Visible)
            {
                return;
            }
        }


        public void Update(GameTime gameTime)
        {
            if (Enabled)
            {
                return;
            }
        }
    }
}