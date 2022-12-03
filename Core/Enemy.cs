using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System;

namespace MossBoy.Core
{
    internal class Enemy : GameObject
    {
        public Enemy()
        {
            var random = new Random();
            var type = random.Next(65, 68);
            var x = random.Next(10, 300);
            var y = random.Next(10, 300);
            Texture = Game1.self.textures[$"enemy{(char)type}"];
            Bounds = new RectangleF(x, y, Texture.Width, Texture.Height);
        }
        public override void OnCollision(CollisionEventArgs collisionInfo)
        {
            if (collisionInfo.Other.GetType() == typeof(Bullet))
            {
                Game1.self.activeScene.Remove(this);
                Game1.self.activeScene.Remove((GameObject)collisionInfo.Other);
            }
        }
    }
}