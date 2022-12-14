using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class EnemyBoss : MonoBehaviour, IDamageable
{
    Transform targetDestination;
    [SerializeField] float speed;
    GameObject targetObject;
    Rigidbody2D rb;

    [SerializeField] int hp = 2000;
    [SerializeField] int damage = 20;
    [SerializeField] int exp_get = 3000;

    Character targetCharacter;

    public bool facingRight = false;
    public GameObject fadeout;



    string URL = "http://localhost/FinalProject_Games/InformInsert.php";
    public string IDinput;
    public int Levelinput;
    public int Coininput;
    public float Timeinput;


    private void Awake()
    {
        StartCoroutine(getRB());
        GameObject fadeout = Resources.Load("FadeOut") as GameObject;
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
        yield return new WaitForSeconds(3);
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

    public void AddRecord(string ID, int Level, int Coin, float Time)
    {
        WWWForm form = new WWWForm();
        form.AddField("addID", ID);
        form.AddField("addLevel", Level);
        form.AddField("addCoin", Coin);
        form.AddField("addTime", Time.ToString());

        WWW www = new WWW(URL, form);
    }

    private void OnDestroy()
    {
        targetObject.GetComponent<BoxCollider2D>().enabled = false;
        GameObject instance = Instantiate(fadeout) as GameObject;
        instance.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        PlayerPrefs.SetInt("CoinSave", Coins.CoinValue);
        PlayerPrefs.SetInt("Level", PlayerLeveling.levelvalue);
        Levelinput = PlayerPrefs.GetInt("Level");
        Coininput = PlayerPrefs.GetInt("CoinSave");
        Timeinput = Time.time;
        AddRecord(IDinput, Levelinput, Coininput, Timeinput);
    }

}
