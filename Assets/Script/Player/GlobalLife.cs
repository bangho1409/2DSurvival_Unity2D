using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GlobalLife : MonoBehaviour
{

    public GameObject lifedisplay1;
    public GameObject lifedisplay2;
    public GameObject lifedisplay3;
    public static int lifeValue = 3;
    public int internalLife;
    Character life;
    int currentlife;

    void Update()
    {
        internalLife = lifeValue;
        currentlife = life.GetComponent<Character>().currentHp;

        if (currentlife <= 0)
        {
            lifeValue--;
            SceneManager.LoadScene(1);
        }

        if (lifeValue == 3)
        {
            lifedisplay1.SetActive(true);
            lifedisplay2.SetActive(true);
            lifedisplay3.SetActive(true);
        }

        if (lifeValue == 2)
        {
            lifedisplay1.SetActive(true);
            lifedisplay2.SetActive(true);
            lifedisplay3.SetActive(false);
        }

        if (lifeValue == 1)
        {
            lifedisplay1.SetActive(true);
            lifedisplay2.SetActive(false);
            lifedisplay3.SetActive(false);
        }
    }

}
