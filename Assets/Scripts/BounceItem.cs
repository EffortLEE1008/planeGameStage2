using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceItem : MonoBehaviour
{
    [SerializeField] float speed =10f;
    Vector2 nextdir;
    Rigidbody2D my_rigid;
    float randomX, randomY;

    // Start is called before the first frame update
    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame

    private void Update()
    {
        



    }

}
