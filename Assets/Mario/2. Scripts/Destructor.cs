using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public bool destroyOnAwake;
    public float awakeDestroyDelay;
    public bool findChild = false;
    public string nameChild;

    void Awake()
    {
        if(destroyOnAwake)
        {
            if (findChild)
            {
                Destroy(transform.Find(nameChild).gameObject);
            }
            else
                Destroy(gameObject, awakeDestroyDelay);
        }    
    }
    void DestroyChildGameObject()
    {
        if (transform.Find(nameChild).gameObject != null)
            Destroy(transform.Find(nameChild).gameObject);
    }

    void DisableChildGameObject()
    {
        if (transform.Find(nameChild).gameObject.activeSelf == true)
            transform.Find(nameChild).gameObject.SetActive(false);
    }

    void DestroyParentGameObject()
    {
        if(transform.parent.gameObject != null)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
