using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Interactable : MonoBehaviour
{
    // What happens when the player triggers the collider (activates some interactions)
    public int interactableLayer = 6;

    // Type of interaction object can have
    public enum InteractionType {
        NONE, // where nothing happens
        ALTERABLE, // item gets altered in some way
        EXAMINABLE // object is interacted with but unchanged
    }

    public InteractionType interactionType;

    // gets called only in editor
    private void Reset(){
        // makes specifically the boxcollider trigger instead of blocking movement
        GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.layer = interactableLayer;
    }

    public virtual void Interact(){
        switch(interactionType){
            case InteractionType.NONE:
                // nothing happens
                Debug.Log("Interactable, but nothing happened");
                break;
                
            case InteractionType.ALTERABLE:
                // ALTER OBJ
                Debug.Log("Interactable, object altered");
                break;

            case InteractionType.EXAMINABLE:
                // EXAMINE OBJ
                Debug.Log("Interactable, object examined");
                break;
        }
    }
    
}
