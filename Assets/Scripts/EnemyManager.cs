using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public int initialSpawnCount = 6;

    public string killCondition = "J";

    private string[] enemyNames = new string[] { "Wovok", "Kadan", "Istadum", "Stratic", "Riovok", "Pokhar", "Stigan", "Nobrum", "Soutic", "Wraexor", "Yauzius", "Utozad", "Gitic", "Zothik", "Ezaurow", "Owobrum", "Vrozor", "Grethum", "Kezad", "Hekras", "Herbert", "Azerak" };
    private string[] enemySurnames = new string[] { "the Abomination", "the Corruptor", "the Doctor", "Shade", "the Livid", "the Animator", "the Plaguemaster", "Rotheart", "the Hallowed", "Doomwhisper", "the Corrupted", "Morbide", "the Reianimator", "the Fleshrender", "Mortice", "the Crippled", "the Black", "Plasma", "Calamity", "Blight " };

    public Transform[] spawnPoints;
    public GameObject[] enemyTypes;
    public List<GameObject> enemies;

    public int EnemyCount => enemies.Count;

    public bool NoEnemies => enemies.Count == 0;
    private void Start()
    {
        SpawnEnemies();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            KillRandomEnemy();
        if (Input.GetKeyDown(KeyCode.J))
            KillSpecificEnemy(killCondition);
        if (Input.GetKeyDown(KeyCode.H))
            KillAllEnemies();
    }

    private void SpawnEnemies() 
    {
        for (int i = 0; i < initialSpawnCount; i++) 
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int rndEnemy = Random.Range(0, enemyTypes.Length);
        int rndSpawn = Random.Range(0, spawnPoints.Length);
        int rndName = Random.Range(0, enemyNames.Length);
        int rndSurname = Random.Range(0, enemySurnames.Length);

        GameObject enemy = Instantiate(enemyTypes[rndEnemy & rndSurname], spawnPoints[rndSpawn].transform.position, spawnPoints[rndSpawn].transform.rotation);
        enemy.name = enemyNames[rndName] + " " + enemySurnames[rndSurname];

        enemies.Add(enemy);

        print(enemies.Count);
    }

    private void KillEnemy(GameObject _enemy)
    {
        Destroy(_enemy);
        enemies.Remove(_enemy);
    }

    private void KillRandomEnemy()
    {
        if (NoEnemies)
            return;

        int rndEnemy = Random.Range(0, EnemyCount);
        KillEnemy(enemies[rndEnemy]);
    }

    private void KillSpecificEnemy(string _condition)
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

    private void KillAllEnemies()
    {
        if (NoEnemies)
            return;

        for(int i = EnemyCount - 1; i>= 0; i--)
            KillEnemy(enemies[i]);
    }
}
