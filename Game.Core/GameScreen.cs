using System;
using Microsoft.Xna.Framework;

namespace Game.Core
{
    public abstract class GameScreen : IDrawable, IUpdateable
    {
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        private IGameCore gameCore;
        
        private int drawOrder = 0;
        private bool visible = true;
        private bool enabled = true;
        private int updateOrder = 0;

        public GameScreen()
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
        
        public Color DrawColor { get; protected set; }

        internal void SetGameCore(IGameCore gameCore)
        {
            this.gameCore = gameCore;
        }

        public abstract void Draw(GameTime gameTime);


        public abstract void Update(GameTime gameTime);
    }
}