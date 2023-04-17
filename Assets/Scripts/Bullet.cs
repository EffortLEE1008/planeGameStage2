using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float alive_timer = 5f;
    float cur_timer = 0;

    // Update is called once per frame
    void Update()
    {
        cur_timer = cur_timer + Time.deltaTime;

        if (cur_timer > alive_timer)
        {
            Destroy(gameObject);
            cur_timer = 0;
        }
        
    }
}
