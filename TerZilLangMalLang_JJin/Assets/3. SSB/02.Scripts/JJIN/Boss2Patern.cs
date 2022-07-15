using System;
using System.Collections;
using UnityEngine;


public class Boss2Patern : MonoBehaviour
{
    public static Boss2Patern instance;
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
    public GameObject[] FireFactory;
    public Transform FirePosiotion;
    public float Distance;
    SpriteRenderer spriterenderer;
    public GameObject Capsule;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        PlayerTarget = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
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
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);
        }
        else // Ÿ���� �����ʿ� ���� ��
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
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
private void BossAI()
{
        anim.SetTrigger("Idle");
        //���� ���°� ���� �����϶��� ����ȴ�.
        print("BossAI");
        int randAction = UnityEngine.Random.Range(0, 3);
        //int randAction = 0;
        switch (randAction)
        {
            case 0:
                     //���� 0 ���� - Blink ��  Player ���� �����̵� �� ��������
                     BossTelePortDash();
                     break;
            case 1:
                     //���� 1 ���� - �Ҳ� �ձ�                  
                     BossAttack();
                     break;
            case 2:
                     //���� 3 ���� - Player �Ӹ������� ���� �������� �� ��������
                     BossFireRain();
                     break;
        }
}
    private void BossTelePortDash()
    {
        StartCoroutine("BossTel");
        p = false;
        state = State.Chase;
    }
    IEnumerator BossTel()
    {
        StartCoroutine(Blink(2));
        yield return new WaitForSeconds(0.5f);
        int num = UnityEngine.Random.Range(0, 2);
        if (num == 0)
        {
            this.transform.position = new Vector3(PlayerTarget.transform.position.x,0,0) + new Vector3(5, 2, 0);
        }
        if (num == 1)
        {
            this.transform.position = new Vector3(PlayerTarget.transform.position.x, 0, 0) + new Vector3(-5, 2, 0);
        }
        Blink(3);
        yield return new WaitForSeconds(0.5f);
        FaceTarget();
        anim.SetTrigger("Strike");
        EfxAnim.SetTrigger("StrikeEfx");
        StartCoroutine("Dash");
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
        for (int i = 0; i < 50; i++)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(PlayerTarget.transform.position.x ,1,0), 0.05f) ;
            yield return 0;
        }
    }
    //���� ���� ����
    //�Ҳ� �ձ�

    private void BossAttack()
    {
    FaceTarget();
    anim.SetTrigger("Attack");
    EfxAnim.SetTrigger("AttackEfx");
        StartCoroutine("attack");
        p = false;
        state = State.Chase;
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject[] Fire = new GameObject[bossAttackfirenum];
        for (int i = 0; i < bossAttackfirenum; i++)
        {
            Fire[i] = Instantiate(FireFactory[1]);
            Fire[i].transform.position = FirePosiotion.transform.position;
        }
        yield return 0;
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
        Fire[i] = Instantiate(FireFactory[1]);
        Fire[i].transform.position = PlayerTarget.transform.position + new Vector3(-(fireRainfirenum % 2) + i, 5f, 0);
            Fire[i].transform.right = -Vector3.up;
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
        spriterenderer.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        spriterenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriterenderer.color = Color.green;
        yield return new WaitForSeconds(0.1f);
    }
}
