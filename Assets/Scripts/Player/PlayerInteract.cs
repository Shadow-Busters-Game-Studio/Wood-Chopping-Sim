using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public ScoreHandler sh;

    // interact button key, can change as desired manually or through code or UI
    public KeyCode interactButton = KeyCode.Space;
    public GameObject interactIndicator;

    // interactable detection point
    public Transform intDetPoint;
    //interactable detection radius
    private const float intDetRadius = 0.2f;
    //interactable detection layer (in tilemap)
    public LayerMask intDetLayer;

    // cached object (aka obj we are interacting with currently)
    public GameObject intDetObject;

    // checks for key press of interact input
    public bool InteractKeyPress(){
        return Input.GetKeyDown(interactButton);
    }

    // checks if we are colliding with/ near an interactable
    bool ObjectInteractTrigger(){
        // check if theres a collision box
        Collider2D intTriggered = Physics2D.OverlapCircle(intDetPoint.position, intDetRadius, intDetLayer);
        // if no, then theres nothing possibly to interact with
        if(intTriggered == null){
            intDetObject = null;
            return false;
        }

        // if yes, there could be, so we check
        intDetObject = intTriggered.gameObject;
        // if object has an interaction type thats not NONE, then there is something interactable
        if(intDetObject.GetComponent<Interactable>().interactionType == Interactable.InteractionType.NONE){
            return false;
        }

        return true;
    }

    // Update is called once per frame
    void Update()
    {
        // if interactable object is nearby
        if(ObjectInteractTrigger()){
            // activate the indicator that tells the user they can interact
            if(!interactIndicator.activeSelf){
                interactIndicator.SetActive(true);
            }
            // if interact key is pressed, run the interact command
            if(InteractKeyPress()){ 
                // Debug.Log("Interacted!");
                if(sh.isScoreBased){
                    sh.AddPoints(5);
                }
                intDetObject.GetComponent<Interactable>().Interact();
                if(intDetObject.GetComponent<SpriteChangerInteractable>().interactionType == SpriteChangerInteractable.InteractionType.ALTERABLE){
                    
                }
                intDetObject.GetComponent<Animator>().SetTrigger("Chopped");
            }
        } else {
            // otherwise, remove the interact indicator i guess
            if(interactIndicator.activeSelf){
                interactIndicator.SetActive(false);
            }
        }
    }
}
