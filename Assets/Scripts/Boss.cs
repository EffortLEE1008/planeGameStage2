using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    const int bulletnum1 = 30;
    const int bulletnum2 = 60;
    const int bulletnum3 = 90;

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

    List<GameObject> bullet_arr = new List<GameObject>();
    List<Rigidbody2D> rigid_arr = new List<Rigidbody2D>();
    Rigidbody2D bullet_rigid;
    Rigidbody2D my_rigid;
    PolygonCollider2D capsule;

    public int pattenIndex=0;
    public ObjectManager obj_manager;
    


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
            collision.gameObject.SetActive(false);
            
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

        pattenIndex = 3;

        switch (pattenIndex)
        {
            case 0:
                StartCoroutine(FireFast2());
                break;

            case 1:
                StartCoroutine(FireSin());
                break;

            case 2:
                StartCoroutine(FireArt());
                break;

            case 3:
                StartCoroutine(FireCross());
                break;

        }
    }


    IEnumerator FireFast2()
    {
        int count = 0;
        

        while (count<20)
        {
            count += 1;

            GameObject fastbullet1 = obj_manager.SelectObj("Boss_bullet");
            fastbullet1.transform.position = transform.position + new Vector3(-.3f, -1f, 0);

            GameObject fastbullet2 = obj_manager.SelectObj("Boss_bullet");
            fastbullet2.transform.position = transform.position + new Vector3(.3f, -1f, 0); 

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
            GameObject fastbullet1 = obj_manager.SelectObj("Boss_bullet");
            fastbullet1.transform.position = boss_barrel[0].transform.position + new Vector3(.3f, -1f, 0);
            
            GameObject fastbullet2 = obj_manager.SelectObj("Boss_bullet");
            fastbullet2.transform.position = boss_barrel[1].transform.position + new Vector3(.3f, -1f, 0);
            
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

    IEnumerator FireArt()
    {

        for (int i = 0; i < bulletnum1; i++)
        {
                
            bullet_arr.Add(obj_manager.SelectObj("Boss_bullet"));

            bullet_arr[i].transform.position = boss_barrel[0].transform.position ;
            bullet_arr[i].transform.rotation = Quaternion.identity;
            Debug.Log("here");
            bullet_rigid = bullet_arr[i].GetComponent<Rigidbody2D>();
            rigid_arr.Add(bullet_rigid);
            Debug.Log(rigid_arr[i]);

            rigid_arr[i].AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            Debug.Log("실행 2");
        }
        yield return new WaitForSeconds(.4f);

        for (int i = bulletnum1; i < bulletnum2; i++)
        {

            bullet_arr.Add(obj_manager.SelectObj("Boss_bullet"));

            bullet_arr[i].transform.position = boss_barrel[0].transform.position;
            bullet_arr[i].transform.rotation = Quaternion.identity;
            
            bullet_rigid = bullet_arr[i].GetComponent<Rigidbody2D>();
            rigid_arr.Add(bullet_rigid);
            Debug.Log(rigid_arr[i]);

            rigid_arr[i].AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            
        }
        yield return new WaitForSeconds(.4f);

        for (int i = bulletnum2; i < bulletnum3; i++)
        {

            bullet_arr.Add(obj_manager.SelectObj("Boss_bullet"));

            bullet_arr[i].transform.position = boss_barrel[0].transform.position;
            bullet_arr[i].transform.rotation = Quaternion.identity;
            Debug.Log("here");
            bullet_rigid = bullet_arr[i].GetComponent<Rigidbody2D>();
            rigid_arr.Add(bullet_rigid);
            Debug.Log(rigid_arr[i]);

            rigid_arr[i].AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            Debug.Log("실행 2");
        }
        yield return new WaitForSeconds(.4f);

        for(int i=0; i < bulletnum1; i++)
        {
            
            Vector2 bullet_dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / bulletnum1), Mathf.Sin(Mathf.PI * 2 * i / bulletnum1));
            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir.normalized * 5, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.4f);
        int j = 0;
        for (int i = bulletnum1; i < bulletnum2; i++)
        {
            
            Vector2 bullet_dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletnum1), Mathf.Sin(Mathf.PI * 2 * j / bulletnum1));
            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir.normalized * 5, ForceMode2D.Impulse);
            j++;
        }

        yield return new WaitForSeconds(.4f);

        j = 0;
        for (int i = bulletnum2; i < bulletnum3; i++)
        {
            Vector2 bullet_dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * j / bulletnum1), Mathf.Sin(Mathf.PI * 2 * j / bulletnum1)); // 부채꼴 모양으로 날리기.
            
            rigid_arr[i].velocity = Vector2.zero;   //속도 초기화
            rigid_arr[i].AddForce(bullet_dir.normalized * 5, ForceMode2D.Impulse);
            j++;
        }

        rigid_arr.Clear();
        bullet_arr.Clear();

        Invoke("Selectpatten",4f);

    }

    IEnumerator FireCross()
    {

        for (int i = 0; i < 4; i++)
        {

            bullet_arr.Add(obj_manager.SelectObj("Boss_bullet"));

            bullet_arr[i].transform.position = boss_barrel[0].transform.position;
            bullet_arr[i].transform.rotation = Quaternion.identity;
            Debug.Log("here");
            bullet_rigid = bullet_arr[i].GetComponent<Rigidbody2D>();
            rigid_arr.Add(bullet_rigid);
           // Debug.Log(rigid_arr[i]);

            rigid_arr[i].AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            //Debug.Log("실행 2");
        }
        yield return new WaitForSeconds(.4f);

        for (int i = 4; i < 8; i++)
        {

            bullet_arr.Add(obj_manager.SelectObj("Boss_bullet"));

            bullet_arr[i].transform.position = boss_barrel[0].transform.position;
            bullet_arr[i].transform.rotation = Quaternion.identity;

            bullet_rigid = bullet_arr[i].GetComponent<Rigidbody2D>();
            rigid_arr.Add(bullet_rigid);
            Debug.Log(rigid_arr[i]);

            rigid_arr[i].AddForce(Vector2.down * 5, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.4f);

        for (int i = 8; i < 12; i++)
        {

            bullet_arr.Add(obj_manager.SelectObj("Boss_bullet"));

            bullet_arr[i].transform.position = boss_barrel[0].transform.position;
            bullet_arr[i].transform.rotation = Quaternion.identity;
            //Debug.Log("here");
            bullet_rigid = bullet_arr[i].GetComponent<Rigidbody2D>();
            rigid_arr.Add(bullet_rigid);
            Debug.Log(rigid_arr[i]);

            rigid_arr[i].AddForce(Vector2.down * 5, ForceMode2D.Impulse);
            //Debug.Log("실행 2");
        }
        yield return new WaitForSeconds(.4f);


        int index = 0;
        Vector3 bullet_dir = new Vector2(0, 0);
        for (int i = 0; i < 4; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir = new Vector2(0, 1);
                    break;

                case 1:
                    bullet_dir = new Vector2(0, -1);
                    break;

                case 2:
                    bullet_dir = new Vector2(1, 0);
                    break;

                case 3:
                    bullet_dir = new Vector2(-1, 0);
                    break;
            }


            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir.normalized * 5, ForceMode2D.Impulse);
            index++;

        }
        yield return new WaitForSeconds(.4f);

        index = 0;
        for (int i = 4; i < 8; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir = new Vector2(0, 1);
                    break;

                case 1:
                    bullet_dir = new Vector2(0, -1);
                    break;

                case 2:
                    bullet_dir = new Vector2(1, 0);
                    break;

                case 3:
                    bullet_dir = new Vector2(-1, 0);
                    break;
            }


            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir.normalized * 5, ForceMode2D.Impulse);
            index++;
        }
        yield return new WaitForSeconds(.4f);

        index = 0;
        for (int i = 8; i < 12; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir = new Vector2(0, 1);
                    break;

                case 1:
                    bullet_dir = new Vector2(0, -1);
                    break;

                case 2:
                    bullet_dir = new Vector2(1, 0);
                    break;

                case 3:
                    bullet_dir = new Vector2(-1, 0);
                    break;
            }


            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir.normalized * 5, ForceMode2D.Impulse);
            index++;

        }
        yield return new WaitForSeconds(.4f);

        rigid_arr.Clear();
        bullet_arr.Clear();

        Invoke("Selectpatten", 4f);

    }

    void onHit(float damage)
    {
        cur_hp = cur_hp - damage;

        if (cur_hp <= 0)
        {
            
            isdead = true;
            gameObject.SetActive(false);
        }
    } 

}
