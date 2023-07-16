using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    private ConversationState conversationState;

    public List<string> AnnabelDialogues;
    public List<string> IsabelleDialogues;
    public List<string> CliffDilogues;
    public List<string> AdrianDialogues;
    public List<string> EzkielDialogues;
    
    

    private Dictionary<string, List<string>> dialogues;

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


        dialogues = new Dictionary<string, List<string>>
        {
            { "Annabel", AnnabelDialogues },
            { "Isabelle", IsabelleDialogues },
            { "Cliff", CliffDilogues },
            { "Adrian", AdrianDialogues },
            { "Ezkiel", EzkielDialogues },
            
        };
    }

    public string GetDialogue(string npcName)
    {
        List<string> npcDialogues;

        if (!dialogues.TryGetValue(npcName, out npcDialogues))
        {
            return "";
        }

        if (npcName == "Annabel" && ConversationState.Instance.TalkedWithAnnabel[ConversationState.Instance.AnnabelDialogNumber])
        {
            return npcDialogues[ConversationState.Instance.AnnabelDialogNumber];
        }
        if (npcName == "Isabelle" && ConversationState.Instance.TalkedWithIsabelle[ConversationState.Instance.IsabelleDialogNumber])
        {
            return npcDialogues[ConversationState.Instance.IsabelleDialogNumber];
        }

        if (npcName == "Cliff" && ConversationState.Instance.TalkedWithCliff[ConversationState.Instance.CliffDialogNumber])
        {
            return npcDialogues[ConversationState.Instance.CliffDialogNumber];
        }
        if (npcName == "Adrian" && ConversationState.Instance.TalkedWithAdrian[ConversationState.Instance.AdrianDialogNumber])
        {
            return npcDialogues[ConversationState.Instance.AdrianDialogNumber];
        }
        if (npcName == "Ezkiel" && ConversationState.Instance.TalkedWithEzkiel[ConversationState.Instance.EzkielDialogNumber])
        {
            return npcDialogues[ConversationState.Instance.EzkielDialogNumber];
        }

        return "";
    }

    
}
