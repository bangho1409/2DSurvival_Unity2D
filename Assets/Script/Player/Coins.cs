using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int CoinAqquire;
    public static int CoinValue;
    [SerializeField]TMPro.TextMeshProUGUI CoinText;

    private void Update()
    {
        CoinValue = CoinAqquire;
        CoinText.text = PlayerPrefs.GetInt("CoinSave").ToString();
        CoinAqquire = PlayerPrefs.GetInt("CoinSave");
    }

    public void Add(int count)
    {
        CoinAqquire += count;
        PlayerPrefs.SetInt("CoinSave", CoinAqquire);
    }
}
