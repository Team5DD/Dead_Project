using System;
using System.Collections;
using UnityEngine;


public class Boss4Patern : MonoBehaviour
{
    public static Boss4Patern instance;
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
    Transform[] SpawnPosition;
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
        SpawnPosition = GameObject.Find("FlyKickSpawnPosition").transform.GetComponentsInChildren<Transform>();
        PlayerTarget = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        UIManager.instance.GetCrowUI.SetActive(false);
        UIManager.instance.SuccessUI.SetActive(false);
        Distance = PlayerTarget.transform.position.x - transform.position.x;
        spriterenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    bool facetarget = true;
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
        if (facetarget == true)
        {
            FaceTarget();
        }
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
            transform.localScale = new Vector3(-2.5f, 2.5f, 1);
        }
        else // Ÿ���� �����ʿ� ���� ��
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 1);
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
        //int randAction = 0;

        switch (randAction)
        {

            case 0:
                //���� 0 ���� - Blink �� Player ���� ���ʿ��� ������ / �����ʿ��� ���� FlyKick
                FlyKick();
                     break;
            case 1:
                //���� 1 ���� - �Ҳ� �ձ�               
                BossAttack();
                     break;

            case 2:
                //���� 2 ���� - ���� ��ġ��
                BossTelePort();
                print("cc");
                break;

            case 3:
                     //���� 3 ���� - Player �Ӹ������� ���� �������� �� ��������
                BossFireRain();
                print("dd");
                break;
        }
}


    private void FlyKick()
    {
        StartCoroutine("Flykick");
        state = State.Chase;
        p = false;
    }

    IEnumerator Flykick()
    {
        facetarget = false;
        anim.SetBool("FlyKick", true); 
        anim.SetTrigger("flykick");
        StartCoroutine(Blink(2));
        this.transform.position = SpawnPosition[1].transform.position;
        rb.simulated = false;
        StartCoroutine(Blink(1));
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 100; i++)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, SpawnPosition[2].transform.position, 0.05f);
            yield return 0;
        }
        this.transform.position = SpawnPosition[3].transform.position;
        StartCoroutine(Blink(2));
        transform.localScale = new Vector3(-2.5f, 2.5f, 1);
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 100; i++)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, SpawnPosition[4].transform.position, 0.05f);
            yield return 0;
        }
        rb.simulated = true;
        anim.SetBool("FlyKick", false);
        yield return new WaitForSeconds(0.3f);
        facetarget = true;
    }
/*
    IEnumerator Dash()
    {

    }
*/
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

        p = false;
        state = State.Chase;
    }
    IEnumerator BA()
    {
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);
        EfxAnim.SetTrigger("AttackEfx");
        GameObject[] Fire = new GameObject[bossAttackfirenum];
        for (int i = 0; i < bossAttackfirenum; i++)
        {
            Fire[i] = Instantiate(FireFactory[0]);
            Fire[i].transform.position = FirePosiotion.transform.position;
        }
        yield return 0;
    }

    //���� ��ġ��
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
        this.transform.position = PlayerTarget.transform.position + new Vector3(0, 6, 0);
        rb.bodyType = RigidbodyType2D.Kinematic;

        StartCoroutine(Blink(2));
        yield return new WaitForSeconds(0.3f);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(new Vector3(0, -0.002f, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.3f);
        GameObject[] Fire = new GameObject[bossAttackfirenum];
        int a = 1;
        for (int i = 0; i < 2; i++)
        {
            a = a * -1;
            Fire[i] = Instantiate(FireFactory[1]);
            Fire[i].transform.position = FirePosiotion.transform.position + new Vector3(0,-1f,0);
            Fire[i].transform.right = FirePosiotion.transform.right * a;
        }
        EfxAnim.SetTrigger("ExposionEfx");
        anim.SetTrigger("JumpAttack");
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
        rb.AddForce(new Vector3(0, 0.002f, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        rb.AddForce(new Vector3(0, -0.003f, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);

        StartCoroutine(Blink(3));
        yield return new WaitForSeconds(0.5f);
        GameObject[] Fire = new GameObject[fireRainfirenum];
        for (int i = 0; i < fireRainfirenum; i++)
        {
            Fire[i] = Instantiate(FireFactory[0]);
            Fire[i].transform.localScale = new Vector3(3f, 3f, 3f);
            Fire[i].transform.position = PlayerTarget.transform.position + new Vector3(-(fireRainfirenum % 2) + i, 5f, 0);
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
