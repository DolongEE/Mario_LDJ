using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Animator anim;
    [HideInInspector]
    public float monsterPosY;
    public float bulletSpeed = 10f;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Animator monDie = collision.gameObject.GetComponent<Animator>();
            anim.SetBool("explosion", true);
            monDie.SetBool("MonDie", true);
            monsterPosY = collision.transform.position.y;
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Tile")
        {
            anim.SetBool("explosion", true);
            Destroy(gameObject);
        }
    }
}
