using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombmanager : MonoBehaviour
{
    public Transform firePositon;
    public GameObject nBombFactory;
    public GameObject sBombFactory;

    void Update()
    {


    }

    public void OnButtonDownNomal()
    {
        GameObject bomb = Instantiate(nBombFactory, firePositon);

    }

    public void OnButtonDownSpecial()
    {
        GameObject SPbomb = Instantiate(sBombFactory, firePositon);

    }

}
