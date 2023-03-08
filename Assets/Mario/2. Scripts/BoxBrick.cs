using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBrick : MonoBehaviour
{
    private Animator anim;
    private ParticleSystem brokeBrick;
    private ScoreStage scoreStage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        brokeBrick = GameObject.FindGameObjectWithTag("BrokeFx").GetComponent<ParticleSystem>();
        scoreStage = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreStage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Animator playerAnim = collision.gameObject.GetComponent<Animator>();
            if (playerAnim.GetInteger("countLife") == 2 || playerAnim.GetInteger("countLife") == 3)
            {
                brokeBrick.transform.position = transform.position;
                brokeBrick.Play();
                scoreStage.Score(50);
                anim.SetTrigger("Broken");
            }
            anim.SetTrigger("isHit");            
        }
    }
}
