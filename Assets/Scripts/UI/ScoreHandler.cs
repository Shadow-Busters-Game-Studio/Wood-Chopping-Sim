using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TMP_Text))]
public class ScoreHandler : MonoBehaviour
{
    // holds score for current game time
    public int Score;
    // isScoreBased, used in other classes
    public bool isScoreBased;

    // call frmo other functions with number of points as input
    public void AddPoints(int points){
        Score += points;
    }

    // initializes score to 0
    public void Start(){
        Score = 0;
    }

    // keeps updating the scores UI
    public void Update(){
        // render the scoreboard?
        gameObject.GetComponent<TMP_Text>().text = Score.ToString();
    }
}
