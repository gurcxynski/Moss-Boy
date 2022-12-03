using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace MossBoy.Core;

public class Bullet : GameObject
{

    public Bullet(RectangleF bounds, Vector2 vel) : base()
    {
        Bounds = bounds;
        Velocity = vel;
    }
    override public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Yellow, 3);
    }
}
