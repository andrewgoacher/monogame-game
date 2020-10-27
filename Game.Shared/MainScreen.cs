using Game.Core;
using Game.Core.Graphics;
using Game.Core.Graphics.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Shared
{
    public class MainScreen : GameScreen
    {
        private SpriteFont _spriteFont;
        private Sprite _sprite;
        private AnimatedSprite _animatedSprite;

        public MainScreen()
        {
        }

        protected override void OnLoad()
        {
            var contentManager = GameCore.Game.Services.GetService<ContentManager>();
            _spriteFont = contentManager.Load<SpriteFont>("Default");
            
            _sprite = new Sprite("b2ap3_large_kyt_wizard_400", new Vector2(100, 100), new Vector2(100, 200));


            _animatedSprite = new AnimatedSprite("animation", new Rectangle(500, 200, 100, 100));
        }

        public override void Draw(GameTime gameTime)
        {
            var batch = GameCore.Game.Services.GetService<SpriteBatch>();
            batch.DrawString(_spriteFont, "Test", new Vector2(10, 10), Color.White);
            _sprite.Draw(batch);
            _animatedSprite.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            _animatedSprite.Update(gameTime);
        }
    }
}