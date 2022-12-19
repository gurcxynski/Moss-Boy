using Microsoft.Xna.Framework;
using MossBoy.Core;

namespace MossBoy.UI;

public class LevelUpMenu : Menu
{
    public LevelUpMenu()
    {
        var basepos = Configuration.windowSize / 2;

        buttons = new()
        {
            new HitPointButton(basepos - new Vector2(100, 20)),
            new DamageButton(basepos + new Vector2(30, -20)),
        };
    }
}
