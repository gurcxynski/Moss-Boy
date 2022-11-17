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
            Velocity.Y = -Configuration.playerJump;
        }
        Velocity *= Configuration.dampening;
        base.Update(gameTime);
        //if (Bounds.Position.X < 0) Bounds.Position = new Vector2(0, Bounds.Position.Y);
        //if (Bounds.Position.X + 50 > Configuration.windowSize.X) Bounds.Position = new Vector2(Configuration.windowSize.X - 50, Bounds.Position.Y);
    }
}