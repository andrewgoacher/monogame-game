using Game.Core;
using Game.Core.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Shared
{
    public class MainScreen : GameScreen
    {
        private SpriteFont spriteFont;
        private Sprite sprite;
        
        public MainScreen()
        {
        }

        protected override void OnLoad()
        {
            var contentManager = Game.Services.GetService<ContentManager>();
            spriteFont = contentManager.Load<SpriteFont>("Default");
            sprite = new Sprite(Game, "b2ap3_large_kyt_wizard_400", new Vector2(100, 150))
            {
                Position = new Vector2(200, 200)
            };
        }

        public override void Draw(GameTime gameTime)
        {
            var batch = Game.Services.GetService<SpriteBatch>();
            batch.DrawString(spriteFont, "Test", new Vector2(10, 10), Color.White);
            sprite.Draw(batch);
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}