using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace PlatformerGame.Core
{
    public class Bullet : IEntity
    {
        public Bullet(IShapeF bounds, Vector2 velocity) : base(bounds, velocity)
        {

        }
        public new void Initialize()
        {

        }
        new public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Yellow, 3);
        }
    }
}
