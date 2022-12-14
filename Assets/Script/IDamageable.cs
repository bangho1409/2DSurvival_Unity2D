using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is Interface Script - Every GameObject contented this script will be damageable and destroyed - This Script used for DropBarrel, Enemy, Boss

public interface IDamageable
{
     void TakeDamage(int damage);
}

