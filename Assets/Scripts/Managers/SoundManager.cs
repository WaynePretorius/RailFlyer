using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        int managers = FindObjectsOfType<SoundManager>().Length;

        if(managers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
