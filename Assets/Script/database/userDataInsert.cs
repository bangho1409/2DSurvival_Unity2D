using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class userDataInsert : MonoBehaviour
{
    string URL = "http://localhost/FinalProject_Games/InformInsert.php";
    public string IDinput;
    public int Levelinput;
    public int Coininput;
    public float Timeinput;

    PlayerLeveling level;
    Coins coins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Levelinput = PlayerPrefs.GetInt("Level");
        Coininput = PlayerPrefs.GetInt("CoinSave");
        Timeinput = Time.time;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddRecord(IDinput, Levelinput, Coininput, Timeinput);
        }
        
    }

    public void AddRecord(string ID, int Level, int Coin, float Time)
    {
        WWWForm form = new WWWForm() ;
        form.AddField("addID", ID);
        form.AddField("addLevel", Level);
        form.AddField("addCoin", Coin);
        form.AddField("addTime", Time.ToString());

        WWW www = new WWW(URL, form);
    }
}
