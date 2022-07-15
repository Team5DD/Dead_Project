using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    private VirtualJoystick virtualJoystick;
    private float moveSpeed = 5;
    public float jumpPower = 5f;
    Rigidbody2D rigid2d;

    public GameObject[] Enemy;
    [SerializeField] float JumpCount=2;
    private bool IsJump;

    public GameObject playerHP;


    public void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        for (int i = 0; i < Enemy.Length; i++)
        {
            Enemy[i] = GameObject.FindWithTag("Enemy");

        }
        JumpCount = 2;
    }

    private void Update()
    {
        float x = virtualJoystick.Horizontal;   // 좌/우 이동
                                                //float y = virtualJoystick.Vertical;		// 위/아래 이동

        if (x != 0)
        {
            transform.position += new Vector3(x, 0, 0) * moveSpeed * Time.deltaTime;
        }

      
    }

    void FaceTarget()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i].transform.position.x - transform.position.x < 0) // 타겟이 왼쪽에 있을 때
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else // 타겟이 오른쪽에 있을 때
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

        }
    }


    //플레이어가 Bomb버튼을 누르면
    //그리고 만약 그 플레이어가 노랑이라면 => 태그 사용
    //이펙트가 생성된다
    //생성된 이펙트는 움직인다 => 애니메이션
    public GameObject[] effectFactoy;

    public void AttackEffect_yellow()
    {
        Debug.Log("노랑이공격");
        if (gameObject.CompareTag("Yellow") == true)
        {
            //만약 노랑이가 맞다면 인덱스0번째 프리펩 생성
            //GameObject[] effect = Instantiate(effectFactoy)[0];
            //effect.transform.position = effectFactoy.transform.position;

        }

    }


    public void AttackEffect_half()
    {
        Debug.Log("반쪽공격");
        if (gameObject.CompareTag("Half") == true)
        {
            //만약 노랑이가 맞다면 인덱스0번째 프리펩 생성
            //GameObject[] effect = Instantiate(effectFactoy)[0];
            //effect.transform.position = effectFactoy.transform.position;

        }

    }

    public void AttackEffect_Blue()
    {
        Debug.Log("파랑이공격");
        if (gameObject.CompareTag("Blue") == true)
        {
            //만약 노랑이가 맞다면 인덱스0번째 프리펩 생성
            //GameObject[] effect = Instantiate(effectFactoy)[0];
            //effect.transform.position = effectFactoy.transform.position;

        }

    }

    public void AttackEffect_Blackjoy()
    {
        Debug.Log("검정조이공격");
        if (gameObject.CompareTag("Blackjoy") == true)
        {
            //만약 노랑이가 맞다면 인덱스0번째 프리펩 생성
            //GameObject[] effect = Instantiate(effectFactoy)[0];
            //effect.transform.position = effectFactoy.transform.position;

        }

    }

    public void AttackEffect_Pink()
    {
        Debug.Log("핑크공격");
        if (gameObject.CompareTag("Pink") == true)
        {
            //만약 노랑이가 맞다면 인덱스0번째 프리펩 생성
            //GameObject[] effect = Instantiate(effectFactoy)[0];
            //effect.transform.position = effectFactoy.transform.position;

        }

    }


    public void OnButtonDown()
    {
        IsJump =true;
        if (IsJump == true)
        {
            if (JumpCount > 0.0f)
            {
                JumpCount--;
                rigid2d.velocity = new Vector2(rigid2d.velocity.y, jumpPower);
            }
        }
    }

    //추가
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            Debug.Log("죽음");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("PrevCol"))
        {

            Destroy(collision.gameObject);
            MapManager.instance.OnColBox();
        }
        if (collision.gameObject.CompareTag("AfterCol"))
        {

            Destroy(collision.gameObject);
            MapManager.instance.OffColBox();

        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            JumpCount = 2;
        }

    }
}

