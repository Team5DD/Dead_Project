using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBomb : MonoBehaviour
{
    public float speed = 8f;
    public int getDamage_SB = 25;
    void Start()
    {
    }

    void Update()
    {
        this.transform.position += -transform.right * speed * Time.deltaTime;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //수빈이 보스 스크립트
        //특수공격은 적의 HP를 많이 깜

        BossPatern enemy = collision.GetComponent<BossPatern>();
        if (enemy != null)
        {
            BossHP.instance.HP -= getDamage_SB; // 보스의 HP 많이 까임

        }
    }
}
