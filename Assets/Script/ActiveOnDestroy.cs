using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveOnDestroy : MonoBehaviour
{
    // this script is for GameObject "B" be spawned when GameObject "A" is destroyed

    [SerializeField] GameObject ItemDropObject;
    
    Vector3 poss;

    private void Start()
    {
        poss = new Vector3(0, 0);
    }

    private void OnDestroy()
    {
        Instantiate(ItemDropObject, poss, Quaternion.identity);
        
    }
}
