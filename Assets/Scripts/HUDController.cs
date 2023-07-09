using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{

    public Animator InfoPanelAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowInfo();
        }
    }

    public void ShowInfo(){
        InfoPanelAnimator.SetBool("IsInfoOpened", true);
    }

    public void HideInfo(){
        InfoPanelAnimator.SetBool("IsInfoOpened", false);
    }
}
