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
    public GameObject ButtonRobby;

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
        StartUIImg.SetActive(true);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void TriggerCapusle()
    {

        if (AutoSave.instance.gameData.isClear_4 == true)
        {
            ButtonRobby.SetActive(false);
            EndingUIImg.SetActive(true);
            print("5�ܰ� Ŭ����");
        }
        else if (AutoSave.instance.gameData.isClear_3 == true)
        {
            ClearUIImg.SetActive(true);
          
            AutoSave.instance.gameData.isClear_4 = true;
            ClearImg.sprite = ClearSprite[3];
            print("4�ܰ� Ŭ����");
        }
        else if (AutoSave.instance.gameData.isClear_2 == true)
        {
            ClearUIImg.SetActive(true);
         
            AutoSave.instance.gameData.isClear_3 = true;
            ClearImg.sprite = ClearSprite[2];
            print("3�ܰ� Ŭ����");
        }
        else if (AutoSave.instance.gameData.isClear_1 == true)
        {
            ClearUIImg.SetActive(true);
           
            AutoSave.instance.gameData.isClear_2 = true;
            ClearImg.sprite = ClearSprite[1];
            print("2�ܰ� Ŭ����");
        }

        else if (AutoSave.instance.gameData.isClear_1 == false)
        {
            ClearUIImg.SetActive(true);
            AutoSave.instance.gameData.isClear_1 = true;
            print("1�ܰ� Ŭ����");
        }
    
    
      
    }

    public void GameOverUI()
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
        ButtonOK.SetActive(false);
        ButtonRobby.SetActive(true);
        AutoSave.instance.gameData.isClear_5= true;

    }
}
