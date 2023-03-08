using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCoinCount : MonoBehaviour
{
    public int coin;
    public Text coinCount;

    void Start()
    {
        coin = 0;    
    }

    public void GetCoin()
    {
        coin++;
        coinCount.text = coin.ToString("D2");
    }
}
