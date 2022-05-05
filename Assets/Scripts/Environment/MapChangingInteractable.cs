using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapChangingInteractable : Interactable
{
    public enum MCIType{
        NONE,
        PORTAL,
        DOOR,
        OTHER
    }
    public MCIType mCIType;

    // holds int for the next map (numbers shown ni build settings)
    public int nextScene;

    public override void Interact(){
        if(mCIType == MCIType.NONE){
            // do nothing....
        } else {
            SceneManager.LoadScene(nextScene);
        }
    }
}
