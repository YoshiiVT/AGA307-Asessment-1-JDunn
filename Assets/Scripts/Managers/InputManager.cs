using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    public string killCondition = "a";

    [SerializeField]
    private FiringPoint firingPoint;

    private void Update()
    {
        if (!(_GM.gameState == GameState.Paused))
        {
            if (Input.GetKeyDown(KeyCode.K))
                _EM.KillRandomEnemy();
            if (Input.GetKeyDown(KeyCode.J))
                _EM.KillSpecificEnemy(killCondition);
            if (Input.GetKeyDown(KeyCode.H))
                _EM.KillAllEnemies();
            if (Input.GetKeyDown(KeyCode.I))
                _EM.SpawnEnemy();

            if (Input.GetButtonDown("Fire1"))
            {
                firingPoint.FireProjectile();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!(_GM.gameState == GameState.Paused))
            {
                print("Pausing Game");
                _GM.gameState = GameState.Paused;
                _UI.PauseScreen();
            }
            else
            {
                print("Playing Game");
                _GM.gameState = GameState.Playing;
                _UI.PauseScreen();
            }
        }

    }
}
