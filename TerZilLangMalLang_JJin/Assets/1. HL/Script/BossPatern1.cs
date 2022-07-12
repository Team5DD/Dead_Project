using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossPatern1 : MonoBehaviour
{
    [Header("효과")]
    public GameObject fireFactory;
    //public GameObject windFactory;
    //public GameObject explosionFactory;
    //public GameObject blastFactory;

    [Header("보스 죽었을때 UI")]
    [SerializeField] GameObject Crown;
    public GameObject SuccessUI;         //보스가 죽고 왕관조각을 얻었습니다 UI 띄우기
    public ParticleSystem succesEfx;    //성공시 나오는 파티클

    Animator anim;
    public Animator EfxAnim;    //자식이 애니메이터

    public int getDamage=10;

    public State state;
    public enum State
    {
        Idle,

        Pattern,

        Attack, //불꽃뿜기
        Strike, //몸통박치기

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
                StartCoroutine("TakeDamage");
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
                //공격 1 패턴 - 불꽃 뿜기
                state = State.Attack;
                break;
            case 2:
            case 3:
                //공격 2 패턴 - 몸통 박치기
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
    //공격 패턴
    
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


    ///죽음
    IEnumerator Die()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1f); 
    }

    IEnumerator TakeDamage()
    {
        anim.SetTrigger("TakeDamage");
        yield return new WaitForSeconds(1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            //데미지 얻기
            Debug.Log("밤 맞고 데미지 얻음");
            BossHP.instance.HP -= getDamage;
        }
    }
}
