using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System;

namespace MossBoy.Core
{
    internal class Enemy : GameObject
    {
        double lastTurned = 0;
        int turnTimer = 0;
        public Enemy()
        {
            var random = new Random();
            var type = random.Next(65, 68);
            var x = random.Next(20, (int)Configuration.windowSize.X - 20);
            var y = random.Next(20, (int)Configuration.windowSize.Y - 20);
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
            if (collisionInfo.Other.GetType() == typeof(Player))
            {
                Game1.self.activeScene.player.Hit();
            }
        }
        public override void Update(GameTime updateTime)
        {
            if (updateTime.TotalGameTime.TotalSeconds - lastTurned > turnTimer)
            {
                var rand = new Random();
                var relative = (Game1.self.activeScene.player.Bounds.Position - Bounds.Position);
                var vel = relative / relative.Length() * Configuration.EnemyVel;
                Velocity = vel;
                lastTurned = updateTime.TotalGameTime.TotalSeconds;
                turnTimer = rand.Next(1, 3);
            }
            base.Update(updateTime);
        }
    }
}