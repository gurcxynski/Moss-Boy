using System;

namespace MossBoy.Core;

public class StateMachine
{
    public enum GameState
    {
        HomeScreen,
        Running,
        GameWon,
        GameLost,
        Paused
    }
    public GameState state;
    public int wave = 0;
    public void UpdateStatus()
    {
        if (Game1.self.activeScene is not null && !Game1.self.activeScene.EnemiesLeft() && state == GameState.Running){
            NextLevel();
        }
        if (state == GameState.GameWon && !Game1.self.activeScene.drawScreen)
        {
            ToStartMenu();
        }
        if (state == GameState.GameLost && !Game1.self.activeScene.drawScreen)
        {
            ToStartMenu();
        }
    }

    void NextLevel()
    {
        Game1.self.activeScene.SpawnWave();
        state = GameState.Running;
    }

    public bool GameOver()
    {
        //if (state != GameState.Running) return false;
        //Game1.self.activeScene.TextPopUp(2000, "YOU LOSE");
        //state = GameState.GameLost;
        ToStartMenu();
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
    public void Play()
    {
        Game1.self.homeScreen.Deactivate();
        Game1.self.activeScene = new();
        Game1.self.activeScene.Initialize();
        state = GameState.Running;
    }
    public void LevelUp()
    {
        Game1.self.activeScene.waveLevel++;
        state = GameState.Paused;
        Game1.self.pauseMenu.Activate();
    }

    internal void Resume()
    {
        state = GameState.Running;
        Game1.self.pauseMenu.Deactivate();
    }
}