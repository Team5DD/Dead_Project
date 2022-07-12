using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
    }

    void Update()
    {
        this.transform.position += -transform.right * speed * Time.deltaTime;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        //수빈이 적 스크립트
        //일반공격은 적의 HP를 적게 깜

        EnemyMove enemy = collision.GetComponent<EnemyMove>();
        if (enemy != null)
        {
            enemy.TakeDamage(); // 적의 HP 적게 까임
        }
        Destroy(gameObject);
    }

}
