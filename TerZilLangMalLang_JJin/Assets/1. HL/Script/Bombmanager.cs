using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bombmanager : MonoBehaviour
{
    public Transform firePositon;
    public GameObject nBombFactory;
    public GameObject sBombFactory;
    public Button buttonIT;
    public float timer;
    bool ClickBntSB = false;
    bool ClickBntNB = false;


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
            if (timer >= 0.5f)
            {
                buttonIT.interactable = true;
                timer = 0;
                ClickBntNB = false;
            }
        }

    }



    public void OnButtonDownNomal()
    {
        GameObject bomb = Instantiate(nBombFactory, firePositon);
        buttonIT.interactable = false;
        ClickBntNB = true;


    }

    public void OnButtonDownSpecial()
    {
        GameObject SPbomb = Instantiate(sBombFactory, firePositon);
        buttonIT.interactable = false;
        ClickBntSB = true;
        //만약 눌렸다면, 비활성화한다. 4초동안

    }

}
