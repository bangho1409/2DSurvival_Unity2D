using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator animator;
    public float horizontal;
    public float vertical;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        // Get the animator of the GameObject when the system is Awake.
    }


    private void Update()
    {
        // Base on Player's movement, "Horizontal" and "Vertical" value will be set to do the Animation of GameObject. In this case it's Player's Animation.
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
}
