using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public static PlayerHP instance;
    private void Awake()
    {
        instance = this;
    }

    public Image[] playerHP;
    public int damagecount = 0;
    void Start()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Ãæµ¹");
        if (collision != null && collision.gameObject.tag == "Enemy")
        {
            damagecount++;

            playerHP[damagecount - 1].gameObject.SetActive(false);

        }

    }


}
