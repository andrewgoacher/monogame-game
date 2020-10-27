using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core
{
    public class GameScreenCollection : IGameComponent, IDrawable, IUpdateable
    {
        private GameScreen currentScreen;

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        private int drawOrder = 0;
        private bool visible = true;
        private bool enabled = true;
        private int updateOrder = 0;

        internal Color DrawColor
        {
            get { return currentScreen.DrawColor; }
        }

        public GameScreenCollection(GameScreen firstScreen)
        {
            currentScreen = firstScreen;
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

        public void Initialize()
        {
        }

        public void LoadContent()
        {
            currentScreen.LoadContent();
        }

        public void Draw(GameTime gameTime)
        {
            if (!Visible)
            {
                return;
            }

            var batch = GameCore.Game.Services.GetService<SpriteBatch>();

            batch.Begin();
            currentScreen.Draw(gameTime);
            batch.End();
        }


        public void Update(GameTime gameTime)
        {
            if (!Enabled)
            {
                return;
            }
            
            currentScreen.Update(gameTime);
        }
    }
}