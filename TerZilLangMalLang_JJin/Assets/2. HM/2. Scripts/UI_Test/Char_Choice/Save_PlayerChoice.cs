using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_PlayerChoice : MonoBehaviour
{
    public static Save_PlayerChoice instance;

    public GameObject save_char_Img;
    public string save_char_Name;
    public int save_nft_Number;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);
    }
}
