using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System.Collections.Generic;
using System.Diagnostics;

namespace MossBoy.Core;

public class GameScene
{
    internal bool drawScreen = false;
    List<GameObject> gameObjects;
    List<Block> blocks;
    CollisionComponent collisionComponent = new (new RectangleF(-20, -20, Configuration.windowSize.X + 40, Configuration.windowSize.Y + 40));
    public GameScene(int level)
    {
        gameObjects = new()
        {
            new Player(),
            new Enemy(),
            new Enemy(),
            new Enemy(),
            new Enemy(),
            new Enemy(),
        };
        blocks = new()
        {
            new(new RectangleF(-20, -20, Configuration.windowSize.X + 40, 20)), // upper

            new(new RectangleF(-20, -20, 20, Configuration.windowSize.Y + 40)), // left

            new(new RectangleF(Configuration.windowSize.X, -20, 20, Configuration.windowSize.Y + 40)), // right
            
            new(new RectangleF(-20, Configuration.windowSize.Y, Configuration.windowSize.X + 40, 20)), // down
        };
    }
    public void Initialize()
    {
        gameObjects.ForEach(item => collisionComponent.Insert(item));
        blocks.ForEach(block => collisionComponent.Insert(block));
    }

    public void TextPopUp(int time, string text)
    {
        
    }
    public void Add(GameObject item)
    {
        gameObjects.Add(item);
        collisionComponent.Insert(item);
    }
    internal void Remove(GameObject item)
    {
        Debug.WriteLine(item.GetType());
        gameObjects.Remove(item);
        collisionComponent.Remove(item);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        gameObjects.ForEach(item => item.Draw(spriteBatch));
        blocks.ForEach(block => block.Draw(spriteBatch));
    }

    public void Update(GameTime gameTime)
    {
        gameObjects.ForEach(item => item.Update(gameTime));
        blocks.ForEach(block => block.Update(gameTime));
        collisionComponent.Update(gameTime);
    }

}
