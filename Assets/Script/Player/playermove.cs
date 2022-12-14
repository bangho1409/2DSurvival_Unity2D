using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This Script is for Player's Character movement.

public class playermove : MonoBehaviour
{

    Rigidbody2D rb;
    [HideInInspector] public Vector3 MoveVector;
    [HideInInspector] public float LastHorizontal;
    [HideInInspector] public float LastVertical;

    [SerializeField] float speed = 10f;
    Animate anim;
    Animator animator;



    bool faceRight;
 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveVector = new Vector3();
        anim = GetComponent<Animate>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        faceRight = true;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MoveVector.x = Input.GetAxisRaw("Horizontal");
        MoveVector.y = Input.GetAxisRaw("Vertical");

        if (MoveVector.x != 0)
        {
            LastHorizontal = MoveVector.x;
        }
        if (MoveVector.y != 0)
        {
            LastVertical = MoveVector.y;
        }

        if (LastHorizontal > 0)
        {
            faceRight = true;
        }
        else if (LastHorizontal < 0)
        {
            faceRight = false;
        }

        if (faceRight == true)
        {
            animator.SetBool("FaceRight", true);
        }
        if (faceRight == false)
        {
            animator.SetBool("FaceRight", false);
        }


            anim.horizontal = MoveVector.x;
        anim.vertical = MoveVector.y;
        MoveVector *= speed;
        rb.velocity = MoveVector;


    }

 
}


