using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level01 : MonoBehaviour
{
    public GameObject script1;
    public GameObject script2;
    public GameObject script3;
    public GameObject instruct;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Script());
        instruct.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(instruct.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                instruct.SetActive(false);
            }
        }
       
    }
 
  
    IEnumerator Script()
    {
        script1.SetActive(true);
        yield return new WaitForSeconds(3);
        script1.SetActive(false);
        script2.SetActive(true);
        yield return new WaitForSeconds(3);
        instruct.SetActive(false);
        script2.SetActive(false);
        script3.SetActive(true);
        yield return new WaitForSeconds(3);
        script3.SetActive(false);
    }
}
