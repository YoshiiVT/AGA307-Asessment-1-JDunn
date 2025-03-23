using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIManager : Singleton<UIManager>
{
    public TMP_Text scoreText;
    public TMP_Text enemyCount;
    public TMP_Text difficulty;

    [SerializeField]
    private Canvas pausedScreen;

    private void Start()
    {
        pausedScreen.gameObject.SetActive(false);
        UpdateScore();
        UpdateEnemyCount();

    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + _GM.Score;
    }

    public void UpdateEnemyCount()
    {
        enemyCount.text = "Enemies Left :" + _EM.EnemyCount;
    }

    public void UpdateDifficulty()
    {
        difficulty.text = "[" + _GM.difficulty.ToString() + " Mode]";
    }

    public void PauseScreen()
    {
        if (!(_GM.gameState == GameState.Paused))
        {
            print("Gamestate was not paused");
            pausedScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            pausedScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
