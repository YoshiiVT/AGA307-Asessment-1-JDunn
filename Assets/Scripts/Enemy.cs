using System.Collections;
using UnityEngine;

public class Enemy : GameBehaviour
{
    [SerializeField] EnemySize enemySize;
    public float moveDistance = 1000f;
    public float stoppingDistance = 0.3f;

    [Header("Stats")]
    private int mySpeed;
    private int myHealth;
    private int myMaxHealth;

    [Header("Score")]
    private int myScore;

    [Header("Patrols")]
    private Transform moveToPos;


    public void Initialize(Transform _startPos, string _name)
    {
        switch(enemySize)
        {
            case EnemySize.Large:
                mySpeed = 5;
                myHealth = 3;
                myScore += 200;
                break;
            case EnemySize.Medium:
                mySpeed = 10;
                myHealth = 2;
                myScore += 100;
                break;
            case EnemySize.Small:
                mySpeed = 20;
                myHealth = 1;
                myScore += 150;
                break;
        }
        myMaxHealth = myHealth;

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        moveToPos = _EM.GetRandomSpawnPoint;
        transform.LookAt(moveToPos);

        while (Vector3.Distance(transform.position, moveToPos.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPos.position, mySpeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(3);
        StartCoroutine(Move());
    }
}
