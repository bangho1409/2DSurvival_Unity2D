using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ending());

    }

   IEnumerator Ending()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(5);
    }
}
