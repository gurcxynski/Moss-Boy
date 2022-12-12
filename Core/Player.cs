using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.EasyInput;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System;
using System.Diagnostics;

namespace MossBoy.Core;

public class Player : GameObject
{
    public int HP = Configuration.playerHP;
    int XP = 0;
    public Player()
    {
        Texture = Game1.self.textures["player"];
        Bounds = new RectangleF(Configuration.startPos.X, Configuration.startPos.Y, Texture.Width, Texture.Height);
        originalPosition = Configuration.startPos;
        Game1.self.mouse.OnMouseButtonPressed += OnClick;
    }
    public override void Update(GameTime gameTime)
    {
        if (Game1.self.keyboard.IsPressed(Keys.A)) Velocity.X -= Configuration.playerMove;
        if (Game1.self.keyboard.IsPressed(Keys.D)) Velocity.X += Configuration.playerMove;
        if (Game1.self.keyboard.IsPressed(Keys.W)) Velocity.Y -= Configuration.playerMove;
        if (Game1.self.keyboard.IsPressed(Keys.S)) Velocity.Y += Configuration.playerMove;

        Velocity *= Configuration.dampening;
        base.Update(gameTime);
    }
    public void Shoot()
    {
        var relative = Game1.self.mouse.Position - Bounds.Position;
        var velocity = relative / relative.Length() * Configuration.bulletSpeed;
        var bullet = new Bullet(Bounds.Position, velocity);
        Game1.self.activeScene.Add(bullet);
    }
    public void Hit()
    {
        if (--HP == 0) Game1.self.machine.GameOver();
    }
    void OnClick(MouseButtons button)
    {
        if(button == MouseButtons.Left) Shoot();
    }
    public override void OnCollision(CollisionEventArgs collisionInfo)
    {
        if (collisionInfo.Other.GetType() == typeof(Bullet) || collisionInfo.Other.GetType() == typeof(Enemy)) return;
        base.OnCollision(collisionInfo);
    }
    internal void GainXP()
    {
        XP += 20;
        if (XP == 40)
        {
            XP = 0;
            Game1.self.machine.LevelUp();
        }
    }
}