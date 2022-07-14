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

    // Start is called before the first frame update
    void Start()
    {

        findobject = GameObject.Find("Player_Choice_Save(Clone)");
        if (findobject == null)
        {
            GameObject saveFile = Instantiate(savePrefeb);
            saveFile.transform.position = new Vector3(0, 0, 0);
        }
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

         fadeCount = 1;
        while (fadeCount > 0.0f)
        {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }

        typing_UI.SetActive(true);
        
        char_Choice_UI.SetActive(false);
    }
}
