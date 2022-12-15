using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;

namespace MossBoy.Core;

public class GameScene
{
    internal bool drawScreen = false;
    List<GameObject> gameObjects;
    List<Block> blocks;
    public Player player;
    CollisionComponent collisionComponent = new(new RectangleF(-20, -20, Configuration.windowSize.X + 40, Configuration.windowSize.Y + 40));
    internal int waveLevel = 0;
    Timer timer;
    Texture2D toDraw;

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
        Random rand = new();
        var a = 5 + waveLevel * (2 + waveLevel * rand.Next(3, 5));
        var b = 3 + waveLevel * (1 + waveLevel * rand.Next(1, 2));
        var c = rand.Next(0, waveLevel);
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
        Debug.WriteLine($"WAVE {waveLevel}, A: {a}, B: {b}, C: {c}");
        toAdd.ForEach(item => collisionComponent.Insert(item));
        gameObjects.AddRange(toAdd);
        player.Bounds.Position = Configuration.startPos;
    }

    public void Initialize()
    {
        gameObjects.ForEach(item => collisionComponent.Insert(item));
        blocks.ForEach(block => collisionComponent.Insert(block));
    }

    public void TextPopUp(int time, Texture2D texture)
    {
        drawScreen = true;
        timer = new(time)
        {
            Enabled = true
        };
        timer.Elapsed += TimedOut;
        toDraw = texture;
    }
    void TimedOut(object sender, ElapsedEventArgs e)
    {
        drawScreen = false;
        timer.Enabled = false;
        timer.Elapsed -= TimedOut;
        timer.Dispose();
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
        if (drawScreen)
        {
            var pos = (Configuration.windowSize - new Vector2(toDraw.Width, toDraw.Height)) / 2;
            spriteBatch.Draw(toDraw, pos, Color.White);
        }
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
