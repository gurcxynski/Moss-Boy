using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace MossBoy.Core;

public class Block : IEntity
{
    public IShapeF Bounds { get; private set; }

    public Block(IShapeF bounds)
    {
        Bounds = bounds;
    }
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.FillRectangle((RectangleF)Bounds, Color.Black);
    }

    public void OnCollision(CollisionEventArgs collisionInfo)
    {

    }

    public virtual void Update(GameTime gameTime)
    {

    }
}
