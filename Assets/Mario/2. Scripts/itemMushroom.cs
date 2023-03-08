using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemMushroom : MonoBehaviour
{
    private ScoreStage scoreStage;

    private void Awake()
    {
        scoreStage = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreStage>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animator playerAnim = collision.gameObject.GetComponent<Animator>();
            playerAnim.SetTrigger("SuperUp");
            playerAnim.SetInteger("countLife", 2);
            scoreStage.Score(1000);
            Destroy(gameObject);
        }
    }
}
