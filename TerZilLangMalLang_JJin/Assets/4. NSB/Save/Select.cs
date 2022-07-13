using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Select : MonoBehaviour
{
    public GameObject create;	// �� ���� �˸� UI => ���� Ȯ�� ��ư�� �� ���۹�ư����...
    public Text[] slotText;		// ���Թ�ư �Ʒ��� �����ϴ� Text��

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
                slotText[i].text = DataManager.instance.nowPlayer.CharacterName;	// ��ư�� �г��� ǥ��
            }
            else	// �����Ͱ� ���� ���
            {
                slotText[i].text = "�������";
            }
        }
        // �ҷ��� �����͸� �ʱ�ȭ��Ŵ.(��ư�� �г����� ǥ���ϱ������̾��� ����)
        DataManager.instance.DataClear();
    }

    //������ 3���ε� ��� �˸°� �ҷ����°�
    public void Slot(int number)	// ������ ��� ����
    {
        DataManager.instance.nowSlot = number;	// ������ ��ȣ�� ���Թ�ȣ�� �Է���.

        if (savefile[number])	// bool �迭���� ���� ���Թ�ȣ�� true��� = ������ �����Ѵٴ� ��
        {
            DataManager.instance.LoadData();	// �����͸� �ε��ϰ�
            GoGame();	// ���Ӿ����� �̵�
        }
        else	// bool �迭���� ���� ���Թ�ȣ�� false��� �����Ͱ� ���ٴ� ��
        {
            Create();	// ���� ����� �˸� UI Ȱ��ȭ
        }
    }

    public void Create()	// ���� ����� �˸� UI ���
    {
        create.gameObject.SetActive(true);
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