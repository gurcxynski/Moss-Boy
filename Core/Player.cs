using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System.Diagnostics;

namespace PlatformerGame.Core;

public class Player : GameObject
{
    public Player(Vector2 velocity, IShapeF bounds) : base(velocity, bounds)
    {
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
            Debug.WriteLine(Velocity.Y);
            if(Velocity.Y < 3 && Velocity.Y > -3) Velocity.Y = -Configuration.playerJump;
        }
        Velocity *= Configuration.dampening;
        base.Update(gameTime);
    }
}