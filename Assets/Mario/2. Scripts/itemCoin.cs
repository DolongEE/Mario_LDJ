using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCoin : MonoBehaviour
{
    private ScoreStage scoreStage;
    private itemCoinCount coinCount;
    
    private void Awake()
    {
        scoreStage = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScoreStage>();
        coinCount = GameObject.Find("CoinCount").GetComponent<itemCoinCount>();
    }

    void ScoreCoin()
    {
        scoreStage.Score(200);
        coinCount.GetCoin();
    }
}
