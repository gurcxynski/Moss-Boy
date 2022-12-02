using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System.Diagnostics;

namespace MossBoy.Core;

public class Player : GameObject
{
    double lastShot = 0;
    public Player() : base()
    {
        Texture = Game1.self.textures["player"];
        Bounds = new RectangleF(50, 100, Texture.Width, Texture.Height);
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
        if (Game1.self.keyboard.IsPressed(Keys.Up))
        {
            Velocity.Y = -Configuration.playerMove;
        }
        if (Game1.self.keyboard.IsPressed(Keys.Down))
        {
            Velocity.Y = Configuration.playerMove;
        }
        if (Game1.self.mouse.IsPressed(MonoGame.EasyInput.MouseButtons.Left)) 
        { 
            Shoot(gameTime); 
        }
        Velocity *= Configuration.dampening;
        base.Update(gameTime);
    }
    public void Shoot(GameTime time)
    {
        if (time.TotalGameTime.TotalSeconds - lastShot < 0.3) return;
        var relative = Game1.self.mouse.Position - Bounds.Position;
        var velocity = relative / relative.Length() * Configuration.bulletSpeed;
        var bullet = new Bullet(new RectangleF((int)Bounds.Position.X, (int)Bounds.Position.Y, 10, 10), velocity);
        Game1.self.activeScene.AddBullet(bullet);
        lastShot = time.TotalGameTime.TotalSeconds;
    }
    public override void OnCollision(CollisionEventArgs collisionInfo)
    {
        if (collisionInfo.Other.GetType() == typeof(Bullet)) return;
        base.OnCollision(collisionInfo);
    }
    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Texture, Bounds.Position, Color.White);
    }
}