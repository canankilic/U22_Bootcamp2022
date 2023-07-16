using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveScript : MonoBehaviour
{
    private ConversationState conversationState;
    public float speed = 2f;
    private float lerpTime = 0.02f;
    private float rotationSpeed = 5f;
    private Rigidbody rigi;
    private Animator anim;
    private Animator dollyanim;
    private Vector3 movement;
    private float currentMovement = 0f;
    public GameObject Dolly;

    [SerializeField]
    private GameObject TurnCorner;
    private int TurnCount = 0;

    public GameObject panel;
    public HUDController CurrentHUDController;
    public DialogSystem DialogSystemRef;
    public NPC_DialogInfo DialogInfoRef;
    private string[] currentDialog;
    private int dialogStep = 0;

    private bool isNearAnabell = false;
    private bool isNearIsabelle = false;
    private bool isNearCliff = false;
    private bool isNearAdrian = false;
    private bool isNearEzkiel = false;
    private bool isNearMetro = false;
    private bool isNearPhone = false;
    private bool isNearCadde = false;
    private bool isNearOlay = false;

    public string[] talkOrder;
    private string currentTalkTarget;
    private int currentTalkIndex = 0;
    private bool isInConversation = false;
    private bool isInGuide = false;
    private bool isInInfo = false;

    public GameObject Cadde;
    

    void Start()
    {
        conversationState = ConversationState.Instance;
        rigi = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        dollyanim = Dolly.GetComponent<Animator>();

        currentTalkTarget = talkOrder[0];

        if(DialogSystemRef==null){
                    GameObject dialogSystem = GameObject.FindGameObjectWithTag("DialogSystem");
                    DialogSystemRef = dialogSystem.GetComponent<DialogSystem>();
        }

        if(DialogInfoRef==null){
                    GameObject dialogInfo = GameObject.FindGameObjectWithTag("DialogSystem");
                    DialogInfoRef = dialogInfo.GetComponent<NPC_DialogInfo>();
        }
       
        
    }

   

    void Update()
    {
        float moveHorizontal = 0.0f;
        float moveVertical = 0.0f;

        if (Dolly.GetComponent<Dolly>().Turned)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");
            movement = new Vector3(-moveHorizontal, 0.0f, -moveVertical);
        }
        else
        {
            moveHorizontal = Input.GetAxisRaw("Vertical");
            moveVertical = Input.GetAxisRaw("Horizontal");
            movement = new Vector3(0.0f, 0.0f, -moveVertical);
        }

        float targetMovement = movement.sqrMagnitude > 0 ? 1f : 0f;

        currentMovement = Mathf.Lerp(currentMovement, targetMovement, lerpTime);
        anim.SetFloat("Movement", currentMovement);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Test");
            //Anabell ile etkilesim
            if (isNearAnabell)
            {
                if (!isInConversation)
                {
                    CurrentHUDController.UpdateNPC(NPCName.Annabel);
                    if (string.Equals(currentTalkTarget, "Annabel"))
                    {
                        //Debug.Log(DialogInfoRef.AnabellDialogNumber);
                        currentDialog = DialogSystemRef.ReturnDialog(
                            "Annabel",
                            DialogInfoRef.AnabellDialogNumber
                        );
                        CurrentHUDController.ShowDialog();
                        CurrentHUDController.SetDialogText(currentDialog[dialogStep]);
                        isInConversation = true;
                        DialogInfoRef.AnabellDialogNumber++;
                    }
                    else
                    {
                        CurrentHUDController.ShowDialog();
                        CurrentHUDController.SetDialogText(
                            "Su anda seninle konusamam once "
                                + currentTalkTarget
                                + "'ya gitmen gerek."
                        );
                        isInGuide = true;
                    }
                }
            }

            //Ezkiel ile etkileşim
            if (isNearEzkiel)
            {
                if (!isInConversation)
                {
                    CurrentHUDController.UpdateNPC(NPCName.Ezkiel);
                    if (string.Equals(currentTalkTarget, "Ezkiel"))
                    {
                        //Debug.Log(DialogInfoRef.AnabellDialogNumber);
                        currentDialog = DialogSystemRef.ReturnDialog(
                            "Ezkiel",
                            DialogInfoRef.EzkielDialogNumber
                        );
                        CurrentHUDController.ShowDialog();
                        CurrentHUDController.SetDialogText(currentDialog[dialogStep]);
                        isInConversation = true;
                        DialogInfoRef.EzkielDialogNumber++;
                    }
                    else
                    {
                        CurrentHUDController.ShowDialog();
                        CurrentHUDController.SetDialogText(
                            "Su anda seninle konusamam once "
                                + currentTalkTarget
                                + "'ya gitmen gerek."
                        );
                        isInGuide = true;
                    }
                }
            }

            //Ezkiel ile etkileşim
            if (isNearCliff)
            {
                if (!isInConversation)
                {
                    CurrentHUDController.UpdateNPC(NPCName.Cliff);
                    if (string.Equals(currentTalkTarget, "Cliff"))
                    {
                        //Debug.Log(DialogInfoRef.AnabellDialogNumber);
                        currentDialog = DialogSystemRef.ReturnDialog(
                            "Cliff",
                            DialogInfoRef.CliffDialogNumber
                        );
                        CurrentHUDController.ShowDialog();
                        CurrentHUDController.SetDialogText(currentDialog[dialogStep]);
                        isInConversation = true;
                        DialogInfoRef.CliffDialogNumber++;
                    }
                    else
                    {
                        CurrentHUDController.ShowDialog();
                        CurrentHUDController.SetDialogText(
                            "Su anda seninle konusamam once "
                                + currentTalkTarget
                                + "'ya gitmen gerek."
                        );
                        isInGuide = true;
                    }
                }
            }

            //Ezkiel ile etkileşim
            if (isNearAdrian)
            {
                if (!isInConversation)
                {
                    CurrentHUDController.UpdateNPC(NPCName.Adrian);
                    if (string.Equals(currentTalkTarget, "Adrian"))
                    {
                        //Debug.Log(DialogInfoRef.AnabellDialogNumber);
                        currentDialog = DialogSystemRef.ReturnDialog(
                            "Adrian",
                            DialogInfoRef.AdrianDialogNumber
                        );
                        CurrentHUDController.ShowDialog();
                        CurrentHUDController.SetDialogText(currentDialog[dialogStep]);
                        isInConversation = true;
                        DialogInfoRef.AdrianDialogNumber++;
                    }
                    else
                    {
                        CurrentHUDController.ShowDialog();
                        CurrentHUDController.SetDialogText(
                            "Su anda seninle konusamam once "
                                + currentTalkTarget
                                + "'ya gitmen gerek."
                        );
                        isInGuide = true;
                    }
                }
            }

            //Ezkiel ile etkileşim
            if (isNearIsabelle)
            {
                if (!isInConversation)
                {
                    CurrentHUDController.UpdateNPC(NPCName.Isabelle);
                    if (string.Equals(currentTalkTarget, "Isabelle"))
                    {
                        //Debug.Log(DialogInfoRef.AnabellDialogNumber);
                        currentDialog = DialogSystemRef.ReturnDialog(
                            "Isabelle",
                            DialogInfoRef.IsabelleDialogNumber
                        );
                        CurrentHUDController.ShowDialog();
                        CurrentHUDController.SetDialogText(currentDialog[dialogStep]);
                        isInConversation = true;
                        DialogInfoRef.IsabelleDialogNumber++;
                    }
                    else
                    {
                        CurrentHUDController.ShowDialog();
                        CurrentHUDController.SetDialogText(
                            "Su anda seninle konusamam once "
                                + currentTalkTarget
                                + "'ya gitmen gerek."
                        );
                        isInGuide = true;
                    }
                }
            }

            if(isNearMetro)
            {
                SceneManager.LoadScene("SoruşturmaAlanı2");
                currentTalkIndex++;
                currentTalkTarget = talkOrder[currentTalkIndex];
                CurrentHUDController.NextMission();
                DialogInfoRef.TalkOrderNumber = currentTalkIndex;
                DialogInfoRef.MissionInfoNumber = CurrentHUDController.MissionGuideRef.currentMissionID;
            }

            if(isNearPhone)
            {  
                Debug.Log("Near phone");
                CurrentHUDController.ShowDialog();
                CurrentHUDController.SetDialogText("Alex’e Mesaj: Selam dostum. Kafanı şişirmek istemiyorum ancak garip bir şeyler dönüyor gibi hissediyorum. Çok ilginç bir rüya gördüm. Rüyamda hiç mutlu değildin Alex. Hatta mutlu olmak için fazla cansızdın. Neyse bunu daha sonra anlatırım. Nasıl olduğunu merak ettim. Müsait olduğunda yaz bana.");
                CurrentHUDController.NextMission();
            }

            if(isNearCadde)
            {
                if(SceneManager.GetActiveScene().name == "SoruşturmaAlanı1"){
                    SceneManager.LoadScene("Cadde");
                }
                
                if(SceneManager.GetActiveScene().name == "SoruşturmaAlanı2"){
                    SceneManager.LoadScene("Cadde2");
                }
                
                CurrentHUDController.NextMission();
            }

            if(isNearOlay)
            {
                Cadde.SetActive(true);
                CurrentHUDController.NextMission();
            }
        }

        if(Input.GetKeyDown(KeyCode.R)){

            if(!isInInfo){

                    if(isNearAnabell){
                        CurrentHUDController.SetCharacterInfo("Annabel");
                    }
                    
                    if(isNearAdrian){
                        CurrentHUDController.SetCharacterInfo("Adrian");
                    }
                    
                    if(isNearCliff){
                        CurrentHUDController.SetCharacterInfo("Cliff");
                    }
                    
                    if(isNearEzkiel){
                        CurrentHUDController.SetCharacterInfo("Ezkiel");
                    }      
                    
                    if(isNearIsabelle){
                        CurrentHUDController.SetCharacterInfo("Isabelle");
                    }

                    if(isNearAnabell||isNearAdrian||isNearCliff||isNearEzkiel||isNearIsabelle){
                        isInInfo = true;
                        CurrentHUDController.ShowInfo();
                    }

                    

            }else {
                isInInfo = false;
                CurrentHUDController.HideInfo();
            }
            
            

        }

        // Diyalog ilerletme kısmı
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isInConversation)
            {
                Debug.Log("DialogStep: " + dialogStep);
                Debug.Log("DialofLength: " + currentDialog.Length);

                if (dialogStep + 2 <= currentDialog.Length)
                {
                    dialogStep++;
                    CurrentHUDController.SetDialogText(currentDialog[dialogStep]);
                }
                else
                {
                    CurrentHUDController.HideDialog();
                    currentDialog = new string[0];
                    dialogStep = 0;
                    isInConversation = false;
                    currentTalkIndex++;
                    currentTalkTarget = talkOrder[currentTalkIndex];
                    CurrentHUDController.NextMission();
                }
            }
            else if (isInGuide)
            {
                CurrentHUDController.HideDialog();
                currentDialog = new string[0];
                dialogStep = 0;
                isInGuide = false;
            }
        }

        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isNearAnabell)
            {
                for (int i=0; i < conversationState.TalkedWithAnnabel.Count; i++)
                {
                    if (conversationState.TalkedWithEzkiel[3] == false)
                    {
                        break;
                        
                    }
                    if (!conversationState.SecondDialog && conversationState.TalkedWithAnnabel[12])
                    {
                        break;
                    }
                    if (!conversationState.TalkedWithAnnabel[i])
                    {
                        conversationState.TalkedWithAnnabel[i] = true;
                        break;
                    }
                }
                string dialogue = DialogueManager.Instance.GetDialogue("Annabel");
                CurrentHUDController.ShowDialog();
                CurrentHUDController.SetDialogText(dialogue);
                
               // panel.GetComponentInChildren<Text>().text = dialogue;
                //panel.SetActive(true);

                if (conversationState.TalkedWithAnnabel[2] && !conversationState.TalkedWithIsabelle[4])
                {
                    
                }
                else if (!conversationState.SecondDialog && conversationState.TalkedWithAnnabel[12])
                {
                    
                }
                else if (conversationState.AnnabelDialogNumber != DialogueManager.Instance.AnnabelDialogues.Count-1 && conversationState.TalkedWithEzkiel[3])
                {
                    
                    conversationState.AnnabelDialogNumber++;
                }
                
                
            }
            else if (isNearIsabelle)
            {
                for (int i=0; i < conversationState.TalkedWithIsabelle.Count; i++)
                {
                    if (conversationState.TalkedWithEzkiel[3] == false)
                    {
                        break;
                        
                    }

                    if (!conversationState.SecondDialog && conversationState.TalkedWithIsabelle[4])
                    {
                        break;
                    }
                    if (!conversationState.TalkedWithIsabelle[i])
                    {
                        conversationState.TalkedWithIsabelle[i] = true;
                        break;
                    }
                }
                string dialogue = DialogueManager.Instance.GetDialogue("Isabelle");
                panel.GetComponentInChildren<Text>().text = dialogue;
                panel.SetActive(true);
                if (!conversationState.SecondDialog && conversationState.TalkedWithIsabelle[4])
                {
                    
                }
                else if (conversationState.IsabelleDialogNumber != DialogueManager.Instance.IsabelleDialogues.Count-1 && conversationState.TalkedWithEzkiel[3])//&& conversationState.TalkedWithAnnabel[3]
                {
                    conversationState.IsabelleDialogNumber++;
                }
            }
            else if (isNearCliff)
            {
                for (int i=0; i < conversationState.TalkedWithCliff.Count; i++)
                {
                    if (conversationState.TalkedWithEzkiel[3] == false)
                    {
                        break;
                        
                    }
                    if (!conversationState.SecondDialog && conversationState.TalkedWithCliff[3])
                    {
                        break;
                    }
                    if (!conversationState.TalkedWithCliff[i])
                    {
                        conversationState.TalkedWithCliff[i] = true;
                        break;
                    }
                }
                string dialogue = DialogueManager.Instance.GetDialogue("Cliff");
                panel.GetComponentInChildren<Text>().text = dialogue;
                panel.SetActive(true);
                if (!conversationState.SecondDialog && conversationState.TalkedWithCliff[3])
                {
                    
                }
                else if (conversationState.CliffDialogNumber != DialogueManager.Instance.CliffDilogues.Count-1 && conversationState.TalkedWithEzkiel[3])
                {
                    conversationState.CliffDialogNumber++;
                }
            }
            else if (isNearAdrian)
            {
                for (int i=0; i < conversationState.TalkedWithAdrian.Count; i++)
                {
                    if (conversationState.TalkedWithEzkiel[3] == false)
                    {
                        break;
                        
                    }
                    if (!conversationState.SecondDialog && conversationState.TalkedWithAdrian[3])
                    {
                        break;
                    }
                    if (!conversationState.TalkedWithAdrian[i])
                    {
                        conversationState.TalkedWithAdrian[i] = true;
                        break;
                    }
                }
                string dialogue = DialogueManager.Instance.GetDialogue("Adrian");
                panel.GetComponentInChildren<Text>().text = dialogue;
                panel.SetActive(true);
                if (!conversationState.SecondDialog && conversationState.TalkedWithAdrian[3])
                {
                    
                }
                else if (conversationState.AdrianDialogNumber != DialogueManager.Instance.AdrianDialogues.Count-1 && conversationState.TalkedWithEzkiel[3])
                {
                    conversationState.AdrianDialogNumber++;
                }
            }
            else if (isNearEzkiel)
            {
                for (int i=0; i < conversationState.TalkedWithEzkiel.Count; i++)
                {
                    if (!conversationState.SecondDialog && conversationState.TalkedWithEzkiel[3])
                    {
                        break;
                    }
                    if (!conversationState.TalkedWithEzkiel[i])
                    {
                        conversationState.TalkedWithEzkiel[i] = true;
                        break;
                    }
                }
                string dialogue = DialogueManager.Instance.GetDialogue("Ezkiel");
                
                CurrentHUDController.ShowDialog();
                CurrentHUDController.SetDialogText(dialogue);
                
                //panel.GetComponentInChildren<Text>().text = dialogue;
                //panel.SetActive(true);
                
                if (!conversationState.SecondDialog && conversationState.TalkedWithEzkiel[3])
                {
                    
                }
                else if (conversationState.EzkielDialogNumber != DialogueManager.Instance.EzkielDialogues.Count-1)
                {
                    conversationState.EzkielDialogNumber++;
                }
            }
        }
        */
    }

    void FixedUpdate()
    {
        rigi.velocity = movement * speed;
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                toRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Anabell"))
        {
            isNearAnabell = true;
        }
        if (other.gameObject.CompareTag("Isabelle"))
        {
            isNearIsabelle = true;
        }
        if (other.gameObject.CompareTag("Cliff"))
        {
            isNearCliff = true;
        }
        if (other.gameObject.CompareTag("Adrian"))
        {
            isNearAdrian = true;
        }
        if (other.gameObject.CompareTag("Ezkiel"))
        {
            isNearEzkiel = true;
        }
        if (other.gameObject.CompareTag("Metro"))
        {
            isNearMetro = true;
        }
        if (other.gameObject.CompareTag("Telefon"))
        {
            isNearPhone = true;
        }
        if (other.gameObject.CompareTag("Cadde"))
        {
            isNearCadde = true;
        }
        if (other.gameObject.CompareTag("Olay"))
        {
            isNearOlay = true;
        }


        if (other.CompareTag("GameController"))
        {
            Dolly.GetComponent<Dolly>().Turned = !Dolly.GetComponent<Dolly>().Turned;
            TurnCount++;

            if (TurnCount == 1)
            {
                dollyanim.SetTrigger("Turn");
            }
            else if (TurnCount % 2 == 0)
            {
                dollyanim.SetTrigger("OtherTurn");
            }
            else
            {
                dollyanim.SetTrigger("TurnBack");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Anabell"))
        {
            panel.SetActive(false);
            isNearAnabell = false;
        }
        if (other.gameObject.CompareTag("Isabelle"))
        {
            panel.SetActive(false);
            isNearIsabelle = false;
        }
        if (other.gameObject.CompareTag("Cliff"))
        {
            panel.SetActive(false);
            isNearCliff = false;
        }
        if (other.gameObject.CompareTag("Adrian"))
        {
            panel.SetActive(false);
            isNearAdrian = false;
        }
        if (other.gameObject.CompareTag("Ezkiel"))
        {
            panel.SetActive(false);
            isNearEzkiel = false;
        }
        if (other.gameObject.CompareTag("Metro"))
        {
            isNearMetro = false;
        }
        if (other.gameObject.CompareTag("Telefon"))
        {
            isNearPhone = false;
            CurrentHUDController.HideDialog();
        }
        if (other.gameObject.CompareTag("Cadde"))
        {
            isNearCadde = false;
        }
        if (other.gameObject.CompareTag("Olay"))
        {
            isNearOlay = false;
        }
    }


}
