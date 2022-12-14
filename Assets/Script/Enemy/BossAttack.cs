using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject attack;
    public int AttackDamage = 250;
    public float TimeAttack;
    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (TimeAttack <= Time.time)
        {
            StartCoroutine(attackanim());
            StartCoroutine(Attack());
            TimeAttack += 3;
        }
    }

    IEnumerator Attack()
    {
        attack.SetActive(true);
        yield return new WaitForSeconds(2f);
        attack.SetActive(false);
    }

    IEnumerator attackanim()
    {
        animator.SetBool("Attacking", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("Attacking", false);
    }

}
