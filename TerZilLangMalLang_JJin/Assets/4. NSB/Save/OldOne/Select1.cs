using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{

    bool[] savefile = new bool[3];	// ���̺����� �������� ����

    void Start()
    {
        // ���Ժ��� ����� �����Ͱ� �����ϴ��� �Ǵ�.
        for (int i = 0; i < 3; i++)
        {
            if (File.Exists(DataManager.instance.path+ $"{i}"))	// �����Ͱ� �ִ� ���
            {
                savefile[i] = true;			// �ش� ���� ��ȣ�� bool�迭 true�� ��ȯ
                DataManager.instance.nowSlot = i;	// ������ ���� ��ȣ ����
                DataManager.instance.LoadData();	// �ش� ���� ������ �ҷ���
            
            }
            else	// �����Ͱ� ���� ���
            {
                slotText[i].text = "�������";
            }
        }
        // �ҷ��� �����͸� �ʱ�ȭ��Ŵ.(��ư�� �г����� ǥ���ϱ������̾��� ����)
        DataManager.instance.DataClear();
    }





    public void GoGame()
    {
        if (!savefile[DataManager.instance.nowSlot])	// ���� ���Թ�ȣ�� �����Ͱ� ���ٸ�
        {
            SceneManager.LoadScene("GameScene"); // ĳ���� ���� ������ �̵�(�����ʿ�)
        }
        SceneManager.LoadScene("GameScene");// ���Ӿ����� �̵�
    }
}