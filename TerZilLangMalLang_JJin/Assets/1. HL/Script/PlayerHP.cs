using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    SpriteRenderer sp;
    public static PlayerHP instance;
    private void Awake()
    {
        instance = this;
    }

    Image[] playerHP;
    public int damagecount = 0;
    void Start()
    {
        playerHP = GameObject.Find("PlayerHP").GetComponentsInChildren<Image>();
        sp = this.gameObject.GetComponent<SpriteRenderer>();
    }
    IEnumerator blink()
    {
        sp.color = Color.gray;
        yield return new WaitForSeconds(0.1f);
        sp.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        sp.color = Color.gray;
        yield return new WaitForSeconds(0.1f);
        sp.color = Color.white;
        yield return new WaitForSeconds(0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine("blink");
            damagecount++;
            playerHP[damagecount].gameObject.SetActive(false);
        }

    }


}
