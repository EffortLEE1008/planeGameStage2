using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D my_rigid;

    
    [SerializeField]
    float hp;

    [SerializeField]
    GameObject player;

    float alive_timer = 8f;
    float cur_timer = 0;

    private void Awake()
    {
        my_rigid = transform.GetComponent<Rigidbody2D>();
        
    }



    // Update is called once per frame
    void Update()
    {
        cur_timer = cur_timer + Time.deltaTime;

        if (cur_timer >= alive_timer)
        {
            Destroy(gameObject);
        }
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            hit(bullet.bullet_damge);
            Destroy(collision.gameObject);

        }
        else if (collision.transform.tag == "Player")
        {
            Player playercs = collision.gameObject.GetComponent<Player>();
            playercs.player_hp = playercs.player_hp - 1;
            Destroy(gameObject);

        }



    }

    void hit(float damage)
    {
        hp = hp - damage;

        if (hp <= 0)
        {

            Player playercs = player.GetComponent<Player>();
            playercs.score = playercs.score + 100;
            Destroy(gameObject);
        }

    }
}
