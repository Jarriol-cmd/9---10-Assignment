using UnityEngine;

public class BarricadeScript : MonoBehaviour
{
    public PlayerScript player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EBullet")
        {
            Destroy(collision.gameObject);
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x - 0.1f, gameObject.transform.localScale.y);
            if(collision.gameObject.tag == "Bullet")
            { 
                player.bulletSpawned = 0; 
            }
            
        }

        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x - 0.1f, gameObject.transform.localScale.y);
        }
    }
}
