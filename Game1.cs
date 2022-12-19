using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.EasyInput;
using MossBoy.Core;
using MossBoy.UI;
using System.Collections.Generic;

namespace MossBoy;
public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public static Game1 self;

    public EasyMouse mouse;
    public EasyKeyboard keyboard;

    public Dictionary<string, Texture2D> textures;

    public HomeScreen homeScreen;
    public LevelUpMenu pauseMenu;
    public GameScene activeScene;
    public StateMachine machine;
    internal SpriteFont font;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        self = this;
    }


    protected override void Initialize()
    {
        _graphics.PreferredBackBufferHeight = (int)Configuration.windowSize.Y;
        _graphics.PreferredBackBufferWidth = (int)Configuration.windowSize.X;
        Window.Title = "Mossboy";
        _graphics.ApplyChanges();

        mouse = new();
        keyboard = new();

        machine = new();

        homeScreen = new();
        homeScreen.Activate();
        pauseMenu = new();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        textures = new()
        {
            ["arena"] = Content.Load<Texture2D>("arena"),
            ["menubackground"] = Content.Load<Texture2D>("menu"),
            ["button"] = Content.Load<Texture2D>("button"),
            ["buttonHP"] = Content.Load<Texture2D>("buttonHP"),
            ["buttonDMG"] = Content.Load<Texture2D>("buttonDMG"),
            ["wave"] = Content.Load<Texture2D>("wave"),
            ["player"] = Content.Load<Texture2D>("player"),
            ["bullet"] = Content.Load<Texture2D>("bullet"),
            ["enemyA"] = Content.Load<Texture2D>("enemyA"),
            ["enemyB"] = Content.Load<Texture2D>("enemyB"),
            ["enemyC"] = Content.Load<Texture2D>("enemyC"),
            ["startbutton"] = Content.Load<Texture2D>("startbutton"),
            ["gameover"] = Content.Load<Texture2D>("gameover"),
        };
        font = Content.Load<SpriteFont>("font");
        homeScreen.Initialize();
        pauseMenu.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        mouse.Update();
        keyboard.Update();

        activeScene?.Update(gameTime);

        machine.UpdateStatus();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.Draw(textures["arena"], new Rectangle(new Point(0, 0), new Point((int)Configuration.windowSize.X, (int)Configuration.windowSize.Y)), Color.White);

        homeScreen.Draw(_spriteBatch);

        if (machine.state != StateMachine.GameState.HomeScreen) activeScene?.Draw(_spriteBatch);

        pauseMenu.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}