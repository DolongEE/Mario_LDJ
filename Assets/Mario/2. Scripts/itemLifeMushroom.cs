using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemLifeMushroom : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CtrlPlayer>().gameLife++;

            Destroy(gameObject);
        }
    }
}
