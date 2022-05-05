using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

// Parent class for anything that can have interaction with player
public abstract class Interactable : MonoBehaviour
{
    // makes sure collider is a trigger collider
    private void Reset(){
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Parent class defining function for when interact is called
    public abstract void Interact();

    // when we enter an interactable space (Using method from PlayerInteract script)
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            collision.GetComponent<PlayerInteract>().OpenInteractableIcon();
        }
    }

    // when we exit an niteractable space (Using method from PlayerInteract script)
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            collision.GetComponent<PlayerInteract>().CloseInteractableIcon();
        }
    }
}
