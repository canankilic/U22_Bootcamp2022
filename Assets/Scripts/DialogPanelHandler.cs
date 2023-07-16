using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogPanelHandler : MonoBehaviour
{
    public NPCName currentNPC = NPCName.Cliff;

    [SerializeField]
    private Sprite AnnabelIcon;

    [SerializeField]
    private Sprite IsabelleIcon;

    [SerializeField]
    private Sprite CliffIcon;

    [SerializeField]
    private Sprite AdrianIcon;

    [SerializeField]
    private Sprite EzkielIcon;

    [SerializeField]
    public TextMeshProUGUI DialogText;

    [SerializeField]
    public Image NPCIcon;

    // Start is called before the first frame update
    void Start() { 

       if (Input.GetKeyDown(KeyCode.M))
        {
           Debug.Log("Test");
           UpdateNPC(NPCName.Cliff);
           WriteText("Cliff: Ren, senin o saf arkadasina olanlari duydum. Daha once soyledim dostum, o sesini kesmeyi ogrenmeliydi.");
        }
    }

    // Update is called once per frame
    void Update() { }

    public void UpdateNPC(NPCName targetNPC) 
    {
        switch (targetNPC){
            case NPCName.Annabel:
            NPCIcon.sprite = AnnabelIcon;
                break;
            case NPCName.Isabelle:
            NPCIcon.sprite = IsabelleIcon;
                break;
            case NPCName.Cliff:
            NPCIcon.sprite = CliffIcon;
                break;
            case NPCName.Adrian:
            NPCIcon.sprite = AdrianIcon;
                break;
            case NPCName.Ezkiel:
            NPCIcon.sprite = EzkielIcon;
                break;
            default:
                break;
        }

     }

    public void WriteText(string text) 
    {
        StopAllCoroutines();
        StartCoroutine(TypeSentence(text));
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            DialogText.text += letter;
            yield return null;
        }
    }
}
