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
        message = "평화로웠던 장난감 세상에서 개성 넘치는 메타토이 드래곤들이 살아가고 있었다.\n하지만, 어느 날 알 수 없는 버그로 생긴 차원의 균열로 인해 다른 게임 세상의 몬스터들이 나타나기 시작했다.\n몬스터들은 장난감 세상을 지배하기 위해 메타 토이 드래곤들을 장난감 캡슐로 포획하고 그들이 가지고 있는 왕관의 조각들을 빼앗아갔다.\n폐허가 되어버린 장난감 세상...\n장난감 세상을 사랑하는 옐로 드래곤 1023A38은 메타 토이 드래곤들을 구출하고 세상을 구하기로 결심했다.";

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
