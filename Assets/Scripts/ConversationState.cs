using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationState : MonoBehaviour
{
    public static ConversationState Instance { get; private set; }

    public List<bool> TalkedWithAnnabel { get; set; } = new List<bool> { false,false,false,false,false,false,false,false,false,false,false,false,false};
    public List<bool> TalkedWithIsabelle { get; set; } = new List<bool> { false,false,false,false,false};
    public List<bool> TalkedWithCliff { get; set; } = new List<bool> { false,false,false,false};
    public List<bool> TalkedWithAdrian { get; set; } = new List<bool> { false,false,false,false };
    public List<bool> TalkedWithEzkiel{ get; set; } = new List<bool> {false,false,false,false};
    public int AnnabelDialogNumber { get; set; }
    public int IsabelleDialogNumber { get; set; }
    public int CliffDialogNumber { get; set; }
    public int AdrianDialogNumber { get; set; }
    public int EzkielDialogNumber { get; set; }
    
    public bool SecondDialog{ get; set; }
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
