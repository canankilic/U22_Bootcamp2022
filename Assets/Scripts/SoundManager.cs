using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

public static SoundManager instance;

   private void Awake()
    {
        if (instance == null)
        {
            // If no instance exists, set this instance as the singleton instance
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this instance
            Destroy(gameObject);
        }
    }

}
