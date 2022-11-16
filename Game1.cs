using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.EasyInput;
using MonoGame.Extended;
using PlatformerGame.Core;
using System.Collections.Generic;

namespace PlatformerGame;
public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public static Game1 self;

    public EasyMouse mouse;
    public EasyKeyboard keyboard;

    public Dictionary<string, Texture2D> textures;

    public HomeScreen homeScreen; 
    public GameScene activeScene;
    public StateMachine machine;

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
        _graphics.ApplyChanges();

        mouse = new();
        keyboard = new();

        machine = new();

        homeScreen = new();
        homeScreen.Activate();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        textures = new()
        {
            ["menubackground"] = Content.Load<Texture2D>("menu"),
            ["button"] = Content.Load<Texture2D>("button"),
            ["player"] = Content.Load<Texture2D>("player"),
            ["dodge"] = Content.Load<Texture2D>("dodge"),
        };

        homeScreen.Initialize();
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        mouse.Update();
        keyboard.Update();

        activeScene?.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        homeScreen.Draw(_spriteBatch);
        activeScene?.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}