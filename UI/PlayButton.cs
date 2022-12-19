using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace MossBoy.UI
{
    public class PlayButton : Button
    {
        public PlayButton(Vector2 pos) : base(pos)
        {
            position = pos;
        }
        override public void Initialize()
        {
            texture = Game1.self.textures["startbutton"];
        }
        override protected void Action()
        {
            Debug.WriteLine("oeeoeoe");
            Game1.self.machine.Play();
        }
    }
}
