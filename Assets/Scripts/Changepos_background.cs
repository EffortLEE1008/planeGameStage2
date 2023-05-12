using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changepos_background : MonoBehaviour
{

    [SerializeField]
    GameObject background;
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            background.transform.position = background.transform.position + Vector3.up * 28*3;

        }
    }


}
