using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }

    VirtualJoystick virtualJoystick;
    [SerializeField]
    private float moveSpeed = 5;
    public float jumpPower = 8f;
    Rigidbody2D rigid2d;

    public GameObject[] Enemy;
    [SerializeField] float JumpCount=2;
    private bool IsJump;

    bool isRight = true;

    public Camera[] Camera;     //0. �÷��̾��� ���� ī�޶� , 1.���ο� ���� ī�޶�


    public void Start()
    {
        virtualJoystick = GameObject.Find("PlayerCanvas").transform.GetChild(0).GetComponent<VirtualJoystick>();
        rigid2d = GetComponent<Rigidbody2D>();
        JumpCount = 2;
        Camera[0] = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Camera>();
        Camera[1] = GameObject.Find("Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        float x = virtualJoystick.Horizontal;   // ��/�� �̵�
                                                //float y = virtualJoystick.Vertical;		// ��/�Ʒ� �̵�

        if (x != 0)
        {
            transform.position += new Vector3(x, 0, 0) * moveSpeed * Time.deltaTime;
            isRight = x > 0 ? true : false;
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
            Camera[0].gameObject.SetActive(false);
            Camera[1].gameObject.SetActive(true);
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

