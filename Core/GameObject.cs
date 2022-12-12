using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace MossBoy.Core;

public abstract class GameObject : IEntity
{
    public Vector2 Velocity;
    public IShapeF Bounds { get; protected set; }

    protected Vector2 originalPosition;

    protected Texture2D Texture;

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Bounds.Position, Color.White);
    }
    public virtual void Update(GameTime gameTime)
    {
        Bounds.Position += Velocity * gameTime.GetElapsedSeconds();
    }
    public virtual void Reset()
    {
        Bounds.Position = originalPosition;
    }
    public virtual void OnCollision(CollisionEventArgs collisionInfo)
    {
        Bounds.Position -= collisionInfo.PenetrationVector;
    }
}
