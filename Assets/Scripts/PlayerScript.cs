using TMPro;
using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public bool buttonPressed;

    public Button leftButton;
    public Button rightButton;
    public Button fireButton;

    public GameObject bullet;

    public int bulletSpawned;

    public TextMeshProUGUI livesCount;

    public GameObject respawnPoint;

    Rigidbody2D rb;

    int lives = 3;

    int enemyColl = 0;
    int bulletColl = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.freeze == true)
        {
            return;
        }

        if(leftButton.IsPressed())
        {
            rb.linearVelocityX -= 0.1f;
        }


        if (rightButton.IsPressed())
        {
            rb.linearVelocityX += 0.1f;
        }


        if (fireButton.IsPressed() && bulletSpawned == 0)
        {
            FireBullet();
        }



        if(rb.linearVelocityX >= 5 || rb.linearVelocityX <= -5)
        {
            if (rb.linearVelocityX >= 5)
            {
                rb.linearVelocityX = 5;
            }

            if (rb.linearVelocityX <= -5)
            {
                rb.linearVelocityX = -5;
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && enemyColl == 0)
        {

            enemyColl = 1;
            LostLife();

            if (lives == 0)
            {
                GameOver();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EBullet" && bulletColl == 0)
        {
            bulletColl = 1;
            Destroy(collision.gameObject);

            LostLife();

            
        }
    }

    void FireBullet()
    {
        GameObject clone;
        clone = Instantiate(bullet, transform.position, Quaternion.identity);

        Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

        rb.linearVelocity = new Vector2(0, 15);

        rb.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);

        bulletSpawned = 1;
    }

    void LostLife()
    {
        

        lives--;

        if (lives == 0)
        {
            GameOver();
        }

        Manager.freeze = true;

        Invoke("RespawnPlayer", 2);
    }

    void RespawnPlayer()
    {
        gameObject.transform.position = respawnPoint.transform.position;

        enemyColl = 0;
        bulletColl = 0;

        livesCount.text = "Lives: " + lives;
        
        Manager.freeze = false;
    }

    void GameOver()
    {
        Manager.freeze = true;
    }
}
