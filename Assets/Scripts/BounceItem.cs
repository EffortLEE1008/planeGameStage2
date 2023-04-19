using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceItem : MonoBehaviour
{
    [SerializeField] [Range(50f, 200f)] float speed = 100f;

    Rigidbody2D my_rigid;
    float randomX, randomY;

    // Start is called before the first frame update
    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();

        randomX = Random.Range(-1f, 1f);
        randomY = Random.Range(-1f, 1f);

        Vector2 nextdir = new Vector2(randomX, randomY).normalized;

        my_rigid.AddForce(nextdir * speed);


    }

    // Update is called once per frame

}
