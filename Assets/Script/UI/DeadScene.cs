using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This Script is for Scene Managing

public class DeadScene : MonoBehaviour
{
    public void NextButton()
    {
        SceneManager.LoadScene(0);
    }
}
