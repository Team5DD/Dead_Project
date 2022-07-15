using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bombmanager : MonoBehaviour
{
    Transform firePositon_L;
    Transform firePositon_R;

    public GameObject[] nBombFactory;
    public GameObject[] sBombFactory;
    public Button buttonIT;
    float timer;
    bool ClickBntSB = false;
    bool ClickBntNB = false;

    GameObject PlayerTag;
    SpriteRenderer sprender;

    private void Start()
    {
        PlayerTag = GameObject.Find("Player");
        sprender = PlayerTag.GetComponent<SpriteRenderer>();
        firePositon_L = PlayerTag.transform.GetChild(0);
        firePositon_R = PlayerTag.transform.GetChild(1);
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

        if (PlayerTag.gameObject.CompareTag("Yellow") == true)
        {
            GameObject bomb = Instantiate(nBombFactory[0]);
            if (sprender.flipX == true)
            {
                bomb.transform.position = firePositon_L.position;
            }
            else
            {
                bomb.transform.position = firePositon_R.position;
            }
            buttonIT.interactable = false;
            ClickBntNB = true;
            Destroy(bomb, 2.5f);

        }
        if (PlayerTag.gameObject.CompareTag("Half") == true)
        {
            GameObject bomb = Instantiate(nBombFactory[1]);
            bomb.transform.position = firePositon_L.position;
            buttonIT.interactable = false;
            ClickBntNB = true;
            Destroy(bomb, 2.5f);

        }
        if (PlayerTag.gameObject.CompareTag("Blackjoy") == true)
        {
            GameObject bomb = Instantiate(nBombFactory[2]);
            bomb.transform.position = firePositon_L.position;
            buttonIT.interactable = false;
            ClickBntNB = true;
            Destroy(bomb, 2.5f);

        }
        if (PlayerTag.gameObject.CompareTag("Blue") == true)
        {
            GameObject bomb = Instantiate(nBombFactory[3]);
            bomb.transform.position = firePositon_L.position;
            buttonIT.interactable = false;
            ClickBntNB = true;
            Destroy(bomb, 2.5f);

        }
        if (PlayerTag.gameObject.CompareTag("Pink") == true)
        {
            GameObject bomb = Instantiate(nBombFactory[4]);
            bomb.transform.position = firePositon_L.position;
            buttonIT.interactable = false;
            ClickBntNB = true;
            Destroy(bomb, 2.5f);

        }

    }

    public void OnButtonDownSpecial()
    {
        if (PlayerTag.gameObject.CompareTag("Yellow") == true)
        {
            GameObject bomb = Instantiate(sBombFactory[0]);
            bomb.transform.position = firePositon_L.position + new Vector3(0, 1.5f, 0);
            Destroy(bomb, 2.5f);

        }
        if (PlayerTag.gameObject.CompareTag("Half") == true)
        {
            GameObject bomb = Instantiate(sBombFactory[1]);
            bomb.transform.position = firePositon_L.position;
            Destroy(bomb, 2.5f);

        }
        if (PlayerTag.gameObject.CompareTag("Blackjoy") == true)
        {
            GameObject bomb = Instantiate(sBombFactory[2]);
            bomb.transform.position = firePositon_L.position;
            Destroy(bomb, 2.5f);

        }
        if (PlayerTag.gameObject.CompareTag("Blue") == true)
        {
            GameObject bomb = Instantiate(sBombFactory[3]);
            bomb.transform.position = firePositon_L.position;
            Destroy(bomb, 2.5f);

        }
        if (PlayerTag.gameObject.CompareTag("Pink") == true)
        {
            GameObject bomb = Instantiate(sBombFactory[4]);
            bomb.transform.position = firePositon_L.position;
            Destroy(bomb, 2.5f);

        }

        buttonIT.interactable = false;
        ClickBntSB = true;
        //만약 눌렸다면, 비활성화한다. 4초동안

    }

}
