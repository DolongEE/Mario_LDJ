using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemStar : MonoBehaviour
{
    private ScoreStage scoreStage;
    private Rigidbody2D rigid;
    private Transform frontCheck;

    public float moveSpeed = 2f;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        frontCheck = transform.Find("frontCheck").transform;
        scoreStage = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreStage>();
    }

    void FixedUpdate()
    {
        Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position);

        foreach (Collider2D c in frontHits)
        {
            if (c.tag == "Stair")
            {
                Flip();
                break;
            }
        }
        rigid.velocity = new Vector2(transform.localScale.x * moveSpeed, rigid.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animator playerAnim = collision.gameObject.GetComponent<Animator>();
            playerAnim.SetBool("KillEverything", true);
            scoreStage.Score(1000);

            Destroy(gameObject);
        }
        
    }

    public void Flip()
    {
        Vector3 itemScale = transform.localScale;
        itemScale.x *= -1;
        transform.localScale = itemScale;
    }
}
