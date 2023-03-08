using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBrickCoin : MonoBehaviour
{
    private Animator anim;
    private int itemNum;    
    private int count = 0;
    private ScoreStage scoreStage;

    public string itemTag = "Coin";
    public GameObject[] itemPrefabs;
    public int maxCount = 12;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        scoreStage = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreStage>();
    }
    private void Start()
    {
        for (itemNum = 0; itemNum < itemPrefabs.Length; itemNum++)
        {
            if (itemPrefabs[itemNum].gameObject.CompareTag(itemTag))
            {
                break;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            count++;
            anim.SetTrigger("isHit");
            getItem();
            scoreStage.Score(200);

            if (maxCount <= count)
            {
                anim.SetTrigger("endCoin");
            }
            else if (count == 1)
            {
                InvokeRepeating("EndCoin", 5f, 1f);
            }
        }
    }
    public void getItem()
    {
        Instantiate(itemPrefabs[itemNum], new Vector2(transform.position.x, transform.position.y + 0.8f), transform.rotation);
    }
    void EndCoin()
    {
        if (count > 1)
        {
            anim.SetTrigger("endCoin");
            CancelInvoke();
        }
    }
}
