using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public GameObject script1;
    public GameObject script2;
    public GameObject script3;
    public GameObject redscreen;
    public GameObject credit;

    private void Start()
    {
        StartCoroutine(RunEndScript());
    }

    IEnumerator RunEndScript()
    {
        script1.SetActive(true);
        yield return new WaitForSeconds(3);
        script1.SetActive(false);
        script2.SetActive(true);
        yield return new WaitForSeconds(3);
        script2.SetActive(false);
        script3.SetActive(true);
        yield return new WaitForSeconds(3);
        script3.SetActive(false);
        redscreen.SetActive(true);
        credit.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
