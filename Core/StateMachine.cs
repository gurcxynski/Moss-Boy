namespace MossBoy.Core;

public class StateMachine
{
    public enum GameState
    {
        HomeScreen,
        Running,
        GameWon,
        GameLost,
        Paused,
        Drawing
    }
    public GameState state;
    public void UpdateStatus()
    {
        if (Game1.self.activeScene is not null && !Game1.self.activeScene.EnemiesLeft() && state == GameState.Running)
        {
            NextLevel();
        }
        if (state == GameState.GameLost && !Game1.self.activeScene.drawScreen)
        {
            ToStartMenu();
        }
        if (state == GameState.Drawing && !Game1.self.activeScene.drawScreen)
        {
            Game1.self.activeScene.waveLevel++;
            Game1.self.activeScene.SpawnWave();
            state = GameState.Running;
        }
    }

    void NextLevel()
    {
        Game1.self.activeScene.TextPopUp(1500, Game1.self.textures["wave"]);
        state = GameState.Drawing;
    }

    public bool GameOver()
    {
        if (state != GameState.Running) return false;
        Game1.self.activeScene.TextPopUp(1500, Game1.self.textures["gameover"]);
        state = GameState.GameLost;
        return false;
    }
    public bool ToStartMenu()
    {
        Game1.self.activeScene.Clear();
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
        state = GameState.Paused;
        Game1.self.pauseMenu.Activate();
    }

    internal void Resume()
    {
        state = GameState.Running;
        Game1.self.pauseMenu.Deactivate();
    }
}