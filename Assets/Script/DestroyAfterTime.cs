using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    // This Script help destroy GameObject after a specific Time like : Player WhipAttack , Player Fireball

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
            Destroy(gameObject);
        }
    }
}
