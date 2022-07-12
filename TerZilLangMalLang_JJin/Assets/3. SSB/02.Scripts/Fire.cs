using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public static Fire instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject FireFactory;
    public Transform FirePosiotion;

    Rigidbody2D rigid;
    [Header("∫“≤…¿Ã ¥Í¿ª π¸¿ß")]
    public int nextMove;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        nextMove = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BossPatern.instance.IsAttack == true)
        {
            StartCoroutine("FireShot");
        }
    }

    IEnumerator FireShot()
    {

        GameObject Fire = Instantiate(FireFactory);
        Fire.transform.position = FirePosiotion.transform.position;
        Fire.GetComponent<Rigidbody2D>().velocity = new Vector2(nextMove, 0);

        yield return new WaitForSeconds(3f);

    }


}
