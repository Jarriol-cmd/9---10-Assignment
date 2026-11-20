using UnityEngine;

public class EvilBullet : MonoBehaviour
{
    public PlayerScript player;

    public float timer;

    public int bullethealth = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();

        timer -= Time.deltaTime;

        if (timer <= 0 || bullethealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);

            bullethealth--;

            player.bulletSpawned = 0;
            

        }


    }
}
