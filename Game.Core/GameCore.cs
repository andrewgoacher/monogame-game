using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game.Core
{
    public sealed class GameCore : Microsoft.Xna.Framework.Game, IGameCore
    {
        private readonly GameScreenCollection _gameScreenCollection;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public GameCore(GameScreenCollection screens)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Services.AddService(Content);

            _gameScreenCollection = screens;
            Components.Add(screens);
            Game = this;
        }

        public static IGameCore Game { get; private set; }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_gameScreenCollection.DrawColor);

            base.Draw(gameTime);
        }
    }
}