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
        float x = virtualJoystick.Horizontal;   // ��/�� �̵�
                                                //float y = virtualJoystick.Vertical;		// ��/�Ʒ� �̵�

        if (x != 0)
        {
            transform.position += new Vector3(x, 0, 0) * moveSpeed * Time.deltaTime;
        }

      
    }

    void FaceTarget()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i].transform.position.x - transform.position.x < 0) // Ÿ���� ���ʿ� ���� ��
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else // Ÿ���� �����ʿ� ���� ��
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

        }
    }


    //�÷��̾ Bomb��ư�� ������
    //�׸��� ���� �� �÷��̾ ����̶�� => �±� ���
    //����Ʈ�� �����ȴ�
    //������ ����Ʈ�� �����δ� => �ִϸ��̼�
    public GameObject[] effectFactoy;

    public void AttackEffect_yellow()
    {
        Debug.Log("����̰���");
        if (gameObject.CompareTag("Yellow") == true)
        {
            //���� ����̰� �´ٸ� �ε���0��° ������ ����
            //GameObject[] effect = Instantiate(effectFactoy)[0];
            //effect.transform.position = effectFactoy.transform.position;

        }

    }


    public void AttackEffect_half()
    {
        Debug.Log("���ʰ���");
        if (gameObject.CompareTag("Half") == true)
        {
            //���� ����̰� �´ٸ� �ε���0��° ������ ����
            //GameObject[] effect = Instantiate(effectFactoy)[0];
            //effect.transform.position = effectFactoy.transform.position;

        }

    }

    public void AttackEffect_Blue()
    {
        Debug.Log("�Ķ��̰���");
        if (gameObject.CompareTag("Blue") == true)
        {
            //���� ����̰� �´ٸ� �ε���0��° ������ ����
            //GameObject[] effect = Instantiate(effectFactoy)[0];
            //effect.transform.position = effectFactoy.transform.position;

        }

    }

    public void AttackEffect_Blackjoy()
    {
        Debug.Log("�������̰���");
        if (gameObject.CompareTag("Blackjoy") == true)
        {
            //���� ����̰� �´ٸ� �ε���0��° ������ ����
            //GameObject[] effect = Instantiate(effectFactoy)[0];
            //effect.transform.position = effectFactoy.transform.position;

        }

    }

    public void AttackEffect_Pink()
    {
        Debug.Log("��ũ����");
        if (gameObject.CompareTag("Pink") == true)
        {
            //���� ����̰� �´ٸ� �ε���0��° ������ ����
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

    //�߰�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            Debug.Log("����");
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

