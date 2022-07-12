using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public Button gameStart;

    // Start is called before the first frame update
    void Start()
    {
        character_Img[selectCharCount].SetActive(true); // 0번 캐릭터 이미지 활성화

        characterChoice = new Dictionary<int, Character>();

        string name;

        name = "원더 드래곤";
        characterChoice.Add(0, new Character(character_Img[0], name, 1234523,"노랭이"));

        name = "엔젤 드래곤";
        characterChoice.Add(1, new Character(character_Img[1], name, 323451,"검흰댕이"));

        name = "위너 드래곤";
        characterChoice.Add(2, new Character(character_Img[2], name, 544353,"검댕이무지개"));

        name = "베리 드래곤";
        characterChoice.Add(3, new Character(character_Img[3], name, 54634,"핑크핑쿠"));

        name = "지니 드래곤";
        characterChoice.Add(4, new Character(character_Img[4], name, 987654,"퍼랭이"));

       
    }

    public void LeftBtn_Clik()
    {
        selectCharCount--;                              
        if(selectCharCount < 0)
        {
            selectCharCount += 4;
        }
        for (int i = 0; i < 4; i++)
        {
            //character_Img[i].SetActive(false);
            if(characterChoice.ContainsKey(i))
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
        if(characterChoice.ContainsKey(selectCharCount))
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
        }
    }
}
