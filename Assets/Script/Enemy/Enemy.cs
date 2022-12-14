using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    Transform targetDestination;
    [SerializeField] float speed;
    GameObject targetObject;
    Rigidbody2D rb;

    [SerializeField] int hp = 10;
    [SerializeField] int damage = 5;
    [SerializeField] int exp_get = 100;

    Character targetCharacter;

    public bool facingRight = false;


    private void Awake()
    {
        StartCoroutine(getRB());
    }

    public void SetTarget(GameObject target)
    {
        targetObject = target;
        targetDestination = target.transform;
    }


    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject == targetObject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Damaged !");
        if (targetCharacter == null)
        {
            targetCharacter = targetObject.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 1)
        {
            targetObject.GetComponent<PlayerLeveling>().ExpAdd(exp_get);
            Destroy(gameObject);
        }
    }

    IEnumerator getRB()
    {
        yield return new WaitForSeconds(2);
        rb = GetComponent<Rigidbody2D>();
    }


    void FlipRight()
    {
        facingRight = true;
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }
    void FlipLeft()
    {
        facingRight = false;
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    void facingPlayer()
    {
        if (targetDestination.transform.position.x < gameObject.transform.position.x && facingRight)
        {   
            FlipLeft();
        }

        if (targetDestination.transform.position.x > gameObject.transform.position.x && !facingRight)
        {
            FlipRight();
        }
    }

    private void Update()
    {
        facingPlayer();
    }

}
