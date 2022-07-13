using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossPatern : MonoBehaviour
{
    public static BossPatern instance;
    private void Awake()
    {
        instance = this;
    }

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

    public float AttackDistance = 1.5f;
    public float FindDistance=3.0f;

    float moveSpeed = 1f;
    float attackTime;
    float curTime;

    [SerializeField] int nextMove;
    public GameObject FireFactory;
    public Transform FirePosiotion;
    public float Distance;

    // Start is called before the first frame update
    void Start()
    {

        PlayerTarget = GameObject.Find("Player");
           anim = GetComponent<Animator>();
        UIManager.instance.GetCrowUI.SetActive(false);
        UIManager.instance.SuccessUI.SetActive(false);
        Distance= PlayerTarget.transform.position.x - transform.position.x;

    }

    void Update()
    {
         Distance = PlayerTarget.transform.position.x - transform.position.x;


     

        if (Mathf.Abs(Distance) <= Mathf.Abs(FindDistance))
        {
            MoveToTarget();
            FaceTarget();
            if (Mathf.Abs(Distance) <= Mathf.Abs(AttackDistance))
            {
                state = State.Pattern;
            }
        }

        if (BossHP.instance.HP <= 0)
        {
            StopAllCoroutines();
            state = State.Die;
        }

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

    void MoveToTarget()
    {

        if (Mathf.Abs(Distance) <= Mathf.Abs(FindDistance))
        {
           
            float dir = PlayerTarget.transform.position.x - transform.position.x;
            dir = (dir < AttackDistance) ? -1 : 1;
            transform.Translate(new Vector2(dir, 0) * moveSpeed * Time.deltaTime);
            anim.SetTrigger("Move");
        }
     
    }

    void FaceTarget()
    {
        if (PlayerTarget.transform.position.x - transform.position.x < 0) // 타겟이 왼쪽에 있을 때
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // 타겟이 오른쪽에 있을 때
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        anim.SetTrigger("Move");
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
                StartCoroutine("Attack");
                break;
            case 2:
            case 3:
                //공격 2 패턴 - 몸통 박치기
                state = State.Strike;
                StartCoroutine("Strike");
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
    
    IEnumerator Attack()            //불꽃뿜기
    {

        anim.SetTrigger("Attack");
        EfxAnim.SetTrigger("AttackEfx");

        StartCoroutine("FireShot");

        yield return new WaitForSeconds(1f);    
    }

    IEnumerator Strike()            //몸통 박치기
    {    
        anim.SetTrigger("Strike");
        EfxAnim.SetTrigger("StrikeEfx");
        yield return new WaitForSeconds(1f);
    }


    ///죽음
    IEnumerator Die()
    {
        StopAllCoroutines();

        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1f);
        UIManager.instance.SuccessUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        UIManager.instance.SuccessUI.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        UIManager.instance.GetCrowUI.SetActive(true);
        yield return new WaitForSeconds(1f);
        UIManager.instance.GetCrowUI.SetActive(false);

    }

    public void TakeDamage()
    {
        anim.SetTrigger("TakeDamage");
    }

    IEnumerator FireShot()
    {

        //Destroy(Fire);

        GameObject Fire = Instantiate(FireFactory);
        Fire.transform.position = FirePosiotion.transform.position;
        Fire.GetComponent<Rigidbody2D>().velocity = new Vector2(nextMove, 0);

        yield return new WaitForSeconds(1f);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            //데미지 얻기
            anim.SetTrigger("TakeDamage");
            Debug.Log("밤 맞고 데미지 얻음");
            BossHP.instance.HP -= getDamage;
            Debug.Log(BossHP.instance.HP);
        }
    }
}
