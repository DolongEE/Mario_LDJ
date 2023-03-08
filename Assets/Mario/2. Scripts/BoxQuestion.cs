using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxQuestion : MonoBehaviour
{
    private Animator anim;
    private int itemNum;

    public string itemTag = "Coin";
    public GameObject[] itemPrefabs;

    private void Awake()
    {
        anim = GetComponent<Animator>();
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
        if(collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("isHit");
            getItem(collision);
        }
    }
    public void getItem(Collider2D collision)
    {
        if (itemPrefabs[itemNum].name == "Item_Mushroom")
        {
            Animator playerAnim = collision.gameObject.GetComponent<Animator>();
            if (playerAnim.GetInteger("countLife") == 2 || playerAnim.GetInteger("countLife") == 3) 
            {
                itemNum = 1;
            }
        }
        Instantiate(itemPrefabs[itemNum], new Vector2(transform.position.x, transform.position.y +0.8f), transform.rotation);
    }
}
