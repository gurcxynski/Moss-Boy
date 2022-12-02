using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace MossBoy.Core;

public abstract class GameObject : IEntity
{
    public Vector2 Velocity;
    public IShapeF Bounds { get; protected set; }

    protected Texture2D Texture;

    public GameObject()
    {

    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        //spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Red, 3);
    }
    public virtual void Initialize()
    {

    }
    public virtual void Update(GameTime gameTime)
    {
        Bounds.Position += Velocity * gameTime.GetElapsedSeconds();
    }

    public virtual void OnCollision(CollisionEventArgs collisionInfo)
    {
        Bounds.Position -= collisionInfo.PenetrationVector;
    }
}
