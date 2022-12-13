using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.EasyInput;
using MossBoy;

namespace PlatformerGame.UI;

public abstract class Button
{
    protected Vector2 position;
    protected Texture2D texture;

    protected bool active = false;
    public Button(Vector2 pos)
    {
        position = pos;
    }
    public virtual void Initialize()
    {
        texture = Game1.self.textures["button"];
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, EnteredButton() ? Color.PeachPuff : Color.White);
    }
    protected bool EnteredButton()
    {
        if (Game1.self.mouse.Position.X < position.X + texture.Width &&
                Game1.self.mouse.Position.X > position.X &&
                Game1.self.mouse.Position.Y < position.Y + texture.Height &&
                Game1.self.mouse.Position.Y > position.Y) return true;
        return false;
    }
    public void OnClick(MouseButtons button)
    {
        if (EnteredButton() && active && button == MouseButtons.Left)
        {
            Action();
        }
    }
    public void Activate()
    {
        active = true;
        Game1.self.mouse.OnMouseButtonPressed += OnClick;
    }
    public void Deactivate()
    {
        active = false;
        Game1.self.mouse.OnMouseButtonPressed -= OnClick;
    }
    protected abstract void Action();
}