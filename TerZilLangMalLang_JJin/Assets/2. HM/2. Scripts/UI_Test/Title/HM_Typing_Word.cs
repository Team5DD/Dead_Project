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
        message = "��ȭ�ο��� �峭�� ���󿡼� ���� ��ġ�� ��Ÿ���� �巡����� ��ư��� �־���.\n������, ��� �� �� �� ���� ���׷� ���� ������ �տ��� ���� �ٸ� ���� ������ ���͵��� ��Ÿ���� �����ߴ�.\n���͵��� �峭�� ������ �����ϱ� ���� ��Ÿ ���� �巡����� �峭�� ĸ���� ��ȹ�ϰ� �׵��� ������ �ִ� �հ��� �������� ���Ѿư���.\n���㰡 �Ǿ���� �峭�� ����...\n�峭�� ������ ����ϴ� ���� �巡�� 1023A38�� ��Ÿ ���� �巡����� �����ϰ� ������ ���ϱ�� ����ߴ�.";

        StartCoroutine(TypingAction());
    }

    IEnumerator TypingAction()
    {
        for(int i =0; i<message.Length; i++)
        {
            yield return new WaitForSeconds(0.05f);

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
