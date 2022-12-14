using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalLevel1 : MonoBehaviour
{
    string URL = "http://localhost/FinalProject_Games/InformInsert.php";
    public string IDinput;
    public int Levelinput;
    public int Coininput;
    public float Timeinput;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(CompletedFloor()); 
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

    IEnumerator CompletedFloor()
    {
        // Save player Coins and Level gained 
        PlayerPrefs.SetInt("CoinSave", Coins.CoinValue);
        PlayerPrefs.SetInt("Level", PlayerLeveling.levelvalue);
        yield return new WaitForSeconds(1);
        Levelinput = PlayerPrefs.GetInt("Level");
        Coininput = PlayerPrefs.GetInt("CoinSave");
        Timeinput = Time.time;
        AddRecord(IDinput, Levelinput, Coininput, Timeinput);
        SceneManager.LoadScene(2);
        
    }
}
