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
        //������ �� ��ũ��Ʈ
        //�Ϲݰ����� ���� HP�� ���� ��

        EnemyMove enemy = collision.GetComponent<EnemyMove>();
        if (enemy != null)
        {
            enemy.TakeDamage(); // ���� HP ���� ����
        }
        Destroy(gameObject);
    }

}
