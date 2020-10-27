using Game.Core;
using Game.Core.Graphics;
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
            _sprite = new Sprite("b2ap3_large_kyt_wizard_400", new Vector2(100, 150))
            {
                Position = new Vector2(200, 200)
            };
            
            _animatedSprite = new AnimatedSprite("spritesheet", new []
            {
                new Animation("walk-down", new []
                {
                    new AnimationFrame("sprite1", 200f),
                    new AnimationFrame("sprite2", 200f),
                    new AnimationFrame("sprite3", 200f),
                    new AnimationFrame("sprite4", 200f),
                    new AnimationFrame("sprite5", 200f),
                    new AnimationFrame("sprite6", 200f),
                }), 
                new Animation("walk-right", new []
                {
                    new AnimationFrame("sprite7", 200f),
                    new AnimationFrame("sprite8", 200f),
                    new AnimationFrame("sprite9", 200f),
                    new AnimationFrame("sprite10", 200f),
                    new AnimationFrame("sprite11", 200f),
                    new AnimationFrame("sprite12", 200f),
                }), 
                new Animation("walk-up", new []
                {
                    new AnimationFrame("sprite13", 200f),
                    new AnimationFrame("sprite14", 200f),
                    new AnimationFrame("sprite15", 200f),
                    new AnimationFrame("sprite16", 200f),
                    new AnimationFrame("sprite17", 200f),
                    new AnimationFrame("sprite18", 200f),
                }), 
                new Animation("walk-left", new []
                {
                    new AnimationFrame("sprite19", 200f),
                    new AnimationFrame("sprite20", 200f),
                    new AnimationFrame("sprite21", 200f),
                    new AnimationFrame("sprite22", 200f),
                    new AnimationFrame("sprite23", 200f),
                    new AnimationFrame("sprite24", 200f),
                }), 
            })
            {
                Position = new Vector2(500, 200)
            };
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