using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text CharacterName;
    public Text Crown;
    public Text Hp;
    

   

    void Start()
    {
        CharacterName.text += DataManager.instance.nowPlayer.CharacterName;
        Crown.text += DataManager.instance.nowPlayer.Crown.ToString();
        Hp.text += DataManager.instance.nowPlayer.PlayerHP.ToString();
  
    }
    
    public void HpUp()
    {
        DataManager.instance.nowPlayer.PlayerHP++;
        Hp.text = "Hp : " + DataManager.instance.nowPlayer.PlayerHP.ToString();
    }

    public void CrownUp()
    {
        DataManager.instance.nowPlayer.Crown++;
        Crown.text = "코인 : " + DataManager.instance.nowPlayer.Crown.ToString();
    }

    public void Save()
    {
        DataManager.instance.SaveData();
    }

    public void ChangeName1()
    {
        DataManager.instance.nowPlayer.CharacterName = "위너";
    }

    public void ChangeName2()
    {
        DataManager.instance.nowPlayer.CharacterName = "엔젤";
    }


    public void ChangeName3()
    {
        DataManager.instance.nowPlayer.CharacterName = "지니";
    }

}