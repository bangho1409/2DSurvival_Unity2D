using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool gamePaused = false;
    public AudioSource levelMusic;
    public GameObject pauseMenu;
    public AudioSource Pausesound;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pausesound.Play();
            if (gamePaused == false)
            {
                Time.timeScale = 0;
                gamePaused = true;
                
                levelMusic.Pause();
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
                levelMusic.UnPause();
                
                gamePaused = false;
                Time.timeScale = 1;
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        levelMusic.UnPause();
        
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void QuitMenu()
    {
        pauseMenu.SetActive(false);
        levelMusic.UnPause();
        gamePaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
