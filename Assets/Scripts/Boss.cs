using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    public float max_hp;
    public float cur_hp;
    public bool isdead=false;
    
    public GameObject player;

    [SerializeField]
    GameObject playerbullet;

    [SerializeField]
    GameObject bossBullet;
    [SerializeField]
    GameObject[] boss_barrel;

    Rigidbody2D my_rigid;
    PolygonCollider2D capsule;

    public int pattenIndex=0;
    


    private void Awake()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        capsule = GetComponent<PolygonCollider2D>();
        cur_hp = max_hp;
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
        //pattenIndex = pattenIndex == 3 ? 0 : pattenIndex + 1;
        
        //////////////////////////
        if (pattenIndex == 2)
        {
            pattenIndex = 0;
        }
        else if (pattenIndex != 2)
            pattenIndex = pattenIndex + 1;
        //////////////////////////

        switch (pattenIndex)
        {
            case 0:
                StartCoroutine(FireFast2());
                break;

            case 1:
                StartCoroutine(FireSin());
                break;

            case 2:
                FireArt();
                break;

        }
    }


    IEnumerator FireFast2()
    {
        int count = 0;
        

        while (count<20)
        {
            count += 1;
            
            GameObject fastbullet1 = Instantiate(bossBullet, transform.position + new Vector3(.3f, -1f, 0), transform.rotation);
            GameObject fastbullet2 = Instantiate(bossBullet, transform.position + new Vector3(-.3f, -1f, 0), transform.rotation);

            Rigidbody2D rigid_fast1 = fastbullet1.GetComponent<Rigidbody2D>();
            Rigidbody2D rigid_fast2 = fastbullet2.GetComponent<Rigidbody2D>();

            Vector2 dir = player.transform.position - transform.position;
            //Debug.Log("player의 위치는 ? : " + player.transform.position);
            rigid_fast1.AddForce(dir.normalized * 3, ForceMode2D.Impulse);
            rigid_fast2.AddForce(dir.normalized * 3, ForceMode2D.Impulse);

            yield return new WaitForSeconds(.5f);
        }
        Invoke("Selectpatten", 2);
    }


    IEnumerator FireSin()
    {
        int count = 0;
        
        //Debug.Log("Sin파로 발싸");
        while (count < 30)
        {
            count += 1;
            GameObject fastbullet1 = Instantiate(bossBullet, boss_barrel[0].transform.position + new Vector3(.3f, -1f, 0), transform.rotation);
            GameObject fastbullet2 = Instantiate(bossBullet, boss_barrel[1].transform.position + new Vector3(.3f, -1f, 0), transform.rotation);

            Rigidbody2D rigid_fast1 = fastbullet1.GetComponent<Rigidbody2D>();
            Rigidbody2D rigid_fast2 = fastbullet2.GetComponent<Rigidbody2D>();

            Vector2 bullet_dir0 = new Vector2(Mathf.Sin(Mathf.PI* 3*count/30), -1);
            Vector2 bullet_dir1 = new Vector2(Mathf.Sin(Mathf.PI * 3*count / 30), -1);

            rigid_fast1.AddForce(bullet_dir0.normalized * 5, ForceMode2D.Impulse);
            rigid_fast2.AddForce(bullet_dir1.normalized * 5, ForceMode2D.Impulse);

            yield return new WaitForSeconds(.2f);

        }


        Invoke("Selectpatten", 1);


    }

    void FireArt()
    {
        //Debug.Log("아름답게 발싸");


        Invoke("Selectpatten", .5f);

    }

    void onHit(float damage)
    {
        cur_hp = cur_hp - damage;

        if (cur_hp <= 0)
        {
            Destroy(gameObject);
            isdead = true;
        }
    } 

}
