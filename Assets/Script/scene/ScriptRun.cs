using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScriptRun : MonoBehaviour
{
    public GameObject script1;
    public GameObject script2;
    public GameObject script3;
    public GameObject script4;
    public GameObject script5;
    public GameObject script6;
    public GameObject script7;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RunScript());
    }

    IEnumerator RunScript()
    {
        script1.SetActive(true);
        yield return new WaitForSeconds(2);
        script1.SetActive(false);
        script2.SetActive(true);
        yield return new WaitForSeconds(2);
        script2.SetActive(false);
        script3.SetActive(true);
        yield return new WaitForSeconds(2);
        script3.SetActive(false);
        script4.SetActive(true);
        yield return new WaitForSeconds(2);
        script4.SetActive(false);
        script5.SetActive(true);
        yield return new WaitForSeconds(2);
        script5.SetActive(false);
        script6.SetActive(true);
        yield return new WaitForSeconds(2);
        script6.SetActive(false);
        script7.SetActive(true);
        yield return new WaitForSeconds(2);
        script7.SetActive(false);
        SceneManager.LoadScene(3);
    }
}
