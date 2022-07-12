using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HM_Typing_Word : MonoBehaviour
{
    public TextMeshProUGUI txt;
     string message;
     string temp_message;
    public float speed = 0.2f;

    public GameObject anyKey;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "";
        message = "��Ÿ���� �巡�� ���� �����ϴ� �հ��� �ٸ� ���� ĳ���Ͱ� ����鼭 ��Ÿ ���� �巡����� �峭�� ĸ���� ���ֹ��ȴ�.\n ��Ÿ ���� �巡���� ���ѱ� �հ� ������ ��ã��, ģ������ ���ϱ� ���� �ٸ� �������� �� A�� óġ�Ϸ��� �Ѵ�!!";

        StartCoroutine(TypingAction());
    }

    IEnumerator TypingAction()
    {
        for(int i =0; i<message.Length; i++)
        {
            yield return new WaitForSeconds(0.1f);

            temp_message += message.Substring(0, i);
            txt.text = temp_message;
            temp_message = "";
        }

        yield return new WaitForSeconds(1f);

        anyKey.SetActive(true);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
