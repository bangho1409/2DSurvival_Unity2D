using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour, IPickupalbe
{
    [SerializeField] int coinPoint;

   public void PickUp(Character character)
    {
        character.coin.Add(coinPoint);
    }
}
