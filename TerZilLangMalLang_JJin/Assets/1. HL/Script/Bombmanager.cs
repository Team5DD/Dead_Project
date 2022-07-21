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
    public SpriteRenderer PlayerSR;
    private void Start()
    {
        PlayerTag = GameObject.FindWithTag("Player");
        //ssprender = PlayerTag.GetComponent<SpriteRenderer>();
        firePositon_L = PlayerTag.transform.GetChild(0);
        firePositon_R = PlayerTag.transform.GetChild(1);

<<<<<<< Updated upstream
        PlayerSR = PlayerTag.gameObject.GetComponent<SpriteRenderer>();
=======
       // PlayerSR = Player.gameObject.GetComponent<SpriteRenderer>();
>>>>>>> Stashed changes
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

    public void OnButtonJump()
    {
        PlayerTag.GetComponent<PlayerController>().OnButtonDown();
    }


    public void OnButtonDownNomal()
    {


        // GameObject bomb = Instantiate(nBombFactory[0]);
        //GameObject bomb = Instantiate(nBombFactory[0], firePositon_L.position, firePositon_L.transform.rotation) ;

        GameObject bomb;
        if (PlayerSR.flipX == false)
        {
            if (PlayerTag.name.Contains("1"))
            {
                bomb = Instantiate(nBombFactory[0], firePositon_L.position, firePositon_L.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("2"))
            {
                bomb = Instantiate(nBombFactory[1], firePositon_L.position, firePositon_L.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("3"))
            {
                bomb = Instantiate(nBombFactory[2], firePositon_L.position, firePositon_L.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("4"))
            {
                bomb = Instantiate(nBombFactory[3], firePositon_L.position, firePositon_L.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("5"))
            {
                bomb = Instantiate(nBombFactory[4], firePositon_L.position, firePositon_L.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }


        }
        else
        {
            //bomb.transform.position = firePositon_R.position;
            if (PlayerTag.name.Contains("1"))
            {
                bomb = Instantiate(nBombFactory[0], firePositon_R.position, firePositon_R.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("2"))
            {
                bomb = Instantiate(nBombFactory[1], firePositon_R.position, firePositon_R.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("3"))
            {
                bomb = Instantiate(nBombFactory[2], firePositon_R.position, firePositon_R.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("4"))
            {
                bomb = Instantiate(nBombFactory[3], firePositon_R.position, firePositon_R.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("5"))
            {
                bomb = Instantiate(nBombFactory[4], firePositon_R.position, firePositon_R.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }

        }
        

        buttonIT.interactable = false;
        ClickBntNB = true;
    }
    public void OnButtonDownSpecial()
    {
        GameObject bomb;
        if (PlayerSR.flipX == false)
        {
            if (PlayerTag.name.Contains("1"))
            {
                bomb = Instantiate(sBombFactory[0], firePositon_L.position, firePositon_L.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("2"))
            {
                bomb = Instantiate(sBombFactory[1], firePositon_L.position, firePositon_L.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("3"))
            {
                bomb = Instantiate(sBombFactory[2], firePositon_L.position, firePositon_L.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("4"))
            {
                bomb = Instantiate(sBombFactory[3], firePositon_L.position, firePositon_L.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("5"))
            {
                bomb = Instantiate(sBombFactory[4], firePositon_L.position, firePositon_L.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
        }

        else
        {

            if (PlayerTag.name.Contains("1"))
            {
                bomb = Instantiate(sBombFactory[0], firePositon_R.position, firePositon_R.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("2"))
            {
                bomb = Instantiate(sBombFactory[1], firePositon_R.position, firePositon_R.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("3"))
            {
                bomb = Instantiate(sBombFactory[2], firePositon_R.position, firePositon_R.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("4"))
            {
                bomb = Instantiate(sBombFactory[3], firePositon_R.position, firePositon_R.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
            if (PlayerTag.name.Contains("5"))
            {
                bomb = Instantiate(sBombFactory[4], firePositon_R.position, firePositon_R.transform.rotation);
                bomb.GetComponent<Bomb2>().SetDirection(PlayerSR.flipX);
            }
        }

        

        buttonIT.interactable = false;
        ClickBntSB = true;
        //���� ���ȴٸ�, ��Ȱ��ȭ�Ѵ�. 4�ʵ���

    }

}
