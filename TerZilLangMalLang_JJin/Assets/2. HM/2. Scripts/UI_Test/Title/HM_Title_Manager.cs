using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HM_Title_Manager : MonoBehaviour
{
    GameObject findobject;
    public GameObject savePrefeb;
    public GameObject title_UI;
    public GameObject char_Choice_UI;
    public GameObject characters;
    public GameObject backGround;
    public GameObject typing_UI;

    public Image image;
    public GameObject gameStart_Btn;

    
    bool titleOff = false;

    string ticket_RandNum;

    // Start is called before the first frame update
    void Start()
    {

        findobject = GameObject.Find("Player_Choice_Save(Clone)");
        if (findobject == null)
        {
            GameObject saveFile = Instantiate(savePrefeb);
            saveFile.transform.position = new Vector3(0, 0, 0);
        }

        MakeTicketRanNum();
        Save_PlayerChoice.instance.TicketRandNum = ticket_RandNum;
    }

    // Update is called once per frame
    void Update()
    {
        print(Input.touchCount);

        if (Input.touchCount > 0 && titleOff == false)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                titleOff = true;
                char_Choice_UI.SetActive(true);
                characters.SetActive(true);
                title_UI.SetActive(false);
                backGround.SetActive(true);
            }
        }
    }

    void MakeTicketRanNum()
    {
        for (int i = 0; i < 16; i++)
        {
            int[] a = new int[16];
            a[i] = Random.Range(0, 10);

            ticket_RandNum += $"{a[i]}";
        }

    }

    public void GameStart_Btn()
    {
        StartCoroutine(FadeOutIn());
        gameStart_Btn.SetActive(false);
    }

    IEnumerator FadeOutIn()
    {
        characters.SetActive(false);
        float fadeCount = 0;
        while(fadeCount < 1.0f)
        {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }

        yield return new WaitForSeconds(1.0f);

         

        if(Save_PlayerChoice.instance.isTitleSkip == false)
        {
            backGround.SetActive(false);
            char_Choice_UI.SetActive(false);
            typing_UI.SetActive(true);
            Save_PlayerChoice.instance.isTitleSkip = true;

            fadeCount = 1;
            while (fadeCount > 0.0f)
            {
                fadeCount -= 0.02f;
                yield return new WaitForSeconds(0.01f);
                image.color = new Color(0, 0, 0, fadeCount);
            }
        }
        else
        {
            SceneManager.LoadScene(1);
        }

        
    }
}
