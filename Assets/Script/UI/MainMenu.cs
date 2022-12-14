using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int LastScore;
    public int LastLevel;
    public GameObject LastScoreDisplay;
    public GameObject LastLevelDisplay;

    public GameObject LastScoreDisplay2;
    public GameObject LastLevelDisplay2;

    private void Start()
    {
        LastScore = PlayerPrefs.GetInt("CoinSave");
        LastScoreDisplay.GetComponent<Text>().text = LastScore.ToString();
        LastScoreDisplay2.GetComponent<Text>().text = LastScore.ToString();
        LastLevel = PlayerPrefs.GetInt("Level");
        LastLevelDisplay.GetComponent<Text>().text = LastLevel.ToString();
        LastLevelDisplay2.GetComponent<Text>().text = LastLevel.ToString();
    }

    public void PlayGame()

    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetInt("CoinSave", 0);
        PlayerPrefs.SetInt("Level", 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("CoinSave", 0);
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(0);
    }

}
