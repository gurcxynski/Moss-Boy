using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System;

namespace MossBoy.Core;

internal class Enemy : GameObject
{
    double lastTurned = 0;
    int turnTimer = 0;
    int HP;
    public Enemy(int type)
    {
        var random = new Random();
        var x = random.Next(20, (int)Configuration.windowSize.X - 20);
        var y = random.Next(20, (int)Configuration.windowSize.Y - 300);
        originalPosition = new(x, y);
        switch (type)
        {
            case 1:
                Texture = Game1.self.textures[$"enemyA"];
                HP = 5; 
                break;
            case 2:
                Texture = Game1.self.textures[$"enemyB"];
                HP = 7;
                break;
            case 3:
                Texture = Game1.self.textures[$"enemyC"];
                HP = 10;
                break;
        }
        Bounds = new RectangleF(x, y, Texture.Width, Texture.Height);
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
                Game1.self.activeScene.player.GainXP();
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
    void UpdateVelocity()
    {
        var rand = new Random();
        var relative = (Game1.self.activeScene.player.Bounds.Position - Bounds.Position);
        var vel = relative / relative.Length() * Configuration.EnemyVel;
        Velocity = vel;
        turnTimer = rand.Next(1, 3);
    }
    public override void Reset()
    {
        UpdateVelocity();
        base.Reset();
    }
}