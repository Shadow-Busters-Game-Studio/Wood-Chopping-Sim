using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreToText : MonoBehaviour
{
    public TMP_Text highscoretext;
    public SavePrefs fromsave;
    int lastsave;

    void Start(){
        fromsave.LoadGame();
        lastsave = fromsave.HighestScore;
        highscoretext.text = "High Score: " + (lastsave).ToString();
    }

    void Update(){
        if(fromsave.HighestScore != lastsave){
            highscoretext.text = "High Score: " + (fromsave.HighestScore).ToString();
            lastsave = fromsave.HighestScore;
        }
    }
}
