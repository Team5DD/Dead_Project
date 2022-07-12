using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBomb : MonoBehaviour
{
    public float speed = 8f;
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

        //EnemyMove enemy = collision.GetComponent<EnemyMove>();
        //if (enemy != null)
        //{
        //    enemy.TakeDamage(); // 보스의 HP 많이 까임
        //}
        //Destroy(gameObject);
    }
}
