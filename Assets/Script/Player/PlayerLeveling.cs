using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeveling : MonoBehaviour
{
    public int exp = 0;
    public static int levelvalue;
    public int level = 1;
    [SerializeField] ExpBar expbarUI;



    int Level_Up
    {
        get
        {
            return level * 1000;
        }
    }

    
    private void Start()
    {
        // PlayerPrefs method help getting the information from the storage that been Saved before.
        expbarUI.UpdateExpSlider(exp, Level_Up);
        expbarUI.TextLevel(PlayerPrefs.GetInt("Level"));
    }

    private void Update()
    {
        levelvalue = level;
        level = PlayerPrefs.GetInt("Level");
    }

    // Adding the experience that player gained.
    public void ExpAdd(int amount)
    {
        exp += amount;
        LevelCheck();
        expbarUI.UpdateExpSlider(exp, Level_Up);
    }

    // LevelCheck Statement will check for player's Experience, if it reach to 1000 value the Level variable will count +1 and Save to the Storage.
    public void LevelCheck()
    {
        if (exp >= Level_Up)
        {
            exp -= Level_Up;
            level += 1;
            expbarUI.TextLevel(level);
            PlayerPrefs.SetInt("Level", level + 1);
        }
        
    }
}
