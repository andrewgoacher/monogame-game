using System.Collections.Generic;

namespace Game.Core.UI.Controls
{
    public abstract class ContainerBase : ControlBase
    {
        private readonly HashSet<ControlBase> _controls;

        public ContainerBase()
        {
            _controls = new HashSet<ControlBase>();
        }

        public IEnumerable<ControlBase> Children => _controls;

        public void AddChild(ControlBase control)
        {
            _controls.Add(control);
            control.UserInterface = UserInterface;
            control.OnAdd(this);
            Reconfigure(ParentBounds);
        }

        public void RemoveChild(ControlBase control)
        {
            _controls.Remove(control);
            control.OnRemove(this);
        }
    }
}