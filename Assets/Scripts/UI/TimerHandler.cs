using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerHandler : MonoBehaviour
{
    // uses pausecontroller for when time is up
    public PauseController pc;
    public SavePrefs sp;

    // number of seconds that the timer will last before pausing game
    public float StartTime;
    // current number of seconds left in game
    private float CurrentTime;

    // timer text mesh pro to edit the number on for UI (showing timer)
    public TMP_Text TimerUI;

    // when it starts, unpause (just incase it's paused) and set the time to total time
    public void OnEnable(){
        sp.LoadGame();
        pc.Unpause();
        CurrentTime = StartTime;
    }

    public void CountDown(){
        // if theres still time left, keep conting down
        if(CurrentTime > 0){
            CurrentTime -= Time.deltaTime;
            
        }
        // if there's no time left, trigger to game isOver flag
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
        // Handles all the UI and runs countdown
        string TimeString = ((int)CurrentTime).ToString();
        TimeString += "s";
        TimerUI.text = TimeString;
        CountDown();
    }
}
