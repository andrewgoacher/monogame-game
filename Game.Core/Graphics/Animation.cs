using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Game.Core.Graphics
{
    public class Animation : IUpdateable
    {
        private readonly AnimationFrame[] _frames;

        private int _currentFrameIndex;
        private double _currentFrameTime;
        private bool _enabled = true;
        private int _updateOrder;

        public Animation(string name, IEnumerable<AnimationFrame> frames)
        {
            Name = name;
            _frames = frames.ToArray();
        }

        public string Name { get; }
        public bool Loops { get; set; } = true;

        public bool Enabled
        {
            get => _enabled;
            private set
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

        public AnimationFrame Frame => _frames[_currentFrameIndex];

        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;


        public void Update(GameTime gameTime)
        {
            if (!Enabled) return;

            var currentFrame = _frames[_currentFrameIndex];

            _currentFrameTime +=  gameTime.ElapsedGameTime.TotalMilliseconds;
            if (!(_currentFrameTime >= currentFrame.Duration)) return;

            _currentFrameIndex += 1;
            if (_currentFrameIndex >= _frames.Length)
            {
                if (Loops)
                    _currentFrameIndex = 0;
                else
                    Enabled = false;
            }

            _currentFrameTime = 0f;
        }

        public void Reset()
        {
            Enabled = true;
            _currentFrameIndex = 0;
            _currentFrameTime = 0f;
        }
    }
}