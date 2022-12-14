using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This Script Help Showing the Experience Bar of the player;

public class ExpBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI level;


    public void UpdateExpSlider (int current, int target)
    {
        slider.maxValue = target;
        slider.value = current;
    }


    public void TextLevel(int levels)
    {
        level.text =  levels.ToString();
    }
}
