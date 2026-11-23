using UnityEngine;

public class WallScript : MonoBehaviour
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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EBullet")
        {
            Destroy(collision.gameObject);

            if (collision.gameObject.tag == "Bullet")
            {
                player.bulletSpawned = 0;
            }

        }
    }
}
