using System.Collections;
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
    public int getDamage = 10;
    public State state;
    public enum State
    {
        Idle,

        Pattern,

        Move,
        TakeDamage,

        Die,

        Chase,


    }

    public GameObject PlayerTarget;

    public float AttackDistance = 1.5f;
    public float FindDistance = 3.0f;
    public float ChaseDistance = 5f;

    float moveSpeed = 1f;
    float attackTime;
    float curTime;

    [SerializeField] int nextMove;
    public GameObject FireFactory;
    public Transform FirePosiotion;
    public float Distance;

    public GameObject Capsule;

    // Start is called before the first frame update
    void Start()
    {

        PlayerTarget = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        UIManager.instance.GetCrowUI.SetActive(false);
        UIManager.instance.SuccessUI.SetActive(false);
        Distance = PlayerTarget.transform.position.x - transform.position.x;
        Capsule.SetActive(false);

    }
    IEnumerator abc()
    {
        yield
    }
    void Update()
    {
        // Distance = PlayerTarget.transform.position.x - transform.position.x;
        //if (Mathf.Abs(Distance) <= Mathf.Abs(FindDistance))
        //{        
        //    MoveToTarget();
        //    FaceTarget();
        //    state = State.Move;
        //    if (Mathf.Abs(Distance) <= Mathf.Abs(AttackDistance))
        //    {
        //        state = State.Pattern;
        //    }
        //}

        if (BossHP.instance.HP <= 0)
        {
            StopAllCoroutines();
            state = State.Die;
        }

        switch (state)
        {
            case State.Idle:
                Invoke("Idle", 1f);
                break;

            case State.Move:
                Invoke("Move", 1f);
                break;
            ////////////////////////////////////////////////////////////            case State.Pattern:
                BossAI();
                break;
            //////////////////////////////////////////////////////////
            case State.TakeDamage:
                Invoke("TakeDamage", 1f);
                break;

            case State.Die:
                StartCoroutine("Die");
                break;

            case State.Chase:

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
    private void Idle()
    {
        anim.SetTrigger("Idle");
        EfxAnim.SetTrigger("IdleEfx");

        Distance = PlayerTarget.transform.position.x - transform.position.x;
        if (Mathf.Abs(Distance) <= Mathf.Abs(FindDistance))
        {
            MoveToTarget();
            FaceTarget();
            state = State.Move;
            if (Mathf.Abs(Distance) <= Mathf.Abs(AttackDistance))
            {
                state = State.Pattern;
            }
        }
    }
    private void Move()
    {
        anim.SetTrigger("Move");
        Distance = PlayerTarget.transform.position.x - transform.position.x;
        if (Mathf.Abs(Distance) <= Mathf.Abs(FindDistance))
        {
            MoveToTarget();
            FaceTarget();
            state = State.Move;
            if (Mathf.Abs(Distance) <= Mathf.Abs(AttackDistance))
            {
                state = State.Pattern;
            }
        }
    }
    ///죽음
    IEnumerator Die()
    {
        anim.SetTrigger("Die");
        Capsule.SetActive(true);
        Destroy(this.gameObject);
        yield return new WaitForSeconds(2f);
        //UIManager.instance.SuccessUI.SetActive(true);
        //StartCoroutine("OffSiccessUI");

        //UIManager.instance.SuccessUI.SetActive(false);
        //yield return new WaitForSeconds(1f);
        //Debug.Log("bbb");

        //UIManager.instance.GetCrowUI.SetActive(true);
        //yield return new WaitForSeconds(1f);
        //Debug.Log("ccc");
        //UIManager.instance.GetCrowUI.SetActive(false);
        //Destroy(this.gameObject);
    }
    public void TakeDamage()
    {
    anim.SetTrigger("TakeDamage");
    }

//public void FireShot()
//{

//    //Destroy(Fire);

//    GameObject Fire = Instantiate(FireFactory);
//    Fire.transform.position = FirePosiotion.transform.position;
//    Fire.GetComponent<Rigidbody2D>().velocity = new Vector2(nextMove, 0);


//    state = State.Idle;

//}


private void BossAI()
{
    //보스 상태가 공격 상태일때만 실행된다.
    if (state == State.Pattern)
    {
        int randAction = Random.Range(0, 4);

        switch (randAction)
        {

            case 0:
            case 1:
                //공격 1 패턴 - 불꽃 뿜기                  
                BossAttack();
                break;
            case 2:
            case 3:
                //공격 2 패턴 - 몸통 박치기
                BossStrike();
                break;
        }
    }
}

//보스 패턴 형식
//불꽃 뿜기
private void BossAttack()
{
    Debug.Log("공격");
    anim.SetTrigger("Attack");
    EfxAnim.SetTrigger("AttackEfx");

    GameObject Fire = Instantiate(FireFactory);
    Fire.transform.position = FirePosiotion.transform.position;

        if (Distance < ChaseDistance)
        {
            state = State.Move;
        }

}

//몸통 박치기
private void BossStrike()
{
    anim.SetTrigger("Strike");
    EfxAnim.SetTrigger("StrikeEfx");

    Distance = PlayerTarget.transform.position.x - transform.position.x;
    if (Mathf.Abs(Distance) < Mathf.Abs(AttackDistance))
    {
        BossAI();
    }
    else
    {
        state = State.Move;
    }
}

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Bomb"))
    {
        if (BossHP.instance.HP > 1)
        {
            //데미지 얻기
            anim.SetTrigger("TakeDamage");
            Debug.Log("밤 맞고 데미지 얻음");
            BossHP.instance.HP -= getDamage;
            Destroy(collision.gameObject);
        }
        else
        {
            //state = State.Die;
            StartCoroutine("Die");
        }
    }
}
}
