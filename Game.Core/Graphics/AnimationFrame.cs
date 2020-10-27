using System;

namespace Game.Core.Graphics
{
    public class AnimationFrame
    {
        public AnimationFrame(string name, float duration)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (duration <= 0f)
            {
                throw new ArgumentException(nameof(duration));
            }
            
            Name = name;
            Duration = duration;
        }

        public string Name { get; }
        public float Duration { get; }
    }
}