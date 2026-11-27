using UnityEngine;

public class BarricadeScript : MonoBehaviour
{
    public PlayerScript player;

    int timesHit = 0;

    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.freeze == true)
        {
            return;
        }

        if (timesHit >= 5)
        {
            Destroy(gameObject);
        }

        HitSprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EBullet")
        {
            Destroy(collision.gameObject);

            timesHit++;

            if(collision.gameObject.tag == "Bullet")
            { 
                player.bulletSpawned = 0; 
            }
            
        }

        if (collision.gameObject.tag == "Enemy")
        {
            timesHit++;
        }
    }




    void HitSprite()
    {
        if (timesHit == 1)
        {
            anim.SetBool("HitOnce", true);
        }

        if (timesHit == 2)
        {
            anim.SetBool("HitOnce", false);
            anim.SetBool("HitTwice", true);
        }

        if (timesHit == 3)
        {
            anim.SetBool("HitTwice", false);
            anim.SetBool("HitThrice", true);
        }

        if (timesHit == 4)
        {
            anim.SetBool("HitThrice", false);
            anim.SetBool("AboutToBreak", true);
        }
    }
}
