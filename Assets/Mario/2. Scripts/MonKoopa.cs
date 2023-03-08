using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MonKoopa : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip MonDieClip;
    private Animator anim;
    private Rigidbody2D rigid;
    private Transform frontCheck;
    private FireBullet MonPos;
    private ScoreStage scoreStage;
    private bool dieCount = false;
    private bool isDie;

    public float moveSpeed = 2f;
    public int cnt = 0;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        MonPos = GetComponent<FireBullet>();
        scoreStage = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreStage>();

        frontCheck = transform.GetChild(0).transform;
    }

    void FixedUpdate()
    {
        Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position);

        foreach (Collider2D c in frontHits)
        {
            if (c.tag == "Stair" || c.tag == "Monster")
            {
                Flip();
                break;
            }
        }


        if (!anim.GetBool("isDie"))
        {
            //MonDieSound();
        }
        else if (anim.GetBool("isDie") && anim.GetBool("Kick"))
        {
            rigid.velocity = new Vector2(transform.localScale.x * -10f, transform.rotation.y);
        }
        else //if (!anim.GetBool("isDie") && !anim.GetBool("Kick"))
        {
            rigid.velocity = new Vector2(transform.localScale.x * -moveSpeed, rigid.velocity.y);
        }

        if (anim.GetBool("MonDie"))
        {
            if(!isDie)
            {
                MonDieSound();
                isDie = true;
            }
            if (!dieCount)
            {
                if (transform.position.y > -3)
                {
                    dieCount = true;               
                }
                gameObject.layer = LayerMask.NameToLayer("MonDie");
                transform.localScale *= -transform.localScale.y;
                rigid.velocity = new Vector2(transform.localScale.x * 10f, transform.localScale.y * -10f);
            }
            else
            {
                rigid.AddForce(new Vector2(0f, transform.localScale.y * 10f));
            }
        }
    }
    public void Flip()
    {
        Vector3 itemScale = transform.localScale;
        itemScale.x *= -1;
        transform.localScale = itemScale;
    }

    void MonDieSound()
    {
        audioSource.clip = MonDieClip;
        audioSource.Play();
    }
}
