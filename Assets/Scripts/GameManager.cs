using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyobj;
    [SerializeField]
    Transform[] spawnpos;
    float max_timer = .7f;
    float cur_timer;

    float enemy_speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cur_timer = cur_timer + Time.deltaTime;

        if (cur_timer >= max_timer)
        {
            SpawnEnemy();
            cur_timer = 0;
        }
        
    }

    void SpawnEnemy()
    {
        int randspawn = Random.Range(0, 6);
        GameObject enemy = Instantiate(enemyobj, spawnpos[randspawn].position, spawnpos[randspawn].rotation);
        Rigidbody2D enemy_rigid = enemy.GetComponent<Rigidbody2D>();

        if (randspawn == 4)
        {
            enemy_rigid.transform.Rotate(Vector3.back * 115);
            enemy_rigid.velocity = new Vector2(1 * enemy_speed, -1);
        }
        else if(randspawn == 5)
        {
            enemy_rigid.transform.Rotate(Vector3.back * -115);
            enemy_rigid.velocity = new Vector2(-1 * enemy_speed, -1);
        }
        else if(randspawn<4)
        {
            enemy_rigid.transform.Rotate(Vector3.back * 180);
            enemy_rigid.velocity = Vector2.down * enemy_speed;
        }
    }
}
