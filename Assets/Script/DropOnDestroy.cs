using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    // this script is for GameObject "B" be spawned when GameObject "A" is destroyed but it will have a random chance to drop

    [SerializeField] GameObject ItemDropObject;
    [SerializeField] [Range(0f, 1f)] float rate = 1f;

    private void OnDestroy()
    {
        if( Random.value < rate)
        {
            Transform d = Instantiate(ItemDropObject).transform;
            d.position = transform.position;
        }
    }
}
