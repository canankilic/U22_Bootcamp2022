using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_DialogInfo : MonoBehaviour
{
    
    public static NPC_DialogInfo instance;
    public int AnabellDialogNumber = 0;
    public int IsabelleDialogNumber = 0;
    public int CliffDialogNumber = 0;
    public int AdrianDialogNumber = 0;
    public int EzkielDialogNumber = 0;
    public int TalkOrderNumber = 0;
    public int MissionInfoNumber = 0;

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
