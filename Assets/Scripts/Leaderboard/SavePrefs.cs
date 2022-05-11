using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{
    public ScoreHandler ThisScore;
    public int HighestScore;

    public void SaveGame(){
        if(ThisScore.Score > HighestScore){
            PlayerPrefs.SetInt("HighestScore", ThisScore.Score);
            PlayerPrefs.Save();
            Debug.Log("New High Score Saved");
        }
    }

    public void LoadGame(){
        if(PlayerPrefs.HasKey("HighestScore")){
            HighestScore = PlayerPrefs.GetInt("HighestScore");
        }
    }

    public void ResetData(){
        PlayerPrefs.DeleteAll();
        HighestScore = 0;
    }
}
