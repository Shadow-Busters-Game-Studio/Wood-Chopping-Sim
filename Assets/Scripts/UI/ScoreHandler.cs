using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TMP_Text))]
public class ScoreHandler : MonoBehaviour
{
    public int Score;
    public bool isScoreBased;

    public void AddPoints(int points){
        Score += points;
    }

    public void Update(){
        // render the scoreboard?
        gameObject.GetComponent<TMP_Text>().text = Score.ToString();
    }

    public void SaveScore(){
        // save the score somewhere i guess
    }
}
