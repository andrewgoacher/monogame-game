using Microsoft.Xna.Framework;

namespace Game.Core.UI
{
    public static class RectangleConfigureExtensions
    {
        public static Rectangle Configure(this Rectangle vp, Rectangle bounds)
        {
            var (vpx, vpy, _, _) = vp;
            var (bx, by, bw, bh) = bounds;

            var offsetX = vpx + bx;
            var offsetY = vpy + by;

            if (offsetX > vp.Right) offsetX = vpx;

            if (offsetY > bounds.Bottom) offsetY = vpy;

            var width = bw;
            var height = bh;

            if (offsetX + width > vp.Right) width = vp.Right - offsetX;

            if (offsetY + height > vp.Bottom) height = vp.Bottom - offsetY;

            return new Rectangle(
                offsetX, offsetY,
                width,
                height
            );
        }
    }
}