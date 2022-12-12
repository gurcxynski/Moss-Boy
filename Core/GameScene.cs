using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System.Collections.Generic;

namespace MossBoy.Core;

public class GameScene
{
    internal bool drawScreen = false;
    List<GameObject> gameObjects;
    List<Block> blocks;
    public Player player;
    CollisionComponent collisionComponent = new (new RectangleF(-20, -20, Configuration.windowSize.X + 40, Configuration.windowSize.Y + 40));
    public GameScene()
    {
        player = new();
        gameObjects = new() { player };

        SpawnWave();

        blocks = new()
        {
            new(new RectangleF(-20, -20, Configuration.windowSize.X + 40, 20)), // upper

            new(new RectangleF(-20, -20, 20, Configuration.windowSize.Y + 40)), // left

            new(new RectangleF(Configuration.windowSize.X, -20, 20, Configuration.windowSize.Y + 40)), // right
            
            new(new RectangleF(-20, Configuration.windowSize.Y, Configuration.windowSize.X + 40, 20)), // down
        };
    }

    void SpawnWave()
    {
        gameObjects.Add(new Enemy(1));
        gameObjects.Add(new Enemy(1));
        gameObjects.Add(new Enemy(1));
        gameObjects.Add(new Enemy(1));
        gameObjects.Add(new Enemy(1));
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

    internal bool EnemiesLeft()
    {
        return gameObjects.FindAll(item => item.GetType() == typeof(Enemy)).Count > 0;
    }

    internal void Clear()
    {
        collisionComponent.Dispose();
        Game1.self.mouse.OnMouseButtonPressed = null;
    }

    internal void Reset()
    {
        gameObjects.ForEach(item => item.Reset());
    }
}
