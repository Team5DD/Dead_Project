using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwanplayer : MonoBehaviour
{
    
   
    GameObject playerchar;
    AutoSave savePlayer;

    GameObject playerspwan;
    public GameObject spwanpoint;

    // Start is called before the first frame update
    void Start()
    {
        playerchar = GameObject.Find("Player_Choice_Save(Clone)");
        savePlayer = playerchar.GetComponent<AutoSave>();
        playerspwan = AutoSave.instance.char_Prefeb_Choice;

        //spriteRender.sprite = playerspwan;

        GameObject player = Instantiate(playerspwan);
        player.transform.position = spwanpoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
