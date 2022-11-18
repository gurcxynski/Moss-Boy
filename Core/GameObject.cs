using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System.Diagnostics;

namespace PlatformerGame.Core
{
    public abstract class GameObject : IEntity
    {
        public Vector2 Velocity;
        public IShapeF Bounds { get; private set; }

        public GameObject(IShapeF bounds, Vector2 velocity)
        {
            Velocity = velocity;
            Bounds = bounds;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Red, 3);
        }
        public virtual void Initialize()
        {

        }
        public virtual void Shoot(Vector2 pos)
        {
            var bullet = new Bullet(new RectangleF((int)pos.X, (int)pos.Y, 10, 10), new (10, 0));
            Game1.self.activeScene.AddBullet(bullet);
        }
        public virtual void Update(GameTime gameTime)
        {
            Velocity.Y += Configuration.gravity;
            Bounds.Position += Velocity * gameTime.GetElapsedSeconds() * 50;
        }

        public virtual void OnCollision(CollisionEventArgs collisionInfo)
        {
            Bounds.Position -= collisionInfo.PenetrationVector;
        }
    }
}
