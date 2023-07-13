using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{

    public Animator InfoPanelAnimator;
    public Animator DialogPanelAnimator;
    public DialogPanelHandler myHandler;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowInfo();
        }

if (Input.GetKeyDown(KeyCode.B))
        {
            ShowDialog();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            HideDialog();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            myHandler.UpdateNPC(NPCName.Cliff);
            myHandler.WriteText("Cliff: Ren, senin o saf arkadasina olanlari duydum. Daha once soyledim dostum, o sesini kesmeyi ogrenmeliydi.");
        }
    }

    public void ShowInfo(){
        InfoPanelAnimator.SetBool("IsInfoOpened", true);
    }

    public void HideInfo(){
        InfoPanelAnimator.SetBool("IsInfoOpened", false);
    }

     public void ShowDialog(){
        DialogPanelAnimator.SetBool("IsDialogOpened", true);
    }

    public void HideDialog(){
        DialogPanelAnimator.SetBool("IsDialogOpened", false);
    }
}
