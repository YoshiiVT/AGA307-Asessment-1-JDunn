using System.Collections;
using UnityEngine;

public class Enemy : GameBehaviour
{
    [SerializeField] 
    public EnemySize enemySize;
    public float moveDistance = 1000f;
    public float stoppingDistance = 0.3f;

    [Header("Stats")]
    private int mySpeed;
    private int myHealth;
    private int myMaxHealth;

    [Header("Score")]
    public int myScore;

    [Header("Patrols")]
    private Transform moveToPos;


    public void Initialize(Transform _startPos, string _name)
    {
        switch(enemySize)
        {
            case EnemySize.Large:
                mySpeed = 5;
                myHealth = 3;
                myScore = 200;
                //gameObject.AddComponent<Transform>().localScale = Vector3.one;
                gameObject.GetComponent<Transform>().localScale += new Vector3(1.5f, 1.5f, 1.5f);
                gameObject.GetComponentInChildren<Renderer>().material.color = Color.black;
                break;
            case EnemySize.Medium:
                mySpeed = 10;
                myHealth = 2;
                myScore = 100;
                break;
            case EnemySize.Small:
                mySpeed = 20;
                myHealth = 1;
                myScore = 150;
                gameObject.GetComponentInChildren<Renderer>().material.color = Color.blue;
                gameObject.GetComponent<Transform>().localScale += new Vector3(0.5f, 0.5f, 0.5f);
                break;
        }

        switch(_GM.difficulty)
        {
            case Difficulty.Easy:
                break;
            case Difficulty.Medium:
                mySpeed = mySpeed * 2;
                myScore = myScore * 2;
                break;
            case Difficulty.Hard:
                mySpeed *= 2;
                myHealth *= 2;
                myScore *= 3;
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
