using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwanplayer : MonoBehaviour
{
    public GameObject tplayer;
    SpriteRenderer spriteRender;
    GameObject playerchar;
    Save_PlayerChoice savePlayer;

    Sprite playerspwan;
    GameObject spwanpoint;

    // Start is called before the first frame update
    void Start()
    {
        spriteRender = tplayer.GetComponent<SpriteRenderer>();


        playerchar = GameObject.Find("Player_Choice_Save(Clone)");
        savePlayer = playerchar.GetComponent<Save_PlayerChoice>();
        playerspwan = Save_PlayerChoice.instance.char_Prefeb_Choice;

        spriteRender.sprite = playerspwan;

        //GameObject player = Instantiate(playerspwan, spwanpoint.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
