using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    float hp;

    
    public GameObject player;

    [SerializeField]
    GameObject playerbullet;

    [SerializeField]
    GameObject bossBullet;

    Rigidbody2D my_rigid;
    PolygonCollider2D capsule;

    int pattenIndex;
    int curPatten;
    [SerializeField]
    int[] maxPatten;


    private void Awake()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        capsule = GetComponent<PolygonCollider2D>();
    }



    private void OnEnable()
    {
        Invoke("Selectpatten", 4);        
        
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(0,2.91f,0), 2 * Time.deltaTime);
        player.transform.position = player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PlayerBullet")
        {
            Bullet playerbulletcs = playerbullet.gameObject.GetComponent<Bullet>();
            onHit(playerbulletcs.bullet_damge);
            Destroy(collision.gameObject);
            
        }

    }
    void Selectpatten()
    {
        //3차 연산자
        pattenIndex = pattenIndex == 3 ? 0 : pattenIndex + 1;
        ////////////////////////////
        //if (pattenIndex == 3)
        //{
        //    pattenIndex = 0;
        //}
        //else if (pattenIndex != 3)
        //    pattenIndex = pattenIndex + 1;
        ////////////////////////////
        curPatten = 0;

        switch (pattenIndex)
        {
            case 0:
                FireFoward();
                break;

            case 1:
                FireFast();
                break;

            case 2:
                FireSin();
                break;

            case 3:
                FireArt();
                break;
        }
    }

    void FireFoward()
    {
        Debug.Log("앞으로 4발 발싸");

        curPatten++;

        if (curPatten < maxPatten[pattenIndex])
            Invoke("FireFoward", 1);
        else
            Invoke("Selectpatten", 2);

    }

    void FireFast()
    {
        GameObject fastbullet1 = Instantiate(bossBullet, transform.position + new Vector3(.3f, -1f,0), transform.rotation);
        GameObject fastbullet2 = Instantiate(bossBullet, transform.position + new Vector3(-.3f, -1f, 0), transform.rotation);


        Rigidbody2D rigid_fast1 = fastbullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rigid_fast2 = fastbullet2.GetComponent<Rigidbody2D>();

        Vector2 dir = player.transform.position - transform.position;
        Debug.Log("player의 위치는 ? : "+ player.transform.position);
        rigid_fast1.AddForce(dir.normalized * 3, ForceMode2D.Impulse);
        rigid_fast2.AddForce(dir.normalized * 3, ForceMode2D.Impulse);

        curPatten++;

        if (curPatten < maxPatten[pattenIndex])
            Invoke("FireFast", .5f);
        else
            Invoke("Selectpatten", 2);

    }

    void FireSin()
    {
        Debug.Log("Sin파로 발싸");

        curPatten++;

        if (curPatten < maxPatten[pattenIndex])
            Invoke("FireSin",1);
        else
            Invoke("Selectpatten", 2);


    }

    void FireArt()
    {
        Debug.Log("아름답게 발싸");

        curPatten++;

        if (curPatten < maxPatten[pattenIndex])
            Invoke("FireArt", .7f);
        else
            Invoke("Selectpatten", 2);

    }

    void onHit(float damage)
    {
        hp = hp - damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    } 

}
