using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlMonster : MonoBehaviour
{
    private int MonNum;

    public string MonsterName;
    public GameObject[] Monster;


    private void Start()
    {
        for (MonNum = 0; MonNum < Monster.Length; MonNum++)
        {
            if (Monster[MonNum].gameObject.CompareTag(MonsterName))
            {
                break;
            }
        }
    }
    
}
