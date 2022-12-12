﻿using Microsoft.Xna.Framework;
using MossBoy.Core;
using PlatformerGame.Buttons;

namespace PlatformerGame.Core;

public class HomeScreen : Menu
{
    public HomeScreen() 
    {
        buttons = new()
        {
            new PlayButton(new Vector2(100, 100))
        };
    }
}
