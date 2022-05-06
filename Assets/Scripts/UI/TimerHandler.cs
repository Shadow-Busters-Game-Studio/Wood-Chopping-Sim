using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerHandler : MonoBehaviour
{
    public PauseController pc;
    public float StartTime;
    private float CurrentTime;

    public TMP_Text TimerUI;

    public void OnEnable(){
        pc.Unpause();
        CurrentTime = StartTime;
    }

    public void CountDown(){
        if(CurrentTime > 0){
            CurrentTime -= Time.deltaTime;
            
        }
        if(CurrentTime < 0){
            CurrentTime = 0;
        }
        if(CurrentTime == 0){
            pc.isOver = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string TimeString = ((int)CurrentTime).ToString();
        TimeString += "s";
        TimerUI.text = TimeString;
        CountDown();
    }
}
