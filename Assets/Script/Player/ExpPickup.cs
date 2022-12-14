using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickup : MonoBehaviour, IPickupalbe
{
    [SerializeField] int ExpDrop = 20;

    public void PickUp(Character character)
    {
        character.exp.ExpAdd(ExpDrop);
    }
}
