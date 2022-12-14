using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickSkill : MonoBehaviour
{
    
    public GameObject PickCanvas;
    public GameObject fireball;
    public GameObject dash;
    public GameObject player;
    public int levels;
    public int levelRequire = 3;

    public GameObject instructDash;
    public GameObject instructFire;

    private void Update()
    {
        levels = player.GetComponent<PlayerLeveling>().level;
        LevelUpPick();

        if(instructDash.activeSelf)
        {
            instructFire.SetActive(false);
            if (Input.GetKeyDown(KeyCode.F))
            {
                instructDash.SetActive(false);
            }
        }
        if (instructFire.activeSelf)
        {
            instructDash.SetActive(false);
            if (Input.GetKeyDown(KeyCode.F))
            {
                instructFire.SetActive(false);
            }
        }
    }

    public void DashPick()
    {  
        player.GetComponent<DashScript>().enabled = true;
        dash.SetActive(true);
        Time.timeScale = 1;
        PickCanvas.SetActive(false);
        instructDash.SetActive(true);
    }

    public void FireBallPick()
    {
        fireball.SetActive(true);
        Time.timeScale = 1;
        PickCanvas.SetActive(false);
        instructFire.SetActive(true);
    }

    public void LevelUpPick()
    {
        if (levels == levelRequire)
        {
            PickCanvas.SetActive(true);
            Time.timeScale = 0;
            levels += 1;
            levelRequire += 2;
        }
    }


}
