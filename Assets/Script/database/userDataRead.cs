using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userDataRead : MonoBehaviour
{
    string URL = "http://localhost/FinalProject_Games/InformSelect.php";
    public string[] userData;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW users = new WWW(URL);
        yield return users;
        string UserDataString = users.text;
        userData = UserDataString.Split(';');

        print(GetValueData(userData[0], "Level"));
    }

    string GetValueData ( string Data, string index)
    {
        string Value = Data.Substring(Data.IndexOf(index) + index.Length);
        if (Value.Contains("|"))
        {
            Value = Value.Remove(Value.IndexOf("|"));
        }
        return Value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
