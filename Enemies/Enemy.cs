using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using MossBoy;
using MossBoy.Core;
using System;

namespace PlatformerGame.Enemies;

internal class Enemy : GameObject
{
    protected double lastTurned = 0;
    protected int turnTimer = 0;
    protected int HP;
    protected int expValue;
    int baseSpeed;
    public Enemy(char type)
    {
        baseSpeed = Configuration.enemySpeed[type - 65];
        var random = new Random();
        var x = random.Next(20, (int)Configuration.windowSize.X - 20);
        var y = random.Next(20, (int)Configuration.windowSize.Y - 300); 
        originalPosition = new(x, y);
        Texture = Game1.self.textures["enemy" + type.ToString().ToUpper()];
        Bounds = new RectangleF(originalPosition, new Point(Texture.Width, Texture.Height));
        HP = Configuration.enemyHP[type - 65];
        expValue = (type - 64) * 10;
    }
    public override void OnCollision(CollisionEventArgs collisionInfo)
    {
        if (collisionInfo.Other.GetType() == typeof(Bullet))
        {
            HP -= Configuration.playerDMG;
            Game1.self.activeScene.Remove((GameObject)collisionInfo.Other);
            if (HP <= 0)
            {
                Game1.self.activeScene.Remove(this);
                Game1.self.activeScene.player.GainXP(expValue);
            }
        }
        if (collisionInfo.Other.GetType() == typeof(Player))
        {
            Game1.self.activeScene.Reset();
            Game1.self.activeScene.player.Hit();
        }
        if (collisionInfo.Other.GetType() == typeof(Block))
        {
            UpdateVelocity();
        }
    }
    public override void Update(GameTime updateTime)
    {
        if (updateTime.TotalGameTime.TotalSeconds - lastTurned > turnTimer)
        {
            UpdateVelocity();
            lastTurned = updateTime.TotalGameTime.TotalSeconds;
        }
        base.Update(updateTime);
    }
    protected void UpdateVelocity()
    {
        var rand = new Random();
        var relative = Game1.self.activeScene.player.Bounds.Position - Bounds.Position;
        var vel = relative / relative.Length() * baseSpeed;
        Velocity = vel;
        turnTimer = rand.Next(1, 3);
    }
    public override void Reset()
    {
        UpdateVelocity();
        base.Reset();
    }
}