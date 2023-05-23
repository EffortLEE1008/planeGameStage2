using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject boss_bullet;
    public GameObject player_bullet;
    public GameObject flarebim;


    GameObject[] enemy_arr;
    
    GameObject[] player_bullet_arr;
    GameObject[] boss_bullet_arr;

    GameObject[] flarebim_arr;

    GameObject[] obj_arr;

    private void Awake()
    {
        enemy_arr = new GameObject[30];
        player_bullet_arr = new GameObject[30];

        boss_bullet_arr = new GameObject[30];
        flarebim_arr = new GameObject[50];

        InitObj();
    }

    void InitObj()
    {
        for(int i =0; i<enemy_arr.Length; i++)
        {

            enemy_arr[i] = Instantiate(enemy);
            enemy_arr[i].SetActive(false);

        }

        for (int i = 0; i < player_bullet_arr.Length; i++)
        {

            player_bullet_arr[i] = Instantiate(player_bullet);
            player_bullet_arr[i].SetActive(false);

        }

        for (int i = 0; i < boss_bullet_arr.Length; i++)
        {

            boss_bullet_arr[i] = Instantiate(boss_bullet);
            boss_bullet_arr[i].SetActive(false);

        }
        for (int i = 0; i < flarebim_arr.Length; i++)
        {

            flarebim_arr[i] = Instantiate(flarebim);
            flarebim_arr[i].SetActive(false);

        }

    }
    public GameObject MakeObj(string type)
    {
        
        switch (type)
        {
            case "Enemy":
                obj_arr = enemy_arr;

                break;

            case "Player_bullet":
                obj_arr = player_bullet_arr;
                break;

            case "Boss_bullet":
                obj_arr = boss_bullet_arr;
                break;

            case "flare_bim":
                obj_arr = flarebim_arr;
                break;
        }

        for (int i = 0; i < obj_arr.Length; i++)
        {

            if (!obj_arr[i].activeSelf)
            {
                obj_arr[i].SetActive(true);
                return obj_arr[i];
            }

        }




        return null;

    }





}
