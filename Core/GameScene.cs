using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;

namespace PlatformerGame.Core
{
    public class GameScene
    {
        internal bool drawScreen = false;
        Player player;
        Block block;
        Block block2;
        Block ground;
        CollisionComponent collisionComponent = new (new RectangleF(0, 0, Configuration.windowSize.X, Configuration.windowSize.Y));
        public GameScene(int level)
        {
            player = new(new(0, 1), new RectangleF(50, 100, 100, 100));
            block = new(new RectangleF(100, 300, 100, 50));
            block2 = new(new RectangleF(300, 100, 400, 50));
            ground = new(new RectangleF(0, Configuration.windowSize.Y - 20, Configuration.windowSize.X, 20));
        }

        internal void Initialize()
        {
            collisionComponent.Insert(player);
            collisionComponent.Insert(block);
            collisionComponent.Insert(block2);
            collisionComponent.Insert(ground);
        }

        internal void TextPopUp(int time, string text)
        {
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            block.Draw(spriteBatch);
            block2.Draw(spriteBatch);
            ground.Draw(spriteBatch);
        }

        internal void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            block.Update(gameTime);
            block2.Update(gameTime);
            ground.Update(gameTime);
            collisionComponent.Update(gameTime);
        }
    }
}
