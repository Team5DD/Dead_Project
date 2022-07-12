using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private VirtualJoystick virtualJoystick;
    private float moveSpeed = 5;
    public float jumpPower = 5f;
    Rigidbody2D rigid2d;

    public void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();

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

    public void OnButtonDown()
    {
        rigid2d.velocity = new Vector2(rigid2d.velocity.y, jumpPower);
    }
}

