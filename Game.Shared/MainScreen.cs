using Game.Core;
using Game.Core.Graphics;
using Game.Core.Graphics.Animations;
using Game.Core.UI;
using Game.Core.UI.Controls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Shared
{
    public class MainScreen : GameScreen
    {
        private AnimatedSprite _animatedSprite;
        private Sprite _sprite;
        private SpriteFont _spriteFont;
        private UserInterface _userInterface;

        protected override void OnLoad()
        {
            var contentManager = GameCore.Game.Services.GetService<ContentManager>();
            _spriteFont = contentManager.Load<SpriteFont>("Default");

            _sprite = new Sprite("b2ap3_large_kyt_wizard_400", new Vector2(100, 100), new Vector2(100, 200));


            _animatedSprite = new AnimatedSprite("animation", new Rectangle(500, 200, 100, 100));

            _userInterface = GameCore.Game.Services.GetService<IUserInterfaceManager>()
                .CreateUserInterface(true);

            var panel = new Panel
            {
                Background = new ColorBackground(Color.Red),
                Bounds = new Rectangle(0, 0, 300, 100)
            };

            var childPanel = new Panel
            {
                Background = new ColorBackground(Color.Yellow),
                Bounds = new Rectangle(50, 25, 200, 50)
            };

            panel.AddChild(childPanel);

            _userInterface.AddChild(panel);
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