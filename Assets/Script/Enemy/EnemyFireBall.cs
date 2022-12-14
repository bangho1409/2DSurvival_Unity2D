using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour
{

    public float speed = 5f;
    public int damage = 10;
    Rigidbody2D rb;

    playermove target;

    GameObject targetObject;
    Character TargetCharacter;
    Vector2 dir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<playermove>();
        dir = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(dir.x, dir.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Character>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
