using Microsoft.Xna.Framework;

namespace Game.Core
{
    public static class RectangleExtensions
    {
        public static bool Intersects(this Rectangle rect, Point p)
        {
            return p.X >= rect.X && p.X <= rect.Right &&
                   p.Y >= rect.Y && p.Y <= rect.Bottom;
        }
    }
}