using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI
{
    internal class UserInterfaceComponent :
        IGameComponent, IUpdateable, IDrawable, IUserInterfaceManager
    {
        private readonly string _font;
        private  SpriteFont _defaultFont;
        
        private int _drawOrder;
        private bool _enabled = true;

        private UserInterface _interface;
        private int _updateOrder;
        private bool _visible = true;
        private RasterizerState _rasterizerState;

        public UserInterfaceComponent(string defaultFont)
        {
            _font = defaultFont;
            _rasterizerState = new RasterizerState() { ScissorTestEnable = true};
        }
        
        internal SpriteBatch Batch { get; set; }

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
            if (!Visible || _interface == null || Batch == null) return;
            Batch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,
                null, null, _rasterizerState);
            _interface.Draw(gameTime, Batch);
            Batch.End();
        }

        public void Initialize()
        {
            GameCore.Game.ViewportChanged += GameOnViewportChanged;
            Reconfigure(GameCore.Game.Viewport);

            _defaultFont = GameCore.Game.Services.GetService<ContentManager>()
                .Load<SpriteFont>(_font);
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
            if (!Enabled || _interface == null) return;
            _interface.Update(gameTime);
        }

        public void SetInterface(UserInterface ui)
        {
            _interface = ui;
            ui.DefaultFont = _defaultFont;
            Reconfigure(GameCore.Game.Viewport);
        }

        private void GameOnViewportChanged(object sender, Rectangle e)
        {
            Reconfigure(e);
        }

        public void Reconfigure(Rectangle vp)
        {
            _interface?.Reconfigure(vp);
        }

        public UserInterface CreateUserInterface(bool set = false)
        {
            var ui = new UserInterface
            {
                DefaultFont = _defaultFont
            };

            if (set) SetInterface(ui);

            return ui;
        }
    }
}