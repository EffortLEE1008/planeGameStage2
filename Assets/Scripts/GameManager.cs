using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyobj;
    [SerializeField]
    Transform[] spawnpos;

    [SerializeField]
    GameObject player;
    GameObject playerobj;

    [SerializeField]
    GameObject boss;

    [SerializeField]
    Transform playerspawnPos;

    [SerializeField]
    Transform bossspawnPoss;
    float max_timer = .7f;
    float cur_timer;

    float enemy_speed = 2;

    public Text scoreText;
    bool isspawnboss = true;

    Player playercs;

    private void Awake()
    {
        playerobj = Instantiate(player, playerspawnPos.position, playerspawnPos.rotation);
        playercs = player.GetComponent<Player>();
        playercs.score = 0;
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
        if((playercs.score >= 0) && isspawnboss){
            isspawnboss = false;
            SpawnBoss();

        }
            
       

        
        scoreText.text = string.Format("{0:n0}", playercs.score);
        
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

    void SpawnBoss()
    {
        // playerid-> 인스턴스화 하고
        
        GameObject bossid = Instantiate(boss, bossspawnPoss.position, bossspawnPoss.rotation);
        bossid.transform.Rotate(Vector3.back * 180);

        //boss.cs파일에 player object에 playerid 인스턴스화 된 값을 넣어주기!!! 핵심 어려움
        Boss bosscs = bossid.GetComponent<Boss>();
        bosscs.player = playerobj;

    }
}
