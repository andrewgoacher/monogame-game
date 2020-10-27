using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.Graphics
{
    public class AnimatedSprite : IDrawable, IUpdateable
    {
        private readonly Dictionary<string, Animation> _animations;
        private readonly string _currentAnimation;
        private readonly TextureAtlas _textureAtlas;
        private int _drawOrder;
        private bool _enabled = true;
        private int _updateOrder;
        private bool _visible = true;

        public AnimatedSprite(string file)
        {
            if (string.IsNullOrEmpty(file)) throw new ArgumentNullException(nameof(file));

            var contentManager = GameCore.Game.Services.GetService<ContentManager>();

            using (var stream = TitleContainer.OpenStream($"{contentManager.RootDirectory}/{file}.txt"))
            {
                using (var reader = new StreamReader(stream))
                {
                    var lines = reader.ReadToEnd().Split('\n', '\r');
                    _textureAtlas = new TextureAtlas(lines[0]);
                    var animations = new List<Animation>();
                    var frames = new List<AnimationFrame>();
                    var idx = 1;
                    while (idx < lines.Length)
                    {
                        var name = lines[idx++];
                        var loops = Convert.ToBoolean(lines[idx++]);
                        var next = lines[idx++];
                        do
                        {
                            var parts = next.Split(new[] {':'});
                            frames.Add(new AnimationFrame(parts[0], Convert.ToSingle(parts[1])));
                            next = lines[idx++];
                        } while (next.Equals($"!{name}") == false);

                        animations.Add(new Animation(name, frames)
                        {
                            Loops = loops
                        });

                        frames.Clear();
                    }

                    _animations = animations.ToDictionary(a => a.Name, a => a);
                    _currentAnimation = animations.First().Name;
                }
            }
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

        public void SetAnimation(string animation)
        {
            _animations[_currentAnimation].Reset();
            if (!_animations.TryGetValue(animation, out var anim)) throw new ArgumentException(nameof(animation));

            anim.Reset();
        }
    }
}