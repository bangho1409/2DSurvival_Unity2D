using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script is for Player's FireBall when hitting an Enemy.

public class FireBallHit : MonoBehaviour
{
    [SerializeField] int Damage = 20;
    private Rigidbody2D rb;
    playermove playermove;
    [SerializeField] LayerMask targetLayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            ApplyDamage(other);
            Destroy(gameObject);
        }
        
    }

    private void ApplyDamage(Collider2D colliders)
    {
            IDamageable e = colliders.GetComponent<IDamageable>();
            if (e != null)
            {
                e.TakeDamage(Damage);
            }

    }
}
