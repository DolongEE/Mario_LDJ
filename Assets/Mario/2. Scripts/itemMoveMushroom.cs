using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMoveMushroom : MonoBehaviour
{
    public float moveSpeed = 2f;

    private Rigidbody2D rigid;
    private Transform frontCheck;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        frontCheck = transform.Find("frontCheck").transform;
    }

    void FixedUpdate()
    {
        Collider2D[] frontHits = Physics2D.OverlapPointAll(frontCheck.position);

        foreach(Collider2D c in frontHits)
        {
            if(c.tag == "Stair")
            {
                Flip();
                break;
            }
        }
        rigid.velocity = new Vector2(transform.localScale.x * moveSpeed, rigid.velocity.y);
    }

    public void Flip()
    {
        Vector3 itemScale = transform.localScale;
        itemScale.x *= -1;
        transform.localScale = itemScale;
    }
}
