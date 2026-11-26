using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMoveScript : MonoBehaviour
{
    int checkers = 1;
    int checkers2 = 65;

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

            if (enemy != null)
            {
                enemy.transform.position = new Vector2(enemy.transform.position.x + wayToMove, enemy.transform.position.y);
            }

            else
            {
                if(enemy != enemiesToMove[64] && enemy.activeInHierarchy == true)
                {
                    enemy = enemiesToMove[currentEnemy + 1];
                }

                else
                {
                    enemy = enemiesToMove[1];
                }
                
            }

            currentEnemy++;


            if (currentEnemy >= enemiesToMove.Length)
            {
                currentEnemy = 0;
            }


            timer = 0.02f;

            if(enemyCheck1.activeInHierarchy == false)
            {
                enemyCheck1 = enemiesToMove[checkers + 1];
                checkers++;

                if (enemyCheck2.activeInHierarchy == false)
                {
                    checkers = 1;
                }

            }

            if (enemyCheck2.activeInHierarchy == false)
            {
                enemyCheck2 = enemiesToMove[checkers2 - 1];
                checkers2--;


                if (enemyCheck2.activeInHierarchy == true)
                {
                    checkers2 = 65;
                }
            }
        }

    }


    public void moveOnDown()
    {
        foreach (GameObject allEnemy in enemiesToMove)
        {
            if(allEnemy.activeInHierarchy != false)
            {
                allEnemy.transform.position = new Vector2(allEnemy.transform.position.x + wayToMove, allEnemy.transform.position.y - 0.5f);

            }
        }
    }

}
