using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyHealth;

    int count = 0;
    public float timer;
    public PlayerScript player;
    public GameObject bullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        timer = Random.Range(30, 90);

        if (gameObject.name == "Blocker")
        {
            bullet = null;

            enemyHealth = 3;
        }

        else
        {
            enemyHealth = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.freeze == true)
        {
            return;
        }

        if (gameObject.name == "Sprite")
        {
            bullet.GetComponent<EvilBullet>().bullethealth = 2;
        }

        else
        {
            if(gameObject.name != "Blocker")
            {
                bullet.GetComponent<EvilBullet>().bullethealth = 1;
            }
        }

        if (gameObject.name == "Bugger")
        {
            bullet.GetComponent<EvilBullet>().timer = 7;
            bullet.GetComponent<EvilBullet>().bullethealth = 100;
        }

        else
        {
            if (gameObject.name != "Blocker")
            { 
                 bullet.GetComponent<EvilBullet>().timer = 2;
            }
        }

            timer -= Time.deltaTime;

        if (timer <= 0 && gameObject.name != "Blocker")
        {
            if(gameObject.name == "Goober")
            {
                FireBullet(2);

                timer = Random.Range(60, 180);
            }
            
            if (gameObject.name == "Leaffly")
            {
                FireBullet(3);

                timer = Random.Range(90, 150);
            }

            if (gameObject.name == "Sprite")
            {
                FireBullet(1);

                timer = Random.Range(20, 100);
            }

            if (gameObject.name == "Bugger")
            {
                FireBullet(1);

                timer = Random.Range(50, 150);
            }
        }

        if(enemyHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void FireBullet(int amount)
    {
        count = 0;

        while (count != amount)
        {
            GameObject clone;

            clone = Instantiate(bullet, transform.position, Quaternion.identity);

            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            if (gameObject.name == "Goober")
            {
                rb.transform.position = new Vector2(transform.position.x - 0.2f + (0.4f * count), transform.position.y);
            }

            else
            {
                rb.transform.position = new Vector2(transform.position.x, transform.position.y);
            }

            

            if (gameObject.name == "Leaffly")
            {
                rb.transform.Rotate(new Vector3(0, 0, -45 + (45 * count)));
                rb.linearVelocity = new Vector2(-5 + (5 * count), -5);

            }

            else
            {
                rb.linearVelocity = new Vector2(0, -5);
            }

            if (gameObject.name == "Bugger")
            {
                rb.linearVelocity = new Vector2(0, -1);
                rb.transform.localScale = new Vector3(0.6f, 1, 1);
            }

            


            count++;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            player.bulletSpawned = 0;
            Destroy(collision.gameObject);
            enemyHealth -= 1;
        }
    }

}
