using Microsoft.Xna.Framework;
using MossBoy;
using MossBoy.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Buttons
{
    public class PlayButton : Button
    {
        public PlayButton(Vector2 pos) : base(pos)
        {
            position = pos;
        }

        override protected void Action()
        {
            Game1.self.machine.Play();
        }
    }
}
