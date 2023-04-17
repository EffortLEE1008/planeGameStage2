using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Rigidbody2D my_rigid;
    

    float alive_timer = 5f;
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
}
