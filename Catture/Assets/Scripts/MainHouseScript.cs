using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainHouseScript : MonoBehaviour
{
    [SerializeField] Image f_Image;

    PlayerMovement playerMovement;
    WitchScript witcherScript;
    public Dialogue dialogue;

    bool isDialogueEnded = false;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        witcherScript = FindObjectOfType<WitchScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDialogueEnded && other.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            playerMovement.canPlayerMove = false;
            witcherScript.canWitchCome = true;
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        if (!isDialogueEnded)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            isDialogueEnded = true;
        }
    }
}
