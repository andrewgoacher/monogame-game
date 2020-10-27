using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.Graphics
{
    public class AnimatedSprite : IDrawable, IUpdateable
    {
        private readonly Dictionary<string, Animation> _animations;
        private readonly string _currentAnimation;
        private int _drawOrder;
        private bool _enabled = true;
        private readonly TextureAtlas _textureAtlas;
        private int _updateOrder;
        private bool _visible = true;

        public AnimatedSprite(string atlas, IEnumerable<Animation> animations)
        {
            if (animations?.Any() == false) throw new ArgumentException(nameof(animations));

            if (string.IsNullOrEmpty(atlas)) throw new ArgumentNullException(nameof(atlas));

            _textureAtlas = new TextureAtlas(atlas);
            _animations = animations.ToDictionary(a => a.Name, a => a);
            _currentAnimation = animations.First().Name;
        }

        public Vector2 Position { get; set; } = Vector2.Zero;

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

        public void SetAnimation(string animation)
        {
            _animations[_currentAnimation].Reset();
            if (!_animations.TryGetValue(animation, out var anim))
            {
                throw new ArgumentException(nameof(animation));
            }
            
            anim.Reset();
        }

        public void Draw(GameTime gameTime)
        {
            if (!Visible) return;

            var batch = GameCore.Game.Services.GetService<SpriteBatch>();

            var currentAnimation = _animations[_currentAnimation];
            var frame = currentAnimation.Frame;
            var atlasFrame = _textureAtlas[frame.Name];

            batch.Draw(_textureAtlas.Texture, Position, atlasFrame, Color.White, 0f, Vector2.Zero, Vector2.One,
                SpriteEffects.None, 0f);
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
            _animations[_currentAnimation].Update(gameTime);
        }
    }
}