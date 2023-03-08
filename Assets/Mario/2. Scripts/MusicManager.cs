using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlay = false;
    private bool nowPlay = true;
    private bool end =false;

    public CtrlPlayer player;
    public Animator flag;

    public AudioClip mainSound;
    public AudioClip starSound;
    public AudioClip hurrymainSound;
    public AudioClip areaClearSound;
    public AudioClip warpPipeSound;
    public AudioClip gameOVerSound;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = mainSound;
        audioSource.Play();
    }

    void Update()
    {

        if (player.end)
        {
            if (!end)
            {
                audioSource.loop = false;
                audioSource.clip = gameOVerSound;
                audioSource.Play();
                end = true;
            }
        }
        else if (player.isDie)
        {
            nowPlay = false;
            if (!isPlay)
            {
                audioSource.Stop();
                isPlay = true;
            }
        }     
        else if (flag.GetBool("Goal") )
        {
            if (!isPlay)
            {
                audioSource.loop = false;
                audioSource.clip = areaClearSound;
                audioSource.Play();
                isPlay = true;
            }
        }
        else if (!player.isDie && !nowPlay)
        {
            audioSource.clip = mainSound;
            audioSource.Play();
            nowPlay = true;
            isPlay = false;
        }

    }

}