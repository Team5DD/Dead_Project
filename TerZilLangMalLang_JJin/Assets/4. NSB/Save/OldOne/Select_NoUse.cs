using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{
    public GameObject create;	// 빈 공간 알림 UI => 차후 확인 버튼이 겜 시작버튼으로...
    public Text[] slotText;		// 슬롯버튼 아래에 존재하는 Text들

    bool[] savefile = new bool[3];	// 세이브파일 존재유무 저장

    void Start()
    {
        // 슬롯별로 저장된 데이터가 존재하는지 판단.
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path+ $"{i}"))	// 데이터가 있는 경우
            {
                savefile[i] = true;			// 해당 슬롯 번호의 bool배열 true로 변환
                DataManager.instance.nowSlot = i;	// 선택한 슬롯 번호 저장
                DataManager.instance.LoadData();	// 해당 슬롯 데이터 불러옴
                slotText[i].text = DataManager.instance.nowPlayer.CharacterName;	// 버튼에 닉네임 표시
            }
            else	// 데이터가 없는 경우
            {
                slotText[i].text = "비어있음";
            }
        }
        // 불러온 데이터를 초기화시킴.(버튼에 닉네임을 표현하기위함이었기 때문)
        DataManager.instance.DataClear();
    }

    //슬롯이 3개인데 어떻게 알맞게 불러오는가
    public void Slot(int number)	// 슬롯의 기능 구현
    {
        DataManager.instance.nowSlot = number;	// 슬롯의 번호를 슬롯번호로 입력함.

        if (savefile[number])	// bool 배열에서 현재 슬롯번호가 true라면 = 데이터 존재한다는 뜻
        {
            DataManager.instance.LoadData();	// 데이터를 로드하고
            GoGame();	// 게임씬으로 이동
        }
        else	// bool 배열에서 현재 슬롯번호가 false라면 데이터가 없다는 뜻
        {
            Create();	// 슬롯 빈공간 알림 UI 활성화
        }
    }

    public void Create()	// 슬롯 빈공간 알림 UI 띄움
    {
        create.gameObject.SetActive(true);
    }

    public void GoGame()
    {
        if (!savefile[DataManager.instance.nowSlot])	// 현재 슬롯번호의 데이터가 없다면
        {
            SceneManager.LoadScene("GameScene"); // 캐릭터 선택 씬으로 이동(수정필요)
        }
        SceneManager.LoadScene("GameScene");// 게임씬으로 이동
    }
}