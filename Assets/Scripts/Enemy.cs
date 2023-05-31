using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D my_rigid;

    public float hp;

    [SerializeField]
    GameObject player;

    float alive_timer = 8f;
    float cur_timer = 0;

    public Player playercs;

    public ObjectManager objManager;
    
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
            gameObject.SetActive(false);
            cur_timer = 0;
        }
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            hit(bullet.bullet_damge);
            collision.gameObject.SetActive(false);

            GameObject flarebim = objManager.SelectObj("flare_bim");
            flarebim.transform.position = collision.transform.position;

            flarebim.SetActive(true);

            //StartCoroutine(SetActiveFalse(flarebim));
            

        }
        else if (collision.transform.tag == "Player")
        {
            Player playercs = collision.gameObject.GetComponent<Player>();
            playercs.player_curhp = playercs.player_curhp - 1;
            //gameObject.SetActive(false);

        }


    }

    void hit(float damage)
    {
        hp = hp - damage;

        if (hp <= 0)
        {
            int rand = Random.Range(0, 10);
            if (rand > 5)
            {
                GameObject itemobj = objManager.SelectObj("Item");
                itemobj.transform.position = gameObject.transform.position;
                Rigidbody2D item_rigid = itemobj.GetComponent<Rigidbody2D>();
                float randomX = Random.Range(-1f, 1f);
                float randomY = Random.Range(-1f, 1f);

                Vector2 nextdir = new Vector2(randomX, randomY).normalized;

                item_rigid.AddForce(nextdir * 100);

            }
            cur_timer = 0;
            playercs.score = playercs.score + 100;
            gameObject.SetActive(false);

        }

    }



    IEnumerator SetActiveFalse(GameObject target)
    {
        Debug.Log("Ω√¿€");
        yield return new WaitForSeconds(1.1f);
        target.SetActive(false);

    }




}
