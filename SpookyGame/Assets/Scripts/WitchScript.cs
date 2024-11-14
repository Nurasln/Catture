using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchScript : MonoBehaviour
{
    DialogueManager dialogueManager;
    PlayerMovement playerMovement;

    [SerializeField] GameObject WitchPlacement;
    [SerializeField] float goingDelay = 1f;

    public bool canWitchCome = false;
    Vector2 initialPosition;

    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        playerMovement = FindObjectOfType<PlayerMovement>();

        initialPosition = transform.position;
    }

    void Update()
    {
        if (canWitchCome)
        {
            WitchComing();
        }

        if(dialogueManager.endDialogue)
        {
            WitchTurning();
        }
    }

    void WitchComing()
    {
        transform.position = new Vector2(WitchPlacement.transform.position.x, transform.position.y);
    }

    void WitchTurning()
    {
        transform.localScale = new Vector2(-1f, 1f);
        Invoke("WitchGoing", goingDelay);
    }

    void WitchGoing()
    {
        transform.position = initialPosition;
        playerMovement.canPlayerMove = true;
        gameObject.SetActive(false);
    }
}
