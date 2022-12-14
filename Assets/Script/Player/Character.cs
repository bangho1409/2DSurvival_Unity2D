using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// This Script containt player's Health Point, Experiences gain, Coins gain and life.

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHp = 1000;
    [SerializeField] HPStatus hpBar;
    [SerializeField] HPStatus hpBarUI;
    [HideInInspector] public PlayerLeveling exp;
    [HideInInspector] public Coins coin;





    public GameObject lifedisplay1;
    public GameObject lifedisplay2;
    public GameObject lifedisplay3;
    public static int lifeValue = 3;
    public int internalLife;
    Character life;
    int currentlife;


    private void Start()
    {
        hpBar.SetState(currentHp, maxHp);
        hpBarUI.SetState(currentHp, maxHp);
    }

    private void Awake()
    {
        exp = GetComponent<PlayerLeveling>();
        coin = GetComponent<Coins>();
    }

    // TakeDamage Statement let Enemy to Damage player and lost Life if HP = 0.
    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            lifeValue--;
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
        hpBarUI.SetState(currentHp, maxHp);
    }


    // When Player pick up Heal Object, HP will be restored.
    public void Heal(int amount)
    {
        if ( currentHp <= 0 )
        {
            return;
        }

        currentHp += amount;

        if ( currentHp > maxHp )
        {
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
        hpBarUI.SetState(currentHp, maxHp);
    }


    private void Update()
    {
        internalLife = lifeValue;
        if ( lifeValue == 0 )
        {
            PlayerPrefs.SetInt("CoinSave", Coins.CoinValue);
            PlayerPrefs.SetInt("Level", PlayerLeveling.levelvalue);
            SceneManager.LoadScene(4);
        }
        dead();
    }

    // This Script help show up life of player.
    public void dead()
    {
        if (lifeValue == 3)
        {
            lifedisplay1.SetActive(true);
            lifedisplay2.SetActive(true);
            lifedisplay3.SetActive(true);
        }

        if (lifeValue == 2)
        {
            lifedisplay1.SetActive(true);
            lifedisplay2.SetActive(true);
            lifedisplay3.SetActive(false);
        }

        if (lifeValue == 1)
        {
            lifedisplay1.SetActive(true);
            lifedisplay2.SetActive(false);
            lifedisplay3.SetActive(false);
        }
    }

}
