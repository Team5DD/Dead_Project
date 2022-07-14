using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bombmanager : MonoBehaviour
{
     Transform firePositon;
    public GameObject[] nBombFactory;
    public GameObject[] sBombFactory;
    public Button buttonIT;
    float timer;
    bool ClickBntSB = false;
    bool ClickBntNB = false;

    GameObject PlayerTag;
    

    private void Start()
    {
        PlayerTag = GameObject.Find("Player");
        firePositon = PlayerTag.transform.GetChild(0);
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
            GameObject bomb = Instantiate(nBombFactory[0], firePositon);
            buttonIT.interactable = false;
            ClickBntNB = true;

        }
        if (PlayerTag.gameObject.CompareTag("Half") == true)
        {
            GameObject bomb = Instantiate(nBombFactory[1], firePositon);
            buttonIT.interactable = false;
            ClickBntNB = true;

        }
        if (PlayerTag.gameObject.CompareTag("Blackjoy") == true)
        {
            GameObject bomb = Instantiate(nBombFactory[2], firePositon);
            buttonIT.interactable = false;
            ClickBntNB = true;

        }
        if (PlayerTag.gameObject.CompareTag("Blue") == true)
        {
            GameObject bomb = Instantiate(nBombFactory[3], firePositon);
            buttonIT.interactable = false;
            ClickBntNB = true;

        }
        if (PlayerTag.gameObject.CompareTag("Pink") == true)
        {
            GameObject bomb = Instantiate(nBombFactory[4], firePositon);
            buttonIT.interactable = false;
            ClickBntNB = true;

        }

    }

    public void OnButtonDownSpecial()
    {
        GameObject SPbomb = Instantiate(nBombFactory[0], firePositon);
        buttonIT.interactable = false;
        ClickBntSB = true;
        //만약 눌렸다면, 비활성화한다. 4초동안

    }

}
