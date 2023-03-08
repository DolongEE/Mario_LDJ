using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CtrlPlayerFireBullet : MonoBehaviour
{
    private Animator anim;
    private CtrlPlayer playerCtrl;
    //private AudioSource audio;
    public GameObject bullet;
    public float bulletSpeed = 15f;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerCtrl = GetComponent<CtrlPlayer>();        
        //audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && anim.GetInteger("countLife") == 3)
        {
            anim.SetTrigger("Fire");
            //audio.Play();

            if (playerCtrl.dirRight)
            {
                Rigidbody2D bulletInstance = Instantiate(bullet.GetComponent<Rigidbody2D>(), transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(transform.localScale.x * bulletSpeed, bulletInstance.velocity.y);                
            }
            else
            {
                Rigidbody2D bulletInstance = Instantiate(bullet.GetComponent<Rigidbody2D>(), transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(transform.localScale.x * bulletSpeed, bulletInstance.velocity.y);
            }
        }
    }
}
