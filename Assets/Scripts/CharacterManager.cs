using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }
    
    public bool Anabelle { get; set; }
    public bool İsabelle { get; set; }
    public bool Cliff { get; set; }
    public bool Ezkiel { get; set; }
    public bool Adrian { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
