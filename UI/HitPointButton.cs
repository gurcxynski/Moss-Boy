using Microsoft.Xna.Framework;
using MossBoy;
using MossBoy.Core;

namespace MossBoy.UI
{
    internal class HitPointButton : Button
    {
        public HitPointButton(Vector2 pos) : base(pos)
        {
            position = pos;
        }
        override public void Initialize()
        {
            texture = Game1.self.textures["buttonHP"];
        }

        override protected void Action()
        {
            Configuration.playerHP += 1;
            Game1.self.activeScene.player.HP++;
            Game1.self.machine.Resume();
        }
    }
}