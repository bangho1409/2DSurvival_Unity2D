using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUp : MonoBehaviour, IPickupalbe
{
    [SerializeField] int healPoint;

    public void PickUp(Character character)
    {
        character.Heal(healPoint);
    }
}
