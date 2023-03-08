using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_FlagDown : MonoBehaviour
{
    private Animator anim;

    public GameObject Mario;
    public GameObject soundManager;
    public GameObject[] instantMario;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            instantMario[i].SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animator playerAnim = collision.gameObject.GetComponent<Animator>();
            anim.SetBool("Goal", true);
            if (playerAnim.GetInteger("countLife") == 1)
            {
                instantMario[0].SetActive(true);
                Destroy(instantMario[1]);
                Destroy(instantMario[2]);
                anim.SetInteger("who", 1);
                StartCoroutine(MarioOff());
            }
            else if(playerAnim.GetInteger("countLife") == 2)
            {
                instantMario[1].SetActive(true);
                Destroy(instantMario[0]);
                Destroy(instantMario[2]);
                anim.SetInteger("who", 2);
                StartCoroutine(MarioOff());
            }
            else if (playerAnim.GetInteger("countLife") == 3)
            {
                instantMario[2].SetActive(true);
                Destroy(instantMario[0]);
                Destroy(instantMario[1]);
                anim.SetInteger("who", 3);
                StartCoroutine(MarioOff());
            }
        }
    }


    IEnumerator MarioOff()
    {
        yield return new WaitForSeconds(1.5f);
        Mario.SetActive(false);

        yield return null;
    }


}
