using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossPatern : MonoBehaviour
{
    [Header("ȿ��")]
    public GameObject fireFactory;
    //public GameObject windFactory;
    //public GameObject explosionFactory;
    //public GameObject blastFactory;

    [Header("���� �׾����� UI")]
    [SerializeField] GameObject Crown;
    public GameObject SuccessUI;         //������ �װ� �հ������� ������ϴ� UI ����
    public ParticleSystem succesEfx;    //������ ������ ��ƼŬ

    Animator anim;
    public Animator EfxAnim;    //�ڽ��� �ִϸ�����

    public int getDamage=10;

    public State state;
    public enum State
    {
        Idle,

        Pattern,

        Attack, //�Ҳɻձ�
        Strike, //�����ġ��

        Move,
        TakeDamage,

        Die,


    }

    public GameObject PlayerTarget;

    public float AttackDistance = 2.5f;
    public float FindDistance=5.0f;
    float attackTime;
    float curTime;

    // Start is called before the first frame update
    void Start()
    {
        PlayerTarget = GameObject.Find("Player");
           anim = GetComponent<Animator>();
        Crown.SetActive(false);
        SuccessUI.SetActive(false);
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                StartCoroutine("Idle");
                break;

            case State.Move:
                StartCoroutine("Move");
                break;
//////////////////////////////////////////////////////////////
            case State.Pattern:
                StartCoroutine("Pattern");
                break;

            case State.Strike:
                StartCoroutine("Strike");
                break;

            case State.Attack:
                StartCoroutine("Attack");
                break;
//////////////////////////////////////////////////////////
            case State.TakeDamage:
                Invoke("TakeDamage", 1f);
                break;

            case State.Die:
                StartCoroutine("Die");
                break;
           
        }
    }


    IEnumerator Pattern()
    {

        yield return new WaitForSeconds(0.1f);

        int randAction = Random.Range(0, 4);

        switch (randAction)
        {

            case 0:
            case 1:
                //���� 1 ���� - �Ҳ� �ձ�
                state = State.Attack;
                break;
            case 2:
            case 3:
                //���� 2 ���� - ���� ��ġ��
                state = State.Strike;
                break;
        }
    
    }

    IEnumerable Idle()
    {
        anim.SetTrigger("Idle");
        EfxAnim.SetTrigger("IdleEfx");

        yield return new WaitForSeconds(1f);
    }

    IEnumerator Move()
    {
        anim.SetTrigger("Move");

        yield return new WaitForSeconds(1f);    
    }

    
    /// ///////////
    //���� ����
    
    IEnumerator Attack()
    {
        anim.SetTrigger("Attack");
        EfxAnim.SetTrigger("AttackEfx");
        yield return new WaitForSeconds(1f);
    }

    IEnumerator Strike() 
    {
        anim.SetTrigger("Strike");
        EfxAnim.SetTrigger("StrikeEfx");
        yield return new WaitForSeconds(1f);
    }


    ///����
    IEnumerator Die()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1f); 
    }

    public void TakeDamage()
    {
        anim.SetTrigger("TakeDamage");      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            //������ ���
            anim.SetTrigger("TakeDamage");
            Debug.Log("�� �°� ������ ����");
            BossHP.instance.HP -= getDamage;
        }
    }
}
