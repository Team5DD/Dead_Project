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
    public GameObject[] character_Img; // ĳ���� �̹��� �迭
    int selectCharCount = 0;           // ĳ���� ���� ��ȣ
    int getKeyNum;

    public Dictionary<int, Character> characterChoice;

    public TextMeshProUGUI debug_Name;
    public TextMeshProUGUI debug_Nft_Number;
    public TextMeshProUGUI debug_concept;

    public Button gameStart;

    // Start is called before the first frame update
    void Start()
    {
        character_Img[selectCharCount].SetActive(true); // 0�� ĳ���� �̹��� Ȱ��ȭ

        characterChoice = new Dictionary<int, Character>();

        string name;

        name = "���� �巡��";
        characterChoice.Add(0, new Character(character_Img[0], name, 1234523,"�뷩��"));

        name = "���� �巡��";
        characterChoice.Add(1, new Character(character_Img[1], name, 323451,"�������"));

        name = "���� �巡��";
        characterChoice.Add(2, new Character(character_Img[2], name, 544353,"�˴��̹�����"));

        name = "���� �巡��";
        characterChoice.Add(3, new Character(character_Img[3], name, 54634,"��ũ����"));

        name = "���� �巡��";
        characterChoice.Add(4, new Character(character_Img[4], name, 987654,"�۷���"));

       
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
            debug_Name.text = $"����� �̸� : {choiceNow.name}";
            debug_Nft_Number.text = $"����� NFT ��ȣ : {choiceNow.nft_Number}";
            debug_concept.text = $"����� ��漳�� : {choiceNow.concept_Txt}";

            // �÷��̾ ������ ĳ���͸� �����ϱ�
            Save_PlayerChoice.instance.save_char_Img = choiceNow.char_Img;
            Save_PlayerChoice.instance.save_char_Name = choiceNow.name;
            Save_PlayerChoice.instance.save_nft_Number = choiceNow.nft_Number;

            gameStart.interactable = true;
        }
    }
}