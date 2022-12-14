using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour, IDamageable
{
    // This script is for Every OBJECT that can damageable - This Script Included Interface Script

   public void TakeDamage(int damage)
    {
        Destroy(gameObject);
    }
}
