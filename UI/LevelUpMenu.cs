using Microsoft.Xna.Framework;
using MossBoy.Core;

namespace PlatformerGame.UI;

public class LevelUpMenu : Menu
{
    public LevelUpMenu()
    {
        buttons = new()
        {
            new HitPointButton(new Vector2(100, 100)),
            new DamageButton(new Vector2(250, 100)),
        };
    }
}
