using System;
using System.Collections;
using UnityEngine;


public class BossPatern2 : MonoBehaviour
{
    public static BossPatern2 instance;
    private void Awake()
    {
        instance = this;
    }
    Animator anim;
    public Animator EfxAnim;    //�ڽ��� �ִϸ�����
    public int getDamage = 10;
    public int bossAttackfirenum =4;
    public int fireRainfirenum = 5;
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
    public float FindDistance = 10.0f;
    public float ChaseDistance = 5f;

    float moveSpeed = 1f;
    float attackTime;
    float curTime;

    [SerializeField] int nextMove;
    public GameObject FireFactory;
    public Transform FirePosiotion;
    public float Distance;
    SpriteRenderer spriterenderer;
    public GameObject Capsule;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        PlayerTarget = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        UIManager.instance.GetCrowUI.SetActive(false);
        UIManager.instance.SuccessUI.SetActive(false);
        Distance = PlayerTarget.transform.position.x - transform.position.x;
        Capsule.SetActive(false);
        spriterenderer = this.gameObject.GetComponent<SpriteRenderer>();

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
        FaceTarget();
        if (BossHP.instance.HP <= 0)
        {
            
            state = State.Die;
        }

        switch (state)
        {
            case State.Idle:
                Idle();
                break;

            case State.Move:
                Move();
                break;
            case State.Pattern:
                BossAI();
                break;
            case State.TakeDamage:
                TakeDamage();
                break;
            case State.Die:
                Die();
                break;

            case State.Chase:
                StartCoroutine("WaitPattern");
                break;

        }
    }
    bool p = false;
    IEnumerator WaitPattern()
    {
        if (p == false)
        {
            p = true;
            yield return new WaitForSeconds(3);
            state = State.Pattern;
        }
    }
    void MoveToTarget()
    {
        if (Mathf.Abs(Distance) <= Mathf.Abs(FindDistance))
        {
            float dir = PlayerTarget.transform.position.x - transform.position.x;
            dir = (dir < AttackDistance) ? -1 : 1;
            transform.Translate(new Vector2(dir, 0) * moveSpeed * Time.deltaTime);
        }
    }
    void FaceTarget()
    {
        if (PlayerTarget.transform.position.x - transform.position.x < 0) // Ÿ���� ���ʿ� ���� ��
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // Ÿ���� �����ʿ� ���� ��
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
       // anim.SetTrigger("Move");
    }
    private void Idle()
    {
        anim.SetTrigger("Idle");
        EfxAnim.SetTrigger("IdleEfx");

        print("Idle");
        Distance = PlayerTarget.transform.position.x - transform.position.x;
        if (Mathf.Abs(Distance) <= Mathf.Abs(FindDistance))
        {
            MoveToTarget();
            
            state = State.Move;
/*
            if (Mathf.Abs(Distance) <= Mathf.Abs(AttackDistance))
            {
                state = State.Pattern;
            }
*/
        }
    }
    private void Move()
    {
        anim.SetTrigger("Move");
        print("Move");
        Distance = PlayerTarget.transform.position.x - transform.position.x;
        if (Mathf.Abs(Distance) <= Mathf.Abs(FindDistance))
        {
            MoveToTarget();
            state = State.Move;
            if (Mathf.Abs(Distance) <= Mathf.Abs(AttackDistance))
            {
                state = State.Pattern;
            }
        }
    }
    bool die = false;
    private void Die()
    {
        if (die == false)
        {
            die = true;
            StartCoroutine("IEDie");
        }
    }
    ///����

    IEnumerator IEDie()
    {
            StartCoroutine(Blink(3));
            anim.SetTrigger("Die");
            yield return new WaitForSeconds(1f);
            print("Die");
            this.gameObject.SetActive(false);
            GameObject capsule = Instantiate(Capsule);
            capsule.SetActive(true);
            capsule.transform.position = this.gameObject.transform.position;
           // StopAllCoroutines ���� !!!
            StopAllCoroutines();

    }
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
    
    public void TakeDamage()
    {
        //���� �ٲٱ�
        StartCoroutine("ColorChange");
        //������ ���
        anim.SetTrigger("Hurt");
        Debug.Log("�� �°� ������ ����");
        BossHP.instance.HP -= getDamage;
        p = false;
        anim.SetTrigger("Idle");
        state = State.Chase;
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
        anim.SetTrigger("Idle");
        //���� ���°� ���� �����϶��� ����ȴ�.
        print("BossAI");
        int randAction = UnityEngine.Random.Range(0, 4);


        switch (randAction)
        {

            case 0:
                     //���� 0 ���� - Blink ��  Player ���� �����̵� �� ��������
                     BossTelePort();
                     break;
            case 1:
                     //���� 1 ���� - �Ҳ� �ձ�                  
                     BossAttack();
                     break;

            case 2:
                     //���� 2 ���� - ���� ��ġ��
                     BossStrike();
                     break;

            case 3:
                     //���� 3 ���� - Player �Ӹ������� ���� �������� �� ��������
                     BossFireRain();
                     break;
        }
}

    private void BossFireRain()
    {
        StartCoroutine("FireRain");
        //���� �ߴٰ� �������� �� ��������
        p = false;
        state = State.Chase;
    }
    IEnumerator FireRain()
    {
        anim.SetTrigger("Jump");
        EfxAnim.SetTrigger("ExposionEfx");
        rb.AddForce(new Vector3(0, 0.001f, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        rb.AddForce(new Vector3(0, -0.002f, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);

        StartCoroutine(Blink(3));
        yield return new WaitForSeconds(0.5f);
        GameObject[] Fire = new GameObject[fireRainfirenum];
        for (int i = 0; i < fireRainfirenum; i++)
        {
            Fire[i] = Instantiate(FireFactory);
            Fire[i].transform.position = PlayerTarget.transform.position + new Vector3(-(fireRainfirenum % 2) + i,5f ,0);
        }
    }
    private void BossTelePort()
    {
        StartCoroutine("BossTel");
        p = false;
        state = State.Chase;
    }
    IEnumerator BossTel()
    {
        StartCoroutine(Blink(2));
        
        
        yield return new WaitForSeconds(0.5f);
        this.transform.position = PlayerTarget.transform.position + new Vector3(0, 3, 0);
        
        rb.bodyType = RigidbodyType2D.Kinematic;

        StartCoroutine(Blink(2));
        yield return new WaitForSeconds(0.3f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(new Vector3(0, -0.001f, 0), ForceMode2D.Impulse);
        EfxAnim.SetTrigger("ExposionEfx");
        anim.SetTrigger("JumpAttack");
    }
    IEnumerator Blink(float num = 2)
    {
        for (int i = 0; i < num; i++)
        {
            spriterenderer.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriterenderer.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
    }
    //���� ���� ����
    //�Ҳ� �ձ�
    private void BossAttack()
    {
    FaceTarget();
    anim.SetTrigger("Attack");
    EfxAnim.SetTrigger("AttackEfx");

        GameObject[] Fire = new GameObject[bossAttackfirenum];
        for (int i=0; i < bossAttackfirenum; i++) {
          Fire[i] = Instantiate(FireFactory);
          Fire[i].transform.position = FirePosiotion.transform.position;
        }
        p = false;
        state = State.Chase;
        

    }

//���� ��ġ��
private void BossStrike()
{
    FaceTarget();
    anim.SetTrigger("Strike");
    EfxAnim.SetTrigger("StrikeEfx");
    StartCoroutine("Dash");

    p = false;
    state = State.Chase;
}

IEnumerator Dash()
{
    for (int i = 0; i < 100; i++)
    {
        this.transform.position = Vector3.Lerp(this.transform.position, PlayerTarget.transform.position, 0.01f);
            yield return 0;
    }
}
private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Bomb"))
    {
        if (BossHP.instance.HP > 1)
        {
                
                print("TakeDamage");
                state = State.TakeDamage;
                // TakeDamage();
                Destroy(collision.gameObject);
            }
            
        
    }
}
    IEnumerator ColorChange()
    {
        spriterenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriterenderer.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        spriterenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriterenderer.color = Color.white;
        yield return new WaitForSeconds(0.1f);
    }
}
