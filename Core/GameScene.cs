using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System.Collections.Generic;
namespace PlatformerGame.Core
{
    public class GameScene
    {
        internal bool drawScreen = false;
        Player player;
        List<Block> blocks;
        CollisionComponent collisionComponent = new (new RectangleF(0, 0, Configuration.windowSize.X, Configuration.windowSize.Y));
        public GameScene(int level)
        {
            player = new(new(0, 1), new RectangleF(50, 100, 50, 50));
            blocks = new()
            {
                new(new RectangleF(100, 300, 100, 20)),
                new(new RectangleF(300, 100, 400, 20)),
                new(new RectangleF(300, 400, 400, 20)),

                new(new RectangleF(0, Configuration.windowSize.Y - 20, Configuration.windowSize.X, 20)),
                //new(new RectangleF(0, 0, Configuration.windowSize.X, 20)),
                
                new(new RectangleF(-20, 0, 25, Configuration.windowSize.Y)),
                new(new RectangleF(Configuration.windowSize.X - 5, 0, 25, Configuration.windowSize.Y)),
            };
        }
        public void Initialize()
        {
            collisionComponent.Insert(player);
            blocks.ForEach(block => collisionComponent.Insert(block));
        }

        public void TextPopUp(int time, string text)
        {
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            blocks.ForEach(block => block.Draw(spriteBatch));
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            blocks.ForEach(block => block.Update(gameTime));
            collisionComponent.Update(gameTime);

        }
    }
}
