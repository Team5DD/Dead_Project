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
        //������ ���� ��ũ��Ʈ
        //Ư�������� ���� HP�� ���� ��

        BossPatern enemy = collision.GetComponent<BossPatern>();
        if (enemy != null)
        {
            BossHP.instance.HP -= getDamage_SB; // ������ HP ���� ����

        }
    }
}
