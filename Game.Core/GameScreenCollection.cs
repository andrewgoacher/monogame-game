using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core
{
    public class GameScreenCollection : IGameComponent, IDrawable, IUpdateable
    {
        private readonly GameScreen _currentScreen;

        private int _drawOrder;
        private bool _enabled = true;
        private int _updateOrder;
        private bool _visible = true;

        public GameScreenCollection(GameScreen firstScreen)
        {
            _currentScreen = firstScreen;
        }

        internal Color DrawColor => _currentScreen.DrawColor;

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

        public void Draw(GameTime gameTime)
        {
            if (!Visible) return;

            var batch = GameCore.Game.Services.GetService<SpriteBatch>();

            batch.Begin();
            _currentScreen.Draw(gameTime);
            batch.End();
        }

        public void Initialize()
        {
        }

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


        public void Update(GameTime gameTime)
        {
            if (!Enabled) return;

            _currentScreen.Update(gameTime);
        }

        public void LoadContent()
        {
            _currentScreen.LoadContent();
        }
    }
}