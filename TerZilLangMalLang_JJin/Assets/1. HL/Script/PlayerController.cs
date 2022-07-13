using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private VirtualJoystick virtualJoystick;
    private float moveSpeed = 5;
    public float jumpPower = 5f;
    Rigidbody2D rigid2d;

    public GameObject[] Enemy;

    public void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        for (int i = 0; i < Enemy.Length; i++)
        {
            Enemy[i] = GameObject.FindWithTag("Enemy");

        }
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

    public void OnButtonDown()
    {
        rigid2d.velocity = new Vector2(rigid2d.velocity.y, jumpPower);
    }
    //�߰�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            Debug.Log("����");
            Destroy(collision.gameObject);
        }
    }
}

