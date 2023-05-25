using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowText : MonoBehaviour
{
    RectTransform rect;
    public GameObject player;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }


    public void ActiveInfo()
    {
        rect.position = Camera.main.WorldToScreenPoint(player.transform.position);
    }



}
