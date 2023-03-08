using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreStage : MonoBehaviour
{
    public int totalScore = 0;
    public Text scoretxt;

    private void Update()
    {
        scoretxt.text = totalScore.ToString("D6");        
    }

    public void Score(int score)
    {
        totalScore += score;
    }
}
