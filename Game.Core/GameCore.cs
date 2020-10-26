using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game.Core
{
    public sealed class GameCore : Microsoft.Xna.Framework.Game, IGameCore
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private readonly GameScreenCollection _gameScreenCollection;

        public GameCore(GameScreenCollection screens)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            Services.AddService(Content);

            _gameScreenCollection = screens;
            screens.SetGameCore(this);
            Components.Add(screens);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(_spriteBatch);
            // TODO: use this.Content to load your game content here
            _gameScreenCollection.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_gameScreenCollection.DrawColor);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public Viewport GetViewPort()
        {
            return GraphicsDevice.Viewport;
        }
    }
}
