using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;

public class Character
{
    public GameObject char_Img;
    public GameObject char_Info;
    public string name;
    public string concept_Txt;
    public int nft_Number;

    public Character(GameObject _char_Img, GameObject _char_Info, string _name, int _nft_Number, string _concept)
    {
        char_Img = _char_Img;
        char_Info = _char_Info;
        name = _name;
        nft_Number = _nft_Number;
        concept_Txt = _concept;
    }
}

public class Character_Choice_Manager : MonoBehaviour
{
    public GameObject[] character_Img; // 캐릭터 이미지 배열
    public GameObject[] character_Info; 
    public int selectCharCount = 0;           // 캐릭터 선택 번호
    int getKeyNum;

    public Dictionary<int, Character> characterChoice;

    public Button gameStart;

    public Image dragon2_image;
    public Image dragon3_image;
    public Image dragon4_image;
    public Image dragon5_image;
    public Image[] crown_Image;
                             
    public Sprite[] drangons;
    public Sprite[] crowns;

    public int debug_StageClear = 0;
    // Start is called before the first frame update
    void Start()
    {
        character_Img[selectCharCount].SetActive(true); // 0번 캐릭터 이미지 활성화
        character_Info[selectCharCount].SetActive(true); 
        characterChoice = new Dictionary<int, Character>();

        string name;

        name = "원더 드래곤";
        characterChoice.Add(0, new Character(character_Img[0],character_Info[0], name, 1234523, "노랭이"));
        name = "엔젤 드래곤";
        characterChoice.Add(1, new Character(character_Img[1],character_Info[1], name, 323451, "검흰댕이"));
        name = "위너 드래곤";
        characterChoice.Add(2, new Character(character_Img[2],character_Info[2], name, 544353, "검댕이무지개"));
        name = "베리 드래곤";
        characterChoice.Add(3, new Character(character_Img[3],character_Info[3], name, 54634, "핑크핑쿠"));
        name = "지니 드래곤";
        characterChoice.Add(4, new Character(character_Img[4],character_Info[4], name, 987654, "퍼랭이"));
    }

    private void Update()
    {
        print($"1:{Save_PlayerChoice.instance.isClear_1}");
        print($"2:{Save_PlayerChoice.instance.isClear_2}");
        print($"3:{Save_PlayerChoice.instance.isClear_3}");
        print($"4:{Save_PlayerChoice.instance.isClear_4}");

        #region 스테이지 클리어시 이미지 변경
        if (Save_PlayerChoice.instance.isClear_1 == true)
        {
            dragon2_image.sprite = drangons[1];
            crown_Image[0].sprite = crowns[0];
            Save_PlayerChoice.instance.save_StageClear = 1;

            if(selectCharCount > 1)
            {
                print("거부");
                gameStart.interactable = false;
            }
            else
            {
                print("승인");
                gameStart.interactable = true;
            }
        }

         if (Save_PlayerChoice.instance.isClear_2 == true)
        {
            dragon3_image.sprite = drangons[2];
            crown_Image[1].sprite = crowns[1];
            Save_PlayerChoice.instance.save_StageClear = 2;

            if (selectCharCount > 2)
            {
                gameStart.interactable = false;
            }
            else
            {
                gameStart.interactable = true;
            }
        }

         if(Save_PlayerChoice.instance.isClear_3 == true)
        {
            dragon4_image.sprite = drangons[3];
            crown_Image[2].sprite = crowns[2];
            Save_PlayerChoice.instance.save_StageClear = 3;

            if (selectCharCount > 3)
            {
                gameStart.interactable = false;
            }
            else
            {
                gameStart.interactable = true;
            }
        }

         if(Save_PlayerChoice.instance.isClear_4 == true)
        {
            dragon5_image.sprite = drangons[4];
            crown_Image[3].sprite = crowns[3];
            Save_PlayerChoice.instance.save_StageClear = 4;

        }
        if(Save_PlayerChoice.instance.isClear_1 == false)
        {
            if (selectCharCount > 0)
            {
                gameStart.interactable = false;
            }
            else
            {
                gameStart.interactable = true;
            }
        }
        #endregion
    }

    public void LeftBtn_Clik()
    {
        selectCharCount--;
        if (selectCharCount < 0)
        {
            selectCharCount += 5;
        }
        for (int i = 0; i < 5; i++)
        {
            //character_Img[i].SetActive(false);
            if (characterChoice.ContainsKey(i))
            {
                Character charf = characterChoice[i];
                charf.char_Img.SetActive(false);
                charf.char_Info.SetActive(false);
            }
        }
        //character_Img[selectCharCount].SetActive(true);
        Character charf1 = characterChoice[selectCharCount];
        charf1.char_Img.SetActive(true);
        charf1.char_Info.SetActive(true);
        
    }

    public void RightBtn_Clik()
    {
        selectCharCount++;
        selectCharCount %= 5;

        for (int i = 0; i < 5; i++)
        {
            //character_Img[i].SetActive(false);
            if (characterChoice.ContainsKey(i))
            {
                Character charf = characterChoice[i];
                charf.char_Img.SetActive(false);
                charf.char_Info.SetActive(false);
            }
        }
        //character_Img[selectCharCount].SetActive(true);
        Character charf1 = characterChoice[selectCharCount];
        charf1.char_Img.SetActive(true);
        charf1.char_Info.SetActive(true);
    }

    public void GameStart_Clik()
    {
        if (characterChoice.ContainsKey(selectCharCount))
        {
            Character choiceNow = characterChoice[selectCharCount];

            // 플레이어가 선택한 캐릭터를 저장하기
            Save_PlayerChoice.instance.save_char_Img = choiceNow.char_Img;
            Save_PlayerChoice.instance.save_char_Name = choiceNow.name;
            Save_PlayerChoice.instance.save_nft_Number = choiceNow.nft_Number;

            gameStart.interactable = true;
            Save_PlayerChoice.instance.char_Prefeb_Choice = Save_PlayerChoice.instance.char_Prefeb[selectCharCount];
        }
        SceneManager.LoadScene(2);
    }

    public void Debug_StageClear()
    {
        debug_StageClear++;

        if(debug_StageClear == 1)       Save_PlayerChoice.instance.isClear_1 = true;
        else if(debug_StageClear == 2)  Save_PlayerChoice.instance.isClear_2 = true;
        else if(debug_StageClear == 3)  Save_PlayerChoice.instance.isClear_3 = true;
        else if(debug_StageClear == 4)  Save_PlayerChoice.instance.isClear_4 = true;

    }
}
