using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.EasyInput;

namespace PlatformerGame.Core;

public class Button
{
    protected Vector2 position;
    protected Texture2D texture;
    protected int level;

    protected bool active = false;
    public Button(int lvl) => level = lvl;
    public void Initalize()
    {
        texture = Game1.self.textures["button"];
        position = new(level * 200, 200);
    }
    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, EnteredButton() ? Color.DarkBlue : Color.White);
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
    public virtual void Activate()
    {
        active = true;
        Game1.self.mouse.OnMouseButtonPressed += OnClick;
    }
    public void Deactivate()
    {
        active = false;
        Game1.self.mouse.OnMouseButtonPressed -= OnClick;
    }
    protected void Action()
    {
        Game1.self.machine.Play(level);
    }
}