using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    public static BossHP instance;
    private void Awake()
    {
        instance = this;
    }

    public int maxHP = 100;
    public Slider sliderBossHP;
    int hp;

    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;
            sliderBossHP.value = hp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sliderBossHP.maxValue = maxHP;
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
