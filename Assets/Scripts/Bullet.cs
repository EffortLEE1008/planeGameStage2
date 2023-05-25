using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bullet_damge = 1;
    float alive_timer = 4f;
    float cur_timer = 0;

    // Update is called once per frame
    void Update()
    {
        cur_timer = cur_timer + Time.deltaTime;

        if (cur_timer > alive_timer)
        {
            gameObject.SetActive(false);
            cur_timer = 0;
        }
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }


}
