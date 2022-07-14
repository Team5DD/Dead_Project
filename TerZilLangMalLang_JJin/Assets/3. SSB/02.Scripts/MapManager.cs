using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject[] ColBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnColBox()
    {
        StartCoroutine("_OnColBox");
    }
    

    IEnumerator _OnColBox()
    {
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < ColBox.Length; i++)
        {
            yield return new WaitForSeconds(0.2f);
            ColBox[i].SetActive(false);

        }
    }

public void OffColBox()
{
        StartCoroutine("_OffColBox");


    }

    IEnumerator _OffColBox()
    {

        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < ColBox.Length; i++)
        {
            yield return new WaitForSeconds(0.2f);
            ColBox[i].SetActive(true);

        }
    }
}
