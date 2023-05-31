using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceItem : MonoBehaviour
{
    [SerializeField] float speed =10f;
    Vector2 nextdir;
    Rigidbody2D my_rigid;
    float randomX, randomY;

    public float cur_timer;
    float max_timer = 10;

    // Start is called before the first frame update
    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame

    private void Update()
    {
        cur_timer = cur_timer + Time.deltaTime;

        if (cur_timer > max_timer)
        {
            gameObject.SetActive(false);

            cur_timer = 0;
                



        }
        



    }

}
