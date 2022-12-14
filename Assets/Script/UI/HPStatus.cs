using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script for Showing the Health Point Bar of the player

public class HPStatus : MonoBehaviour
{
    [SerializeField] Transform hpBar;

    public void SetState(int current, int max)
    {
        float state = (float)current;
        state /= max;
        if(state < 0f)
        {
            state = 0f;
        }
        hpBar.transform.localScale = new Vector3(state, 1f, 1f);
    }
}
