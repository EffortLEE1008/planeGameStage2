using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject target;

    public Vector2 zero_point;
    public Vector2 size;

    float height;
    float width;

    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(zero_point, size);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void LateUpdate()
    {
        transform.position = target.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        float lx = size.x * 0.5f - width;
        float clampX = Mathf.Clamp(transform.position.x, -lx + zero_point.x, lx + zero_point.x);

        float ly = size.y * 0.5f - height;
        float clampY = Mathf.Clamp(transform.position.y, -ly + zero_point.y, ly + zero_point.y);

        transform.position = new Vector3(clampX, clampY, -10f);

    }

}
