using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public static EnemyHP instance;
    private void Awake()
    {
        instance = this;
    }

    public int maxHP = 100;
    public Slider sliderEnemyHP;
    int hp;

    [SerializeField] int BombAttack=10;
    [SerializeField] int SBombAttack = 25;

    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;
            sliderEnemyHP.value = hp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sliderEnemyHP = this.gameObject.GetComponentInChildren<Slider>();
        sliderEnemyHP.maxValue = maxHP;
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Bomb"))
        {
            if (HP > 0)
            {
                HP -= BombAttack;
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("SBomb"))
        {
            if (HP > 0)
            {
                HP -= SBombAttack;
            }
            else
            {
                Destroy(collision.gameObject);

            }
        }
    }
}
