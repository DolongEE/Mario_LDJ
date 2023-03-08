using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemFireFlower: MonoBehaviour
{
    private ScoreStage scoreStage;

    private void Awake()
    {
        scoreStage = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreStage>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        int flower = 1000;
        if (collision.gameObject.tag == "Player")
        {            
            Animator playerAnim = collision.gameObject.GetComponent<Animator>();
            playerAnim.SetTrigger("FireUp");
            playerAnim.SetInteger("countLife", 3);
            scoreStage.Score(flower);
            Destroy(gameObject);
            
        }
    }
}
