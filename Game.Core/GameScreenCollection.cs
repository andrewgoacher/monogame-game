using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core
{
    public class GameScreenCollection : IGameComponent, IDrawable, IUpdateable
    {
        private readonly GameScreen currentScreen;

        private int drawOrder;
        private bool enabled = true;
        private int updateOrder;
        private bool visible = true;

        public GameScreenCollection(GameScreen firstScreen)
        {
            currentScreen = firstScreen;
        }

        internal Color DrawColor => currentScreen.DrawColor;

        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public int DrawOrder
        {
            get => drawOrder;
            set
            {
                drawOrder = value;
                DrawOrderChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public bool Visible
        {
            get => visible;
            set
            {
                visible = value;
                VisibleChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Draw(GameTime gameTime)
        {
            if (!Visible) return;

            var batch = GameCore.Game.Services.GetService<SpriteBatch>();

            batch.Begin();
            currentScreen.Draw(gameTime);
            batch.End();
        }

        public void Initialize()
        {
        }

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled
        {
            get => enabled;
            set
            {
                enabled = value;
                EnabledChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public int UpdateOrder
        {
            get => updateOrder;
            set
            {
                updateOrder = value;
                UpdateOrderChanged?.Invoke(this, EventArgs.Empty);
            }
        }


        public void Update(GameTime gameTime)
        {
            if (!Enabled) return;

            currentScreen.Update(gameTime);
        }

        public void LoadContent()
        {
            currentScreen.LoadContent();
        }
    }
}