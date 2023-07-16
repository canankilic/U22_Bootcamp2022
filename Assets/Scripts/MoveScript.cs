using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject TurnCorner;
    private int TurnCount = 0;
    
    public GameObject ınteract;
    public GameObject panel;
    
    private bool isNearAnabell = false;
    private bool isNearIsabelle = false;
    private bool isNearCliff= false;
    private bool isNearAdrian= false;
    private bool isNearEzkiel= false;

    void Start()
    {
        conversationState = ConversationState.Instance;
        rigi = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        dollyanim = Dolly.GetComponent<Animator>();
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
                panel.GetComponentInChildren<Text>().text = dialogue;
                panel.SetActive(true);
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
                panel.GetComponentInChildren<Text>().text = dialogue;
                panel.SetActive(true);
                if (!conversationState.SecondDialog && conversationState.TalkedWithEzkiel[3])
                {
                    
                }
                else if (conversationState.EzkielDialogNumber != DialogueManager.Instance.EzkielDialogues.Count-1)
                {
                    conversationState.EzkielDialogNumber++;
                }
            }
        }
    }

    void FixedUpdate()
    {
        rigi.velocity = movement * speed;
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Anabell"))
        {
            if (conversationState.TalkedWithEzkiel[3])
            {
                ınteract.SetActive(true);
                isNearAnabell = true;
            }
        }
        if (other.gameObject.CompareTag("Isabelle"))
        {
            if (conversationState.TalkedWithEzkiel[3])
            {
                ınteract.SetActive(true);
                isNearIsabelle = true;
            }
        }
        if (other.gameObject.CompareTag("Cliff"))
        {
            if (conversationState.TalkedWithEzkiel[3])
            {
                ınteract.SetActive(true);
                isNearCliff = true;
            }
        }
        if (other.gameObject.CompareTag("Adrian"))
        {
            if (conversationState.TalkedWithEzkiel[3])
            {
                ınteract.SetActive(true);
                isNearAdrian = true;
            }
        }
        if (other.gameObject.CompareTag("Ezkiel"))
        {
            ınteract.SetActive(true);
            isNearEzkiel = true;
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
            ınteract.SetActive(false);
            panel.SetActive(false);
            isNearAnabell = false;

        }
        if (other.gameObject.CompareTag("Isabelle"))
        {
            ınteract.SetActive(false);
            panel.SetActive(false);
            isNearIsabelle = false;
        }
        if (other.gameObject.CompareTag("Cliff"))
        {
            ınteract.SetActive(false);
            panel.SetActive(false);
            isNearCliff = false;
        }
        if (other.gameObject.CompareTag("Adrian"))
        {
            ınteract.SetActive(false);
            panel.SetActive(false);
            isNearAdrian = false;
        }
        if (other.gameObject.CompareTag("Ezkiel"))
        {
            ınteract.SetActive(false);
            panel.SetActive(false);
            isNearEzkiel = false;
        }
    }
}
