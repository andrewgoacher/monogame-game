using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Core.UI.Controls
{
    public class Panel : ContainerBase
    {
        public IBackground Background { get; set; }

        protected override void OnReconfigureBounds(Rectangle re)
        {
            Background?.Reconfigure(re);
            foreach (var child in Children) child.Reconfigure(re);
        }

        public override bool Equals(ControlBase other)
        {
            if (!(other is Panel otherPanel)) return false;

            return Equals(Children, otherPanel.Children) &&
                   Enabled == otherPanel.Enabled &&
                   Visible == otherPanel.Visible &&
                   Equals(Background, otherPanel.Background);
        }

        protected override void OnDraw(GameTime gameTime, SpriteBatch batch)
        {
            Background?.Draw(batch);

            foreach (var child in Children) child.Draw(gameTime, batch);
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            foreach (var child in Children) child.Update(gameTime);
        }
    }
}