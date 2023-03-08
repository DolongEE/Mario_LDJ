using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlPlayerGoal : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigid;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(anim.GetBool("Goal") && transform.position.y < -2.7)
        {

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Flag")
        {
            anim.SetBool("Goal", true);
            rigid.velocity = new Vector2(0f, transform.localPosition.y * 1f);
        }
    }
}
