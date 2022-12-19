using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MossBoy.UI;

public abstract class Menu
{
    protected List<Button> buttons { get; init; }
    protected bool isActive = false;
    public Vector2 Position;
    public void Initialize()
    {
        buttons.ForEach(button => button.Initialize());
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        if (!isActive) return;
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