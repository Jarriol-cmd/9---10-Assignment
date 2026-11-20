using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float timer;

    public PlayerScript player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = 2;

        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        timer -= Time.deltaTime;

        if (timer <= 0 )
        {
            Destroy(gameObject);

            player.bulletSpawned = 0;
        }
    }
}
