using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{

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
            
            }
            else	// 데이터가 없는 경우
            {
                slotText[i].text = "비어있음";
            }
        }
        // 불러온 데이터를 초기화시킴.(버튼에 닉네임을 표현하기위함이었기 때문)
        DataManager.instance.DataClear();
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