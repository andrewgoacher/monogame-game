using System;
using Microsoft.Xna.Framework;

namespace Game.Core.UI
{
    public static class RectangleConfigureExtensions
    {
        public static Rectangle Configure(this Rectangle vp, Rectangle bounds)
        {
            var (vpx, vpy, vpw, vph) = vp;
            var (bx, by, bw, bh) = bounds;

            var ux = vpx + bx;
            var uy = vpy + by;

            var rx = ux < vpx ? vpx : ux;
            var ry = uy < vpy ? vpy : uy;

            return new Rectangle(
                rx, ry,
                Clamp(bw, rx, vpw),
                Clamp(bh, ry, vph)
            );

            int Clamp(int a, int b, int c)
            {
                if (a + b <= c) return a;
                var rem = c - (a + b);
                return a - rem;
            }
        }
    }
}