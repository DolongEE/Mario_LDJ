using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonMove : MonoBehaviour
{
    public MonGoomba[] Goomba;
    public MonKoopa[] Koopa;

    private void Start()
    {
        for (int i = 0; i < Goomba.Length; i++)
        {
            Goomba[i].moveSpeed = 0;
        }

        for (int i = 0; i < Koopa.Length; i++)
        {
            Koopa[i].moveSpeed = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            if (collision.gameObject.name.Contains("Goomba"))
            {
                collision.gameObject.GetComponent<MonGoomba>().moveSpeed = 2f;
            }
            else
            {
                collision.gameObject.GetComponent<MonKoopa>().moveSpeed = 2f;
            }
        }
    }
}
