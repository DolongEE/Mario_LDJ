using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonHead : MonoBehaviour
{
    private ScoreStage scoreStage;
    private bool dead;

    private void Awake()
    {
        scoreStage = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreStage>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Animator anim = GetComponentInParent<Animator>();
        int score = 100;
        int kickscore = 500;
        if (collision.gameObject.tag == "Player")
        {            
            if (transform.parent.tag != "MonDie")
            {
                anim.SetBool("isDie", true);
                scoreStage.Score(score);
                transform.parent.tag = "MonDie";
            }
            else
            {
                anim.SetBool("Kick", true);
                //scoreStage.Score(kickscore);
            }            
        }
        if(collision.gameObject.tag == "FireBullet" && !dead)
        {
            if(!dead)
            {
                dead = true;
            }
            anim.SetBool("MonDie", true);
            scoreStage.Score(score);
        }
    }

}
