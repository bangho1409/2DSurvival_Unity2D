using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WhipWeapon : MonoBehaviour
{
    public GameObject rightwhip;
    public GameObject leftwhip;
    playermove playermove;
    [SerializeField] int whipDamage = 5;

    // WhipAttackSize is the Size of the Attack base on Player's Character.
    public Vector2 whipAttackSize = new Vector2(5f, 5f);

    public float TimeCoolDown;

    private void Awake()
    {
        playermove = GetComponentInParent<playermove>();
    }
    
    // Update is called once per frame.
    // When Player hit Left-Click, the Attack Statement will do the damage to the Enemy that inside the HitBox.
    void Update()
    {   
     if (Input.GetMouseButtonDown(0) && TimeCoolDown <= Time.time)
        {
            StartCoroutine(Attack());
        }
    }


    IEnumerator Attack()
    { 
        Debug.Log("attack");

        if (playermove.LastHorizontal > 0)
        {
            rightwhip.SetActive(true);
            TimeCoolDown = Time.time + 0.5f;
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightwhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        
        if (playermove.LastHorizontal < 0)
        {
            leftwhip.SetActive(true);
            TimeCoolDown = Time.time + 0.5f;
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftwhip.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }

        yield return new WaitForSeconds(0.5f);
    }



    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {

            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
                e.TakeDamage(whipDamage);
            }
            
        }
    }
}
