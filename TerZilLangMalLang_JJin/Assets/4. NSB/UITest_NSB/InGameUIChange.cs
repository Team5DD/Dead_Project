using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterOpen : MonoBehaviour
{
    public static CharacterOpen instance;
    
    public GameObject StartUIImg;
    public GameObject ClearUIImg;
    public GameObject EndingUIImg;
    public GameObject GameOverUIImg;
  
    Image StartImg;
    Image ClearImg;
    Image EndingImg;

    public Sprite[] StartSprite;
    public Sprite[] ClearSprite;
    public Sprite[] EndingSprite;

    public GameObject ButtonOK;
    GameObject ButtonRobby;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartImg = StartUIImg.GetComponent<Image>();
        ClearImg = ClearUIImg.GetComponent<Image>();
        EndingImg = EndingUIImg.GetComponent<Image>();
        TurnOff();


        
    }

    // Update is called once per frame
    void Update()
    {


        //������ ���۵Ǹ�
        //�̼� UI�� ���´�


        if (Save_PlayerChoice.instance.save_StageClear == 0)
        {
            ClearUIImg.SetActive(true);
            Save_PlayerChoice.instance.isClear_1 = true;
            print("1�ܰ� Ŭ����");
        }
        if (Save_PlayerChoice.instance.save_StageClear == 1)
        {
            ClearUIImg.SetActive(true);
            Save_PlayerChoice.instance.isClear_2 = true;
            ClearImg.sprite = ClearSprite[1];
            print("2�ܰ� Ŭ����");
        }
        if (Save_PlayerChoice.instance.save_StageClear == 2)
        {
            ClearUIImg.SetActive(true);
            Save_PlayerChoice.instance.isClear_3 = true;
            ClearImg.sprite = ClearSprite[2];
            print("3�ܰ� Ŭ����");
        }
        if (Save_PlayerChoice.instance.save_StageClear == 3)
        {
            ClearUIImg.SetActive(true);
            Save_PlayerChoice.instance.isClear_4 = true;
            ClearImg.sprite = ClearSprite[3];
            print("4�ܰ� Ŭ����");
        }
        if (Save_PlayerChoice.instance.save_StageClear == 4)
        {
          
            EndingUIImg.SetActive(true);
            print("5�ܰ� Ŭ����");
        }


        //ĸ���� ������


        //�÷��̾� hp�� 0�̵Ǹ�
        //GameOverUI();
    }

    

    void GameOverUI()
    {
        GameOverUIImg.SetActive(true);
    }

    public void GoRobby()
    {
        SceneManager.LoadScene(0);
    }

   public void TurnOff()
    {
        StartUIImg.SetActive(false);
        ClearUIImg.SetActive(false);
        GameOverUIImg.SetActive(false);
        EndingUIImg.SetActive(false);
    }
    public void EndingTicket()
    {
        EndingImg.sprite = EndingSprite[1];
        print("ȭ����!");
       
    }
}
