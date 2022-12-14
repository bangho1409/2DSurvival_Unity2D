using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossDefeatLevel2 : MonoBehaviour
{
    [SerializeField] GameObject ItemDropObject;
    public GameObject scriptEnd;

    string URL = "http://localhost/FinalProject_Games/InformInsert.php";
    public string IDinput;
    public int Levelinput;
    public int Coininput;
    public float Timeinput;

    private void Awake()
    {
        GameObject scriptEnd = Resources.Load("EndingScript") as GameObject;
        // This Script help get the prefab from the document
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
        // Using PlayerPrefs method will Save the value of that player have obtained 
            PlayerPrefs.SetInt("Level", PlayerLeveling.levelvalue);
            PlayerPrefs.SetInt("CoinSave", Coins.CoinValue);
            Transform d = Instantiate(ItemDropObject).transform;
            d.position = transform.position;
            GameObject instance = Instantiate(scriptEnd) as GameObject;
            instance.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        // Using Instance will spawn an GameObject and SetParent help the GameObject Spawn insie the Canvas Document
            Levelinput = PlayerPrefs.GetInt("Level");
            Coininput = PlayerPrefs.GetInt("CoinSave");
            Timeinput = Time.time;
            AddRecord(IDinput, Levelinput, Coininput, Timeinput);
    }
}
