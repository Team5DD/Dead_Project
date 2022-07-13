using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;

public class Character
{
    public GameObject char_Img;
    public string name;
    public string concept_Txt;
    public int nft_Number;

    public Character(GameObject _char_Img, string _name, int _nft_Number, string _concept)
    {
        char_Img = _char_Img;
        name = _name;
        nft_Number = _nft_Number;
        concept_Txt = _concept;
    }
}

public class Character_Choice_Manager : MonoBehaviour
{
    public GameObject[] character_Img; // 캐릭터 이미지 배열
    int selectCharCount = 0;           // 캐릭터 선택 번호
    int getKeyNum;

    public Dictionary<int, Character> characterChoice;

    public TextMeshProUGUI debug_Name;
    public TextMeshProUGUI debug_Nft_Number;
    public TextMeshProUGUI debug_concept;
    public TextMeshProUGUI debug_stageClear;

    public Button gameStart;

    public Image dragon2_image;
    public Image dragon3_image;
    public Image dragon4_image;
    public Image dragon5_image;
    public Image[] crown_Image;
    //public Image crown2_Image;
    //public Image crown3_Image;
    //public Image crown4_Image;
                             
    public Sprite[] drangons;
    public Sprite[] crowns;

    int debug_num = 0;

    // Start is called before the first frame update
    void Start()
    {
        character_Img[selectCharCount].SetActive(true); // 0번 캐릭터 이미지 활성화

        characterChoice = new Dictionary<int, Character>();

        string name;

        name = "원더 드래곤";
        characterChoice.Add(0, new Character(character_Img[0], name, 1234523, "노랭이"));
        name = "엔젤 드래곤";
        characterChoice.Add(1, new Character(character_Img[1], name, 323451, "검흰댕이"));
        name = "위너 드래곤";
        characterChoice.Add(2, new Character(character_Img[2], name, 544353, "검댕이무지개"));
        name = "베리 드래곤";
        characterChoice.Add(3, new Character(character_Img[3], name, 54634, "핑크핑쿠"));
        name = "지니 드래곤";
        characterChoice.Add(4, new Character(character_Img[4], name, 987654, "퍼랭이"));
    }

    private void Update()
    {
        if (Save_PlayerChoice.instance.isClear_1 == true)
        {
            dragon2_image.sprite = drangons[1];
            crown_Image[0].sprite = crowns[0];
            debug_stageClear.text = "Stage 1 클리어";
            Save_PlayerChoice.instance.save_StageClear = 1;
        }

        if (Save_PlayerChoice.instance.isClear_2 == true)
        {
            dragon3_image.sprite = drangons[2];
            crown_Image[1].sprite = crowns[1];
            debug_stageClear.text = "Stage 2 클리어";
            Save_PlayerChoice.instance.save_StageClear = 2;
        }

        if (Save_PlayerChoice.instance.isClear_3 == true)
        {
            dragon4_image.sprite = drangons[3];
            crown_Image[2].sprite = crowns[2];
            debug_stageClear.text = "Stage 3 클리어";
            Save_PlayerChoice.instance.save_StageClear = 3;
        }

        if (Save_PlayerChoice.instance.isClear_4 == true)
        {
            dragon5_image.sprite = drangons[4];
            crown_Image[3].sprite = crowns[3];
            debug_stageClear.text = "Stage 4 클리어";
            Save_PlayerChoice.instance.save_StageClear = 4;
        }
    }

    public void LeftBtn_Clik()
    {
        selectCharCount--;
        if (selectCharCount < 0)
        {
            selectCharCount += 4;
        }
        for (int i = 0; i < 4; i++)
        {
            //character_Img[i].SetActive(false);
            if (characterChoice.ContainsKey(i))
            {
                Character charf = characterChoice[i];
                charf.char_Img.SetActive(false);
                
            }
        }
        //character_Img[selectCharCount].SetActive(true);
        Character charf1 = characterChoice[selectCharCount];
        charf1.char_Img.SetActive(true);
        gameStart.interactable = false;
        
    }

    public void RightBtn_Clik()
    {
        selectCharCount++;
        selectCharCount %= 4;

        for (int i = 0; i < 4; i++)
        {
            //character_Img[i].SetActive(false);
            if (characterChoice.ContainsKey(i))
            {
                Character charf = characterChoice[i];
                charf.char_Img.SetActive(false);
            }
        }
        //character_Img[selectCharCount].SetActive(true);
        Character charf1 = characterChoice[selectCharCount];
        charf1.char_Img.SetActive(true);
        gameStart.interactable = false;
    }

    public void ChoiceBtn_Clik()
    {
        if (characterChoice.ContainsKey(selectCharCount))
        {
            Character choiceNow = characterChoice[selectCharCount];
            debug_Name.text = $"디버그 이름 : {choiceNow.name}";
            debug_Nft_Number.text = $"디버그 NFT 번호 : {choiceNow.nft_Number}";
            debug_concept.text = $"디버그 배경설명 : {choiceNow.concept_Txt}";

            // 플레이어가 선택한 캐릭터를 저장하기
            Save_PlayerChoice.instance.save_char_Img = choiceNow.char_Img;
            Save_PlayerChoice.instance.save_char_Name = choiceNow.name;
            Save_PlayerChoice.instance.save_nft_Number = choiceNow.nft_Number;

            gameStart.interactable = true;
            Save_PlayerChoice.instance.char_Prefeb_Choice = Save_PlayerChoice.instance.char_Prefeb[selectCharCount];
        }
    }

    public void GameStart_Clik()
    {
        SceneManager.LoadScene(2);
    }

    public void Debug_StageClear_Clik()
    {
        debug_num++;

        if (debug_num == 1)
        {
            Save_PlayerChoice.instance.isClear_1 = true;
        }
        else if (debug_num == 2)
        {
            Save_PlayerChoice.instance.isClear_2 = true;
        }
        else if (debug_num == 3)
        {
            Save_PlayerChoice.instance.isClear_3 = true;
        }
        else if (debug_num == 4)
        {
            Save_PlayerChoice.instance.isClear_4 = true;
        }
    }
}
