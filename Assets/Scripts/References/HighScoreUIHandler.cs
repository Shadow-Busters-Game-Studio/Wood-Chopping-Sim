using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreUIHandler : MonoBehaviour
{
    // specifies number of scores to display on the leaderboard
    public int maxScoresToDisplay = 5;

    // holds UI info for each score
    public HighScoreDisplay[] highScoreDisplayList;

    // holds actual data for each score
    List<PlayerScoreEntry> scoreEntries = new List<PlayerScoreEntry>();

    // adds new score to data
    void AddNewScore(string pName, int pScore){
        scoreEntries.Add(new PlayerScoreEntry{name = pName, score = pScore});
    }

    // initializes scores on the UI, soooo TODO
    void Start(){
        AddNewScore("Test2", 42069);
        AddNewScore("Test1", 42060);
        AddNewScore("Test3", 4206);
        AddNewScore("Test5", 4209);
        AddNewScore("Test4", 2069);
        UpdateScoreDisplay();
    }

    // Sorts and displays scores to UI
    void UpdateScoreDisplay(){
        // sorts entire scoreboard list
        scoreEntries.Sort((PlayerScoreEntry x, PlayerScoreEntry y) => y.score.CompareTo(x.score));
        // displays sorted top maxScoresToDisplay
        for(int i = 0; i < maxScoresToDisplay; i++){
            if(i < scoreEntries.Count){
                highScoreDisplayList[i].ReadScoreEntry(scoreEntries[i].name, scoreEntries[i].score);
            } else {
                highScoreDisplayList[i].HideEntryDisplay();
            }
        }
    }
}
