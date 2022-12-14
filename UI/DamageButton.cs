using Microsoft.Xna.Framework;
using MossBoy.Core;

namespace MossBoy.UI
{
    internal class DamageButton : Button
    {
        public DamageButton(Vector2 pos) : base(pos)
        {
            position = pos;
        }
        override public void Initialize()
        {
            texture = Game1.self.textures["buttonDMG"];
        }
        override protected void Action()
        {
            Configuration.playerDMG += 1;
            Game1.self.machine.Resume();
        }
    }
}