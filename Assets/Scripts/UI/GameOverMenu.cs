using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
     // sets variable as next scene number in build (for main menu, 1 is next)
    public int NextScene = 1;
    public SavePrefs sp;

    // when PlayGame() is called, it brings us to the Next Scene ni the build (after this menu.)
    public void PlayAgain(){
        sp.SaveGame();
        SceneManager.LoadScene(NextScene);
    }

    // when QuitGame() is called, the application shuts down/the game is exited.
    public void QuitGame(){
        sp.SaveGame();
        Application.Quit();
    }
}
