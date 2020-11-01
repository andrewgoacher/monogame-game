using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game.Core.UI.Controls
{
    public class Button : ControlBase
    {
        public event EventHandler Clicked;
        private MouseState _previousMouseState;

        public Button()
        {
            _previousMouseState = Mouse.GetState();
        }
        
        protected override void OnDraw(GameTime gameTime, SpriteBatch batch)
        {
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            var state = Mouse.GetState();

            if (_previousMouseState.LeftButton == ButtonState.Pressed &&
                state.LeftButton == ButtonState.Released)
            {
                if (ViewRect.Intersects(_previousMouseState.Position) &&
                    ViewRect.Intersects(state.Position))
                {
                    Clicked?.Invoke(this, EventArgs.Empty);
                }
            }
            
            _previousMouseState = state;
        }
    }
}