using System.Linq;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour
{

    public GameObject[] enemiesToMove;

    float wayToMove = 0.5f;

    float timer = 0.5f;

    int currentEnemy;

    public GameObject enemyCheck1;
    public GameObject enemyCheck2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentEnemy = 0;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject enemy;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            enemy = enemiesToMove[currentEnemy];

            if (enemy != null)
            {
                enemy.transform.position = new Vector2(enemy.transform.position.x + wayToMove, enemy.transform.position.y);
            }

            else
            {
                enemy = enemiesToMove[currentEnemy + 1];
            }


            currentEnemy++;


            if (currentEnemy >= enemiesToMove.Length)
            {
                currentEnemy = 0;
            }


            timer = 0.02f;


            if (enemyCheck1.transform.position.x >= 9.37f)
            {
                wayToMove = -0.5f;

                moveOnDown();
            }

            if (enemyCheck2.transform.position.x <= -9.37f)
            {
                wayToMove = 0.5f;

                moveOnDown();
            }



        }

    }


    public void moveOnDown()
    {
        foreach (GameObject allEnemy in enemiesToMove)
        {
            allEnemy.transform.position = new Vector2(allEnemy.transform.position.x, allEnemy.transform.position.y - 0.5f);
            allEnemy.transform.position = new Vector2(allEnemy.transform.position.x + wayToMove, allEnemy.transform.position.y);
        }
    }

}
