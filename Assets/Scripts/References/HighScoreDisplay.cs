using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour
{
    // holds this entry's player name
    public Text nameText;
    //holds this entry's game score
    public Text scoreText;

    // call this with players name and score to display it
    public void ReadScoreEntry(string name, int score){
        nameText.text = name;
        scoreText.text = score.ToString();
    }

    // call this to hid this players name and score
    public void HideEntryDisplay(){
        nameText.text = "";
        scoreText.text = "";
    }
}
