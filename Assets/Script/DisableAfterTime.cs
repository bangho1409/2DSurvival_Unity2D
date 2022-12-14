using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterTime : MonoBehaviour
{
    // This Script help the disable the GameObject that existed on the "Hierachy Panel" - It will disable the GameObject, not Destroy GameObject

    [SerializeField] float disableTime = 0.04f;
    float timer;

    private void OnEnable()
    {
        timer = disableTime;
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
