using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public PlayerMovement pm;
    public PlayerInteract pi;

    public void Chop(){
        pm.animator.SetTrigger("Chop");
    }

    void Update(){
        if(pi.InteractKeyPress()){
            Chop();
        }
        if(pm.animator.GetCurrentAnimatorStateInfo(0).IsName("chop")){
            pm.moveable = false;
        } else {
            if(pm.moveable != true){
                pm.moveable = true;
            }
        }
    }
}
