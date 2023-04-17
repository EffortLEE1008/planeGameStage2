using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject bulletobj;
    Rigidbody2D my_rigid;
    Vector2 inputVec;
    Vector2 nextVec;

    float speed = 5;

    bool hit_rightbox;
    bool hit_leftbox;
    bool hit_topbox;
    bool hit_bottombox;


    private void Awake()
    {
        my_rigid = transform.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        if ((hit_rightbox && inputVec.x == 1) || (hit_leftbox && inputVec.x == -1))
            inputVec.x = 0;

        inputVec.y = Input.GetAxisRaw("Vertical");
        if ((hit_topbox && inputVec.y == 1) || (hit_bottombox && inputVec.y == -1))
            inputVec.y = 0;

    }

    private void FixedUpdate()
    {

        nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;

        my_rigid.MovePosition(my_rigid.position + nextVec);
    }

    //void fire()
    //{
        
    //} 

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



}
