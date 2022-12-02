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
    new public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Yellow, 3);
    }
    public override void OnCollision(CollisionEventArgs collisionInfo)
    {
        if (collisionInfo.Other.GetType() != typeof(Player)) Game1.self.activeScene.RemoveBullet(this);
    }
}
