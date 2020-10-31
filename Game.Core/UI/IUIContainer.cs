using Microsoft.Xna.Framework;

namespace Game.Core.UI
{
    public interface IUIContainer
    {
        void AddChild(IUIElement element);
        void RemoveChild(IUIElement element);
        void Reconfigure(Rectangle re);
    }
}