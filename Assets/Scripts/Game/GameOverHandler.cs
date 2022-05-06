using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class GameOverHandler : MonoBehaviour
{
    public TMP_Text FinalScore;
    public ScoreHandler sh;

    public void Update(){
        FinalScore.text = (sh.Score).ToString();
    }
}
