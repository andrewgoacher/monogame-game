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
                Name = "Red Panel",
                Bounds = new Rectangle(0, 0, 800, 400),
            };

            var childPanel = new Panel
            {
                Background = new ColorBackground(Color.Yellow),
                Name = "Yellow Panel",
                Bounds = new Rectangle(50, 25, 200, 50),
            };

            var counter = 0;
            
            var label = new Label()
            {
                Text = "Not clicked",
                Name = "Label",
                Bounds = new Rectangle(0,10,200, 30),
                Color = Color.Black,
                Background = new ColorBackground(Color.Gray)
            };
    
            var button = new Button()
            {
                Name = "Button",
                Background = new ColorBackground(Color.Green),
                Bounds = new Rectangle(50, 200, 50, 50)
            };

            button.Clicked += (sender, args) =>
            {
                counter += 1;
                var additional = counter == 1 ? "" : "s";
                label.Text = $"Clicked {counter} time{additional}";
            };

            _userInterface.AddChild(panel);
            panel.AddChild(childPanel);
            panel.AddChild(button);
            childPanel.AddChild(label);
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