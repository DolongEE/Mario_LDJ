using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManage : MonoBehaviour
{
    public Text timeCount;
    public int MaxTime = 400;
    public int countDown = 0;
    public CtrlPlayer player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CtrlPlayer>();
    }

    private void Start()
    {
        countDown = MaxTime;
        StartCoroutine(Timeout());
    }

    private void Update()
    {
        
    }

    IEnumerator Timeout()
    {
        while (MaxTime != 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeCount.text = (countDown - 1).ToString();
            countDown -= 1;
        }
        player.GameOver();
    }
}
