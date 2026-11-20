using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public bool buttonPressed;

    public Button leftButton;
    public Button rightButton;
    public Button fireButton;

    public GameObject bullet;

    public int bulletSpawned;

    Rigidbody2D rb;

    int lives = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

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
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);

            if (lives == 0)
            {
                GameOver();
            }
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

    void GameOver()
    {

    }
}
