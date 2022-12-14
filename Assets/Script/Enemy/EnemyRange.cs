using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour, IDamageable
{
    Transform targetDestination;
    [SerializeField] float speed;
    GameObject targetObject;
    
    Rigidbody2D rb;

    [SerializeField] int hp = 10;
    [SerializeField] int damage = 5;
    [SerializeField] int exp_get = 100;

    Character targetCharacter;




    public GameObject enemyFireball;
    public Transform firePos;
    public float fireRate;
    public float nextFire;


    public bool facingRight = false;
    Animator animator;




    private void Awake()
    {
        StartCoroutine(getRB()); 
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        nextFire = Time.time + 3;
        fireRate = 3f;
    }

    void Update()
    {
        facingPlayer();
        AttackRange();
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
        if (collision.gameObject == targetObject)
        {
            AttackMelee();
        }
    }

    private void AttackMelee()
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

    IEnumerator getRB()
    {
        yield return new WaitForSeconds(2);
        rb = GetComponent<Rigidbody2D>();
    }



    private void AttackRange()
    {  
        if (Time.time > nextFire)
        {
            GameObject fire = Instantiate(enemyFireball, firePos.position, firePos.rotation);  
            nextFire = Time.time + fireRate;
            StartCoroutine(attackanim());
        } 
    }

    IEnumerator attackanim()
    {
        animator.SetBool("Attacking", true);
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("Attacking", false);
    }

}
