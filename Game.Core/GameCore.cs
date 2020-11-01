using System;
using Game.Core.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game.Core
{
    internal enum Order
    {
        SCREEN = 0,
        USER_INTERFACE = 1000
    }

    public sealed class GameCore : Microsoft.Xna.Framework.Game, IGameCore
    {
        private readonly GameScreenCollection _gameScreenCollection;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly UserInterfaceComponent _userInterfaceComponent;

        public GameCore(GameScreenCollection screens)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Services.AddService(Content);

            _gameScreenCollection = screens;
            screens.DrawOrder = (int) Order.SCREEN;
            screens.UpdateOrder = (int) Order.SCREEN;

            Components.Add(screens);

            _userInterfaceComponent =
                new UserInterfaceComponent("Default");
            _userInterfaceComponent.DrawOrder = (int) Order.USER_INTERFACE;
            _userInterfaceComponent.UpdateOrder = (int) Order.USER_INTERFACE;

            Components.Add(_userInterfaceComponent);
            Services.AddService((IUserInterfaceManager) _userInterfaceComponent);

            Game = this;
        }

        public static IGameCore Game { get; private set; }

        public Rectangle Viewport =>
            new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

        public event EventHandler<Rectangle> ViewportChanged;

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _userInterfaceComponent.Batch = new SpriteBatch(GraphicsDevice);
                Services.AddService(_spriteBatch);
            _gameScreenCollection.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Initialize()
        {
            Window.ClientSizeChanged += WindowOnClientSizeChanged;
            base.Initialize();
        }

        private void WindowOnClientSizeChanged(object sender, EventArgs e)
        {
            ViewportChanged?.Invoke(this, Viewport);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_gameScreenCollection.DrawColor);

            base.Draw(gameTime);
        }
    }
}