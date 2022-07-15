using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


    // 이름, 레벨, 코인, 착용중인 무기
    
    
}

public class DataManager : MonoBehaviour
{
    //저장하는 방법
    //1. 저장할 데이터가 존재
    //2. 데이터를 제이슨으로 변환
    //3. 제이슨을 외부에 저장

    //불러오는 방법
    //1. 외부 저장된 제이슨을 가져옴
    //2. 제이슨을 데이터 형태로 반환
    //3. 불러온 데이터 사용

    public static DataManager instance; // 싱글톤패턴

    public PlayerData nowPlayer = new PlayerData(); // 플레이어 데이터 생성

    public string path; // 경로
    public int nowSlot; // 현재 슬롯번호

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        // DataManager가 파괴되지않도록 유지

        path = Application.persistentDataPath + "/savedata";
        //모바일, PC 상관없이 유티니가 지정한 가장 손쉽게 사용할수 있는 저장경로
        //임시로 저장한 테스트용(삭제필수)
        print(path);
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);    //Json으로 변환
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());  //PlayerData 형식으로 변환
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}