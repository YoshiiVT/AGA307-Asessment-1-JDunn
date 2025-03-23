using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : Singleton<ButtonManager>
{
    public void Resume()
    {
        _GM.gameState = GameState.Playing;
        _UI.PauseScreen();
    }

    public void MainMenu()
    {
        _GM.gameState = GameState.Start;
        Time.timeScale = (1);
        _GM.Score = 0;
        SceneManager.LoadScene("TitleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        _GM.gameState = GameState.Playing;
        SceneManager.LoadScene("MainScene");
    }

    public void Easy()
    {
        _GM.difficulty = Difficulty.Easy;
        _UI.UpdateDifficulty();
    }

    public void Medium()
    {
        _GM.difficulty = Difficulty.Medium;
        _UI.UpdateDifficulty();
    }

    public void Hard()
    {
        _GM.difficulty = Difficulty.Hard;
        _UI.UpdateDifficulty();
    }
}
