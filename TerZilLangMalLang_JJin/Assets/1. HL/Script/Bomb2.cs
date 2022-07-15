using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2 : MonoBehaviour
{
    public float speed = 5f;
    public int getDamage_NB = 10;

    GameObject player;
    SpriteRenderer sprender;


    void Start()
    {
        player = GameObject.Find("Player");
        sprender = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //this.transform.position += -transform.right * speed * Time.deltaTime;

        if (sprender.flipX == false)
        {
            this.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        else
        {
            this.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;

        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //수빈이 적 스크립트
        //일반공격은 적의 HP를 적게 깜
        //BossPatern
        BossPatern enemy = collision.GetComponent<BossPatern>();
        if (enemy != null)
        {
            BossHP.instance.HP -= getDamage_NB; // 보스의 HP 많이 까임

        }
    }
}
