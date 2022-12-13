using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MossBoy;

namespace PlatformerGame.UI;

public class HomeScreen : Menu
{
    protected Texture2D back;
    public HomeScreen()
    {
        buttons = new()
        {
            new PlayButton(new Vector2(100, 100))
        };
    }
    public new void Initialize()
    {
        back = Game1.self.textures["menubackground"];
        base.Initialize();
    }
    public new void Draw(SpriteBatch spriteBatch)
    {
        if (!isActive) return;
        spriteBatch.Draw(back, new Vector2(0, 0), Color.White);
        base.Draw(spriteBatch);
    }
}
