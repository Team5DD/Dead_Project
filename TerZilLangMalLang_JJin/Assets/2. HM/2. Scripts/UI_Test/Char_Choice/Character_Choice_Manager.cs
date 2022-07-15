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
    AudioSource ads;
    GameObject findobject;
    public GameObject savePrefeb;
    public GameObject[] character_Img; // ĳ���� �̹��� �迭
    public GameObject[] character_Info;
    public GameObject dark_Ticket;
    public TextMeshProUGUI crown_NUM;
    public int crownCount = 0;
    public int selectCharCount = 0;           // ĳ���� ���� ��ȣ
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

    public GameObject ticket_FullSize;
    public TextMeshProUGUI ticket_Num;
    public int debug_StageClear = 0;
    string ticket_RandNum;

    // Start is called before the first frame update
    void Start()
    {
        ads = GetComponent<AudioSource>();

        character_Img[selectCharCount].SetActive(true); // 0�� ĳ���� �̹��� Ȱ��ȭ
        character_Info[selectCharCount].SetActive(true);
        characterChoice = new Dictionary<int, Character>();

        #region Dictionary�� ĳ���� �߰�

        string name;
        name = "���� �巡��";
        characterChoice.Add(0, new Character(character_Img[0], character_Info[0], name, 1234523, "�뷩��"));
        name = "���� �巡��";
        characterChoice.Add(1, new Character(character_Img[1], character_Info[1], name, 323451, "�������"));
        name = "���� �巡��";
        characterChoice.Add(2, new Character(character_Img[2], character_Info[2], name, 544353, "�˴��̹�����"));
        name = "���� �巡��";
        characterChoice.Add(3, new Character(character_Img[3], character_Info[3], name, 54634, "��ũ����"));
        name = "���� �巡��";
        characterChoice.Add(4, new Character(character_Img[4], character_Info[4], name, 987654, "�۷���"));
        #endregion

        //findobject = GameObject.Find("Player_Choice_Save(Clone)");
        //if (findobject == null)
        //{
        //    GameObject saveFile = Instantiate(savePrefeb);
        //    saveFile.transform.position = new Vector3(0, 0, 0);
        //}

        //MakeTicketRanNum();
    }

    private void Update()
    {
        crown_NUM.text = $"{crownCount}";

        #region �������� Ŭ����� �̹��� ����
        if (AutoSave.instance.gameData.isClear_1 == true)
        {
            crownCount = 1;
            dragon2_image.sprite = drangons[1];
            crown_Image[0].sprite = crowns[0];
            AutoSave.instance.save_StageClear = 1;

            if (selectCharCount > 1)
            {
                gameStart.interactable = false;
            }
            else
            {
                gameStart.interactable = true;
            }
        }

        if (AutoSave.instance.gameData.isClear_2 == true)
        {
            crownCount = 2;
            dragon3_image.sprite = drangons[2];
            crown_Image[1].sprite = crowns[1];
            AutoSave.instance.save_StageClear = 2;

            if (selectCharCount > 2)
            {
                gameStart.interactable = false;
            }
            else
            {
                gameStart.interactable = true;
            }
        }

        if (AutoSave.instance.gameData.isClear_3 == true)
        {
            crownCount = 3;
            dragon4_image.sprite = drangons[3];
            crown_Image[2].sprite = crowns[2];
            AutoSave.instance.save_StageClear = 3;

            if (selectCharCount > 3)
            {
                gameStart.interactable = false;
            }
            else
            {
                gameStart.interactable = true;
            }
        }

        if (AutoSave.instance.gameData.isClear_4 == true)
        {
            crownCount = 4;
            dragon5_image.sprite = drangons[4];
            crown_Image[3].sprite = crowns[3];
            AutoSave.instance.save_StageClear = 4;

            if (selectCharCount > 4)
            {
                gameStart.interactable = false;
            }
            else
            {
                gameStart.interactable = true;
            }

        }
        if(AutoSave.instance.gameData.isClear_5 == true)
        {

            ticket_Num.text = AutoSave.instance.TicketRandNum;
            AutoSave.instance.save_StageClear = 5;
            dark_Ticket.SetActive(false);
            gameStart.interactable = true;
        }

        if (AutoSave.instance.gameData.isClear_1 == false)
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

    //���� ��ư Ŭ��
    public void LeftBtn_Clik()
    {
        ads.Play();
        selectCharCount--;
        if (selectCharCount < 0)
        {
            selectCharCount += 5;
        }
        for (int i = 0; i < 5; i++)
        {
            if (characterChoice.ContainsKey(i))
            {
                Character charf = characterChoice[i];
                charf.char_Img.SetActive(false);
                charf.char_Info.SetActive(false);
            }
        }
        Character charf1 = characterChoice[selectCharCount];
        charf1.char_Img.SetActive(true);
        charf1.char_Info.SetActive(true);

    }   

    //������ ��ư Ŭ��
    public void RightBtn_Clik()
    {
        ads.Play();
        selectCharCount++;
        selectCharCount %= 5;

        for (int i = 0; i < 5; i++)
        {
            if (characterChoice.ContainsKey(i))
            {
                Character charf = characterChoice[i];
                charf.char_Img.SetActive(false);
                charf.char_Info.SetActive(false);
            }
        }
        Character charf1 = characterChoice[selectCharCount];
        charf1.char_Img.SetActive(true);
        charf1.char_Info.SetActive(true);
    }

    //���ӽ�ŸƮ ��ư Ŭ��
    public void GameStart_Clik()
    {
        ads.Play();
        if (characterChoice.ContainsKey(selectCharCount))
        {
            Character choiceNow = characterChoice[selectCharCount];

            // �÷��̾ ������ ĳ���͸� �����ϱ�
            AutoSave.instance.save_char_Img = choiceNow.char_Img;
            AutoSave.instance.save_char_Name = choiceNow.name;
            AutoSave.instance.save_nft_Number = choiceNow.nft_Number;

            gameStart.interactable = true;
            AutoSave.instance.char_Prefeb_Choice = AutoSave.instance.char_Prefeb[selectCharCount];
        }
        SceneManager.LoadScene(2);
    }

    public void TicketClik()
    {
        ads.Play();
        ticket_FullSize.SetActive(true);
    }

    //����� ��ư Ŭ��
    public void Debug_StageClear()
    {
        debug_StageClear++;

        if (debug_StageClear == 1) AutoSave.instance.gameData.isClear_1 = true;
        else if (debug_StageClear == 2) AutoSave.instance.gameData.isClear_2 = true;
        else if (debug_StageClear == 3) AutoSave.instance.gameData.isClear_3 = true;
        else if (debug_StageClear == 4) AutoSave.instance.gameData.isClear_4 = true;
        else if (debug_StageClear == 5) AutoSave.instance.gameData.isClear_5 = true;

    }
}
