using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace PlatformerGame.Core
{
    public abstract class GameObject : IEntity
    {
        public Vector2 Velocity;
        public IShapeF Bounds { get; private set; }
        bool inAir = false;

        public GameObject(Vector2 velocity, IShapeF bounds)
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
        public virtual void Update(GameTime gameTime)
        {
            Velocity.Y += Configuration.gravity;
            Bounds.Position += Velocity * gameTime.GetElapsedSeconds() * 50;
        }

        public void OnCollision(CollisionEventArgs collisionInfo)
        {
            Velocity = Vector2.Zero;

            Bounds.Position -= collisionInfo.PenetrationVector;
        }
    }
}
