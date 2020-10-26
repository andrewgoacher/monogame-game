using Microsoft.Xna.Framework;

namespace Game.Core.Graphics
{
    internal class AtlasItem
    {
        public AtlasItem(string name, Rectangle rect)
        {
            Name = name;
            Rect = rect;
        }
        
        public string Name { get; }
        public Rectangle Rect { get; }
    }
}