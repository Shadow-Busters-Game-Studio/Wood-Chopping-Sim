using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public KeyCode PauseButton = KeyCode.LeftShift;

    public bool isPaused;
    public bool isOver;
    public GameObject pauseSprite;
    public GameObject gameOverSprite;

    public void Start(){
        isPaused = false;
        isOver = false;
    }
    
    public void Pause(){
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Unpause(){
        Time.timeScale = 1;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOver && Input.GetKeyDown(PauseButton)){
            if(!isPaused){
                Pause();
                pauseSprite.SetActive(true);
            } else {
                Unpause();
                pauseSprite.SetActive(false);
            }
        } else if(isOver && !isPaused) {
            Pause();
            gameOverSprite.SetActive(true);
        }
    }
}
