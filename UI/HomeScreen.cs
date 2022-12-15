using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MossBoy;
using MossBoy.Core;

namespace MossBoy.UI;

public class HomeScreen : Menu
{
    protected Texture2D back;
    public HomeScreen()
    {
        buttons = new()
        {
            new PlayButton(Configuration.windowSize / 2 - new Vector2(70, 70)),
        };
    }
    public new void Initialize()
    {
        back = Game1.self.textures["menubackground"];
        Position = new((Configuration.windowSize.X - back.Width) / 2, 10);
        base.Initialize();
    }
    public new void Draw(SpriteBatch spriteBatch)
    {
        if (!isActive) return; 
        spriteBatch.Draw(back, Position, Color.White);
        base.Draw(spriteBatch);
    }
}
