using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Choppable : Interactable
{
    public Sprite chopped;

    private SpriteRenderer sr;
    private bool isChopped;

    // initializes to unchopped sprite
    private void Start(){
        sr = GetComponent<SpriteRenderer>();
        isChopped = false;
    }

    // This happens if you DO interact with the object
    public override void Interact()
    {
        // if interact and hasnt been chopped, then CHOP it
        if(isChopped == false){
            sr.sprite = chopped;
            isChopped = true;
            Debug.Log("Chopped Tree");
        }
    }
}
