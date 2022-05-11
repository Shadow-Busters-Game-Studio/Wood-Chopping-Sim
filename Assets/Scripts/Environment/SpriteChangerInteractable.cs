using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(AudioSource))]
public class SpriteChangerInteractable : Interactable
{
    // next sprite to happen once interacted
    public Sprite nextSprite;
    public Sprite lastSprite;
    public AudioClip audio;

    // indicated if the sprite can only change once and never again
    public enum SCUsageType{
        NONE,
        ONETIMEUSE,
        TOGGLEABLEUSE,
        OTHER
    }
    public SCUsageType usageType;

    // calling this function just sets the next sprite VARIABLE, usually called from another class
    public void setNextSprite(Sprite ns){
        nextSprite = ns;
    }

    private void Start(){
        lastSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // runs when object is interacted with
    public override void Interact(){
        // if there is an niteraction type
        if(interactionType != InteractionType.NONE){
            // and the object is only interactable ONCE,
            if(usageType == SCUsageType.ONETIMEUSE){
                GetComponent<SpriteRenderer>().sprite = nextSprite;
                GetComponent<AudioSource>().PlayOneShot(audio, 1.0f);
                interactionType = InteractionType.NONE;
            
            // and the object is toggleable
            } else if (usageType == SCUsageType.TOGGLEABLEUSE){
                GetComponent<SpriteRenderer>().sprite = nextSprite;
                Sprite temp = lastSprite;
                lastSprite = nextSprite;
                nextSprite = temp;

            // otherwise, just default change sprite incase theres some other custom items
            } else {
                GetComponent<SpriteRenderer>().sprite = nextSprite;
            }
        }
    }
}
