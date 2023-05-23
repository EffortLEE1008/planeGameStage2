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

            GameObject flarebim = objManager.MakeObj("flare_bim");
            flarebim.transform.position = collision.transform.position;

            flarebim.SetActive(true);

            //StartCoroutine(SetActiveFalse(flarebim));
            

        }
        else if (collision.transform.tag == "Player")
        {
            Player playercs = collision.gameObject.GetComponent<Player>();
            playercs.player_hp = playercs.player_hp - 1;
            gameObject.SetActive(false);

        }


    }

    void hit(float damage)
    {
        hp = hp - damage;

        if (hp <= 0)
        {

            playercs.score = playercs.score + 100;
            gameObject.SetActive(false);

        }

    }



    IEnumerator SetActiveFalse(GameObject target)
    {
        Debug.Log("½ÃÀÛ");
        yield return new WaitForSeconds(1.1f);
        target.SetActive(false);

    }




}
