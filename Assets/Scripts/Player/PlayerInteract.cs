using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // hold interact icon on screen
    public GameObject interactIcon;
    private Vector2 boxSize = new Vector2(1f, 1f);

    // when called, makes interact icon appear
    public void OpenInteractableIcon(){
        interactIcon.SetActive(true);
    }

    // when called, makes interact icon disappear
    public void CloseInteractableIcon(){
        interactIcon.SetActive(false);
    }

    // used to see if can niteract with something
    private void CheckInteraction(){
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        // if there's an interactable object in the range of the box,
        if(hits.Length > 0){
            foreach(RaycastHit2D rc in hits){
                // if it is interactable, call the interact function
                if(rc.transform.GetComponent<Interactable>()){
                    Debug.Log("Interactable object");
                    rc.transform.GetComponent<Interactable>().Interact();
                    return; // return to only interact to closest, dont return if wanna interact with all nearby objects
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if user presses 'E' key; if yes check interaction.
        if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Pressed E");
            CheckInteraction();
        }
    }
}
