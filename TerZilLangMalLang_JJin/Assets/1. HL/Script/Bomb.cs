using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 5f;
    public int getDamage_NB = 10;

    GameObject player;
    SpriteRenderer sprender;
    Rigidbody2D rigid;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        sprender = player.GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();

        //rigid.AddForce(-player.transform.right * speed * Time.deltaTime, ForceMode2D.Force);   
    }

    void Update()
    {

        //this.transform.position += -player.transform.right * speed * Time.deltaTime;

        //this.transform.position += player.transform.right * speed * Time.deltaTime;


        if (sprender.flipX == false)
        {
            this.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
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
