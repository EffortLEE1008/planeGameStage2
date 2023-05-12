using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Background : MonoBehaviour
{
    [SerializeField]
    float move_speed;
    Rigidbody2D my_rigid;
    void Start()
    {

        my_rigid = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        my_rigid.MovePosition(transform.position + Vector3.up * move_speed * Time.deltaTime);
        
    }
}
