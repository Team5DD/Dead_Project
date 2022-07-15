using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


    // �̸�, ����, ����, �������� ����
    
    
}

public class DataManager : MonoBehaviour
{
    //�����ϴ� ���
    //1. ������ �����Ͱ� ����
    //2. �����͸� ���̽����� ��ȯ
    //3. ���̽��� �ܺο� ����

    //�ҷ����� ���
    //1. �ܺ� ����� ���̽��� ������
    //2. ���̽��� ������ ���·� ��ȯ
    //3. �ҷ��� ������ ���

    public static DataManager instance; // �̱�������

    public PlayerData nowPlayer = new PlayerData(); // �÷��̾� ������ ����

    public string path; // ���
    public int nowSlot; // ���� ���Թ�ȣ

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
        // DataManager�� �ı������ʵ��� ����

        path = Application.persistentDataPath + "/savedata";
        //�����, PC ������� ��Ƽ�ϰ� ������ ���� �ս��� ����Ҽ� �ִ� ������
        //�ӽ÷� ������ �׽�Ʈ��(�����ʼ�)
        print(path);
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);    //Json���� ��ȯ
        File.WriteAllText(path + nowSlot.ToString(), data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + nowSlot.ToString());  //PlayerData �������� ��ȯ
        nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowSlot = -1;
        nowPlayer = new PlayerData();
    }
}