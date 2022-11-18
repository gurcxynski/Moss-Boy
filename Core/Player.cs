using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System.Diagnostics;

namespace PlatformerGame.Core;

public class Player : GameObject
{
    protected bool inAir = false;
    public Player(IShapeF bounds, Vector2 velocity) : base(bounds, velocity)
    {
    }
    public new void Update(GameTime gameTime)
    {
        if (Game1.self.keyboard.IsPressed(Keys.Left))
        {
            Velocity.X = -Configuration.playerMove;
        }
        if (Game1.self.keyboard.IsPressed(Keys.Right))
        {
            Velocity.X = Configuration.playerMove;
        }
        if (Game1.self.keyboard.IsPressed(Keys.Up) && !inAir)
        {
            Velocity.Y = -Configuration.playerJump;
            inAir = true;
        }
        if (Game1.self.keyboard.IsPressed(Keys.Space))
        {
            Shoot(Bounds.Position);
        }
        Velocity *= Configuration.dampening;
        base.Update(gameTime);
    }
    public override void OnCollision(CollisionEventArgs collisionInfo)
    {
        if (collisionInfo.PenetrationVector.X == 0 && Velocity.Y > 0) inAir = false;
        base.OnCollision(collisionInfo);
    }
}