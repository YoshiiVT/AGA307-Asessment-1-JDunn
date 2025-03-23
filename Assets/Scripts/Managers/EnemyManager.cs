using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public enum EnemySize
{
    Small,
    Medium,
    Large
}

public class EnemyManager : Singleton<EnemyManager>
{
    public int initialSpawnCount = 6;

    private string[] enemyNames = new string[] { "Wovok", "Kadan", "Istadum", "Stratic", "Riovok", "Pokhar", "Stigan", "Nobrum", "Soutic", "Wraexor", "Yauzius", "Utozad", "Gitic", "Zothik", "Ezaurow", "Owobrum", "Vrozor", "Grethum", "Kezad", "Hekras", "Herbert", "Azerak" };
    private string[] enemySurnames = new string[] { "the Abomination", "the Corruptor", "the Doctor", "Shade", "the Livid", "the Animator", "the Plaguemaster", "Rotheart", "the Hallowed", "Doomwhisper", "the Corrupted", "Morbide", "the Reianimator", "the Fleshrender", "Mortice", "the Crippled", "the Black", "Plasma", "Calamity", "Blight " };

    public EnemySize enemySize;
    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;
    public List<GameObject> enemies;

    public int EnemyCount => enemies.Count;

    public int EnemyScore;

    public bool NoEnemies => enemies.Count == 0;

    public Transform GetRandomSpawnPoint => spawnPoints[Random.Range(0, spawnPoints.Length)];
    private void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies() 
    {
        for (int i = 0; i < initialSpawnCount; i++) 
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        int rndEnemy = Random.Range(0, enemyTypes.Length);
        int rndSpawn = Random.Range(0, spawnPoints.Length);
        int rndName = Random.Range(0, enemyNames.Length);
        int rndSurname = Random.Range(0, enemySurnames.Length);

        int rndSize = Random.Range(0, 3);

        GameObject enemy = Instantiate(enemyTypes[rndEnemy & rndSurname], spawnPoints[rndSpawn].transform.position, spawnPoints[rndSpawn].transform.rotation);
        enemy.name = enemyNames[rndName] + " " + enemySurnames[rndSurname];
        enemy.GetComponent<Enemy>().enemySize = (EnemySize)rndSize;

        enemy.GetComponent<Enemy>().Initialize(GetRandomSpawnPoint, enemy.name);
        enemies.Add(enemy);

        print(enemies.Count);

        _UI.UpdateEnemyCount();
    }

    public void KillEnemy(GameObject _enemy)
    {
        EnemyScore = _enemy.GetComponent<Enemy>().myScore;
        Debug.Log(EnemyScore);
        DeathScore();
        Destroy(_enemy);
        enemies.Remove(_enemy);
        _UI.UpdateEnemyCount();
    }

    public void KillRandomEnemy()
    {
        if (NoEnemies)
            return;

        int rndEnemy = Random.Range(0, EnemyCount);
        KillEnemy(enemies[rndEnemy]);
    }

    public void KillSpecificEnemy(string _condition)
    {
        if (NoEnemies)
            return;

        for(int i = 0; i< EnemyCount; i++)
        {
            if (enemies[i].name.Contains(_condition))
            {
                KillEnemy(enemies[i]);
            }
        }
    }

    public void KillAllEnemies()
    {
        if (NoEnemies)
            return;

        for(int i = EnemyCount - 1; i>= 0; i--)
            KillEnemy(enemies[i]);
    }

    public void DeathScore()
    {
        Debug.Log("DeathScore");
        _GM.Score = _GM.Score + EnemyScore;
        _UI.UpdateScore();
    }
}
