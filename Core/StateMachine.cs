using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformerGame.Core;

public class StateMachine
{
    public enum GameState
    {
        Running,
        GameWon,
        GameLost,
        HomeScreen
    }
    public GameState state;
    public void UpdateStatus()
    {
        if (state == GameState.GameWon && !Game1.self.activeScene.drawScreen)
        {
            ToStartMenu();
        }
        if (state == GameState.GameLost && !Game1.self.activeScene.drawScreen)
        {
            ToStartMenu();
        }
    }
    public bool GameOver()
    {
        if (state != GameState.Running) return false;
        Game1.self.activeScene.TextPopUp(2000, "YOU LOSE");
        state = GameState.GameLost;
        return false;
    }
    public bool GameWon()
    {
        if (state != GameState.Running) return false;
        Game1.self.activeScene.TextPopUp(2000, "YOU WIN");
        state = GameState.GameWon;
        return false;
    }
    public bool ToStartMenu()
    {
        state = GameState.HomeScreen;
        Game1.self.homeScreen.Activate();
        return false;
    }
    public void Play(int arg)
    {
        Game1.self.homeScreen.Deactivate();
        Game1.self.activeScene = new(1);
        Game1.self.activeScene.Initialize();
        state = GameState.Running;
    }
}