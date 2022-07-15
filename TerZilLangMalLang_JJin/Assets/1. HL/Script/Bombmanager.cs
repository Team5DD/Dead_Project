using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bombmanager : MonoBehaviour
{
    public Transform firePositon_L;
    public Transform firePositon_R;

    public GameObject[] nBombFactory;
    public GameObject[] sBombFactory;
    public Button buttonIT;
    float timer;
    bool ClickBntSB = false;
    bool ClickBntNB = false;

    GameObject PlayerTag;
    SpriteRenderer sprender;

    public GameObject Player;
    public SpriteRenderer PlayerSR;
    private void Start()
    {
        PlayerTag = GameObject.Find("Player");
        //ssprender = PlayerTag.GetComponent<SpriteRenderer>();
        firePositon_L = PlayerTag.transform.GetChild(0);
        firePositon_R = PlayerTag.transform.GetChild(1);

        PlayerSR = PlayerTag.gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (ClickBntSB == true)
        {
            timer += Time.deltaTime;
            if (timer >= 4f)
            {
                buttonIT.interactable = true;
                timer = 0;
                ClickBntSB = false;
            }
        }

        if (ClickBntNB == true)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                buttonIT.interactable = true;
                timer = 0;
                ClickBntNB = false;
            }
        }

    }



    public void OnButtonDownNomal()
    {


        // GameObject bomb = Instantiate(nBombFactory[0]);
        //GameObject bomb = Instantiate(nBombFactory[0], firePositon_L.position, firePositon_L.transform.rotation) ;

        GameObject bomb;
        if (PlayerSR.flipX == false)
        {
            //bomb.transform.position = firePositon_L.position;
            Debug.Log("aaaa");
            bomb = Instantiate(nBombFactory[0], firePositon_L.position, firePositon_L.transform.rotation);
        }
        else
        {
            //bomb.transform.position = firePositon_R.position;
            Debug.Log("bbb");

            bomb = Instantiate(nBombFactory[0], firePositon_R.position, firePositon_R.transform.rotation);
        }
        bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);

        buttonIT.interactable = false;
        ClickBntNB = true;

        //    if (PlayerTag.gameObject.CompareTag("Yellow") == true)
        //    {
        //        GameObject bomb = Instantiate(nBombFactory[0]);
        //        if (sprender.flipX == true)
        //        {
        //            bomb.transform.position = firePositon_L.position;
        //        }
        //        else
        //        {
        //            bomb.transform.position = firePositon_R.position;
        //        }
        //        buttonIT.interactable = false;
        //        ClickBntNB = true;

        //    }
        //    if (PlayerTag.gameObject.CompareTag("Half") == true)
        //    {
        //        GameObject bomb = Instantiate(nBombFactory[1]);
        //        bomb.transform.position = firePositon_L.position;
        //        buttonIT.interactable = false;
        //        ClickBntNB = true;

        //    }
        //    if (PlayerTag.gameObject.CompareTag("Blackjoy") == true)
        //    {
        //        GameObject bomb = Instantiate(nBombFactory[2]);
        //        bomb.transform.position = firePositon_L.position;
        //        buttonIT.interactable = false;
        //        ClickBntNB = true;

        //    }
        //    if (PlayerTag.gameObject.CompareTag("Blue") == true)
        //    {
        //        GameObject bomb = Instantiate(nBombFactory[3]);
        //        bomb.transform.position = firePositon_L.position;
        //        buttonIT.interactable = false;
        //        ClickBntNB = true;

        //    }
        //    if (PlayerTag.gameObject.CompareTag("Pink") == true)
        //    {
        //        GameObject bomb = Instantiate(nBombFactory[4]);
        //        bomb.transform.position = firePositon_L.position;
        //        buttonIT.interactable = false;
        //        ClickBntNB = true;

        //    }

        //}
    }
    public void OnButtonDownSpecial()
    {
        if (PlayerTag.gameObject.CompareTag("Yellow") == true)
        {
            GameObject bomb = Instantiate(sBombFactory[0]);
            bomb.transform.position = firePositon_L.position + new Vector3(0, 1.5f, 0);

        }
        if (PlayerTag.gameObject.CompareTag("Half") == true)
        {
            GameObject bomb = Instantiate(sBombFactory[1]);
            bomb.transform.position = firePositon_L.position;


        }
        if (PlayerTag.gameObject.CompareTag("Blackjoy") == true)
        {
            GameObject bomb = Instantiate(sBombFactory[2]);
            bomb.transform.position = firePositon_L.position;


        }
        if (PlayerTag.gameObject.CompareTag("Blue") == true)
        {
            GameObject bomb = Instantiate(sBombFactory[3]);
            bomb.transform.position = firePositon_L.position;


        }
        if (PlayerTag.gameObject.CompareTag("Pink") == true)
        {
            GameObject bomb = Instantiate(sBombFactory[4]);
            bomb.transform.position = firePositon_L.position;


        }

        buttonIT.interactable = false;
        ClickBntSB = true;
        //만약 눌렸다면, 비활성화한다. 4초동안

    }

}
