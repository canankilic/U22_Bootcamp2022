using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    public List<DialogStruct> AnnabelDialogs;
    public List<DialogStruct> IsabelleDialogs;
    public List<DialogStruct> CliffDialogs;
    public List<DialogStruct> AdrianDialogs;
    public List<DialogStruct> EzkielDialogs;

    public string[] ReturnDialog(string NPCName, int DialogNum){
        
        switch (NPCName)
        {
            case "Annabel":
                return AnnabelDialogs[DialogNum].Dialogs;
                break;
            case "Isabelle":
                return IsabelleDialogs[DialogNum].Dialogs;
                break;
            case "Cliff":
                return CliffDialogs[DialogNum].Dialogs;
                break;
            case "Adrian":
                return AdrianDialogs[DialogNum].Dialogs;
                break;
            case "Ezkiel":
                return EzkielDialogs[DialogNum].Dialogs;
                break;
            default:
            return null;
                break;
        }

        return null;
    }
}
