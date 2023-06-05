using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject bulletobj;
    Rigidbody2D my_rigid;
    Vector2 inputVec;
    Vector2 nextVec;

    float speed = 5;
    float bullet_speed = 5;
    public float player_maxhp = 30;
    public float player_curhp;
    public int score = 0;


    bool hit_rightbox;
    bool hit_leftbox;
    bool hit_topbox;
    bool hit_bottombox;

    float max_firedelay = .3f;
    float firedelay = 0;

    public ObjectManager obj_manager;

    private void Awake()
    {
        
    }
    void Start()
    {

        my_rigid = transform.GetComponent<Rigidbody2D>();
        player_curhp = player_maxhp;

    }

    // Update is called once per frame
    void Update()
    {

        firedelay += Time.deltaTime;

        my_rigid.velocity = Vector2.zero;

        inputVec.x = Input.GetAxisRaw("Horizontal");
        if ((hit_rightbox && inputVec.x == 1) || (hit_leftbox && inputVec.x == -1))
            inputVec.x = 0;

        inputVec.y = Input.GetAxisRaw("Vertical");
        if ((hit_topbox && inputVec.y == 1) || (hit_bottombox && inputVec.y == -1))
            inputVec.y = 0;

        Fire();
        Reload();


    }

    private void FixedUpdate()
    {

        nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        transform.position = my_rigid.position + nextVec;
        float clampx = Mathf.Clamp(transform.position.x, -5, 5);
        float clampy = Mathf.Clamp(transform.position.y, -5, 5);

        transform.position = new Vector2(clampx, clampy);

        //my_rigid.MovePosition(my_rigid.position + nextVec);
    }

    void Fire()
    {
        if (firedelay < max_firedelay)
            return;

        GameObject bullet = obj_manager.SelectObj("Player_bullet");
        bullet.transform.position = gameObject.transform.position;
        Rigidbody2D bul_rigid = bullet.GetComponent<Rigidbody2D>();
        //bul_rigid.velocity = Vector2.up * bullet_speed;
        bul_rigid.AddForce(Vector2.up * bullet_speed, ForceMode2D.Impulse);

        
        firedelay = 0;
    }
    void Reload()
    {
        firedelay = firedelay + Time.deltaTime;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag=="Boundary")
        {
            switch (collision.gameObject.name)
            {
                case "Right_box":
                    hit_rightbox = true;
                    break;

                case "Left_box":
                    hit_leftbox = true;
                    break;

                case "Top_box":
                    hit_topbox = true;
                    break;

                case "Bottom_box":
                    hit_bottombox = true;
                    break;


            }

        }
        else if (collision.gameObject.tag == "BossBullet")
        {
            Hit(1);
            collision.gameObject.SetActive(false);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Boundary")
        {

            switch (collision.gameObject.name)
            {
                case "Right_box":
                    hit_rightbox = false;
                    break;

                case "Left_box":
                    hit_leftbox = false;
                    break;

                case "Top_box":
                    hit_topbox = false;
                    break;

                case "Bottom_box":
                    hit_bottombox = false;
                    break;


            }

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            BounceItem itemcs = collision.gameObject.GetComponent<BounceItem>();
            //itemcs.cur_timer = 0;
            collision.gameObject.SetActive(false);

        }

        if (collision.gameObject.tag == "Enemy")
        {
            Hit(1);
        }

    }

    void Hit(float dmg)
    {
        player_curhp = player_curhp - dmg;

        if (player_curhp <= 0)
        {
            gameObject.SetActive(false);
        }



    }



}
