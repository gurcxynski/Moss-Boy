using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using PlatformerGame.Enemies;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MossBoy.Core;

public class GameScene
{
    internal bool drawScreen = false;
    List<GameObject> gameObjects;
    List<Block> blocks;
    public Player player;
    CollisionComponent collisionComponent = new (new RectangleF(-20, -20, Configuration.windowSize.X + 40, Configuration.windowSize.Y + 40));
    internal int waveLevel = 0;

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

    public void SpawnWave()
    {
        List<Enemy> toAdd = new();
        Random rand = new Random();
        var a = rand.Next(5, 5 * (waveLevel + 1));
        var b = rand.Next(3, 3 * (waveLevel + 1));
        var c = rand.Next(waveLevel);
        for (int _ = 0; _ < a; _++)
        {
            toAdd.Add(new Enemy('A'));
        }
        for (int _ = 0; _ < b; _++)
        {
            toAdd.Add(new Enemy('B'));
        }
        for (int _ = 0; _ < c; _++)
        {
            toAdd.Add(new Enemy('C'));
        }
        Debug.WriteLine($"spawned {a}, {b}, {c}");
        toAdd.ForEach(item => collisionComponent.Insert(item));
        gameObjects.AddRange(toAdd);
        player.Bounds.Position = Configuration.startPos;
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
        if (Game1.self.machine.state != StateMachine.GameState.Running) return;
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
