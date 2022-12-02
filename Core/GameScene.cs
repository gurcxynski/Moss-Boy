using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System;
using System.Collections.Generic;
namespace MossBoy.Core
{
    public class GameScene
    {
        internal bool drawScreen = false;
        Player player;
        List<Block> blocks;
        public List<Bullet> bullets;
        CollisionComponent collisionComponent = new (new RectangleF(-20, -20, Configuration.windowSize.X + 40, Configuration.windowSize.Y + 40));
        public GameScene(int level)
        {
            player = new();
            blocks = new()
            {
                new(new RectangleF(-20, -20, Configuration.windowSize.X + 40, 20)), // upper

                new(new RectangleF(-20, -20, 20, Configuration.windowSize.Y + 40)), // left

                new(new RectangleF(Configuration.windowSize.X, -20, 20, Configuration.windowSize.Y + 40)), // right
                
                new(new RectangleF(-20, Configuration.windowSize.Y, Configuration.windowSize.X + 40, 20)), // down
            };
            bullets = new();
        }
        public void Initialize()
        {
            collisionComponent.Insert(player);
            blocks.ForEach(block => collisionComponent.Insert(block));
        }

        public void TextPopUp(int time, string text)
        {
            
        }
        public void AddBullet(Bullet item)
        {
            bullets.Add(item);
            collisionComponent.Insert(item);
        }
        internal void RemoveBullet(Bullet item)
        {
            bullets.Remove(item);
            collisionComponent.Remove(item);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            player.Draw(spriteBatch);
            blocks.ForEach(block => block.Draw(spriteBatch));
            bullets.ForEach(bullet => bullet.Draw(spriteBatch));
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            blocks.ForEach(block => block.Update(gameTime));
            bullets.ForEach(bullet => bullet.Update(gameTime));
            collisionComponent.Update(gameTime);

        }

    }
}
