using Game.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Shared
{
    public class MainScreen : GameScreen
    {
        private SpriteFont spriteFont;

        public MainScreen()
        {
        }

        protected override void OnLoad()
        {
            var contentManager = Game.Services.GetService<ContentManager>();
            spriteFont = contentManager.Load<SpriteFont>("Default");
        }

        public override void Draw(GameTime gameTime)
        {
            var batch = Game.Services.GetService<SpriteBatch>();
            batch.DrawString(spriteFont, "Test", new Vector2(10, 10), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}