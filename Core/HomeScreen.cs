using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MossBoy.Core;

public class  HomeScreen
{
    readonly protected List<Button> buttons;

    protected bool isActive = false;

    protected Texture2D back;
    protected Texture2D title;
    public HomeScreen() => buttons = new()
    {
        new Button(1),
        new Button(2)
    };
    public virtual void Initialize()
    {
        back = Game1.self.textures["menubackground"];

        buttons.ForEach(button => button.Initalize());
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        if (!isActive) return;
        spriteBatch.Draw(back, new Vector2(0,0), Color.White);
        buttons.ForEach(delegate (Button btn) { btn.Draw(spriteBatch); });
    }
    public void Activate()
    {
        if (isActive) return;
        buttons.ForEach(delegate (Button btn) { btn.Activate(); });
        isActive = true;
    }
    public void Deactivate()
    {
        if (!isActive) return;
        buttons.ForEach(delegate (Button btn) { btn.Deactivate(); });
        isActive = false;
    }
}