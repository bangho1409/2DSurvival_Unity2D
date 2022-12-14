using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelBlast : MonoBehaviour
{
    
    public int damage = 50;

    // Player's Character will be damaged if it enter the Blash HitBox.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Character>().TakeDamage(damage);      
        }
    }
}
