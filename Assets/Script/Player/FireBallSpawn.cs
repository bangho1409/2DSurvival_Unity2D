using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script help player to Shoot A FireBall after Right-click

public class FireBallSpawn : MonoBehaviour
{
    
    public Transform FireBarrel;
    public GameObject FireBall;
    private Vector2 MouseDir;
    private float MouseLookAngle;
    float cooldownTime;



    void Update()
    {
        // MouseDir is to find the Mouse Position in the Game.
        MouseDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        MouseLookAngle = Mathf.Atan2(MouseDir.y, MouseDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, MouseLookAngle - 90);

        
        if (Input.GetMouseButtonDown(1) && cooldownTime <= Time.time)
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        cooldownTime = Time.time + 2;
        GameObject fire = Instantiate(FireBall, FireBarrel.position, FireBarrel.rotation * Quaternion.Euler(0f, 0f, 90f));
        fire.GetComponent<Rigidbody2D>().velocity = FireBarrel.up * 10f;
        yield return new WaitForSeconds(0.1f);
    }
}
