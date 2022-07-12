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
        message = "메타토이 드래곤 세상에 존재하는 왕관을 다른 게임 캐릭터가 뺏어가면서 메타 토이 드래곤들을 장난감 캡슐에 가둬버렸다.\n 메타 토이 드래곤은 빼앗긴 왕관 조각을 되찾고, 친구들을 구하기 위해 다른 게임으로 들어가 A를 처치하려고 한다!!";

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
