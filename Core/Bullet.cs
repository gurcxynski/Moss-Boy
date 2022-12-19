using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace MossBoy.Core;

public class Bullet : GameObject
{
    public Bullet(Vector2 pos, Vector2 vel) : base()
    {
        Bounds = new RectangleF(pos, new Size2(7, 7));
        Velocity = vel;
    }
    override public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.FillRectangle((RectangleF)Bounds, Color.Red);
    }
}
